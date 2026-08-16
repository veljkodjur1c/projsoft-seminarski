using Common.Domain;

namespace Server.SystemOperation
{
    /// <summary>UG4: PromeniKupac(Kupac) - veza sa SK4, SK6.</summary>
    public class PromeniKupacSO : SystemOperationBase
    {
        private readonly Kupac kupac;

        public PromeniKupacSO(Kupac kupac)
        {
            this.kupac = kupac;
        }

        protected override void ExecuteConcreteOperation()
        {
            kupac.UpdateCondition = $"WHERE idKupac = {kupac.Id}";
            broker.UpdateByCondition(kupac);
        }
    }
}
