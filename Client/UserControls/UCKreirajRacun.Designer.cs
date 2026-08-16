namespace Client.UserControls
{
    partial class UCKreirajRacun
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
            lblKupac = new Label();
            lblProdavac = new Label();
            lblDatum = new Label();
            lblUkupanIznos = new Label();
            cmbKupac = new ComboBox();
            cmbProdavac = new ComboBox();
            dtpDatum = new DateTimePicker();
            txtUkupanIznos = new TextBox();
            btnKreirajRacun = new Button();
            btnSacuvajRacun = new Button();
            btnOtkazi = new Button();
            grpStavka = new GroupBox();
            lblIdRacuna = new Label();
            lblIdRacunaVrednost = new Label();
            lblSuplementacija = new Label();
            lblKolicina = new Label();
            lblCena = new Label();
            lblIznos = new Label();
            cmbSuplementacija = new ComboBox();
            txtKolicina = new TextBox();
            txtCena = new TextBox();
            txtIznos = new TextBox();
            btnDodajStavku = new Button();
            btnUkloniStavku = new Button();
            lblDodateStavke = new Label();
            dgvStavke = new DataGridView();
            colRb = new DataGridViewTextBoxColumn();
            colSuplementacija = new DataGridViewTextBoxColumn();
            colKolicina = new DataGridViewTextBoxColumn();
            colCena = new DataGridViewTextBoxColumn();
            colIznos = new DataGridViewTextBoxColumn();
            grpStavka.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).BeginInit();
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNaslov.ForeColor = Color.FromArgb(34, 40, 49);
            lblNaslov.Location = new Point(30, 20);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(165, 21);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "KREIRAJ RACUN";
            // 
            // lblKupac
            // 
            lblKupac.AutoSize = true;
            lblKupac.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblKupac.Location = new Point(30, 65);
            lblKupac.Name = "lblKupac";
            lblKupac.Size = new Size(55, 17);
            lblKupac.TabIndex = 1;
            lblKupac.Text = "Kupac:";
            // 
            // lblProdavac
            // 
            lblProdavac.AutoSize = true;
            lblProdavac.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblProdavac.Location = new Point(30, 105);
            lblProdavac.Name = "lblProdavac";
            lblProdavac.Size = new Size(75, 17);
            lblProdavac.TabIndex = 2;
            lblProdavac.Text = "Prodavac:";
            // 
            // lblDatum
            // 
            lblDatum.AutoSize = true;
            lblDatum.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblDatum.Location = new Point(30, 145);
            lblDatum.Name = "lblDatum";
            lblDatum.Size = new Size(130, 17);
            lblDatum.TabIndex = 3;
            lblDatum.Text = "Datum izvrsenja:";
            // 
            // lblUkupanIznos
            // 
            lblUkupanIznos.AutoSize = true;
            lblUkupanIznos.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblUkupanIznos.Location = new Point(30, 185);
            lblUkupanIznos.Name = "lblUkupanIznos";
            lblUkupanIznos.Size = new Size(110, 17);
            lblUkupanIznos.TabIndex = 4;
            lblUkupanIznos.Text = "Ukupan iznos:";
            // 
            // cmbKupac
            // 
            cmbKupac.Font = new Font("Segoe UI", 10F);
            cmbKupac.FormattingEnabled = true;
            cmbKupac.Location = new Point(170, 62);
            cmbKupac.Name = "cmbKupac";
            cmbKupac.Size = new Size(230, 25);
            cmbKupac.TabIndex = 5;
            // 
            // cmbProdavac
            // 
            cmbProdavac.Font = new Font("Segoe UI", 10F);
            cmbProdavac.FormattingEnabled = true;
            cmbProdavac.Location = new Point(170, 102);
            cmbProdavac.Name = "cmbProdavac";
            cmbProdavac.Size = new Size(230, 25);
            cmbProdavac.TabIndex = 6;
            // 
            // dtpDatum
            // 
            dtpDatum.Font = new Font("Segoe UI", 10F);
            dtpDatum.Format = DateTimePickerFormat.Short;
            dtpDatum.Location = new Point(170, 142);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(230, 25);
            dtpDatum.TabIndex = 7;
            // 
            // txtUkupanIznos
            // 
            txtUkupanIznos.BorderStyle = BorderStyle.FixedSingle;
            txtUkupanIznos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtUkupanIznos.Location = new Point(170, 182);
            txtUkupanIznos.Name = "txtUkupanIznos";
            txtUkupanIznos.ReadOnly = true;
            txtUkupanIznos.Size = new Size(230, 25);
            txtUkupanIznos.TabIndex = 8;
            // 
            // btnKreirajRacun
            // 
            btnKreirajRacun.BackColor = Color.FromArgb(63, 114, 175);
            btnKreirajRacun.FlatStyle = FlatStyle.Flat;
            btnKreirajRacun.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnKreirajRacun.ForeColor = Color.White;
            btnKreirajRacun.Location = new Point(30, 230);
            btnKreirajRacun.Name = "btnKreirajRacun";
            btnKreirajRacun.Size = new Size(120, 38);
            btnKreirajRacun.TabIndex = 9;
            btnKreirajRacun.Text = "Kreiraj racun";
            btnKreirajRacun.UseVisualStyleBackColor = false;
            // 
            // btnSacuvajRacun
            // 
            btnSacuvajRacun.BackColor = Color.FromArgb(63, 114, 175);
            btnSacuvajRacun.FlatStyle = FlatStyle.Flat;
            btnSacuvajRacun.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSacuvajRacun.ForeColor = Color.White;
            btnSacuvajRacun.Location = new Point(165, 230);
            btnSacuvajRacun.Name = "btnSacuvajRacun";
            btnSacuvajRacun.Size = new Size(120, 38);
            btnSacuvajRacun.TabIndex = 10;
            btnSacuvajRacun.Text = "Sacuvaj racun";
            btnSacuvajRacun.UseVisualStyleBackColor = false;
            // 
            // btnOtkazi
            // 
            btnOtkazi.BackColor = Color.FromArgb(150, 150, 150);
            btnOtkazi.FlatStyle = FlatStyle.Flat;
            btnOtkazi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOtkazi.ForeColor = Color.White;
            btnOtkazi.Location = new Point(300, 230);
            btnOtkazi.Name = "btnOtkazi";
            btnOtkazi.Size = new Size(100, 38);
            btnOtkazi.TabIndex = 11;
            btnOtkazi.Text = "Otkazi";
            btnOtkazi.UseVisualStyleBackColor = false;
            // 
            // lblIdRacuna
            // 
            lblIdRacuna.AutoSize = true;
            lblIdRacuna.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblIdRacuna.Location = new Point(20, 30);
            lblIdRacuna.Name = "lblIdRacuna";
            lblIdRacuna.Size = new Size(85, 17);
            lblIdRacuna.TabIndex = 0;
            lblIdRacuna.Text = "ID racuna:";
            // 
            // lblIdRacunaVrednost
            // 
            lblIdRacunaVrednost.AutoSize = true;
            lblIdRacunaVrednost.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic);
            lblIdRacunaVrednost.ForeColor = Color.FromArgb(63, 114, 175);
            lblIdRacunaVrednost.Location = new Point(150, 30);
            lblIdRacunaVrednost.Name = "lblIdRacunaVrednost";
            lblIdRacunaVrednost.Size = new Size(15, 17);
            lblIdRacunaVrednost.TabIndex = 1;
            lblIdRacunaVrednost.Text = "-";
            // 
            // lblSuplementacija
            // 
            lblSuplementacija.AutoSize = true;
            lblSuplementacija.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblSuplementacija.Location = new Point(20, 70);
            lblSuplementacija.Name = "lblSuplementacija";
            lblSuplementacija.Size = new Size(120, 17);
            lblSuplementacija.TabIndex = 2;
            lblSuplementacija.Text = "Suplementacija:";
            // 
            // lblKolicina
            // 
            lblKolicina.AutoSize = true;
            lblKolicina.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblKolicina.Location = new Point(20, 110);
            lblKolicina.Name = "lblKolicina";
            lblKolicina.Size = new Size(70, 17);
            lblKolicina.TabIndex = 3;
            lblKolicina.Text = "Kolicina:";
            // 
            // lblCena
            // 
            lblCena.AutoSize = true;
            lblCena.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblCena.Location = new Point(20, 150);
            lblCena.Name = "lblCena";
            lblCena.Size = new Size(45, 17);
            lblCena.TabIndex = 4;
            lblCena.Text = "Cena:";
            // 
            // lblIznos
            // 
            lblIznos.AutoSize = true;
            lblIznos.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblIznos.Location = new Point(20, 190);
            lblIznos.Name = "lblIznos";
            lblIznos.Size = new Size(50, 17);
            lblIznos.TabIndex = 5;
            lblIznos.Text = "Iznos:";
            // 
            // cmbSuplementacija
            // 
            cmbSuplementacija.Font = new Font("Segoe UI", 10F);
            cmbSuplementacija.FormattingEnabled = true;
            cmbSuplementacija.Location = new Point(150, 67);
            cmbSuplementacija.Name = "cmbSuplementacija";
            cmbSuplementacija.Size = new Size(250, 25);
            cmbSuplementacija.TabIndex = 6;
            // 
            // txtKolicina
            // 
            txtKolicina.BorderStyle = BorderStyle.FixedSingle;
            txtKolicina.Font = new Font("Segoe UI", 10F);
            txtKolicina.Location = new Point(150, 107);
            txtKolicina.Name = "txtKolicina";
            txtKolicina.Size = new Size(250, 25);
            txtKolicina.TabIndex = 7;
            // 
            // txtCena
            // 
            txtCena.BorderStyle = BorderStyle.FixedSingle;
            txtCena.Font = new Font("Segoe UI", 10F);
            txtCena.Location = new Point(150, 147);
            txtCena.Name = "txtCena";
            txtCena.ReadOnly = true;
            txtCena.Size = new Size(250, 25);
            txtCena.TabIndex = 8;
            // 
            // txtIznos
            // 
            txtIznos.BorderStyle = BorderStyle.FixedSingle;
            txtIznos.Font = new Font("Segoe UI", 10F);
            txtIznos.Location = new Point(150, 187);
            txtIznos.Name = "txtIznos";
            txtIznos.ReadOnly = true;
            txtIznos.Size = new Size(250, 25);
            txtIznos.TabIndex = 9;
            // 
            // btnDodajStavku
            // 
            btnDodajStavku.BackColor = Color.FromArgb(63, 114, 175);
            btnDodajStavku.FlatStyle = FlatStyle.Flat;
            btnDodajStavku.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDodajStavku.ForeColor = Color.White;
            btnDodajStavku.Location = new Point(150, 230);
            btnDodajStavku.Name = "btnDodajStavku";
            btnDodajStavku.Size = new Size(120, 38);
            btnDodajStavku.TabIndex = 10;
            btnDodajStavku.Text = "Dodaj stavku";
            btnDodajStavku.UseVisualStyleBackColor = false;
            // 
            // btnUkloniStavku
            // 
            btnUkloniStavku.BackColor = Color.FromArgb(150, 150, 150);
            btnUkloniStavku.FlatStyle = FlatStyle.Flat;
            btnUkloniStavku.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUkloniStavku.ForeColor = Color.White;
            btnUkloniStavku.Location = new Point(280, 230);
            btnUkloniStavku.Name = "btnUkloniStavku";
            btnUkloniStavku.Size = new Size(120, 38);
            btnUkloniStavku.TabIndex = 11;
            btnUkloniStavku.Text = "Ukloni stavku";
            btnUkloniStavku.UseVisualStyleBackColor = false;
            // 
            // grpStavka
            // 
            grpStavka.Controls.Add(lblIdRacuna);
            grpStavka.Controls.Add(lblIdRacunaVrednost);
            grpStavka.Controls.Add(lblSuplementacija);
            grpStavka.Controls.Add(lblKolicina);
            grpStavka.Controls.Add(lblCena);
            grpStavka.Controls.Add(lblIznos);
            grpStavka.Controls.Add(cmbSuplementacija);
            grpStavka.Controls.Add(txtKolicina);
            grpStavka.Controls.Add(txtCena);
            grpStavka.Controls.Add(txtIznos);
            grpStavka.Controls.Add(btnDodajStavku);
            grpStavka.Controls.Add(btnUkloniStavku);
            grpStavka.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grpStavka.Location = new Point(440, 20);
            grpStavka.Name = "grpStavka";
            grpStavka.Size = new Size(420, 285);
            grpStavka.TabIndex = 12;
            grpStavka.TabStop = false;
            grpStavka.Text = "Stavka racuna";
            // 
            // lblDodateStavke
            // 
            lblDodateStavke.AutoSize = true;
            lblDodateStavke.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic);
            lblDodateStavke.Location = new Point(30, 320);
            lblDodateStavke.Name = "lblDodateStavke";
            lblDodateStavke.Size = new Size(110, 17);
            lblDodateStavke.TabIndex = 13;
            lblDodateStavke.Text = "Dodate stavke";
            // 
            // colRb
            // 
            colRb.DataPropertyName = "Rb";
            colRb.HeaderText = "Rb";
            colRb.Name = "colRb";
            colRb.Width = 45;
            // 
            // colSuplementacija
            // 
            colSuplementacija.DataPropertyName = "Suplementacija";
            colSuplementacija.HeaderText = "Suplementacija";
            colSuplementacija.Name = "colSuplementacija";
            colSuplementacija.Width = 340;
            // 
            // colKolicina
            // 
            colKolicina.DataPropertyName = "Kolicina";
            colKolicina.HeaderText = "Kolicina";
            colKolicina.Name = "colKolicina";
            colKolicina.Width = 90;
            // 
            // colCena
            // 
            colCena.DataPropertyName = "Cena";
            colCena.HeaderText = "Cena";
            colCena.Name = "colCena";
            colCena.Width = 110;
            // 
            // colIznos
            // 
            colIznos.DataPropertyName = "Iznos";
            colIznos.HeaderText = "Iznos";
            colIznos.Name = "colIznos";
            colIznos.Width = 110;
            // 
            // dgvStavke
            // 
            dgvStavke.AllowUserToAddRows = false;
            dgvStavke.AllowUserToDeleteRows = false;
            dgvStavke.BackgroundColor = Color.White;
            dgvStavke.BorderStyle = BorderStyle.FixedSingle;
            dgvStavke.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStavke.Columns.AddRange(new DataGridViewColumn[] {
                colRb, colSuplementacija, colKolicina, colCena, colIznos });
            dgvStavke.Location = new Point(30, 345);
            dgvStavke.MultiSelect = false;
            dgvStavke.Name = "dgvStavke";
            dgvStavke.ReadOnly = true;
            dgvStavke.RowHeadersVisible = false;
            dgvStavke.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStavke.Size = new Size(830, 160);
            dgvStavke.TabIndex = 14;
            // 
            // UCKreirajRacun
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 238, 238);
            Controls.Add(lblNaslov);
            Controls.Add(lblKupac);
            Controls.Add(lblProdavac);
            Controls.Add(lblDatum);
            Controls.Add(lblUkupanIznos);
            Controls.Add(cmbKupac);
            Controls.Add(cmbProdavac);
            Controls.Add(dtpDatum);
            Controls.Add(txtUkupanIznos);
            Controls.Add(btnKreirajRacun);
            Controls.Add(btnSacuvajRacun);
            Controls.Add(btnOtkazi);
            Controls.Add(grpStavka);
            Controls.Add(lblDodateStavke);
            Controls.Add(dgvStavke);
            Name = "UCKreirajRacun";
            Size = new Size(900, 526);
            grpStavka.ResumeLayout(false);
            grpStavka.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblNaslov;
        private Label lblKupac;
        private Label lblProdavac;
        private Label lblDatum;
        private Label lblUkupanIznos;
        private Label lblIdRacuna;
        private Label lblSuplementacija;
        private Label lblKolicina;
        private Label lblCena;
        private Label lblIznos;
        private Label lblDodateStavke;
        private GroupBox grpStavka;
        public Label lblIdRacunaVrednost;
        public ComboBox cmbKupac;
        public ComboBox cmbProdavac;
        public ComboBox cmbSuplementacija;
        public DateTimePicker dtpDatum;
        public TextBox txtUkupanIznos;
        public TextBox txtKolicina;
        public TextBox txtCena;
        public TextBox txtIznos;
        public Button btnKreirajRacun;
        public Button btnSacuvajRacun;
        public Button btnOtkazi;
        public Button btnDodajStavku;
        public Button btnUkloniStavku;
        public DataGridView dgvStavke;
        private DataGridViewTextBoxColumn colRb;
        private DataGridViewTextBoxColumn colSuplementacija;
        private DataGridViewTextBoxColumn colKolicina;
        private DataGridViewTextBoxColumn colCena;
        private DataGridViewTextBoxColumn colIznos;
    }
}
