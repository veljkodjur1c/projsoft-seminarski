using Microsoft.Data.SqlClient;
using System.Text.Json.Serialization;

namespace Common.Domain
{
    public class Prodavac : IEntity
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }
        public string Email { get; set; }
        public DateTime DatumZaposlenja { get; set; }

        [JsonIgnore]
        public string TableName => "prodavac";

        [JsonIgnore]
        public string Values =>
            $"'{Ime}', '{Prezime}', '{KorisnickoIme}', '{Sifra}', '{Email}', " +
            $"'{DatumZaposlenja:yyyy-MM-dd}'";

        [JsonIgnore]
        public string Join => "";

        [JsonIgnore]
        public string Set =>
            $"SET imeProdavac = '{Ime}', prezimeProdavac = '{Prezime}', " +
            $"korisnickoIme = '{KorisnickoIme}', sifra = '{Sifra}', " +
            $"emailProdavac = '{Email}', datumZaposlenja = '{DatumZaposlenja:yyyy-MM-dd}'";

        public string SelectCondition { get; set; }
        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }

        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> prodavci = new List<IEntity>();
            while (reader.Read())
            {
                Prodavac p = new Prodavac
                {
                    Id = (int)reader["idProdavac"],
                    Ime = (string)reader["imeProdavac"],
                    Prezime = (string)reader["prezimeProdavac"],
                    KorisnickoIme = (string)reader["korisnickoIme"],
                    Sifra = (string)reader["sifra"],
                    Email = (string)reader["emailProdavac"],
                    DatumZaposlenja = (DateTime)reader["datumZaposlenja"]
                };
                prodavci.Add(p);
            }
            return prodavci;
        }
    }
}
