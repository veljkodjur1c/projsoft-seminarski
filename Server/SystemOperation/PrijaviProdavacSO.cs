using Common.Domain;

namespace Server.SystemOperation
{
    /// <summary>UG1: PrijaviProdavac(korisnickoIme, sifra) - veza sa SK8.</summary>
    public class PrijaviProdavacSO : SystemOperationBase
    {
        private readonly Prodavac prodavac;
        public Prodavac Result { get; set; }

        public PrijaviProdavacSO(Prodavac prodavac)
        {
            this.prodavac = prodavac;
        }

        protected override void ExecuteConcreteOperation()
        {
            prodavac.SelectCondition =
                $"WHERE korisnickoIme = '{prodavac.KorisnickoIme}' AND sifra = '{prodavac.Sifra}'";

            List<IEntity> pronadjeni = broker.GetByCondition(prodavac);

            if (pronadjeni.Count == 0)
            {
                throw new Exception("Korisnicko ime i sifra nisu ispravni");
            }

            Result = (Prodavac)pronadjeni[0];
        }
    }
}
