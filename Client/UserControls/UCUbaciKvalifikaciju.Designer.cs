namespace Client.UserControls
{
    partial class UCUbaciKvalifikaciju
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
            lblNaslov = new Label();
            lblNaziv = new Label();
            lblNivoStrucnosti = new Label();
            cmbNaziv = new ComboBox();
            cmbNivoStrucnosti = new ComboBox();
            btnUbaci = new Button();
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNaslov.ForeColor = Color.FromArgb(34, 40, 49);
            lblNaslov.Location = new Point(60, 40);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(220, 21);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "UBACI KVALIFIKACIJU";
            // 
            // lblNaziv
            // 
            lblNaziv.AutoSize = true;
            lblNaziv.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblNaziv.Location = new Point(60, 100);
            lblNaziv.Name = "lblNaziv";
            lblNaziv.Size = new Size(130, 17);
            lblNaziv.TabIndex = 1;
            lblNaziv.Text = "Naziv kvalifikacije:";
            // 
            // lblNivoStrucnosti
            // 
            lblNivoStrucnosti.AutoSize = true;
            lblNivoStrucnosti.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblNivoStrucnosti.Location = new Point(60, 145);
            lblNivoStrucnosti.Name = "lblNivoStrucnosti";
            lblNivoStrucnosti.Size = new Size(115, 17);
            lblNivoStrucnosti.TabIndex = 2;
            lblNivoStrucnosti.Text = "Nivo strucnosti:";
            // 
            // cmbNaziv
            // 
            cmbNaziv.Font = new Font("Segoe UI", 10F);
            cmbNaziv.FormattingEnabled = true;
            cmbNaziv.Location = new Point(210, 97);
            cmbNaziv.Name = "cmbNaziv";
            cmbNaziv.Size = new Size(260, 25);
            cmbNaziv.TabIndex = 3;
            // 
            // cmbNivoStrucnosti
            // 
            cmbNivoStrucnosti.Font = new Font("Segoe UI", 10F);
            cmbNivoStrucnosti.FormattingEnabled = true;
            cmbNivoStrucnosti.Location = new Point(210, 142);
            cmbNivoStrucnosti.Name = "cmbNivoStrucnosti";
            cmbNivoStrucnosti.Size = new Size(260, 25);
            cmbNivoStrucnosti.TabIndex = 4;
            // 
            // btnUbaci
            // 
            btnUbaci.BackColor = Color.FromArgb(63, 114, 175);
            btnUbaci.FlatStyle = FlatStyle.Flat;
            btnUbaci.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUbaci.ForeColor = Color.White;
            btnUbaci.Location = new Point(210, 200);
            btnUbaci.Name = "btnUbaci";
            btnUbaci.Size = new Size(130, 38);
            btnUbaci.TabIndex = 5;
            btnUbaci.Text = "Ubaci";
            btnUbaci.UseVisualStyleBackColor = false;
            // 
            // UCUbaciKvalifikaciju
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 238, 238);
            Controls.Add(lblNaslov);
            Controls.Add(lblNaziv);
            Controls.Add(lblNivoStrucnosti);
            Controls.Add(cmbNaziv);
            Controls.Add(cmbNivoStrucnosti);
            Controls.Add(btnUbaci);
            Name = "UCUbaciKvalifikaciju";
            Size = new Size(900, 526);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblNaslov;
        private Label lblNaziv;
        private Label lblNivoStrucnosti;
        public ComboBox cmbNaziv;
        public ComboBox cmbNivoStrucnosti;
        public Button btnUbaci;
    }
}
