using Client.UserControls;
using Common.Domain;
using System.ComponentModel;

namespace Client.GuiController
{
    /// <summary>
    /// Kontroler korisnickog interfejsa za SK1 - Kreiraj racun.
    /// </summary>
    public class RacunGuiController
    {
        private UCKreirajRacun uc;

        /// <summary>
        /// Racun koji je sistem kreirao, a jos nije sacuvan.
        /// Ako korisnik odustane, zaglavlje se brise iz baze.
        /// </summary>
        private Racun kreiraniRacun;

        private BindingList<StavkaRacuna> stavke;

        internal Control CreateKreirajRacun()
        {
            uc = new UCKreirajRacun();
            uc.btnKreirajRacun.Click += KreirajRacun;
            uc.btnSacuvajRacun.Click += SacuvajRacun;
            uc.btnOtkazi.Click += OtkaziKreiranje;
            uc.btnDodajStavku.Click += DodajStavku;
            uc.btnUkloniStavku.Click += UkloniStavku;
            uc.cmbSuplementacija.SelectedIndexChanged += (s, a) => uc.OsveziIznosStavke();
            uc.txtKolicina.TextChanged += (s, a) => uc.OsveziIznosStavke();

            kreiraniRacun = null;
            stavke = new BindingList<StavkaRacuna>();

            UcitajListe();
            return uc;
        }

        /// <summary>Preduslovi SK1 - ucitane su liste prodavaca, kupaca i suplementacije.</summary>
        private void UcitajListe()
        {
            try
            {
                uc.PopuniProdavce(Communication.Instance.VratiListuSviProdavac(),
                    LoginGuiController.Instance.PrijavljeniProdavac);
                uc.PopuniKupce(Communication.Instance.VratiListuSviKupac());
                uc.PopuniSuplementacije(Communication.Instance.VratiListuSviSuplementacija());
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da ucita potrebne liste",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Koraci 1 do 3 scenarija SK1.</summary>
        private void KreirajRacun(object sender, EventArgs e)
        {
            if (uc.cmbKupac.SelectedItem is not Kupac izabraniKupac)
            {
                MessageBox.Show("Molimo izaberite kupca",
                    "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Racun noviRacun = new Racun
            {
                Prodavac = LoginGuiController.Instance.PrijavljeniProdavac,
                Kupac = izabraniKupac,
                DatumIzvrsenja = uc.dtpDatum.Value.Date,
                UkupanIznos = 0
            };

            try
            {
                noviRacun.Id = Communication.Instance.KreirajRacun(noviRacun);
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da kreira racun",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            kreiraniRacun = noviRacun;
            stavke = new BindingList<StavkaRacuna>();
            kreiraniRacun.Stavke = stavke;

            uc.PrikaziIdRacuna(kreiraniRacun.Id);
            uc.PrikaziStavke(stavke);
            uc.PrikaziUkupanIznos(0);
            uc.PostaviStanjeUnosa();

            MessageBox.Show("Sistem je kreirao racun",
                "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Korak 4 scenarija - unos podataka o racunu kroz stavke.</summary>
        private void DodajStavku(object sender, EventArgs e)
        {
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
                IdRacun = kreiraniRacun.Id,
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

        /// <summary>Redni brojevi moraju da idu 1, 2, 3 ... i posle uklanjanja.</summary>
        private void PreracunajRedneBrojeve()
        {
            for (int i = 0; i < stavke.Count; i++)
            {
                stavke[i].Rb = i + 1;
            }
            uc.PrikaziStavke(stavke);
        }

        /// <summary>Slozeno vrednosno ogranicenje: ukupanIznos = suma iznosa stavki.</summary>
        private double IzracunajUkupanIznos()
        {
            double ukupno = 0;
            foreach (StavkaRacuna s in stavke)
            {
                ukupno += s.Iznos;
            }
            return ukupno;
        }

        /// <summary>Koraci 6 do 8 scenarija SK1.</summary>
        private void SacuvajRacun(object sender, EventArgs e)
        {
            if (kreiraniRacun == null)
            {
                MessageBox.Show("Prvo pozovite sistem da kreira racun",
                    "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (stavke.Count == 0)
            {
                MessageBox.Show("Ne mozete sacuvati prazan racun: dodajte stavke",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            kreiraniRacun.Stavke = stavke;
            kreiraniRacun.UkupanIznos = IzracunajUkupanIznos();
            kreiraniRacun.DatumIzvrsenja = uc.dtpDatum.Value.Date;

            try
            {
                Communication.Instance.PromeniRacun(kreiraniRacun);
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da zapamti racun",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Sistem je zapamtio racun broj {kreiraniRacun.Id}",
                "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Racun je sacuvan, vise nije privremen
            kreiraniRacun = null;
            stavke = new BindingList<StavkaRacuna>();
            uc.PostaviPocetnoStanje();
        }

        private void OtkaziKreiranje(object sender, EventArgs e)
        {
            ObrisiNesacuvanRacun();
            stavke = new BindingList<StavkaRacuna>();
            uc.PostaviPocetnoStanje();
        }

        /// <summary>
        /// Uklanja zaglavlje racuna ako korisnik nije sacuvao racun.
        /// </summary>
        internal void HandleClose()
        {
            ObrisiNesacuvanRacun();
        }

        private void ObrisiNesacuvanRacun()
        {
            if (kreiraniRacun == null)
            {
                return;
            }

            try
            {
                Communication.Instance.ObrisiRacun(kreiraniRacun);
            }
            catch (Exception)
            {
                // Ako brisanje ne uspe, korisnika ne treba uznemiravati.
            }
            finally
            {
                kreiraniRacun = null;
            }
        }
    }
}
