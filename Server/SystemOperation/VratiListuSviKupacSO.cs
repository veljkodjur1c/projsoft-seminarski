using Common.Domain;

namespace Server.SystemOperation
{
    /// <summary>vratiListuSviKupac(Lista&lt;Kupac&gt;) - veza sa SK1, SK3.</summary>
    public class VratiListuSviKupacSO : SystemOperationBase
    {
        public List<Kupac> Result { get; set; }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new Kupac());
            Result = lista.Cast<Kupac>().ToList();
        }
    }
}
