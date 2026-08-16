using Microsoft.Data.SqlClient;
using System.Text.Json.Serialization;

namespace Common.Domain
{
    public class Kupac : IEntity
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public Grad Grad { get; set; }

        [JsonIgnore]
        public string TableName => "kupac";

        [JsonIgnore]
        public string Values =>
            $"'{Ime}', '{Prezime}', '{Email}', '{Adresa}', {Grad.Id}";

        [JsonIgnore]
        public string Join => "k JOIN grad g ON k.idGrad = g.idGrad";

        [JsonIgnore]
        public string Set =>
            $"SET imeKupac = '{Ime}', prezimeKupac = '{Prezime}', emailKupac = '{Email}', " +
            $"adresaKupac = '{Adresa}', idGrad = {Grad.Id}";

        public string SelectCondition { get; set; }
        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }

        public override string ToString()
        {
            return $"{Ime} {Prezime} {Email}";
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> kupci = new List<IEntity>();
            while (reader.Read())
            {
                Kupac k = new Kupac
                {
                    Id = (int)reader["idKupac"],
                    Ime = (string)reader["imeKupac"],
                    Prezime = (string)reader["prezimeKupac"],
                    Email = (string)reader["emailKupac"],
                    Adresa = (string)reader["adresaKupac"],
                    Grad = new Grad
                    {
                        Id = (int)reader["idGrad"],
                        Naziv = (string)reader["nazivGrad"],
                        PostanskiBroj = (string)reader["postanskiBroj"]
                    }
                };
                kupci.Add(k);
            }
            return kupci;
        }
    }
}
