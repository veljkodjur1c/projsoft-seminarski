using Client.UserControls;
using Common.Domain;

namespace Client.GuiController
{
    /// <summary>
    /// Kontroler korisnickog interfejsa za SK6 - Promeni kupca.
    /// </summary>
    public class PromeniKupacGuiController
    {
        private UCPromeniKupac uc;

        /// <summary>Kupac koji je pronadjen i koji se menja.</summary>
        private Kupac pronadjeniKupac;

        internal Control CreatePromeniKupac()
        {
            uc = new UCPromeniKupac();
            uc.btnVratiKupce.Click += VratiKupce;
            uc.btnPretraziKupca.Click += PretraziKupca;
            uc.btnPromeniKupca.Click += PromeniKupca;

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

        /// <summary>Koraci 1 do 4 scenarija SK6.</summary>
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
                MessageBox.Show("Sistem ne moze da nadje kupce po zadatom kriterijumu",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                uc.PrikaziKupce(new List<Kupac>());
                return;
            }

            uc.PrikaziKupce(kupci);

            MessageBox.Show("Sistem je nasao kupce po zadatim kriterijumima",
                "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Koraci 5 do 8 scenarija SK6.</summary>
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
            uc.PostaviStanjeIzmene();

            MessageBox.Show("Sistem je nasao kupca",
                "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Koraci 9 do 13 scenarija SK6.</summary>
        private void PromeniKupca(object sender, EventArgs e)
        {
            if (pronadjeniKupac == null)
            {
                MessageBox.Show("Prvo pronadjite kupca kojeg zelite da promenite",
                    "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!uc.Validacija())
            {
                MessageBox.Show("Molimo popunite sva polja ispravno",
                    "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            pronadjeniKupac.Ime = uc.txtIme.Text;
            pronadjeniKupac.Prezime = uc.txtPrezime.Text;
            pronadjeniKupac.Email = uc.txtEmail.Text;
            pronadjeniKupac.Adresa = uc.txtAdresa.Text;
            pronadjeniKupac.Grad = (Grad)uc.cmbGrad.SelectedItem;

            try
            {
                Communication.Instance.PromeniKupac(pronadjeniKupac);
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da zapamti kupca",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Sistem je zapamtio kupca: {pronadjeniKupac}",
                "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OsveziTabelu();
        }

        /// <summary>Ponovo ucitava listu da bi se izmena videla u tabeli.</summary>
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
