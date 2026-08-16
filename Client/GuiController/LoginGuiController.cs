using Common.Domain;
using System.Net.Sockets;

namespace Client.GuiController
{
    /// <summary>
    /// Kontroler korisnickog interfejsa za SK8 - Prijavi prodavca.
    /// </summary>
    public class LoginGuiController
    {
        #region Singleton

        private static LoginGuiController instance;

        public static LoginGuiController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginGuiController();
                }
                return instance;
            }
        }

        private LoginGuiController() { }

        #endregion

        private FrmLogin frmLogin;

        /// <summary>Prijavljeni prodavac, dostupan ostatku aplikacije.</summary>
        public Prodavac PrijavljeniProdavac { get; set; }

        internal void ShowFrmLogin()
        {
            try
            {
                Communication.Instance.Connect();
                frmLogin = new FrmLogin();
                Application.Run(frmLogin);
            }
            catch (SocketException)
            {
                MessageBox.Show("Nije moguce uspostaviti komunikaciju sa serverom",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void PrijaviSe(object sender, EventArgs e)
        {
            if (!frmLogin.Validacija())
            {
                MessageBox.Show("Molimo popunite sva polja",
                    "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Prodavac prodavac = new Prodavac
            {
                KorisnickoIme = frmLogin.txtKorisnickoIme.Text,
                Sifra = frmLogin.txtSifra.Text
            };

            // Korak 4 i 5 scenarija SK8 - sistem proverava korisnicko ime i sifru
            try
            {
                PrijavljeniProdavac = Communication.Instance.PrijaviProdavac(prodavac);
            }
            catch (Exception)
            {
                MessageBox.Show("Korisnicko ime i sifra nisu ispravni",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Korisnicko ime i sifra su ispravni",
                "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Korak 6 - korisnicki interfejs poziva glavnu formu i meni
            try
            {
                frmLogin.Visible = false;
                MainCoordinator.Instance.ShowMain();
                frmLogin.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ne moze da se otvori glavna forma i meni",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmLogin.Close();
            }
        }
    }
}
