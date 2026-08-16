using DBBroker;

namespace Server.SystemOperation
{
    /// <summary>
    /// Sablonski metod za izvrsenje sistemske operacije.
    /// Nadklasa drzi kostur (konekcija, transakcija, commit ili rollback),
    /// a podklase popunjavaju samo konkretan posao nad bazom.
    /// </summary>
    public abstract class SystemOperationBase
    {
        protected Broker broker;

        protected SystemOperationBase()
        {
            broker = new Broker();
        }

        public void ExecuteTemplate()
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();
                ExecuteConcreteOperation();
                broker.Commit();
            }
            catch (Exception)
            {
                broker.RollBack();
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        protected abstract void ExecuteConcreteOperation();
    }
}
