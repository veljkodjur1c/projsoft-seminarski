using Common.Domain;
using Server.SystemOperation;

namespace Server
{
    /// <summary>
    /// Kontroler aplikacione logike. Za svaku sistemsku operaciju
    /// pravi odgovarajucu SO klasu, pokrece je i vraca rezultat.
    /// Implementiran je kao jedinstvenik (singleton).
    /// </summary>
    public class Controller
    {
        #region Singleton

        private static Controller instance;

        public static Controller Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Controller();
                }
                return instance;
            }
        }

        private Controller() { }

        #endregion

        // ---------- SK8 ----------
        public Prodavac PrijaviProdavac(Prodavac prodavac)
        {
            PrijaviProdavacSO so = new PrijaviProdavacSO(prodavac);
            so.ExecuteTemplate();
            return so.Result;
        }

        // ---------- Ucitavanje listi ----------
        public List<Grad> VratiListuSviGrad()
        {
            VratiListuSviGradSO so = new VratiListuSviGradSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Prodavac> VratiListuSviProdavac()
        {
            VratiListuSviProdavacSO so = new VratiListuSviProdavacSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Kupac> VratiListuSviKupac()
        {
            VratiListuSviKupacSO so = new VratiListuSviKupacSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Suplementacija> VratiListuSviSuplementacija()
        {
            VratiListuSviSuplementacijaSO so = new VratiListuSviSuplementacijaSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        // ---------- SK21 ----------
        public void UbaciKvalifikacija(Kvalifikacija kvalifikacija)
        {
            UbaciKvalifikacijaSO so = new UbaciKvalifikacijaSO(kvalifikacija);
            so.ExecuteTemplate();
        }

        // ---------- SK4, SK5, SK6, SK7 ----------
        public int KreirajKupac(Kupac kupac)
        {
            KreirajKupacSO so = new KreirajKupacSO(kupac);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Kupac PretraziKupac(Kupac kupac)
        {
            PretraziKupacSO so = new PretraziKupacSO(kupac);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Kupac> VratiListuKupac(Kupac kupac)
        {
            VratiListuKupacSO so = new VratiListuKupacSO(kupac);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void PromeniKupac(Kupac kupac)
        {
            PromeniKupacSO so = new PromeniKupacSO(kupac);
            so.ExecuteTemplate();
        }

        public void ObrisiKupac(Kupac kupac)
        {
            ObrisiKupacSO so = new ObrisiKupacSO(kupac);
            so.ExecuteTemplate();
        }

        // ---------- SK1, SK2, SK3 ----------
        public int KreirajRacun(Racun racun)
        {
            KreirajRacunSO so = new KreirajRacunSO(racun);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void PromeniRacun(Racun racun)
        {
            PromeniRacunSO so = new PromeniRacunSO(racun);
            so.ExecuteTemplate();
        }

        public void ObrisiRacun(Racun racun)
        {
            ObrisiRacunSO so = new ObrisiRacunSO(racun);
            so.ExecuteTemplate();
        }

        public Racun PretraziRacun(Racun racun)
        {
            PretraziRacunSO so = new PretraziRacunSO(racun);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Racun> VratiListuRacun(Racun racun)
        {
            VratiListuRacunSO so = new VratiListuRacunSO(racun);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<StavkaRacuna> VratiListuStavkaRacuna(StavkaRacuna stavka)
        {
            VratiListuStavkaRacunaSO so = new VratiListuStavkaRacunaSO(stavka);
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}
