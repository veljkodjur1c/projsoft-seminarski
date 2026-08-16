using Common.Domain;

namespace Client.UserControls
{
    /// <summary>
    /// Ekranska forma za SK6 - Promeni kupca.
    /// Ista polja sluze i kao kriterijumi pretrage i za unos izmena.
    /// </summary>
    public partial class UCPromeniKupac : UserControl
    {
        public UCPromeniKupac()
        {
            InitializeComponent();
            cmbGrad.DropDownStyle = ComboBoxStyle.DropDownList;
            dgvKupci.AutoGenerateColumns = false;
            PostaviStanjePretrage();
        }

        public void PopuniGradove(List<Grad> gradovi)
        {
            cmbGrad.DataSource = gradovi;
            cmbGrad.SelectedIndex = -1;
        }

        public void PrikaziKupce(List<Kupac> kupci)
        {
            dgvKupci.DataSource = null;
            dgvKupci.DataSource = kupci;
            dgvKupci.ClearSelection();
        }

        public void PrikaziKupca(Kupac kupac)
        {
            txtIme.Text = kupac.Ime;
            txtPrezime.Text = kupac.Prezime;
            txtEmail.Text = kupac.Email;
            txtAdresa.Text = kupac.Adresa;
            cmbGrad.SelectedIndex = -1;

            foreach (Grad g in cmbGrad.Items)
            {
                if (g.Id == kupac.Grad.Id)
                {
                    cmbGrad.SelectedItem = g;
                    break;
                }
            }
        }

        public Kupac VratiIzabranogKupca()
        {
            if (dgvKupci.SelectedRows.Count == 0)
            {
                return null;
            }
            return dgvKupci.SelectedRows[0].DataBoundItem as Kupac;
        }

        /// <summary>Dok kupac nije pronadjen, izmena nije moguca.</summary>
        public void PostaviStanjePretrage()
        {
            btnPromeniKupca.Enabled = false;
        }

        /// <summary>Posle koraka 8 scenarija, korisnik moze da menja podatke.</summary>
        public void PostaviStanjeIzmene()
        {
            btnPromeniKupca.Enabled = true;
        }

        /// <summary>
        /// Kontrola ispravnosti unetih podataka.
        /// Odgovara koraku 10 scenarija SK6 (AНСО).
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
