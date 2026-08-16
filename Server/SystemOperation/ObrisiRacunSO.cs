using Common.Domain;

namespace Server.SystemOperation
{
    /// <summary>
    /// ObrisiRacun(Racun).
    /// Koristi se kada korisnik odustane od kreiranja racuna,
    /// da u bazi ne bi ostalo prazno zaglavlje.
    /// </summary>
    public class ObrisiRacunSO : SystemOperationBase
    {
        private readonly Racun racun;

        public ObrisiRacunSO(Racun racun)
        {
            this.racun = racun;
        }

        protected override void ExecuteConcreteOperation()
        {
            StavkaRacuna stavke = new StavkaRacuna
            {
                DeleteCondition = $"WHERE idRacun = {racun.Id}"
            };
            broker.DeleteEntity(stavke);

            racun.DeleteCondition = $"WHERE idRacun = {racun.Id}";
            broker.DeleteEntity(racun);
        }
    }
}
