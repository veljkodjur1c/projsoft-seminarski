using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Common.Domain
{
    public class Racun : IEntity
    {
        public int Id { get; set; }
        public double UkupanIznos { get; set; }
        public DateTime DatumIzvrsenja { get; set; }
        public Prodavac Prodavac { get; set; }
        public Kupac Kupac { get; set; }
        public BindingList<StavkaRacuna> Stavke { get; set; }

        [JsonIgnore]
        public string TableName => "racun";

        [JsonIgnore]
        public string Values =>
            $"{UkupanIznos.ToString(CultureInfo.InvariantCulture)}, " +
            $"'{DatumIzvrsenja:yyyy-MM-dd}', {Prodavac.Id}, {Kupac.Id}";

        [JsonIgnore]
        public string Join =>
            "r JOIN prodavac p ON r.idProdavac = p.idProdavac " +
            "JOIN kupac k ON r.idKupac = k.idKupac " +
            "JOIN grad g ON k.idGrad = g.idGrad";

        [JsonIgnore]
        public string Set =>
            $"SET ukupanIznos = {UkupanIznos.ToString(CultureInfo.InvariantCulture)}, " +
            $"datumIzvrsenja = '{DatumIzvrsenja:yyyy-MM-dd}', " +
            $"idProdavac = {Prodavac.Id}, idKupac = {Kupac.Id}";

        public string SelectCondition { get; set; }
        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }

        public override string ToString()
        {
            return $"Racun {Id} - {DatumIzvrsenja:dd.MM.yyyy.} - {UkupanIznos} RSD";
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> racuni = new List<IEntity>();
            while (reader.Read())
            {
                Racun r = new Racun
                {
                    Id = (int)reader["idRacun"],
                    UkupanIznos = (double)reader["ukupanIznos"],
                    DatumIzvrsenja = (DateTime)reader["datumIzvrsenja"],
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
                    Kupac = new Kupac
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
                    },
                    Stavke = new BindingList<StavkaRacuna>()
                };
                racuni.Add(r);
            }
            return racuni;
        }
    }
}
