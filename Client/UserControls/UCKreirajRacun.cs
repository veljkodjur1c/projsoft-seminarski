using Common.Domain;
using System.ComponentModel;

namespace Client.UserControls
{
    /// <summary>
    /// Ekranska forma za SK1 - Kreiraj racun.
    /// </summary>
    public partial class UCKreirajRacun : UserControl
    {
        public UCKreirajRacun()
        {
            InitializeComponent();
            cmbKupac.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProdavac.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSuplementacija.DropDownStyle = ComboBoxStyle.DropDownList;
            dgvStavke.AutoGenerateColumns = false;
            PostaviPocetnoStanje();
        }

        public void PopuniKupce(List<Kupac> kupci)
        {
            cmbKupac.DataSource = kupci;
            cmbKupac.SelectedIndex = -1;
        }

        public void PopuniProdavce(List<Prodavac> prodavci, Prodavac prijavljeni)
        {
            cmbProdavac.DataSource = prodavci;
            cmbProdavac.SelectedIndex = -1;

            foreach (Prodavac p in cmbProdavac.Items)
            {
                if (p.Id == prijavljeni.Id)
                {
                    cmbProdavac.SelectedItem = p;
                    break;
                }
            }

            // Racun izdaje prijavljeni prodavac, izbor nije moguc.
            cmbProdavac.Enabled = false;
        }

        public void PopuniSuplementacije(List<Suplementacija> suplementacije)
        {
            cmbSuplementacija.DataSource = suplementacije;
            cmbSuplementacija.SelectedIndex = -1;
        }

        public void PrikaziStavke(BindingList<StavkaRacuna> stavke)
        {
            dgvStavke.DataSource = null;
            dgvStavke.DataSource = stavke;
        }

        public StavkaRacuna VratiIzabranuStavku()
        {
            if (dgvStavke.SelectedRows.Count == 0)
            {
                return null;
            }
            return dgvStavke.SelectedRows[0].DataBoundItem as StavkaRacuna;
        }

        public void PrikaziIdRacuna(int id)
        {
            lblIdRacunaVrednost.Text = id.ToString();
        }

        public void PrikaziUkupanIznos(double iznos)
        {
            txtUkupanIznos.Text = iznos.ToString("0.00");
        }

        /// <summary>Pre nego sto sistem kreira racun, rad sa stavkama nije moguc.</summary>
        public void PostaviPocetnoStanje()
        {
            lblIdRacunaVrednost.Text = "-";
            txtUkupanIznos.Clear();
            cmbKupac.SelectedIndex = -1;
            cmbSuplementacija.SelectedIndex = -1;
            txtKolicina.Clear();
            txtCena.Clear();
            txtIznos.Clear();
            dtpDatum.Value = DateTime.Today;
            dgvStavke.DataSource = null;

            cmbKupac.Enabled = true;
            btnKreirajRacun.Enabled = true;
            btnSacuvajRacun.Enabled = false;
            btnOtkazi.Enabled = false;
            PostaviDostupnostStavki(false);
        }

        /// <summary>Posle koraka 2 scenarija, mogu da se dodaju stavke.</summary>
        public void PostaviStanjeUnosa()
        {
            cmbKupac.Enabled = false;
            btnKreirajRacun.Enabled = false;
            btnSacuvajRacun.Enabled = true;
            btnOtkazi.Enabled = true;
            PostaviDostupnostStavki(true);
        }

        private void PostaviDostupnostStavki(bool dostupno)
        {
            cmbSuplementacija.Enabled = dostupno;
            txtKolicina.Enabled = dostupno;
            btnDodajStavku.Enabled = dostupno;
            btnUkloniStavku.Enabled = dostupno;
        }

        /// <summary>
        /// Kontrola podataka o stavci pre dodavanja.
        /// </summary>
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

            // Vrednosno ogranicenje: kolicina NOT NULL and > 0
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

        /// <summary>Osvezava cenu i iznos kada se promeni izbor ili kolicina.</summary>
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
