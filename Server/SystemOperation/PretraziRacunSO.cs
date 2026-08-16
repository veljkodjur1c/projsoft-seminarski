using Common.Domain;
using System.ComponentModel;

namespace Server.SystemOperation
{
    /// <summary>
    /// PretraziRacun(Racun) - veza sa SK2, SK3.
    /// Vraca izabrani racun zajedno sa njegovim stavkama.
    /// </summary>
    public class PretraziRacunSO : SystemOperationBase
    {
        private readonly Racun racun;
        public Racun Result { get; set; }

        public PretraziRacunSO(Racun racun)
        {
            this.racun = racun;
        }

        protected override void ExecuteConcreteOperation()
        {
            racun.SelectCondition = $"WHERE r.idRacun = {racun.Id}";

            List<IEntity> pronadjeni = broker.GetByCondition(racun);

            if (pronadjeni.Count == 0)
            {
                throw new Exception("Sistem ne moze da nadje racun");
            }

            Racun nadjen = (Racun)pronadjeni[0];

            // Ucitavanje stavki pronadjenog racuna
            StavkaRacuna kriterijum = new StavkaRacuna
            {
                SelectCondition = $"WHERE sr.idRacun = {nadjen.Id} ORDER BY sr.rb"
            };

            List<IEntity> stavke = broker.GetByCondition(kriterijum);
            nadjen.Stavke = new BindingList<StavkaRacuna>(stavke.Cast<StavkaRacuna>().ToList());

            Result = nadjen;
        }
    }
}
