namespace Server
{
    public partial class FrmServer : Form
    {
        private Server server;

        public FrmServer()
        {
            InitializeComponent();
            btnPokreni.Enabled = true;
            btnZaustavi.Enabled = false;
            lblStatus.Text = "Server ceka na pokretanje";
        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            try
            {
                server = new Server();
                server.Start();

                btnPokreni.Enabled = false;
                btnZaustavi.Enabled = true;
                lblStatus.Text = "Server je pokrenut";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server ne moze da se pokrene: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            server?.Stop();

            btnPokreni.Enabled = true;
            btnZaustavi.Enabled = false;
            lblStatus.Text = "Server je zaustavljen";
        }

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            server?.Stop();
            Environment.Exit(0);
        }
    }
}
