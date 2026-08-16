using Microsoft.Data.SqlClient;
using System.Text.Json.Serialization;

namespace Common.Domain
{
    public class Kvalifikacija : IEntity
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string NivoStrucnosti { get; set; }

        [JsonIgnore]
        public string TableName => "kvalifikacija";

        [JsonIgnore]
        public string Values => $"'{Naziv}', '{NivoStrucnosti}'";

        [JsonIgnore]
        public string Join => "";

        [JsonIgnore]
        public string Set => $"SET nazivKvalifikacija = '{Naziv}', nivoStrucnosti = '{NivoStrucnosti}'";

        public string SelectCondition { get; set; }
        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }

        public override string ToString()
        {
            return $"{Naziv} ({NivoStrucnosti})";
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> kvalifikacije = new List<IEntity>();
            while (reader.Read())
            {
                Kvalifikacija k = new Kvalifikacija
                {
                    Id = (int)reader["idKvalifikacija"],
                    Naziv = (string)reader["nazivKvalifikacija"],
                    NivoStrucnosti = (string)reader["nivoStrucnosti"]
                };
                kvalifikacije.Add(k);
            }
            return kvalifikacije;
        }
    }
}
