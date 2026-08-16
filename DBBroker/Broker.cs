using Common.Domain;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace DBBroker
{
    /// <summary>
    /// Posreduje izmedju poslovne logike i baze podataka.
    /// Upite gradi na osnovu podataka koje mu daje sam objekat preko IEntity.
    /// </summary>
    public class Broker
    {
        private readonly DbConnection connection;

        public Broker()
        {
            connection = new DbConnection();
        }

        public void OpenConnection() => connection.OpenConnection();
        public void CloseConnection() => connection.CloseConnection();
        public void BeginTransaction() => connection.BeginTransaction();
        public void Commit() => connection.Commit();
        public void RollBack() => connection.Rollback();

        /// <summary>
        /// Ubacuje novi slog u tabelu. Koristi se kada nam ne treba
        /// generisani primarni kljuc (sifarnici, veze, stavke racuna).
        /// </summary>
        public void Add(IEntity entity)
        {
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO {entity.TableName} VALUES ({entity.Values})";
            Debug.WriteLine(command.CommandText);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Ubacuje novi slog i vraca generisani primarni kljuc.
        /// InsertCondition mora da sadrzi OUTPUT klauzulu.
        /// </summary>
        public int Create(IEntity entity)
        {
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO {entity.TableName} {entity.InsertCondition}";
            Debug.WriteLine(command.CommandText);
            object id = command.ExecuteScalar();
            return (int)id;
        }

        /// <summary>Vraca sve slogove iz tabele.</summary>
        public List<IEntity> GetAll(IEntity entity)
        {
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {entity.TableName} {entity.Join}";
            Debug.WriteLine(command.CommandText);
            using SqlDataReader reader = command.ExecuteReader();
            return entity.GetReaderList(reader);
        }

        /// <summary>Vraca slogove koji zadovoljavaju SelectCondition.</summary>
        public List<IEntity> GetByCondition(IEntity entity)
        {
            using SqlCommand command = connection.CreateCommand();
            command.CommandText =
                $"SELECT * FROM {entity.TableName} {entity.Join} {entity.SelectCondition}";
            Debug.WriteLine(command.CommandText);
            using SqlDataReader reader = command.ExecuteReader();
            return entity.GetReaderList(reader);
        }

        /// <summary>Menja slogove koji zadovoljavaju UpdateCondition.</summary>
        public void UpdateByCondition(IEntity entity)
        {
            using SqlCommand command = connection.CreateCommand();
            command.CommandText =
                $"UPDATE {entity.TableName} {entity.Set} {entity.UpdateCondition}";
            Debug.WriteLine(command.CommandText);
            command.ExecuteNonQuery();
        }

        /// <summary>Brise slogove koji zadovoljavaju DeleteCondition.</summary>
        public void DeleteEntity(IEntity entity)
        {
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM {entity.TableName} {entity.DeleteCondition}";
            Debug.WriteLine(command.CommandText);
            command.ExecuteNonQuery();
        }
    }
}
