using Common.Domain;
using System.Globalization;

namespace Server.SystemOperation
{
    /// <summary>
    /// UG2: KreirajRacun(Racun) - veza sa SK1.
    /// Upisuje zaglavlje racuna sa ukupnim iznosom nula i vraca
    /// dodeljeni identifikator, da bi stavke mogle da se vezu za racun.
    /// </summary>
    public class KreirajRacunSO : SystemOperationBase
    {
        private readonly Racun racun;
        public int Result { get; set; }

        public KreirajRacunSO(Racun racun)
        {
            this.racun = racun;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (racun.Prodavac == null || racun.Kupac == null)
            {
                throw new Exception("Sistem ne moze da kreira racun");
            }

            racun.InsertCondition =
                $"OUTPUT inserted.idRacun VALUES (0, " +
                $"'{racun.DatumIzvrsenja:yyyy-MM-dd}', {racun.Prodavac.Id}, {racun.Kupac.Id})";

            Result = broker.Create(racun);

            if (Result <= 0)
            {
                throw new Exception("Sistem ne moze da kreira racun");
            }
        }
    }
}
