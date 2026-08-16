using Common.Domain;

namespace Server.SystemOperation
{
    /// <summary>UG3: UbaciKvalifikacija(Kvalifikacija) - veza sa SK21.</summary>
    public class UbaciKvalifikacijaSO : SystemOperationBase
    {
        private readonly Kvalifikacija kvalifikacija;

        public UbaciKvalifikacijaSO(Kvalifikacija kvalifikacija)
        {
            this.kvalifikacija = kvalifikacija;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(kvalifikacija);
        }
    }
}
