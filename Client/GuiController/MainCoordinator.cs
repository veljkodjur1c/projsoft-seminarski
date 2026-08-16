namespace Client.GuiController
{
    /// <summary>
    /// Koordinira rad glavne forme i kontrolera pojedinacnih slucajeva koriscenja.
    /// Na zahtev menija menja sadrzaj centralnog panela.
    /// </summary>
    internal class MainCoordinator
    {
        #region Singleton

        private static MainCoordinator instance;

        public static MainCoordinator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainCoordinator();
                }
                return instance;
            }
        }

        private MainCoordinator()
        {
            // Kontroleri slucajeva koriscenja se dodaju u narednim koracima.
        }

        #endregion

        private FrmMain frmMain;

        internal void ShowMain()
        {
            frmMain = new FrmMain();
            frmMain.Text = $"Pocetni ekran: {LoginGuiController.Instance.PrijavljeniProdavac}";
            frmMain.ShowDialog();
        }

        // ---------- SK1, SK2, SK3 ----------
        internal void ShowKreirajRacunPanel() => UIzradi("Kreiraj racun");
        internal void ShowPretraziRacunPanel() => UIzradi("Pretrazi racun");
        internal void ShowPromeniRacunPanel() => UIzradi("Promeni racun");

        // ---------- SK4, SK5, SK6, SK7 ----------
        internal void ShowKreirajKupacPanel() => UIzradi("Kreiraj kupca");
        internal void ShowPretraziKupacPanel() => UIzradi("Pretrazi kupca");
        internal void ShowPromeniKupacPanel() => UIzradi("Promeni kupca");
        internal void ShowObrisiKupacPanel() => UIzradi("Obrisi kupca");

        // ---------- SK21 ----------
        internal void ShowUbaciKvalifikacijuPanel() => UIzradi("Ubaci kvalifikaciju");

        internal void PrikaziOProgramu()
        {
            MessageBox.Show(
                "Softverski sistem za prodaju suplementacije\n\n" +
                "Seminarski rad iz predmeta Projektovanje softvera\n" +
                "Fakultet organizacionih nauka\n\n" +
                "Student: Veljko Djuric 2023/0039",
                "O programu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Privremena zamena za paneli koji jos nisu napravljeni.
        /// Bice uklonjena kada se dodaju sve korisnicke kontrole.
        /// </summary>
        private void UIzradi(string naziv)
        {
            MessageBox.Show($"Panel \"{naziv}\" jos nije napravljen.",
                "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Poziva se pri promeni panela i pri zatvaranju aplikacije,
        /// da bi se ponistili nedovrseni unosi.
        /// </summary>
        internal void HandleClose()
        {
            // Bice popunjeno kada se dodaju kontroleri koji prave privremene slogove.
        }
    }
}
