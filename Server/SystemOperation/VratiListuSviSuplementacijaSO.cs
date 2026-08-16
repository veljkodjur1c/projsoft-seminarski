using Common.Domain;

namespace Server.SystemOperation
{
    /// <summary>vratiListuSviSuplementacija(Lista&lt;Suplementacija&gt;) - veza sa SK1, SK3.</summary>
    public class VratiListuSviSuplementacijaSO : SystemOperationBase
    {
        public List<Suplementacija> Result { get; set; }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new Suplementacija());
            Result = lista.Cast<Suplementacija>().ToList();
        }
    }
}
