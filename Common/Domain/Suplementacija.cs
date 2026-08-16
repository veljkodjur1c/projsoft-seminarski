using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Common.Domain
{
    public class Suplementacija : IEntity
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Brend { get; set; }
        public double Cena { get; set; }
        public string NetoKolicina { get; set; }

        [JsonIgnore]
        public string TableName => "suplementacija";

        [JsonIgnore]
        public string Values =>
            $"'{Naziv}', '{Brend}', {Cena.ToString(CultureInfo.InvariantCulture)}, '{NetoKolicina}'";

        [JsonIgnore]
        public string Join => "";

        [JsonIgnore]
        public string Set =>
            $"SET nazivSuplementacija = '{Naziv}', brendSuplementacija = '{Brend}', " +
            $"cena = {Cena.ToString(CultureInfo.InvariantCulture)}, netoKolicina = '{NetoKolicina}'";

        public string SelectCondition { get; set; }
        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }

        public override string ToString()
        {
            return $"{Naziv} - {Brend} ({NetoKolicina})";
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> suplementacije = new List<IEntity>();
            while (reader.Read())
            {
                Suplementacija s = new Suplementacija
                {
                    Id = (int)reader["idSuplementacija"],
                    Naziv = (string)reader["nazivSuplementacija"],
                    Brend = (string)reader["brendSuplementacija"],
                    Cena = (double)reader["cena"],
                    NetoKolicina = (string)reader["netoKolicina"]
                };
                suplementacije.Add(s);
            }
            return suplementacije;
        }
    }
}
