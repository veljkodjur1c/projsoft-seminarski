using Client.UserControls;
using Common.Domain;
using System.ComponentModel;
using System.Globalization;

namespace Client.GuiController
{
    /// <summary>
    /// Kontroler korisnickog interfejsa za SK3 - Promeni racun.
    /// </summary>
    public class PromeniRacunGuiController
    {
        private UCPromeniRacun uc;

        /// <summary>Racun koji je pronadjen i koji se menja.</summary>
        private Racun pronadjeniRacun;

        private BindingList<StavkaRacuna> stavke;

        internal Control CreatePromeniRacun()
        {
            uc = new UCPromeniRacun();
            uc.btnVratiRacune.Click += VratiRacune;
            uc.btnPretraziRacun.Click += PretraziRacun;
            uc.btnPromeniRacun.Click += PromeniRacun;
            uc.btnDodajStavku.Click += DodajStavku;
            uc.btnUkloniStavku.Click += UkloniStavku;
            uc.cmbSuplementacija.SelectedIndexChanged += (s, a) => uc.OsveziIznosStavke();
            uc.txtKolicina.TextChanged += (s, a) => uc.OsveziIznosStavke();

            pronadjeniRacun = null;
            stavke = new BindingList<StavkaRacuna>();

            UcitajListe();
            return uc;
        }

        /// <summary>Preduslovi SK3 - ucitane su liste prodavaca, kupaca i suplementacije.</summary>
        private void UcitajListe()
        {
            try
            {
                uc.PopuniProdavce(Communication.Instance.VratiListuSviProdavac());
                uc.PopuniKupce(Communication.Instance.VratiListuSviKupac());
                uc.PopuniSuplementacije(Communication.Instance.VratiListuSviSuplementacija());
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da ucita potrebne liste",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SastaviUslov()
        {
            List<string> uslovi = new List<string>();

            if (uc.cmbKupac.SelectedItem is Kupac izabraniKupac)
            {
                uslovi.Add($"r.idKupac = {izabraniKupac.Id}");
            }

            if (uc.cmbProdavac.SelectedItem is Prodavac izabraniProdavac)
            {
                uslovi.Add($"r.idProdavac = {izabraniProdavac.Id}");
            }

            if (uc.dtpDatum.Checked)
            {
                uslovi.Add($"r.datumIzvrsenja = '{uc.dtpDatum.Value:yyyy-MM-dd}'");
            }

            if (uslovi.Count == 0)
            {
                return string.Empty;
            }

            return "WHERE " + string.Join(" AND ", uslovi);
        }

        /// <summary>Koraci 1 do 4 scenarija SK3.</summary>
        private void VratiRacune(object sender, EventArgs e)
        {
            pronadjeniRacun = null;
            stavke = new BindingList<StavkaRacuna>();
            uc.PrikaziStavke(stavke);
            uc.PostaviStanjePretrage();

            Racun kriterijum = new Racun
            {
                SelectCondition = SastaviUslov()
            };

            List<Racun> racuni;

            try
            {
                racuni = Communication.Instance.VratiListuRacun(kriterijum);
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da nadje racune po zadatom kriterijumu",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                uc.PrikaziRacune(new List<Racun>());
                return;
            }

            uc.PrikaziRacune(racuni);

            MessageBox.Show("Sistem je nasao racune po zadatim kriterijumima",
                "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Koraci 5 do 8 scenarija SK3.</summary>
        private void PretraziRacun(object sender, EventArgs e)
        {
            Racun izabrani = uc.VratiIzabraniRacun();

            if (izabrani == null)
            {
                MessageBox.Show("Molimo izaberite racun iz tabele",
                    "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                pronadjeniRacun = Communication.Instance.PretraziRacun(new Racun { Id = izabrani.Id });
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da nadje racun",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            stavke = pronadjeniRacun.Stavke ?? new BindingList<StavkaRacuna>();
            pronadjeniRacun.Stavke = stavke;

            uc.PrikaziRacun(pronadjeniRacun);
            uc.PrikaziStavke(stavke);
            uc.PostaviStanjeIzmene();

            MessageBox.Show("Sistem je nasao racun",
                "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Korak 9 scenarija - izmena stavki racuna.</summary>
        private void DodajStavku(object sender, EventArgs e)
        {
            if (pronadjeniRacun == null)
            {
                MessageBox.Show("Prvo pronadjite racun koji zelite da promenite",
                    "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!uc.ValidacijaStavke())
            {
                MessageBox.Show("Izaberite suplementaciju i unesite kolicinu vecu od nule",
                    "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Suplementacija izabrana = (Suplementacija)uc.cmbSuplementacija.SelectedItem;
            int kolicina = int.Parse(uc.txtKolicina.Text);

            StavkaRacuna stavka = new StavkaRacuna
            {
                IdRacun = pronadjeniRacun.Id,
                Rb = stavke.Count + 1,
                Suplementacija = izabrana,
                Kolicina = kolicina,
                Cena = izabrana.Cena,
                Iznos = izabrana.Cena * kolicina
            };

            stavke.Add(stavka);

            PreracunajRedneBrojeve();
            uc.PrikaziUkupanIznos(IzracunajUkupanIznos());
            uc.OcistiPoljaStavke();
        }

        private void UkloniStavku(object sender, EventArgs e)
        {
            StavkaRacuna izabrana = uc.VratiIzabranuStavku();

            if (izabrana == null)
            {
                MessageBox.Show("Molimo izaberite stavku koju zelite da uklonite",
                    "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            stavke.Remove(izabrana);

            PreracunajRedneBrojeve();
            uc.PrikaziUkupanIznos(IzracunajUkupanIznos());
        }

        private void PreracunajRedneBrojeve()
        {
            for (int i = 0; i < stavke.Count; i++)
            {
                stavke[i].Rb = i + 1;
            }
            uc.PrikaziStavke(stavke);
        }

        private double IzracunajUkupanIznos()
        {
            double ukupno = 0;
            foreach (StavkaRacuna s in stavke)
            {
                ukupno += s.Iznos;
            }
            return ukupno;
        }

        /// <summary>Koraci 10 do 13 scenarija SK3.</summary>
        private void PromeniRacun(object sender, EventArgs e)
        {
            if (pronadjeniRacun == null)
            {
                MessageBox.Show("Prvo pronadjite racun koji zelite da promenite",
                    "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (stavke.Count == 0)
            {
                MessageBox.Show("Ne mozete sacuvati prazan racun: dodajte stavke",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (uc.cmbKupac.SelectedItem is not Kupac izabraniKupac)
            {
                MessageBox.Show("Molimo izaberite kupca",
                    "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            pronadjeniRacun.Kupac = izabraniKupac;
            pronadjeniRacun.Stavke = stavke;
            pronadjeniRacun.UkupanIznos = IzracunajUkupanIznos();

            if (uc.dtpDatum.Checked)
            {
                pronadjeniRacun.DatumIzvrsenja = uc.dtpDatum.Value.Date;
            }

            try
            {
                Communication.Instance.PromeniRacun(pronadjeniRacun);
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da zapamti racun",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Sistem je zapamtio racun broj {pronadjeniRacun.Id}",
                "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OsveziTabelu();
        }

        private void OsveziTabelu()
        {
            try
            {
                Racun kriterijum = new Racun { SelectCondition = SastaviUslov() };
                uc.PrikaziRacune(Communication.Instance.VratiListuRacun(kriterijum));
            }
            catch (Exception)
            {
                uc.PrikaziRacune(new List<Racun>());
            }
        }

        internal void HandleClose()
        {
            // Ovaj slucaj koriscenja ne pravi privremene slogove u bazi.
        }
    }
}
