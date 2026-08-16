using Common.Domain;

namespace Server.SystemOperation
{
    /// <summary>vratiListuSviGrad(Lista&lt;Grad&gt;) - veza sa SK4, SK6.</summary>
    public class VratiListuSviGradSO : SystemOperationBase
    {
        public List<Grad> Result { get; set; }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new Grad());
            Result = lista.Cast<Grad>().ToList();
        }
    }
}
