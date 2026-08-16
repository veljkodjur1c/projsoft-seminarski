using Common.Domain;
using System.ComponentModel;

namespace Client.UserControls
{
    /// <summary>
    /// Ekranska forma za SK2 - Pretrazi racun.
    /// </summary>
    public partial class UCPretraziRacun : UserControl
    {
        public UCPretraziRacun()
        {
            InitializeComponent();
            cmbKupac.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProdavac.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSuplementacija.DropDownStyle = ComboBoxStyle.DropDownList;
            dgvRacuni.AutoGenerateColumns = false;
            dgvStavke.AutoGenerateColumns = false;
        }

        public void PopuniKupce(List<Kupac> kupci)
        {
            cmbKupac.DataSource = kupci;
            cmbKupac.SelectedIndex = -1;
        }

        public void PopuniProdavce(List<Prodavac> prodavci)
        {
            cmbProdavac.DataSource = prodavci;
            cmbProdavac.SelectedIndex = -1;
        }

        public void PopuniSuplementacije(List<Suplementacija> suplementacije)
        {
            cmbSuplementacija.DataSource = suplementacije;
            cmbSuplementacija.SelectedIndex = -1;
        }

        public void PrikaziRacune(List<Racun> racuni)
        {
            dgvRacuni.DataSource = null;
            dgvRacuni.DataSource = racuni;
            dgvRacuni.ClearSelection();
        }

        public void PrikaziStavke(BindingList<StavkaRacuna> stavke)
        {
            dgvStavke.DataSource = null;
            dgvStavke.DataSource = stavke;
        }

        /// <summary>Prikazuje podatke o pronadjenom racunu.</summary>
        public void PrikaziRacun(Racun racun)
        {
            txtUkupanIznos.Text = racun.UkupanIznos.ToString("0.00");
            dtpDatum.Checked = true;
            dtpDatum.Value = racun.DatumIzvrsenja;

            cmbKupac.SelectedIndex = -1;
            foreach (Kupac k in cmbKupac.Items)
            {
                if (k.Id == racun.Kupac.Id)
                {
                    cmbKupac.SelectedItem = k;
                    break;
                }
            }

            cmbProdavac.SelectedIndex = -1;
            foreach (Prodavac p in cmbProdavac.Items)
            {
                if (p.Id == racun.Prodavac.Id)
                {
                    cmbProdavac.SelectedItem = p;
                    break;
                }
            }

            PrikaziStavke(racun.Stavke);
        }

        public Racun VratiIzabraniRacun()
        {
            if (dgvRacuni.SelectedRows.Count == 0)
            {
                return null;
            }
            return dgvRacuni.SelectedRows[0].DataBoundItem as Racun;
        }

        public void Ocisti()
        {
            cmbKupac.SelectedIndex = -1;
            cmbProdavac.SelectedIndex = -1;
            cmbSuplementacija.SelectedIndex = -1;
            txtUkupanIznos.Clear();
            dtpDatum.Checked = false;
            dgvStavke.DataSource = null;
        }
    }
}
