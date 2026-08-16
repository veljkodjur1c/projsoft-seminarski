using Common.Domain;

namespace Client.UserControls
{
    /// <summary>
    /// Ekranska forma za SK5 - Pretrazi kupca.
    /// </summary>
    public partial class UCPretraziKupac : UserControl
    {
        public UCPretraziKupac()
        {
            InitializeComponent();
            cmbGrad.DropDownStyle = ComboBoxStyle.DropDownList;
            dgvKupci.AutoGenerateColumns = false;
        }

        /// <summary>Puni padajucu listu gradova koja sluzi kao kriterijum.</summary>
        public void PopuniGradove(List<Grad> gradovi)
        {
            cmbGrad.DataSource = gradovi;
            cmbGrad.SelectedIndex = -1;
        }

        /// <summary>Prikazuje pronadjene kupce u tabeli.</summary>
        public void PrikaziKupce(List<Kupac> kupci)
        {
            dgvKupci.DataSource = null;
            dgvKupci.DataSource = kupci;
            dgvKupci.ClearSelection();
        }

        /// <summary>Prikazuje podatke o izabranom kupcu u poljima forme.</summary>
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

        /// <summary>Vraca kupca izabranog u tabeli, ili null.</summary>
        public Kupac VratiIzabranogKupca()
        {
            if (dgvKupci.SelectedRows.Count == 0)
            {
                return null;
            }
            return dgvKupci.SelectedRows[0].DataBoundItem as Kupac;
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
