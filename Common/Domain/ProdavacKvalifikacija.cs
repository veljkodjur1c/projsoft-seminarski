using Microsoft.Data.SqlClient;
using System.Text.Json.Serialization;

namespace Common.Domain
{
    public class ProdavacKvalifikacija : IEntity
    {
        public Prodavac Prodavac { get; set; }
        public Kvalifikacija Kvalifikacija { get; set; }
        public DateTime DatumSticanja { get; set; }

        [JsonIgnore]
        public string TableName => "prodavacKvalifikacija";

        [JsonIgnore]
        public string Values =>
            $"{Prodavac.Id}, {Kvalifikacija.Id}, '{DatumSticanja:yyyy-MM-dd}'";

        [JsonIgnore]
        public string Join =>
            "pk JOIN prodavac p ON pk.idProdavac = p.idProdavac " +
            "JOIN kvalifikacija kv ON pk.idKvalifikacija = kv.idKvalifikacija";

        [JsonIgnore]
        public string Set => $"SET datumSticanja = '{DatumSticanja:yyyy-MM-dd}'";

        public string SelectCondition { get; set; }
        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }

        public override string ToString()
        {
            return $"{Prodavac} - {Kvalifikacija} ({DatumSticanja:dd.MM.yyyy.})";
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                ProdavacKvalifikacija pk = new ProdavacKvalifikacija
                {
                    Prodavac = new Prodavac
                    {
                        Id = (int)reader["idProdavac"],
                        Ime = (string)reader["imeProdavac"],
                        Prezime = (string)reader["prezimeProdavac"],
                        KorisnickoIme = (string)reader["korisnickoIme"],
                        Sifra = (string)reader["sifra"],
                        Email = (string)reader["emailProdavac"],
                        DatumZaposlenja = (DateTime)reader["datumZaposlenja"]
                    },
                    Kvalifikacija = new Kvalifikacija
                    {
                        Id = (int)reader["idKvalifikacija"],
                        Naziv = (string)reader["nazivKvalifikacija"],
                        NivoStrucnosti = (string)reader["nivoStrucnosti"]
                    },
                    DatumSticanja = (DateTime)reader["datumSticanja"]
                };
                lista.Add(pk);
            }
            return lista;
        }
    }
}
