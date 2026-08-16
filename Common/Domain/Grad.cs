using Microsoft.Data.SqlClient;
using System.Text.Json.Serialization;

namespace Common.Domain
{
    public class Grad : IEntity
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }

        [JsonIgnore]
        public string TableName => "grad";

        [JsonIgnore]
        public string Values => $"'{Naziv}', '{PostanskiBroj}'";

        [JsonIgnore]
        public string Join => "";

        [JsonIgnore]
        public string Set => $"SET nazivGrad = '{Naziv}', postanskiBroj = '{PostanskiBroj}'";

        public string SelectCondition { get; set; }
        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }

        public override string ToString()
        {
            return Naziv;
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> gradovi = new List<IEntity>();
            while (reader.Read())
            {
                Grad g = new Grad
                {
                    Id = (int)reader["idGrad"],
                    Naziv = (string)reader["nazivGrad"],
                    PostanskiBroj = (string)reader["postanskiBroj"]
                };
                gradovi.Add(g);
            }
            return gradovi;
        }
    }
}
