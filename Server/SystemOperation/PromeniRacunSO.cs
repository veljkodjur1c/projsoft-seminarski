using Common.Domain;

namespace Server.SystemOperation
{
    /// <summary>
    /// UG9: PromeniRacun(Racun) - veza sa SK1, SK3.
    /// Brise postojece stavke, upisuje nove i azurira zaglavlje racuna.
    /// Sve tri radnje su u jednoj transakciji.
    /// </summary>
    public class PromeniRacunSO : SystemOperationBase
    {
        private readonly Racun racun;

        public PromeniRacunSO(Racun racun)
        {
            this.racun = racun;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (racun.Stavke == null || racun.Stavke.Count == 0)
            {
                throw new Exception("Ne mozete sacuvati prazan racun: dodajte stavke");
            }

            // 1. Brisanje starih stavki racuna
            StavkaRacuna zaBrisanje = new StavkaRacuna
            {
                DeleteCondition = $"WHERE idRacun = {racun.Id}"
            };
            broker.DeleteEntity(zaBrisanje);

            // 2. Upis novih stavki sa redosledom 1, 2, 3 ...
            int redniBroj = 1;
            double ukupno = 0;

            foreach (StavkaRacuna stavka in racun.Stavke)
            {
                stavka.IdRacun = racun.Id;
                stavka.Rb = redniBroj++;
                stavka.Iznos = stavka.Cena * stavka.Kolicina;
                ukupno += stavka.Iznos;

                broker.Add(stavka);
            }

            // 3. Azuriranje zaglavlja - ukupan iznos je zbir iznosa stavki
            racun.UkupanIznos = ukupno;
            racun.UpdateCondition = $"WHERE idRacun = {racun.Id}";
            broker.UpdateByCondition(racun);
        }
    }
}
