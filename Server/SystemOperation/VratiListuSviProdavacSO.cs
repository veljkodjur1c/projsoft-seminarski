using Common.Domain;

namespace Server.SystemOperation
{
    /// <summary>vratiListuSviProdavac(Lista&lt;Prodavac&gt;) - veza sa SK1, SK3.</summary>
    public class VratiListuSviProdavacSO : SystemOperationBase
    {
        public List<Prodavac> Result { get; set; }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new Prodavac());
            Result = lista.Cast<Prodavac>().ToList();
        }
    }
}
