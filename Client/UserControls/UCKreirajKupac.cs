using Common.Domain;

namespace Client.UserControls
{
    /// <summary>
    /// Ekranska forma za SK4 - Kreiraj kupca.
    /// </summary>
    public partial class UCKreirajKupac : UserControl
    {
        public UCKreirajKupac()
        {
            InitializeComponent();
            cmbGrad.DropDownStyle = ComboBoxStyle.DropDownList;
            PostaviPocetnoStanje();
        }

        /// <summary>Puni padajucu listu gradova (preduslov SK4).</summary>
        public void PopuniGradove(List<Grad> gradovi)
        {
            cmbGrad.DataSource = gradovi;
            cmbGrad.SelectedIndex = -1;
        }

        /// <summary>Pre nego sto sistem kreira kupca, polja su zakljucana.</summary>
        public void PostaviPocetnoStanje()
        {
            Ocisti();
            PostaviDostupnostPolja(false);
            btnKreiraj.Enabled = true;
            btnSacuvaj.Enabled = false;
            btnOtkazi.Enabled = false;
        }

        /// <summary>Posle koraka 2 scenarija, korisnik moze da unosi podatke.</summary>
        public void PostaviStanjeUnosa()
        {
            PostaviDostupnostPolja(true);
            btnKreiraj.Enabled = false;
            btnSacuvaj.Enabled = true;
            btnOtkazi.Enabled = true;
            txtIme.Focus();
        }

        private void PostaviDostupnostPolja(bool dostupno)
        {
            txtIme.Enabled = dostupno;
            txtPrezime.Enabled = dostupno;
            txtEmail.Enabled = dostupno;
            txtAdresa.Enabled = dostupno;
            cmbGrad.Enabled = dostupno;
        }

        /// <summary>
        /// Kontrola ispravnosti unetih podataka.
        /// Odgovara koraku 5 scenarija SK4 (AНСО).
        /// </summary>
        public bool Validacija()
        {
            txtIme.BackColor = Color.White;
            txtPrezime.BackColor = Color.White;
            txtEmail.BackColor = Color.White;
            txtAdresa.BackColor = Color.White;
            cmbGrad.BackColor = Color.White;

            bool ispravno = true;

            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                txtIme.BackColor = Color.Salmon;
                ispravno = false;
            }

            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                txtPrezime.BackColor = Color.Salmon;
                ispravno = false;
            }

            // Vrednosno ogranicenje: emailKupac LIKE '%@%'
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains('@'))
            {
                txtEmail.BackColor = Color.Salmon;
                ispravno = false;
            }

            if (string.IsNullOrWhiteSpace(txtAdresa.Text))
            {
                txtAdresa.BackColor = Color.Salmon;
                ispravno = false;
            }

            if (cmbGrad.SelectedItem == null)
            {
                cmbGrad.BackColor = Color.Salmon;
                ispravno = false;
            }

            return ispravno;
        }

        public void Ocisti()
        {
            txtIme.Clear();
            txtPrezime.Clear();
            txtEmail.Clear();
            txtAdresa.Clear();
            cmbGrad.SelectedIndex = -1;

            txtIme.BackColor = Color.White;
            txtPrezime.BackColor = Color.White;
            txtEmail.BackColor = Color.White;
            txtAdresa.BackColor = Color.White;
            cmbGrad.BackColor = Color.White;
        }
    }
}
