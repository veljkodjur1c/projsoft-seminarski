using Common.Domain;

namespace Client.UserControls
{
    /// <summary>
    /// Ekranska forma za SK7 - Obrisi kupca.
    /// </summary>
    public partial class UCObrisiKupac : UserControl
    {
        public UCObrisiKupac()
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

        /// <summary>Dok kupac nije pronadjen, brisanje nije moguce.</summary>
        public void PostaviStanjePretrage()
        {
            btnObrisiKupca.Enabled = false;
        }

        /// <summary>Posle koraka 8 scenarija, kupac moze da se obrise.</summary>
        public void PostaviStanjeBrisanja()
        {
            btnObrisiKupca.Enabled = true;
        }

        public void Ocisti()
        {
            txtIme.Clear();
            txtPrezime.Clear();
            txtEmail.Clear();
            txtAdresa.Clear();
            cmbGrad.SelectedIndex = -1;
        }
    }
}
