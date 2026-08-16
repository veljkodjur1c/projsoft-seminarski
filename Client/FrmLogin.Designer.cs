namespace Client
{
    partial class FrmLogin
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
            pnlPozadina = new Panel();
            lblKorisnickoIme = new Label();
            lblSifra = new Label();
            txtKorisnickoIme = new TextBox();
            txtSifra = new TextBox();
            btnPrijaviSe = new Button();
            pnlPozadina.SuspendLayout();
            SuspendLayout();
            // 
            // lblKorisnickoIme
            // 
            lblKorisnickoIme.AutoSize = true;
            lblKorisnickoIme.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblKorisnickoIme.Location = new Point(55, 58);
            lblKorisnickoIme.Name = "lblKorisnickoIme";
            lblKorisnickoIme.Size = new Size(115, 17);
            lblKorisnickoIme.TabIndex = 0;
            lblKorisnickoIme.Text = "Korisnicko ime:";
            // 
            // lblSifra
            // 
            lblSifra.AutoSize = true;
            lblSifra.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblSifra.Location = new Point(115, 100);
            lblSifra.Name = "lblSifra";
            lblSifra.Size = new Size(48, 17);
            lblSifra.TabIndex = 1;
            lblSifra.Text = "Sifra:";
            // 
            // txtKorisnickoIme
            // 
            txtKorisnickoIme.BorderStyle = BorderStyle.FixedSingle;
            txtKorisnickoIme.Font = new Font("Segoe UI", 10F);
            txtKorisnickoIme.Location = new Point(180, 55);
            txtKorisnickoIme.Name = "txtKorisnickoIme";
            txtKorisnickoIme.Size = new Size(190, 25);
            txtKorisnickoIme.TabIndex = 2;
            // 
            // txtSifra
            // 
            txtSifra.BorderStyle = BorderStyle.FixedSingle;
            txtSifra.Font = new Font("Segoe UI", 10F);
            txtSifra.Location = new Point(180, 97);
            txtSifra.Name = "txtSifra";
            txtSifra.Size = new Size(190, 25);
            txtSifra.TabIndex = 3;
            // 
            // btnPrijaviSe
            // 
            btnPrijaviSe.BackColor = Color.FromArgb(63, 114, 175);
            btnPrijaviSe.FlatStyle = FlatStyle.Flat;
            btnPrijaviSe.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPrijaviSe.ForeColor = Color.White;
            btnPrijaviSe.Location = new Point(180, 150);
            btnPrijaviSe.Name = "btnPrijaviSe";
            btnPrijaviSe.Size = new Size(130, 38);
            btnPrijaviSe.TabIndex = 4;
            btnPrijaviSe.Text = "Prijavi se";
            btnPrijaviSe.UseVisualStyleBackColor = false;
            // 
            // pnlPozadina
            // 
            pnlPozadina.BackColor = Color.FromArgb(238, 238, 238);
            pnlPozadina.Controls.Add(lblKorisnickoIme);
            pnlPozadina.Controls.Add(lblSifra);
            pnlPozadina.Controls.Add(txtKorisnickoIme);
            pnlPozadina.Controls.Add(txtSifra);
            pnlPozadina.Controls.Add(btnPrijaviSe);
            pnlPozadina.Dock = DockStyle.Fill;
            pnlPozadina.Location = new Point(0, 0);
            pnlPozadina.Name = "pnlPozadina";
            pnlPozadina.Size = new Size(464, 231);
            pnlPozadina.TabIndex = 0;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 231);
            Controls.Add(pnlPozadina);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login forma";
            pnlPozadina.ResumeLayout(false);
            pnlPozadina.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlPozadina;
        private Label lblKorisnickoIme;
        private Label lblSifra;
        public TextBox txtKorisnickoIme;
        public TextBox txtSifra;
        private Button btnPrijaviSe;
    }
}
