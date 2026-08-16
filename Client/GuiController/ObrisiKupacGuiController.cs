using Client.UserControls;
using Common.Domain;

namespace Client.GuiController
{
    /// <summary>
    /// Kontroler korisnickog interfejsa za SK7 - Obrisi kupca.
    /// </summary>
    public class ObrisiKupacGuiController
    {
        private UCObrisiKupac uc;

        /// <summary>Kupac koji je pronadjen i koji se brise.</summary>
        private Kupac pronadjeniKupac;

        internal Control CreateObrisiKupac()
        {
            uc = new UCObrisiKupac();
            uc.btnVratiKupce.Click += VratiKupce;
            uc.btnPretraziKupca.Click += PretraziKupca;
            uc.btnObrisiKupca.Click += ObrisiKupca;

            pronadjeniKupac = null;
            UcitajGradove();
            return uc;
        }

        private void UcitajGradove()
        {
            try
            {
                uc.PopuniGradove(Communication.Instance.VratiListuSviGrad());
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da vrati listu gradova",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SastaviUslov()
        {
            List<string> uslovi = new List<string>();

            if (!string.IsNullOrWhiteSpace(uc.txtIme.Text))
            {
                uslovi.Add($"k.imeKupac LIKE '%{uc.txtIme.Text}%'");
            }

            if (!string.IsNullOrWhiteSpace(uc.txtPrezime.Text))
            {
                uslovi.Add($"k.prezimeKupac LIKE '%{uc.txtPrezime.Text}%'");
            }

            if (!string.IsNullOrWhiteSpace(uc.txtEmail.Text))
            {
                uslovi.Add($"k.emailKupac LIKE '%{uc.txtEmail.Text}%'");
            }

            if (!string.IsNullOrWhiteSpace(uc.txtAdresa.Text))
            {
                uslovi.Add($"k.adresaKupac LIKE '%{uc.txtAdresa.Text}%'");
            }

            if (uc.cmbGrad.SelectedItem is Grad izabraniGrad)
            {
                uslovi.Add($"k.idGrad = {izabraniGrad.Id}");
            }

            if (uslovi.Count == 0)
            {
                return string.Empty;
            }

            return "WHERE " + string.Join(" AND ", uslovi);
        }

        /// <summary>Koraci 1 do 4 scenarija SK7.</summary>
        private void VratiKupce(object sender, EventArgs e)
        {
            pronadjeniKupac = null;
            uc.PostaviStanjePretrage();

            Kupac kriterijum = new Kupac
            {
                SelectCondition = SastaviUslov()
            };

            List<Kupac> kupci;

            try
            {
                kupci = Communication.Instance.VratiListuKupac(kriterijum);
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da nadje kupce po zadatim kriterijumima",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                uc.PrikaziKupce(new List<Kupac>());
                return;
            }

            uc.PrikaziKupce(kupci);

            MessageBox.Show("Sistem je nasao kupce po zadatim kriterijumima",
                "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Koraci 5 do 8 scenarija SK7.</summary>
        private void PretraziKupca(object sender, EventArgs e)
        {
            Kupac izabrani = uc.VratiIzabranogKupca();

            if (izabrani == null)
            {
                MessageBox.Show("Molimo izaberite kupca iz tabele",
                    "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                pronadjeniKupac = Communication.Instance.PretraziKupac(new Kupac { Id = izabrani.Id });
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da nadje kupca",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            uc.PrikaziKupca(pronadjeniKupac);
            uc.PostaviStanjeBrisanja();

            MessageBox.Show("Sistem je nasao kupca",
                "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Koraci 9 do 11 scenarija SK7.</summary>
        private void ObrisiKupca(object sender, EventArgs e)
        {
            if (pronadjeniKupac == null)
            {
                MessageBox.Show("Prvo pronadjite kupca kojeg zelite da obrisete",
                    "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult potvrda = MessageBox.Show(
                $"Da li ste sigurni da zelite da obrisete kupca: {pronadjeniKupac}?",
                "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (potvrda != DialogResult.Yes)
            {
                return;
            }

            try
            {
                Communication.Instance.ObrisiKupac(pronadjeniKupac);
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da obrise kupca",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Sistem je obrisao kupca",
                "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);

            pronadjeniKupac = null;
            uc.Ocisti();
            uc.PostaviStanjePretrage();
            OsveziTabelu();
        }

        private void OsveziTabelu()
        {
            try
            {
                Kupac kriterijum = new Kupac { SelectCondition = SastaviUslov() };
                uc.PrikaziKupce(Communication.Instance.VratiListuKupac(kriterijum));
            }
            catch (Exception)
            {
                uc.PrikaziKupce(new List<Kupac>());
            }
        }

        internal void HandleClose()
        {
            // Ovaj slucaj koriscenja ne pravi privremene slogove u bazi.
        }
    }
}
