namespace Client.UserControls
{
    /// <summary>
    /// Ekranska forma za SK21 - Ubaci kvalifikaciju.
    /// </summary>
    public partial class UCUbaciKvalifikaciju : UserControl
    {
        public UCUbaciKvalifikaciju()
        {
            InitializeComponent();
            PopuniPadajuceListe();
        }

        /// <summary>
        /// Dozvoljene vrednosti odgovaraju ogranicenjima
        /// CK_kvalifikacija_naziv i CK_kvalifikacija_nivo u bazi podataka.
        /// </summary>
        private void PopuniPadajuceListe()
        {
            cmbNaziv.Items.AddRange(new object[]
            {
                "Nutricionisticki savetnik",
                "Specijalista za sportsku ishranu",
                "Farmaceutski tehnicar"
            });

            cmbNivoStrucnosti.Items.AddRange(new object[]
            {
                "Junior",
                "Senior",
                "Master"
            });

            cmbNaziv.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNivoStrucnosti.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Kontrola ispravnosti unetih podataka.
        /// Odgovara koraku 2 scenarija SK21 (AНСО).
        /// </summary>
        public bool Validacija()
        {
            cmbNaziv.BackColor = Color.White;
            cmbNivoStrucnosti.BackColor = Color.White;

            bool ispravno = true;

            if (cmbNaziv.SelectedItem == null)
            {
                cmbNaziv.BackColor = Color.Salmon;
                ispravno = false;
            }

            if (cmbNivoStrucnosti.SelectedItem == null)
            {
                cmbNivoStrucnosti.BackColor = Color.Salmon;
                ispravno = false;
            }

            return ispravno;
        }

        public void Ocisti()
        {
            cmbNaziv.SelectedIndex = -1;
            cmbNivoStrucnosti.SelectedIndex = -1;
            cmbNaziv.BackColor = Color.White;
            cmbNivoStrucnosti.BackColor = Color.White;
        }
    }
}
