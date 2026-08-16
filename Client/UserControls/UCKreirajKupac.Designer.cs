namespace Client.UserControls
{
    partial class UCKreirajKupac
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
            lblIme = new Label();
            lblPrezime = new Label();
            lblEmail = new Label();
            lblAdresa = new Label();
            lblGrad = new Label();
            txtIme = new TextBox();
            txtPrezime = new TextBox();
            txtEmail = new TextBox();
            txtAdresa = new TextBox();
            cmbGrad = new ComboBox();
            btnKreiraj = new Button();
            btnSacuvaj = new Button();
            btnOtkazi = new Button();
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNaslov.ForeColor = Color.FromArgb(34, 40, 49);
            lblNaslov.Location = new Point(60, 30);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(160, 21);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "KREIRAJ KUPCA";
            // 
            // lblIme
            // 
            lblIme.AutoSize = true;
            lblIme.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblIme.Location = new Point(60, 85);
            lblIme.Name = "lblIme";
            lblIme.Size = new Size(85, 17);
            lblIme.TabIndex = 1;
            lblIme.Text = "Ime kupca:";
            // 
            // lblPrezime
            // 
            lblPrezime.AutoSize = true;
            lblPrezime.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblPrezime.Location = new Point(60, 125);
            lblPrezime.Name = "lblPrezime";
            lblPrezime.Size = new Size(115, 17);
            lblPrezime.TabIndex = 2;
            lblPrezime.Text = "Prezime kupca:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblEmail.Location = new Point(60, 165);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(95, 17);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email kupca:";
            // 
            // lblAdresa
            // 
            lblAdresa.AutoSize = true;
            lblAdresa.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblAdresa.Location = new Point(60, 205);
            lblAdresa.Name = "lblAdresa";
            lblAdresa.Size = new Size(105, 17);
            lblAdresa.TabIndex = 4;
            lblAdresa.Text = "Adresa kupca:";
            // 
            // lblGrad
            // 
            lblGrad.AutoSize = true;
            lblGrad.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblGrad.Location = new Point(60, 245);
            lblGrad.Name = "lblGrad";
            lblGrad.Size = new Size(45, 17);
            lblGrad.TabIndex = 5;
            lblGrad.Text = "Grad:";
            // 
            // txtIme
            // 
            txtIme.BorderStyle = BorderStyle.FixedSingle;
            txtIme.Font = new Font("Segoe UI", 10F);
            txtIme.Location = new Point(210, 82);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(280, 25);
            txtIme.TabIndex = 6;
            // 
            // txtPrezime
            // 
            txtPrezime.BorderStyle = BorderStyle.FixedSingle;
            txtPrezime.Font = new Font("Segoe UI", 10F);
            txtPrezime.Location = new Point(210, 122);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(280, 25);
            txtPrezime.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(210, 162);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(280, 25);
            txtEmail.TabIndex = 8;
            // 
            // txtAdresa
            // 
            txtAdresa.BorderStyle = BorderStyle.FixedSingle;
            txtAdresa.Font = new Font("Segoe UI", 10F);
            txtAdresa.Location = new Point(210, 202);
            txtAdresa.Name = "txtAdresa";
            txtAdresa.Size = new Size(280, 25);
            txtAdresa.TabIndex = 9;
            // 
            // cmbGrad
            // 
            cmbGrad.Font = new Font("Segoe UI", 10F);
            cmbGrad.FormattingEnabled = true;
            cmbGrad.Location = new Point(210, 242);
            cmbGrad.Name = "cmbGrad";
            cmbGrad.Size = new Size(280, 25);
            cmbGrad.TabIndex = 10;
            // 
            // btnKreiraj
            // 
            btnKreiraj.BackColor = Color.FromArgb(63, 114, 175);
            btnKreiraj.FlatStyle = FlatStyle.Flat;
            btnKreiraj.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnKreiraj.ForeColor = Color.White;
            btnKreiraj.Location = new Point(210, 300);
            btnKreiraj.Name = "btnKreiraj";
            btnKreiraj.Size = new Size(130, 38);
            btnKreiraj.TabIndex = 11;
            btnKreiraj.Text = "Kreiraj";
            btnKreiraj.UseVisualStyleBackColor = false;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.BackColor = Color.FromArgb(63, 114, 175);
            btnSacuvaj.FlatStyle = FlatStyle.Flat;
            btnSacuvaj.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSacuvaj.ForeColor = Color.White;
            btnSacuvaj.Location = new Point(360, 300);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(130, 38);
            btnSacuvaj.TabIndex = 12;
            btnSacuvaj.Text = "Sacuvaj";
            btnSacuvaj.UseVisualStyleBackColor = false;
            // 
            // btnOtkazi
            // 
            btnOtkazi.BackColor = Color.FromArgb(150, 150, 150);
            btnOtkazi.FlatStyle = FlatStyle.Flat;
            btnOtkazi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOtkazi.ForeColor = Color.White;
            btnOtkazi.Location = new Point(510, 300);
            btnOtkazi.Name = "btnOtkazi";
            btnOtkazi.Size = new Size(130, 38);
            btnOtkazi.TabIndex = 13;
            btnOtkazi.Text = "Otkazi";
            btnOtkazi.UseVisualStyleBackColor = false;
            // 
            // UCKreirajKupac
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 238, 238);
            Controls.Add(lblNaslov);
            Controls.Add(lblIme);
            Controls.Add(lblPrezime);
            Controls.Add(lblEmail);
            Controls.Add(lblAdresa);
            Controls.Add(lblGrad);
            Controls.Add(txtIme);
            Controls.Add(txtPrezime);
            Controls.Add(txtEmail);
            Controls.Add(txtAdresa);
            Controls.Add(cmbGrad);
            Controls.Add(btnKreiraj);
            Controls.Add(btnSacuvaj);
            Controls.Add(btnOtkazi);
            Name = "UCKreirajKupac";
            Size = new Size(900, 526);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblNaslov;
        private Label lblIme;
        private Label lblPrezime;
        private Label lblEmail;
        private Label lblAdresa;
        private Label lblGrad;
        public TextBox txtIme;
        public TextBox txtPrezime;
        public TextBox txtEmail;
        public TextBox txtAdresa;
        public ComboBox cmbGrad;
        public Button btnKreiraj;
        public Button btnSacuvaj;
        public Button btnOtkazi;
    }
}
