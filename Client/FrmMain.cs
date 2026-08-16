using Client.GuiController;

namespace Client
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            // Dokumenti -> Racun
            itemKreirajRacun.Click += (s, a) => MainCoordinator.Instance.ShowKreirajRacunPanel();
            itemPretraziRacun.Click += (s, a) => MainCoordinator.Instance.ShowPretraziRacunPanel();
            itemPromeniRacun.Click += (s, a) => MainCoordinator.Instance.ShowPromeniRacunPanel();

            // Primalac usluge -> Kupac
            itemKreirajKupac.Click += (s, a) => MainCoordinator.Instance.ShowKreirajKupacPanel();
            itemPretraziKupac.Click += (s, a) => MainCoordinator.Instance.ShowPretraziKupacPanel();
            itemPromeniKupac.Click += (s, a) => MainCoordinator.Instance.ShowPromeniKupacPanel();
            itemObrisiKupac.Click += (s, a) => MainCoordinator.Instance.ShowObrisiKupacPanel();

            // Sifarnici -> Kvalifikacija
            itemUbaciKvalifikaciju.Click += (s, a) => MainCoordinator.Instance.ShowUbaciKvalifikacijuPanel();

            itemOProgramu.Click += (s, a) => MainCoordinator.Instance.PrikaziOProgramu();

            FormClosing += FrmMain_FormClosing;
        }

        /// <summary>Zamenjuje sadrzaj centralnog panela izabranom kontrolom.</summary>
        public void ChangePanel(Control kontrola)
        {
            MainCoordinator.Instance.HandleClose();
            pnlMain.Controls.Clear();
            kontrola.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(kontrola);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult odgovor = MessageBox.Show(
                "Da li ste sigurni da zelite da zatvorite aplikaciju?",
                "Zavrsen rad", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (odgovor == DialogResult.OK)
            {
                MainCoordinator.Instance.HandleClose();
                Communication.Instance.Disconnect();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
