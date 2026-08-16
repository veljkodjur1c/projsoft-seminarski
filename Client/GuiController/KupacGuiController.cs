using Client.UserControls;
using Common.Domain;

namespace Client.GuiController
{
    /// <summary>
    /// Kontroler korisnickog interfejsa za SK4 - Kreiraj kupca.
    /// </summary>
    public class KupacGuiController
    {
        private UCKreirajKupac uc;

        /// <summary>
        /// Kupac koji je sistem kreirao, a jos nije sacuvan.
        /// Ako korisnik odustane, ovaj slog se brise iz baze.
        /// </summary>
        private Kupac kreiraniKupac;

        internal Control CreateKreirajKupac()
        {
            uc = new UCKreirajKupac();
            uc.btnKreiraj.Click += KreirajKupac;
            uc.btnSacuvaj.Click += SacuvajKupac;
            uc.btnOtkazi.Click += OtkaziKreiranje;

            UcitajGradove();
            return uc;
        }

        /// <summary>Preduslov SK4 - ucitana je lista gradova.</summary>
        private void UcitajGradove()
        {
            try
            {
                List<Grad> gradovi = Communication.Instance.VratiListuSviGrad();
                uc.PopuniGradove(gradovi);
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da vrati listu gradova",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Koraci 1 do 3 scenarija SK4.</summary>
        private void KreirajKupac(object sender, EventArgs e)
        {
            try
            {
                Kupac noviKupac = new Kupac();
                int id = Communication.Instance.KreirajKupac(noviKupac);

                noviKupac.Id = id;
                kreiraniKupac = noviKupac;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da kreira kupca",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Sistem je kreirao kupca",
                "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);

            uc.PostaviStanjeUnosa();
        }

        /// <summary>Koraci 6 do 8 scenarija SK4.</summary>
        private void SacuvajKupac(object sender, EventArgs e)
        {
            if (kreiraniKupac == null)
            {
                MessageBox.Show("Prvo pozovite sistem da kreira kupca",
                    "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!uc.Validacija())
            {
                MessageBox.Show("Molimo popunite sva polja ispravno",
                    "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            kreiraniKupac.Ime = uc.txtIme.Text;
            kreiraniKupac.Prezime = uc.txtPrezime.Text;
            kreiraniKupac.Email = uc.txtEmail.Text;
            kreiraniKupac.Adresa = uc.txtAdresa.Text;
            kreiraniKupac.Grad = (Grad)uc.cmbGrad.SelectedItem;

            try
            {
                Communication.Instance.PromeniKupac(kreiraniKupac);
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da zapamti kupca",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Sistem je zapamtio kupca: {kreiraniKupac}",
                "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Kupac je sacuvan, vise nije privremen
            kreiraniKupac = null;
            uc.PostaviPocetnoStanje();
        }

        private void OtkaziKreiranje(object sender, EventArgs e)
        {
            ObrisiNesacuvanogKupca();
            uc.PostaviPocetnoStanje();
        }

        /// <summary>
        /// Uklanja privremeni slog ako korisnik nije sacuvao kupca.
        /// Poziva se pri promeni panela i pri zatvaranju aplikacije.
        /// </summary>
        internal void HandleClose()
        {
            ObrisiNesacuvanogKupca();
        }

        private void ObrisiNesacuvanogKupca()
        {
            if (kreiraniKupac == null)
            {
                return;
            }

            try
            {
                Communication.Instance.ObrisiKupac(kreiraniKupac);
            }
            catch (Exception)
            {
                // Ako brisanje ne uspe, korisnika ne treba uznemiravati.
            }
            finally
            {
                kreiraniKupac = null;
            }
        }
    }
}
