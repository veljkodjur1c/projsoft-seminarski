using Common.Domain;

namespace Server.SystemOperation
{
    /// <summary>PretraziKupac(Kupac) - veza sa SK5.</summary>
    public class PretraziKupacSO : SystemOperationBase
    {
        private readonly Kupac kupac;
        public Kupac Result { get; set; }

        public PretraziKupacSO(Kupac kupac)
        {
            this.kupac = kupac;
        }

        protected override void ExecuteConcreteOperation()
        {
            kupac.SelectCondition = $"WHERE k.idKupac = {kupac.Id}";

            List<IEntity> pronadjeni = broker.GetByCondition(kupac);

            if (pronadjeni.Count == 0)
            {
                throw new Exception("Sistem ne moze da nadje kupca");
            }

            Result = (Kupac)pronadjeni[0];
        }
    }
}
