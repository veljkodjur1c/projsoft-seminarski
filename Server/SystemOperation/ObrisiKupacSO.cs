using Common.Domain;

namespace Server.SystemOperation
{
    /// <summary>UG5: ObrisiKupac(Kupac) - veza sa SK7.</summary>
    public class ObrisiKupacSO : SystemOperationBase
    {
        private readonly Kupac kupac;

        public ObrisiKupacSO(Kupac kupac)
        {
            this.kupac = kupac;
        }

        protected override void ExecuteConcreteOperation()
        {
            kupac.DeleteCondition = $"WHERE idKupac = {kupac.Id}";
            broker.DeleteEntity(kupac);
        }
    }
}
