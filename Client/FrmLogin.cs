using Client.GuiController;

namespace Client
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            txtSifra.PasswordChar = '*';
            btnPrijaviSe.Click += LoginGuiController.Instance.PrijaviSe;
            AcceptButton = btnPrijaviSe;
        }

        /// <summary>
        /// Kontrola ispravnosti unetih podataka na strani korisnika.
        /// Odgovara koraku 2 scenarija SK8 (AНСО).
        /// </summary>
        public bool Validacija()
        {
            txtKorisnickoIme.BackColor = Color.White;
            txtSifra.BackColor = Color.White;

            bool ispravno = true;

            if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text))
            {
                txtKorisnickoIme.BackColor = Color.Salmon;
                ispravno = false;
            }

            if (string.IsNullOrWhiteSpace(txtSifra.Text))
            {
                txtSifra.BackColor = Color.Salmon;
                ispravno = false;
            }

            return ispravno;
        }
    }
}
