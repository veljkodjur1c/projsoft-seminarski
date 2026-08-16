namespace Client.UserControls
{
    partial class UCPretraziRacun
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
            lblSuplementacija = new Label();
            cmbKupac = new ComboBox();
            cmbProdavac = new ComboBox();
            dtpDatum = new DateTimePicker();
            txtUkupanIznos = new TextBox();
            cmbSuplementacija = new ComboBox();
            btnVratiRacune = new Button();
            btnPretraziRacun = new Button();
            lblStavke = new Label();
            dgvRacuni = new DataGridView();
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
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNaslov.ForeColor = Color.FromArgb(34, 40, 49);
            lblNaslov.Location = new Point(30, 20);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(180, 21);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "PRETRAZI RACUN";
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
            // lblSuplementacija
            // 
            lblSuplementacija.AutoSize = true;
            lblSuplementacija.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblSuplementacija.Location = new Point(30, 225);
            lblSuplementacija.Name = "lblSuplementacija";
            lblSuplementacija.Size = new Size(120, 17);
            lblSuplementacija.TabIndex = 5;
            lblSuplementacija.Text = "Suplementacija:";
            // 
            // cmbKupac
            // 
            cmbKupac.Font = new Font("Segoe UI", 10F);
            cmbKupac.FormattingEnabled = true;
            cmbKupac.Location = new Point(175, 62);
            cmbKupac.Name = "cmbKupac";
            cmbKupac.Size = new Size(230, 25);
            cmbKupac.TabIndex = 6;
            // 
            // cmbProdavac
            // 
            cmbProdavac.Font = new Font("Segoe UI", 10F);
            cmbProdavac.FormattingEnabled = true;
            cmbProdavac.Location = new Point(175, 102);
            cmbProdavac.Name = "cmbProdavac";
            cmbProdavac.Size = new Size(230, 25);
            cmbProdavac.TabIndex = 7;
            // 
            // dtpDatum
            // 
            dtpDatum.Checked = false;
            dtpDatum.Font = new Font("Segoe UI", 10F);
            dtpDatum.Format = DateTimePickerFormat.Short;
            dtpDatum.Location = new Point(175, 142);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.ShowCheckBox = true;
            dtpDatum.Size = new Size(230, 25);
            dtpDatum.TabIndex = 8;
            // 
            // txtUkupanIznos
            // 
            txtUkupanIznos.BorderStyle = BorderStyle.FixedSingle;
            txtUkupanIznos.Font = new Font("Segoe UI", 10F);
            txtUkupanIznos.Location = new Point(175, 182);
            txtUkupanIznos.Name = "txtUkupanIznos";
            txtUkupanIznos.Size = new Size(230, 25);
            txtUkupanIznos.TabIndex = 9;
            // 
            // cmbSuplementacija
            // 
            cmbSuplementacija.Font = new Font("Segoe UI", 10F);
            cmbSuplementacija.FormattingEnabled = true;
            cmbSuplementacija.Location = new Point(175, 222);
            cmbSuplementacija.Name = "cmbSuplementacija";
            cmbSuplementacija.Size = new Size(230, 25);
            cmbSuplementacija.TabIndex = 10;
            // 
            // btnVratiRacune
            // 
            btnVratiRacune.BackColor = Color.FromArgb(63, 114, 175);
            btnVratiRacune.FlatStyle = FlatStyle.Flat;
            btnVratiRacune.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVratiRacune.ForeColor = Color.White;
            btnVratiRacune.Location = new Point(30, 270);
            btnVratiRacune.Name = "btnVratiRacune";
            btnVratiRacune.Size = new Size(180, 38);
            btnVratiRacune.TabIndex = 11;
            btnVratiRacune.Text = "Vrati racune";
            btnVratiRacune.UseVisualStyleBackColor = false;
            // 
            // btnPretraziRacun
            // 
            btnPretraziRacun.BackColor = Color.FromArgb(63, 114, 175);
            btnPretraziRacun.FlatStyle = FlatStyle.Flat;
            btnPretraziRacun.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPretraziRacun.ForeColor = Color.White;
            btnPretraziRacun.Location = new Point(225, 270);
            btnPretraziRacun.Name = "btnPretraziRacun";
            btnPretraziRacun.Size = new Size(180, 38);
            btnPretraziRacun.TabIndex = 12;
            btnPretraziRacun.Text = "Pretrazi racun";
            btnPretraziRacun.UseVisualStyleBackColor = false;
            // 
            // colIdRacun
            // 
            colIdRacun.DataPropertyName = "Id";
            colIdRacun.HeaderText = "Br.";
            colIdRacun.Name = "colIdRacun";
            colIdRacun.Width = 45;
            // 
            // colDatum
            // 
            colDatum.DataPropertyName = "DatumIzvrsenja";
            colDatum.HeaderText = "Datum";
            colDatum.Name = "colDatum";
            colDatum.Width = 100;
            // 
            // colUkupanIznos
            // 
            colUkupanIznos.DataPropertyName = "UkupanIznos";
            colUkupanIznos.HeaderText = "Iznos";
            colUkupanIznos.Name = "colUkupanIznos";
            colUkupanIznos.Width = 90;
            // 
            // colProdavac
            // 
            colProdavac.DataPropertyName = "Prodavac";
            colProdavac.HeaderText = "Prodavac";
            colProdavac.Name = "colProdavac";
            colProdavac.Width = 130;
            // 
            // colKupac
            // 
            colKupac.DataPropertyName = "Kupac";
            colKupac.HeaderText = "Kupac";
            colKupac.Name = "colKupac";
            colKupac.Width = 90;
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
            dgvRacuni.Location = new Point(440, 62);
            dgvRacuni.MultiSelect = false;
            dgvRacuni.Name = "dgvRacuni";
            dgvRacuni.ReadOnly = true;
            dgvRacuni.RowHeadersVisible = false;
            dgvRacuni.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRacuni.Size = new Size(420, 246);
            dgvRacuni.TabIndex = 13;
            // 
            // lblStavke
            // 
            lblStavke.AutoSize = true;
            lblStavke.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic);
            lblStavke.Location = new Point(30, 325);
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
            dgvStavke.Location = new Point(30, 350);
            dgvStavke.MultiSelect = false;
            dgvStavke.Name = "dgvStavke";
            dgvStavke.ReadOnly = true;
            dgvStavke.RowHeadersVisible = false;
            dgvStavke.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStavke.Size = new Size(830, 155);
            dgvStavke.TabIndex = 15;
            // 
            // UCPretraziRacun
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 238, 238);
            Controls.Add(lblNaslov);
            Controls.Add(lblKupac);
            Controls.Add(lblProdavac);
            Controls.Add(lblDatum);
            Controls.Add(lblUkupanIznos);
            Controls.Add(lblSuplementacija);
            Controls.Add(cmbKupac);
            Controls.Add(cmbProdavac);
            Controls.Add(dtpDatum);
            Controls.Add(txtUkupanIznos);
            Controls.Add(cmbSuplementacija);
            Controls.Add(btnVratiRacune);
            Controls.Add(btnPretraziRacun);
            Controls.Add(dgvRacuni);
            Controls.Add(lblStavke);
            Controls.Add(dgvStavke);
            Name = "UCPretraziRacun";
            Size = new Size(900, 526);
            ((System.ComponentModel.ISupportInitialize)dgvRacuni).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblNaslov;
        private Label lblKupac;
        private Label lblProdavac;
        private Label lblDatum;
        private Label lblUkupanIznos;
        private Label lblSuplementacija;
        private Label lblStavke;
        public ComboBox cmbKupac;
        public ComboBox cmbProdavac;
        public ComboBox cmbSuplementacija;
        public DateTimePicker dtpDatum;
        public TextBox txtUkupanIznos;
        public Button btnVratiRacune;
        public Button btnPretraziRacun;
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
