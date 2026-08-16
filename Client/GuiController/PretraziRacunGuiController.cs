using Client.UserControls;
using Common.Domain;

namespace Client.GuiController
{
    /// <summary>
    /// Kontroler korisnickog interfejsa za SK2 - Pretrazi racun.
    /// </summary>
    public class PretraziRacunGuiController
    {
        private UCPretraziRacun uc;

        internal Control CreatePretraziRacun()
        {
            uc = new UCPretraziRacun();
            uc.btnVratiRacune.Click += VratiRacune;
            uc.btnPretraziRacun.Click += PretraziRacun;

            UcitajListe();
            return uc;
        }

        private void UcitajListe()
        {
            try
            {
                uc.PopuniProdavce(Communication.Instance.VratiListuSviProdavac());
                uc.PopuniKupce(Communication.Instance.VratiListuSviKupac());
                uc.PopuniSuplementacije(Communication.Instance.VratiListuSviSuplementacija());
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da ucita potrebne liste",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sastavlja uslov pretrage. Prefiksi r., p. i k. odgovaraju
        /// aliasima iz Racun.Join. Kriterijum po suplementaciji trazi
        /// racune koji sadrze stavku sa izabranom suplementacijom.
        /// </summary>
        private string SastaviUslov()
        {
            List<string> uslovi = new List<string>();

            if (uc.cmbKupac.SelectedItem is Kupac izabraniKupac)
            {
                uslovi.Add($"r.idKupac = {izabraniKupac.Id}");
            }

            if (uc.cmbProdavac.SelectedItem is Prodavac izabraniProdavac)
            {
                uslovi.Add($"r.idProdavac = {izabraniProdavac.Id}");
            }

            if (uc.dtpDatum.Checked)
            {
                uslovi.Add($"r.datumIzvrsenja = '{uc.dtpDatum.Value:yyyy-MM-dd}'");
            }

            if (double.TryParse(uc.txtUkupanIznos.Text, out double iznos))
            {
                uslovi.Add($"r.ukupanIznos >= {iznos.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
            }

            if (uc.cmbSuplementacija.SelectedItem is Suplementacija izabrana)
            {
                uslovi.Add($"r.idRacun IN (SELECT idRacun FROM stavkaRacuna " +
                           $"WHERE idSuplementacija = {izabrana.Id})");
            }

            if (uslovi.Count == 0)
            {
                return string.Empty;
            }

            return "WHERE " + string.Join(" AND ", uslovi);
        }

        /// <summary>Koraci 1 do 4 scenarija SK2.</summary>
        private void VratiRacune(object sender, EventArgs e)
        {
            Racun kriterijum = new Racun
            {
                SelectCondition = SastaviUslov()
            };

            List<Racun> racuni;

            try
            {
                racuni = Communication.Instance.VratiListuRacun(kriterijum);
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da nadje racune po zadatim kriterijumima",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                uc.PrikaziRacune(new List<Racun>());
                return;
            }

            uc.PrikaziRacune(racuni);

            MessageBox.Show("Sistem je nasao racune po zadatim kriterijumima",
                "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Koraci 5 do 8 scenarija SK2.</summary>
        private void PretraziRacun(object sender, EventArgs e)
        {
            Racun izabrani = uc.VratiIzabraniRacun();

            if (izabrani == null)
            {
                MessageBox.Show("Molimo izaberite racun iz tabele",
                    "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Racun pronadjen;

            try
            {
                pronadjen = Communication.Instance.PretraziRacun(new Racun { Id = izabrani.Id });
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da nadje racun",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            uc.PrikaziRacun(pronadjen);

            MessageBox.Show("Sistem je nasao racun",
                "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal void HandleClose()
        {
            // Ovaj slucaj koriscenja ne pravi privremene slogove u bazi.
        }
    }
}
