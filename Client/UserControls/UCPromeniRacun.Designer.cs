namespace Client.UserControls
{
    partial class UCPromeniRacun
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
            btnVratiRacune = new Button();
            btnPretraziRacun = new Button();
            btnPromeniRacun = new Button();
            dgvRacuni = new DataGridView();
            grpStavka = new GroupBox();
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
            lblStavke = new Label();
            dgvStavke = new DataGridView();
            colIdRacun = new DataGridViewTextBoxColumn();
            colDatum = new DataGridViewTextBoxColumn();
            colUkupanIznos = new DataGridViewTextBoxColumn();
            colProdavac = new DataGridViewTextBoxColumn();
            colKupac = new DataGridViewTextBoxColumn();
            colRb = new DataGridViewTextBoxColumn();
            colSuplementacija = new DataGridViewTextBoxColumn();
            colKolicina = new DataGridViewTextBoxColumn();
            colCena = new DataGridViewTextBoxColumn();
            colIznos = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvRacuni).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).BeginInit();
            grpStavka.SuspendLayout();
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNaslov.ForeColor = Color.FromArgb(34, 40, 49);
            lblNaslov.Location = new Point(30, 15);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(180, 21);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "PROMENI RACUN";
            // 
            // lblKupac
            // 
            lblKupac.AutoSize = true;
            lblKupac.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblKupac.Location = new Point(30, 53);
            lblKupac.Name = "lblKupac";
            lblKupac.Size = new Size(55, 17);
            lblKupac.TabIndex = 1;
            lblKupac.Text = "Kupac:";
            // 
            // lblProdavac
            // 
            lblProdavac.AutoSize = true;
            lblProdavac.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblProdavac.Location = new Point(30, 88);
            lblProdavac.Name = "lblProdavac";
            lblProdavac.Size = new Size(75, 17);
            lblProdavac.TabIndex = 2;
            lblProdavac.Text = "Prodavac:";
            // 
            // lblDatum
            // 
            lblDatum.AutoSize = true;
            lblDatum.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblDatum.Location = new Point(30, 123);
            lblDatum.Name = "lblDatum";
            lblDatum.Size = new Size(130, 17);
            lblDatum.TabIndex = 3;
            lblDatum.Text = "Datum izvrsenja:";
            // 
            // lblUkupanIznos
            // 
            lblUkupanIznos.AutoSize = true;
            lblUkupanIznos.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblUkupanIznos.Location = new Point(30, 158);
            lblUkupanIznos.Name = "lblUkupanIznos";
            lblUkupanIznos.Size = new Size(110, 17);
            lblUkupanIznos.TabIndex = 4;
            lblUkupanIznos.Text = "Ukupan iznos:";
            // 
            // cmbKupac
            // 
            cmbKupac.Font = new Font("Segoe UI", 10F);
            cmbKupac.FormattingEnabled = true;
            cmbKupac.Location = new Point(165, 50);
            cmbKupac.Name = "cmbKupac";
            cmbKupac.Size = new Size(215, 25);
            cmbKupac.TabIndex = 5;
            // 
            // cmbProdavac
            // 
            cmbProdavac.Font = new Font("Segoe UI", 10F);
            cmbProdavac.FormattingEnabled = true;
            cmbProdavac.Location = new Point(165, 85);
            cmbProdavac.Name = "cmbProdavac";
            cmbProdavac.Size = new Size(215, 25);
            cmbProdavac.TabIndex = 6;
            // 
            // dtpDatum
            // 
            dtpDatum.Checked = false;
            dtpDatum.Font = new Font("Segoe UI", 10F);
            dtpDatum.Format = DateTimePickerFormat.Short;
            dtpDatum.Location = new Point(165, 120);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.ShowCheckBox = true;
            dtpDatum.Size = new Size(215, 25);
            dtpDatum.TabIndex = 7;
            // 
            // txtUkupanIznos
            // 
            txtUkupanIznos.BorderStyle = BorderStyle.FixedSingle;
            txtUkupanIznos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtUkupanIznos.Location = new Point(165, 155);
            txtUkupanIznos.Name = "txtUkupanIznos";
            txtUkupanIznos.ReadOnly = true;
            txtUkupanIznos.Size = new Size(215, 25);
            txtUkupanIznos.TabIndex = 8;
            // 
            // btnVratiRacune
            // 
            btnVratiRacune.BackColor = Color.FromArgb(63, 114, 175);
            btnVratiRacune.FlatStyle = FlatStyle.Flat;
            btnVratiRacune.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVratiRacune.ForeColor = Color.White;
            btnVratiRacune.Location = new Point(30, 197);
            btnVratiRacune.Name = "btnVratiRacune";
            btnVratiRacune.Size = new Size(170, 35);
            btnVratiRacune.TabIndex = 9;
            btnVratiRacune.Text = "Vrati racune";
            btnVratiRacune.UseVisualStyleBackColor = false;
            // 
            // btnPretraziRacun
            // 
            btnPretraziRacun.BackColor = Color.FromArgb(63, 114, 175);
            btnPretraziRacun.FlatStyle = FlatStyle.Flat;
            btnPretraziRacun.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPretraziRacun.ForeColor = Color.White;
            btnPretraziRacun.Location = new Point(210, 197);
            btnPretraziRacun.Name = "btnPretraziRacun";
            btnPretraziRacun.Size = new Size(170, 35);
            btnPretraziRacun.TabIndex = 10;
            btnPretraziRacun.Text = "Pretrazi racun";
            btnPretraziRacun.UseVisualStyleBackColor = false;
            // 
            // btnPromeniRacun
            // 
            btnPromeniRacun.BackColor = Color.FromArgb(63, 114, 175);
            btnPromeniRacun.FlatStyle = FlatStyle.Flat;
            btnPromeniRacun.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPromeniRacun.ForeColor = Color.White;
            btnPromeniRacun.Location = new Point(30, 240);
            btnPromeniRacun.Name = "btnPromeniRacun";
            btnPromeniRacun.Size = new Size(350, 35);
            btnPromeniRacun.TabIndex = 11;
            btnPromeniRacun.Text = "Promeni racun";
            btnPromeniRacun.UseVisualStyleBackColor = false;
            // 
            // colIdRacun
            // 
            colIdRacun.DataPropertyName = "Id";
            colIdRacun.HeaderText = "Br.";
            colIdRacun.Name = "colIdRacun";
            colIdRacun.Width = 50;
            // 
            // colDatum
            // 
            colDatum.DataPropertyName = "DatumIzvrsenja";
            colDatum.HeaderText = "Datum";
            colDatum.Name = "colDatum";
            colDatum.Width = 110;
            // 
            // colUkupanIznos
            // 
            colUkupanIznos.DataPropertyName = "UkupanIznos";
            colUkupanIznos.HeaderText = "Iznos";
            colUkupanIznos.Name = "colUkupanIznos";
            colUkupanIznos.Width = 100;
            // 
            // colProdavac
            // 
            colProdavac.DataPropertyName = "Prodavac";
            colProdavac.HeaderText = "Prodavac";
            colProdavac.Name = "colProdavac";
            colProdavac.Width = 150;
            // 
            // colKupac
            // 
            colKupac.DataPropertyName = "Kupac";
            colKupac.HeaderText = "Kupac";
            colKupac.Name = "colKupac";
            colKupac.Width = 140;
            // 
            // dgvRacuni
            // 
            dgvRacuni.AllowUserToAddRows = false;
            dgvRacuni.AllowUserToDeleteRows = false;
            dgvRacuni.BackgroundColor = Color.White;
            dgvRacuni.BorderStyle = BorderStyle.FixedSingle;
            dgvRacuni.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRacuni.Columns.AddRange(new DataGridViewColumn[] {
                colIdRacun, colDatum, colUkupanIznos, colProdavac, colKupac });
            dgvRacuni.Location = new Point(410, 50);
            dgvRacuni.MultiSelect = false;
            dgvRacuni.Name = "dgvRacuni";
            dgvRacuni.ReadOnly = true;
            dgvRacuni.RowHeadersVisible = false;
            dgvRacuni.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRacuni.Size = new Size(560, 225);
            dgvRacuni.TabIndex = 12;
            // 
            // lblSuplementacija
            // 
            lblSuplementacija.AutoSize = true;
            lblSuplementacija.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblSuplementacija.Location = new Point(15, 30);
            lblSuplementacija.Name = "lblSuplementacija";
            lblSuplementacija.Size = new Size(120, 17);
            lblSuplementacija.TabIndex = 0;
            lblSuplementacija.Text = "Suplementacija:";
            // 
            // cmbSuplementacija
            // 
            cmbSuplementacija.Font = new Font("Segoe UI", 10F);
            cmbSuplementacija.FormattingEnabled = true;
            cmbSuplementacija.Location = new Point(145, 27);
            cmbSuplementacija.Name = "cmbSuplementacija";
            cmbSuplementacija.Size = new Size(300, 25);
            cmbSuplementacija.TabIndex = 1;
            // 
            // lblKolicina
            // 
            lblKolicina.AutoSize = true;
            lblKolicina.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblKolicina.Location = new Point(475, 30);
            lblKolicina.Name = "lblKolicina";
            lblKolicina.Size = new Size(70, 17);
            lblKolicina.TabIndex = 2;
            lblKolicina.Text = "Kolicina:";
            // 
            // txtKolicina
            // 
            txtKolicina.BorderStyle = BorderStyle.FixedSingle;
            txtKolicina.Font = new Font("Segoe UI", 10F);
            txtKolicina.Location = new Point(560, 27);
            txtKolicina.Name = "txtKolicina";
            txtKolicina.Size = new Size(120, 25);
            txtKolicina.TabIndex = 3;
            // 
            // lblCena
            // 
            lblCena.AutoSize = true;
            lblCena.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblCena.Location = new Point(15, 70);
            lblCena.Name = "lblCena";
            lblCena.Size = new Size(45, 17);
            lblCena.TabIndex = 4;
            lblCena.Text = "Cena:";
            // 
            // txtCena
            // 
            txtCena.BorderStyle = BorderStyle.FixedSingle;
            txtCena.Font = new Font("Segoe UI", 10F);
            txtCena.Location = new Point(145, 67);
            txtCena.Name = "txtCena";
            txtCena.ReadOnly = true;
            txtCena.Size = new Size(140, 25);
            txtCena.TabIndex = 5;
            // 
            // lblIznos
            // 
            lblIznos.AutoSize = true;
            lblIznos.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblIznos.Location = new Point(310, 70);
            lblIznos.Name = "lblIznos";
            lblIznos.Size = new Size(50, 17);
            lblIznos.TabIndex = 6;
            lblIznos.Text = "Iznos:";
            // 
            // txtIznos
            // 
            txtIznos.BorderStyle = BorderStyle.FixedSingle;
            txtIznos.Font = new Font("Segoe UI", 10F);
            txtIznos.Location = new Point(370, 67);
            txtIznos.Name = "txtIznos";
            txtIznos.ReadOnly = true;
            txtIznos.Size = new Size(140, 25);
            txtIznos.TabIndex = 7;
            // 
            // btnDodajStavku
            // 
            btnDodajStavku.BackColor = Color.FromArgb(63, 114, 175);
            btnDodajStavku.FlatStyle = FlatStyle.Flat;
            btnDodajStavku.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDodajStavku.ForeColor = Color.White;
            btnDodajStavku.Location = new Point(560, 62);
            btnDodajStavku.Name = "btnDodajStavku";
            btnDodajStavku.Size = new Size(160, 35);
            btnDodajStavku.TabIndex = 8;
            btnDodajStavku.Text = "Dodaj stavku";
            btnDodajStavku.UseVisualStyleBackColor = false;
            // 
            // btnUkloniStavku
            // 
            btnUkloniStavku.BackColor = Color.FromArgb(150, 150, 150);
            btnUkloniStavku.FlatStyle = FlatStyle.Flat;
            btnUkloniStavku.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUkloniStavku.ForeColor = Color.White;
            btnUkloniStavku.Location = new Point(730, 62);
            btnUkloniStavku.Name = "btnUkloniStavku";
            btnUkloniStavku.Size = new Size(160, 35);
            btnUkloniStavku.TabIndex = 9;
            btnUkloniStavku.Text = "Ukloni stavku";
            btnUkloniStavku.UseVisualStyleBackColor = false;
            // 
            // grpStavka
            // 
            grpStavka.Controls.Add(lblSuplementacija);
            grpStavka.Controls.Add(cmbSuplementacija);
            grpStavka.Controls.Add(lblKolicina);
            grpStavka.Controls.Add(txtKolicina);
            grpStavka.Controls.Add(lblCena);
            grpStavka.Controls.Add(txtCena);
            grpStavka.Controls.Add(lblIznos);
            grpStavka.Controls.Add(txtIznos);
            grpStavka.Controls.Add(btnDodajStavku);
            grpStavka.Controls.Add(btnUkloniStavku);
            grpStavka.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grpStavka.Location = new Point(30, 295);
            grpStavka.Name = "grpStavka";
            grpStavka.Size = new Size(940, 115);
            grpStavka.TabIndex = 13;
            grpStavka.TabStop = false;
            grpStavka.Text = "Stavka racuna";
            // 
            // lblStavke
            // 
            lblStavke.AutoSize = true;
            lblStavke.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic);
            lblStavke.Location = new Point(30, 425);
            lblStavke.Name = "lblStavke";
            lblStavke.Size = new Size(105, 17);
            lblStavke.TabIndex = 14;
            lblStavke.Text = "Stavke racuna";
            // 
            // colRb
            // 
            colRb.DataPropertyName = "Rb";
            colRb.HeaderText = "Rb";
            colRb.Name = "colRb";
            colRb.Width = 50;
            // 
            // colSuplementacija
            // 
            colSuplementacija.DataPropertyName = "Suplementacija";
            colSuplementacija.HeaderText = "Suplementacija";
            colSuplementacija.Name = "colSuplementacija";
            colSuplementacija.Width = 400;
            // 
            // colKolicina
            // 
            colKolicina.DataPropertyName = "Kolicina";
            colKolicina.HeaderText = "Kolicina";
            colKolicina.Name = "colKolicina";
            colKolicina.Width = 110;
            // 
            // colCena
            // 
            colCena.DataPropertyName = "Cena";
            colCena.HeaderText = "Cena";
            colCena.Name = "colCena";
            colCena.Width = 130;
            // 
            // colIznos
            // 
            colIznos.DataPropertyName = "Iznos";
            colIznos.HeaderText = "Iznos";
            colIznos.Name = "colIznos";
            colIznos.Width = 130;
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
            dgvStavke.Location = new Point(30, 450);
            dgvStavke.MultiSelect = false;
            dgvStavke.Name = "dgvStavke";
            dgvStavke.ReadOnly = true;
            dgvStavke.RowHeadersVisible = false;
            dgvStavke.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStavke.Size = new Size(940, 200);
            dgvStavke.TabIndex = 15;
            // 
            // UCPromeniRacun
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
            Controls.Add(btnVratiRacune);
            Controls.Add(btnPretraziRacun);
            Controls.Add(btnPromeniRacun);
            Controls.Add(dgvRacuni);
            Controls.Add(grpStavka);
            Controls.Add(lblStavke);
            Controls.Add(dgvStavke);
            Name = "UCPromeniRacun";
            Size = new Size(1000, 676);
            ((System.ComponentModel.ISupportInitialize)dgvRacuni).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).EndInit();
            grpStavka.ResumeLayout(false);
            grpStavka.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblNaslov;
        private Label lblKupac;
        private Label lblProdavac;
        private Label lblDatum;
        private Label lblUkupanIznos;
        private Label lblSuplementacija;
        private Label lblKolicina;
        private Label lblCena;
        private Label lblIznos;
        private Label lblStavke;
        private GroupBox grpStavka;
        public ComboBox cmbKupac;
        public ComboBox cmbProdavac;
        public ComboBox cmbSuplementacija;
        public DateTimePicker dtpDatum;
        public TextBox txtUkupanIznos;
        public TextBox txtKolicina;
        public TextBox txtCena;
        public TextBox txtIznos;
        public Button btnVratiRacune;
        public Button btnPretraziRacun;
        public Button btnPromeniRacun;
        public Button btnDodajStavku;
        public Button btnUkloniStavku;
        public DataGridView dgvRacuni;
        public DataGridView dgvStavke;
        private DataGridViewTextBoxColumn colIdRacun;
        private DataGridViewTextBoxColumn colDatum;
        private DataGridViewTextBoxColumn colUkupanIznos;
        private DataGridViewTextBoxColumn colProdavac;
        private DataGridViewTextBoxColumn colKupac;
        private DataGridViewTextBoxColumn colRb;
        private DataGridViewTextBoxColumn colSuplementacija;
        private DataGridViewTextBoxColumn colKolicina;
        private DataGridViewTextBoxColumn colCena;
        private DataGridViewTextBoxColumn colIznos;
    }
}
