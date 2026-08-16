using Common.Domain;
using System.ComponentModel;

namespace Client.UserControls
{
    /// <summary>
    /// Ekranska forma za SK3 - Promeni racun.
    /// Ista polja sluze kao kriterijumi pretrage i za unos izmena.
    /// </summary>
    public partial class UCPromeniRacun : UserControl
    {
        public UCPromeniRacun()
        {
            InitializeComponent();
            cmbKupac.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProdavac.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSuplementacija.DropDownStyle = ComboBoxStyle.DropDownList;
            dgvRacuni.AutoGenerateColumns = false;
            dgvStavke.AutoGenerateColumns = false;
            PostaviStanjePretrage();
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
        }

        public void PrikaziUkupanIznos(double iznos)
        {
            txtUkupanIznos.Text = iznos.ToString("0.00");
        }

        public Racun VratiIzabraniRacun()
        {
            if (dgvRacuni.SelectedRows.Count == 0)
            {
                return null;
            }
            return dgvRacuni.SelectedRows[0].DataBoundItem as Racun;
        }

        public StavkaRacuna VratiIzabranuStavku()
        {
            if (dgvStavke.SelectedRows.Count == 0)
            {
                return null;
            }
            return dgvStavke.SelectedRows[0].DataBoundItem as StavkaRacuna;
        }

        /// <summary>Dok racun nije pronadjen, izmena nije moguca.</summary>
        public void PostaviStanjePretrage()
        {
            btnPromeniRacun.Enabled = false;
            cmbSuplementacija.Enabled = false;
            txtKolicina.Enabled = false;
            btnDodajStavku.Enabled = false;
            btnUkloniStavku.Enabled = false;
        }

        /// <summary>Posle koraka 8 scenarija, racun moze da se menja.</summary>
        public void PostaviStanjeIzmene()
        {
            btnPromeniRacun.Enabled = true;
            cmbSuplementacija.Enabled = true;
            txtKolicina.Enabled = true;
            btnDodajStavku.Enabled = true;
            btnUkloniStavku.Enabled = true;
        }

        public bool ValidacijaStavke()
        {
            cmbSuplementacija.BackColor = Color.White;
            txtKolicina.BackColor = Color.White;

            bool ispravno = true;

            if (cmbSuplementacija.SelectedItem == null)
            {
                cmbSuplementacija.BackColor = Color.Salmon;
                ispravno = false;
            }

            if (!int.TryParse(txtKolicina.Text, out int kolicina) || kolicina <= 0)
            {
                txtKolicina.BackColor = Color.Salmon;
                ispravno = false;
            }

            return ispravno;
        }

        public void OcistiPoljaStavke()
        {
            cmbSuplementacija.SelectedIndex = -1;
            txtKolicina.Clear();
            txtCena.Clear();
            txtIznos.Clear();
            cmbSuplementacija.BackColor = Color.White;
            txtKolicina.BackColor = Color.White;
        }

        public void OsveziIznosStavke()
        {
            if (cmbSuplementacija.SelectedItem is not Suplementacija s)
            {
                txtCena.Clear();
                txtIznos.Clear();
                return;
            }

            txtCena.Text = s.Cena.ToString("0.00");

            if (int.TryParse(txtKolicina.Text, out int kolicina) && kolicina > 0)
            {
                txtIznos.Text = (s.Cena * kolicina).ToString("0.00");
            }
            else
            {
                txtIznos.Clear();
            }
        }
    }
}
