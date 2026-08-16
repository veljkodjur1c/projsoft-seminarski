namespace Client.UserControls
{
    partial class UCPretraziKupac
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
            btnVratiKupce = new Button();
            btnPretraziKupca = new Button();
            dgvKupci = new DataGridView();
            colIme = new DataGridViewTextBoxColumn();
            colPrezime = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colAdresa = new DataGridViewTextBoxColumn();
            colGrad = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvKupci).BeginInit();
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNaslov.ForeColor = Color.FromArgb(34, 40, 49);
            lblNaslov.Location = new Point(40, 25);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(175, 21);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "PRETRAZI KUPCA";
            // 
            // lblIme
            // 
            lblIme.AutoSize = true;
            lblIme.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblIme.Location = new Point(40, 80);
            lblIme.Name = "lblIme";
            lblIme.Size = new Size(85, 17);
            lblIme.TabIndex = 1;
            lblIme.Text = "Ime kupca:";
            // 
            // lblPrezime
            // 
            lblPrezime.AutoSize = true;
            lblPrezime.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblPrezime.Location = new Point(40, 120);
            lblPrezime.Name = "lblPrezime";
            lblPrezime.Size = new Size(115, 17);
            lblPrezime.TabIndex = 2;
            lblPrezime.Text = "Prezime kupca:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblEmail.Location = new Point(40, 160);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(95, 17);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email kupca:";
            // 
            // lblAdresa
            // 
            lblAdresa.AutoSize = true;
            lblAdresa.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblAdresa.Location = new Point(40, 200);
            lblAdresa.Name = "lblAdresa";
            lblAdresa.Size = new Size(105, 17);
            lblAdresa.TabIndex = 4;
            lblAdresa.Text = "Adresa kupca:";
            // 
            // lblGrad
            // 
            lblGrad.AutoSize = true;
            lblGrad.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblGrad.Location = new Point(40, 240);
            lblGrad.Name = "lblGrad";
            lblGrad.Size = new Size(45, 17);
            lblGrad.TabIndex = 5;
            lblGrad.Text = "Grad:";
            // 
            // txtIme
            // 
            txtIme.BorderStyle = BorderStyle.FixedSingle;
            txtIme.Font = new Font("Segoe UI", 10F);
            txtIme.Location = new Point(175, 77);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(230, 25);
            txtIme.TabIndex = 6;
            // 
            // txtPrezime
            // 
            txtPrezime.BorderStyle = BorderStyle.FixedSingle;
            txtPrezime.Font = new Font("Segoe UI", 10F);
            txtPrezime.Location = new Point(175, 117);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(230, 25);
            txtPrezime.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(175, 157);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(230, 25);
            txtEmail.TabIndex = 8;
            // 
            // txtAdresa
            // 
            txtAdresa.BorderStyle = BorderStyle.FixedSingle;
            txtAdresa.Font = new Font("Segoe UI", 10F);
            txtAdresa.Location = new Point(175, 197);
            txtAdresa.Name = "txtAdresa";
            txtAdresa.Size = new Size(230, 25);
            txtAdresa.TabIndex = 9;
            // 
            // cmbGrad
            // 
            cmbGrad.Font = new Font("Segoe UI", 10F);
            cmbGrad.FormattingEnabled = true;
            cmbGrad.Location = new Point(175, 237);
            cmbGrad.Name = "cmbGrad";
            cmbGrad.Size = new Size(230, 25);
            cmbGrad.TabIndex = 10;
            // 
            // btnVratiKupce
            // 
            btnVratiKupce.BackColor = Color.FromArgb(63, 114, 175);
            btnVratiKupce.FlatStyle = FlatStyle.Flat;
            btnVratiKupce.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVratiKupce.ForeColor = Color.White;
            btnVratiKupce.Location = new Point(40, 300);
            btnVratiKupce.Name = "btnVratiKupce";
            btnVratiKupce.Size = new Size(170, 38);
            btnVratiKupce.TabIndex = 11;
            btnVratiKupce.Text = "Vrati kupce";
            btnVratiKupce.UseVisualStyleBackColor = false;
            // 
            // btnPretraziKupca
            // 
            btnPretraziKupca.BackColor = Color.FromArgb(63, 114, 175);
            btnPretraziKupca.FlatStyle = FlatStyle.Flat;
            btnPretraziKupca.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPretraziKupca.ForeColor = Color.White;
            btnPretraziKupca.Location = new Point(235, 300);
            btnPretraziKupca.Name = "btnPretraziKupca";
            btnPretraziKupca.Size = new Size(170, 38);
            btnPretraziKupca.TabIndex = 12;
            btnPretraziKupca.Text = "Pretrazi kupca";
            btnPretraziKupca.UseVisualStyleBackColor = false;
            // 
            // colIme
            // 
            colIme.DataPropertyName = "Ime";
            colIme.HeaderText = "Ime";
            colIme.Name = "colIme";
            colIme.Width = 110;
            // 
            // colPrezime
            // 
            colPrezime.DataPropertyName = "Prezime";
            colPrezime.HeaderText = "Prezime";
            colPrezime.Name = "colPrezime";
            colPrezime.Width = 120;
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "Email";
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            colEmail.Width = 170;
            // 
            // colAdresa
            // 
            colAdresa.DataPropertyName = "Adresa";
            colAdresa.HeaderText = "Adresa";
            colAdresa.Name = "colAdresa";
            colAdresa.Width = 150;
            // 
            // colGrad
            // 
            colGrad.DataPropertyName = "Grad";
            colGrad.HeaderText = "Grad";
            colGrad.Name = "colGrad";
            colGrad.Width = 110;
            // 
            // dgvKupci
            // 
            dgvKupci.AllowUserToAddRows = false;
            dgvKupci.AllowUserToDeleteRows = false;
            dgvKupci.BackgroundColor = Color.White;
            dgvKupci.BorderStyle = BorderStyle.FixedSingle;
            dgvKupci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKupci.Columns.AddRange(new DataGridViewColumn[] {
                colIme, colPrezime, colEmail, colAdresa, colGrad });
            dgvKupci.Location = new Point(440, 77);
            dgvKupci.MultiSelect = false;
            dgvKupci.Name = "dgvKupci";
            dgvKupci.ReadOnly = true;
            dgvKupci.RowHeadersVisible = false;
            dgvKupci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKupci.Size = new Size(420, 261);
            dgvKupci.TabIndex = 13;
            // 
            // UCPretraziKupac
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
            Controls.Add(btnVratiKupce);
            Controls.Add(btnPretraziKupca);
            Controls.Add(dgvKupci);
            Name = "UCPretraziKupac";
            Size = new Size(900, 526);
            ((System.ComponentModel.ISupportInitialize)dgvKupci).EndInit();
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
        public Button btnVratiKupce;
        public Button btnPretraziKupca;
        public DataGridView dgvKupci;
        private DataGridViewTextBoxColumn colIme;
        private DataGridViewTextBoxColumn colPrezime;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colAdresa;
        private DataGridViewTextBoxColumn colGrad;
    }
}
