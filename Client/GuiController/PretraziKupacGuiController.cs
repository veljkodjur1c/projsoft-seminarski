using Client.UserControls;
using Common.Domain;
using System.Text;

namespace Client.GuiController
{
    /// <summary>
    /// Kontroler korisnickog interfejsa za SK5 - Pretrazi kupca.
    /// </summary>
    public class PretraziKupacGuiController
    {
        private UCPretraziKupac uc;

        internal Control CreatePretraziKupac()
        {
            uc = new UCPretraziKupac();
            uc.btnVratiKupce.Click += VratiKupce;
            uc.btnPretraziKupca.Click += PretraziKupca;

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

        /// <summary>
        /// Sastavlja uslov pretrage od popunjenih kriterijuma.
        /// Prazna polja se preskacu, pa prazna forma vraca sve kupce.
        /// Prefiksi k. i g. odgovaraju aliasima iz Kupac.Join.
        /// </summary>
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

        /// <summary>Koraci 1 do 4 scenarija SK5.</summary>
        private void VratiKupce(object sender, EventArgs e)
        {
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

        /// <summary>Koraci 5 do 8 scenarija SK5.</summary>
        private void PretraziKupca(object sender, EventArgs e)
        {
            Kupac izabrani = uc.VratiIzabranogKupca();

            if (izabrani == null)
            {
                MessageBox.Show("Molimo izaberite kupca iz tabele",
                    "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Kupac pronadjen;

            try
            {
                pronadjen = Communication.Instance.PretraziKupac(new Kupac { Id = izabrani.Id });
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da nadje kupca",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            uc.PrikaziKupca(pronadjen);

            MessageBox.Show("Sistem je nasao kupca",
                "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal void HandleClose()
        {
            // Ovaj slucaj koriscenja ne pravi privremene slogove u bazi.
        }
    }
}
