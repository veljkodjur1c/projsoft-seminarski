namespace Server
{
    partial class FrmServer
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnPokreni = new Button();
            btnZaustavi = new Button();
            lblStatus = new Label();
            pnlPozadina = new Panel();
            pnlPozadina.SuspendLayout();
            SuspendLayout();
            // 
            // btnPokreni
            // 
            btnPokreni.BackColor = Color.FromArgb(63, 114, 175);
            btnPokreni.FlatStyle = FlatStyle.Flat;
            btnPokreni.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPokreni.ForeColor = Color.White;
            btnPokreni.Location = new Point(60, 45);
            btnPokreni.Name = "btnPokreni";
            btnPokreni.Size = new Size(140, 45);
            btnPokreni.TabIndex = 0;
            btnPokreni.Text = "POKRENI";
            btnPokreni.UseVisualStyleBackColor = false;
            btnPokreni.Click += btnPokreni_Click;
            // 
            // btnZaustavi
            // 
            btnZaustavi.BackColor = Color.FromArgb(63, 114, 175);
            btnZaustavi.FlatStyle = FlatStyle.Flat;
            btnZaustavi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnZaustavi.ForeColor = Color.White;
            btnZaustavi.Location = new Point(240, 45);
            btnZaustavi.Name = "btnZaustavi";
            btnZaustavi.Size = new Size(140, 45);
            btnZaustavi.TabIndex = 1;
            btnZaustavi.Text = "ZAUSTAVI";
            btnZaustavi.UseVisualStyleBackColor = false;
            btnZaustavi.Click += btnZaustavi_Click;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(34, 40, 49);
            lblStatus.Location = new Point(30, 115);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(380, 35);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Server ceka na pokretanje";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlPozadina
            // 
            pnlPozadina.BackColor = Color.FromArgb(219, 226, 239);
            pnlPozadina.Controls.Add(btnPokreni);
            pnlPozadina.Controls.Add(btnZaustavi);
            pnlPozadina.Controls.Add(lblStatus);
            pnlPozadina.Dock = DockStyle.Fill;
            pnlPozadina.Location = new Point(0, 0);
            pnlPozadina.Name = "pnlPozadina";
            pnlPozadina.Size = new Size(444, 181);
            pnlPozadina.TabIndex = 3;
            // 
            // FrmServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 181);
            Controls.Add(pnlPozadina);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmServer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Server";
            FormClosed += FrmServer_FormClosed;
            pnlPozadina.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Button btnPokreni;
        private Button btnZaustavi;
        private Label lblStatus;
        private Panel pnlPozadina;
    }
}
