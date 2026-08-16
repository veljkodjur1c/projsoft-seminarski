using Common.Domain;

namespace Server.SystemOperation
{
    /// <summary>
    /// UG7: vratiListuRacun(kriterijum, Lista&lt;Racun&gt;) - veza sa SK2, SK3.
    /// </summary>
    public class VratiListuRacunSO : SystemOperationBase
    {
        private readonly Racun racun;
        public List<Racun> Result { get; set; }

        public VratiListuRacunSO(Racun racun)
        {
            this.racun = racun;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetByCondition(racun);

            if (lista.Count == 0)
            {
                throw new Exception("Sistem ne moze da nadje racune po zadatim kriterijumima");
            }

            Result = lista.Cast<Racun>().ToList();
        }
    }
}
