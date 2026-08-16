using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Diagnostics;

namespace DBBroker
{
    /// <summary>
    /// Upravlja konekcijom ka bazi podataka i transakcijama.
    /// Konekcioni string se cita iz App.config serverske aplikacije.
    /// </summary>
    public class DbConnection
    {
        private const string PodrazumevaniString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SuplementiDB;" +
            @"Integrated Security=True;TrustServerCertificate=True";

        private readonly SqlConnection connection;
        private SqlTransaction transaction;

        public DbConnection()
        {
            connection = new SqlConnection(UcitajKonekcioniString());
        }

        private static string UcitajKonekcioniString()
        {
            var podesavanje = ConfigurationManager.ConnectionStrings["SuplementiDB"];

            if (podesavanje != null && !string.IsNullOrWhiteSpace(podesavanje.ConnectionString))
            {
                return podesavanje.ConnectionString;
            }

            Debug.WriteLine("App.config nije pronadjen - koristi se podrazumevani konekcioni string.");
            return PodrazumevaniString;
        }

        public void OpenConnection()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                Debug.WriteLine($"Konekcija otvorena na bazu: {connection.Database}");
            }
        }

        public void CloseConnection()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
                Debug.WriteLine("Konekcija zatvorena.");
            }
        }

        public void BeginTransaction()
        {
            OpenConnection();

            if (transaction != null)
            {
                return;
            }

            transaction = connection.BeginTransaction();
        }

        public void Commit()
        {
            if (transaction == null)
            {
                return;
            }

            transaction.Commit();
            transaction.Dispose();
            transaction = null;
        }

        public void Rollback()
        {
            if (transaction == null)
            {
                return;
            }

            transaction.Rollback();
            transaction.Dispose();
            transaction = null;
        }

        public SqlCommand CreateCommand()
        {
            return new SqlCommand(string.Empty, connection, transaction);
        }
    }
}
