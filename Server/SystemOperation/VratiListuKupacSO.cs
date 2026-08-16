using Common.Domain;

namespace Server.SystemOperation
{
    /// <summary>
    /// vratiListuKupac(kriterijum, Lista&lt;Kupac&gt;) - veza sa SK5, SK6, SK7.
    /// Uslov pretrage sastavlja kontroler korisnickog interfejsa.
    /// </summary>
    public class VratiListuKupacSO : SystemOperationBase
    {
        private readonly Kupac kupac;
        public List<Kupac> Result { get; set; }

        public VratiListuKupacSO(Kupac kupac)
        {
            this.kupac = kupac;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetByCondition(kupac);

            if (lista.Count == 0)
            {
                throw new Exception("Sistem ne moze da nadje kupce po zadatim kriterijumima");
            }

            Result = lista.Cast<Kupac>().ToList();
        }
    }
}
