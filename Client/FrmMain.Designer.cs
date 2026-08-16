namespace Client
{
    partial class FrmMain
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
            menuStrip = new MenuStrip();
            menuDokumenti = new ToolStripMenuItem();
            menuRacun = new ToolStripMenuItem();
            itemKreirajRacun = new ToolStripMenuItem();
            itemPretraziRacun = new ToolStripMenuItem();
            itemPromeniRacun = new ToolStripMenuItem();
            menuPrimalacUsluge = new ToolStripMenuItem();
            menuKupac = new ToolStripMenuItem();
            itemKreirajKupac = new ToolStripMenuItem();
            itemPretraziKupac = new ToolStripMenuItem();
            itemPromeniKupac = new ToolStripMenuItem();
            itemObrisiKupac = new ToolStripMenuItem();
            menuSifarnici = new ToolStripMenuItem();
            menuKvalifikacija = new ToolStripMenuItem();
            itemUbaciKvalifikaciju = new ToolStripMenuItem();
            itemOProgramu = new ToolStripMenuItem();
            pnlMain = new Panel();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] {
                menuDokumenti, menuPrimalacUsluge, menuSifarnici, itemOProgramu });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1000, 24);
            menuStrip.TabIndex = 0;
            // 
            // menuDokumenti
            // 
            menuDokumenti.DropDownItems.AddRange(new ToolStripItem[] { menuRacun });
            menuDokumenti.Name = "menuDokumenti";
            menuDokumenti.Size = new Size(80, 20);
            menuDokumenti.Text = "Dokumenti";
            // 
            // menuRacun
            // 
            menuRacun.DropDownItems.AddRange(new ToolStripItem[] {
                itemKreirajRacun, itemPretraziRacun, itemPromeniRacun });
            menuRacun.Name = "menuRacun";
            menuRacun.Size = new Size(180, 22);
            menuRacun.Text = "Racun";
            // 
            // itemKreirajRacun
            // 
            itemKreirajRacun.Name = "itemKreirajRacun";
            itemKreirajRacun.Size = new Size(180, 22);
            itemKreirajRacun.Text = "Kreiraj racun";
            // 
            // itemPretraziRacun
            // 
            itemPretraziRacun.Name = "itemPretraziRacun";
            itemPretraziRacun.Size = new Size(180, 22);
            itemPretraziRacun.Text = "Pretrazi racun";
            // 
            // itemPromeniRacun
            // 
            itemPromeniRacun.Name = "itemPromeniRacun";
            itemPromeniRacun.Size = new Size(180, 22);
            itemPromeniRacun.Text = "Promeni racun";
            // 
            // menuPrimalacUsluge
            // 
            menuPrimalacUsluge.DropDownItems.AddRange(new ToolStripItem[] { menuKupac });
            menuPrimalacUsluge.Name = "menuPrimalacUsluge";
            menuPrimalacUsluge.Size = new Size(110, 20);
            menuPrimalacUsluge.Text = "Primalac usluge";
            // 
            // menuKupac
            // 
            menuKupac.DropDownItems.AddRange(new ToolStripItem[] {
                itemKreirajKupac, itemPretraziKupac, itemPromeniKupac, itemObrisiKupac });
            menuKupac.Name = "menuKupac";
            menuKupac.Size = new Size(180, 22);
            menuKupac.Text = "Kupac";
            // 
            // itemKreirajKupac
            // 
            itemKreirajKupac.Name = "itemKreirajKupac";
            itemKreirajKupac.Size = new Size(180, 22);
            itemKreirajKupac.Text = "Kreiraj kupca";
            // 
            // itemPretraziKupac
            // 
            itemPretraziKupac.Name = "itemPretraziKupac";
            itemPretraziKupac.Size = new Size(180, 22);
            itemPretraziKupac.Text = "Pretrazi kupca";
            // 
            // itemPromeniKupac
            // 
            itemPromeniKupac.Name = "itemPromeniKupac";
            itemPromeniKupac.Size = new Size(180, 22);
            itemPromeniKupac.Text = "Promeni kupca";
            // 
            // itemObrisiKupac
            // 
            itemObrisiKupac.Name = "itemObrisiKupac";
            itemObrisiKupac.Size = new Size(180, 22);
            itemObrisiKupac.Text = "Obrisi kupca";
            // 
            // menuSifarnici
            // 
            menuSifarnici.DropDownItems.AddRange(new ToolStripItem[] { menuKvalifikacija });
            menuSifarnici.Name = "menuSifarnici";
            menuSifarnici.Size = new Size(70, 20);
            menuSifarnici.Text = "Sifarnici";
            // 
            // menuKvalifikacija
            // 
            menuKvalifikacija.DropDownItems.AddRange(new ToolStripItem[] { itemUbaciKvalifikaciju });
            menuKvalifikacija.Name = "menuKvalifikacija";
            menuKvalifikacija.Size = new Size(180, 22);
            menuKvalifikacija.Text = "Kvalifikacija";
            // 
            // itemUbaciKvalifikaciju
            // 
            itemUbaciKvalifikaciju.Name = "itemUbaciKvalifikaciju";
            itemUbaciKvalifikaciju.Size = new Size(180, 22);
            itemUbaciKvalifikaciju.Text = "Ubaci kvalifikaciju";
            // 
            // itemOProgramu
            // 
            itemOProgramu.Name = "itemOProgramu";
            itemOProgramu.Size = new Size(85, 20);
            itemOProgramu.Text = "O programu";
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(238, 238, 238);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 24);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1000, 676);
            pnlMain.TabIndex = 1;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 700);
            Controls.Add(pnlMain);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pocetni ekran";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private MenuStrip menuStrip;
        private ToolStripMenuItem menuDokumenti;
        private ToolStripMenuItem menuRacun;
        private ToolStripMenuItem itemKreirajRacun;
        private ToolStripMenuItem itemPretraziRacun;
        private ToolStripMenuItem itemPromeniRacun;
        private ToolStripMenuItem menuPrimalacUsluge;
        private ToolStripMenuItem menuKupac;
        private ToolStripMenuItem itemKreirajKupac;
        private ToolStripMenuItem itemPretraziKupac;
        private ToolStripMenuItem itemPromeniKupac;
        private ToolStripMenuItem itemObrisiKupac;
        private ToolStripMenuItem menuSifarnici;
        private ToolStripMenuItem menuKvalifikacija;
        private ToolStripMenuItem itemUbaciKvalifikaciju;
        private ToolStripMenuItem itemOProgramu;
        private Panel pnlMain;
    }
}
