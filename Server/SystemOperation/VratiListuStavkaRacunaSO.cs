using Common.Domain;

namespace Server.SystemOperation
{
    /// <summary>
    /// vratiListuStavkaRacuna(kriterijum, Lista&lt;StavkaRacuna&gt;) - veza sa SK2, SK3.
    /// </summary>
    public class VratiListuStavkaRacunaSO : SystemOperationBase
    {
        private readonly StavkaRacuna stavka;
        public List<StavkaRacuna> Result { get; set; }

        public VratiListuStavkaRacunaSO(StavkaRacuna stavka)
        {
            this.stavka = stavka;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetByCondition(stavka);

            if (lista.Count == 0)
            {
                throw new Exception("Sistem ne moze da nadje stavke po zadatim kriterijumima");
            }

            Result = lista.Cast<StavkaRacuna>().ToList();
        }
    }
}
