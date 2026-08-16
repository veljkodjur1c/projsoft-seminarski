using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Common.Domain
{
    public class StavkaRacuna : IEntity
    {
        public int IdRacun { get; set; }
        public int Rb { get; set; }
        public double Cena { get; set; }
        public int Kolicina { get; set; }
        public double Iznos { get; set; }
        public Suplementacija Suplementacija { get; set; }

        [JsonIgnore]
        public string TableName => "stavkaRacuna";

        [JsonIgnore]
        public string Values =>
            $"{IdRacun}, {Rb}, {Cena.ToString(CultureInfo.InvariantCulture)}, " +
            $"{Kolicina}, {Iznos.ToString(CultureInfo.InvariantCulture)}, {Suplementacija.Id}";

        [JsonIgnore]
        public string Join => "sr JOIN suplementacija s ON sr.idSuplementacija = s.idSuplementacija";

        [JsonIgnore]
        public string Set =>
            $"SET cena = {Cena.ToString(CultureInfo.InvariantCulture)}, kolicina = {Kolicina}, " +
            $"iznos = {Iznos.ToString(CultureInfo.InvariantCulture)}, idSuplementacija = {Suplementacija.Id}";

        public string SelectCondition { get; set; }
        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }

        public override string ToString()
        {
            return $"{Rb}. {Suplementacija?.Naziv} x {Kolicina} = {Iznos}";
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> stavke = new List<IEntity>();

            // Tabele stavkaRacuna i suplementacija obe imaju kolonu "cena".
            // Citac po imenu vraca PRVU takvu kolonu (cenu stavke), pa cenu
            // suplementacije moramo procitati po rednom broju kolone.
            int ordinalCenaSuplementacije = -1;
            for (int i = reader.FieldCount - 1; i >= 0; i--)
            {
                if (reader.GetName(i).Equals("cena", StringComparison.OrdinalIgnoreCase))
                {
                    ordinalCenaSuplementacije = i;
                    break;
                }
            }

            while (reader.Read())
            {
                StavkaRacuna s = new StavkaRacuna
                {
                    IdRacun = (int)reader["idRacun"],
                    Rb = (int)reader["rb"],
                    Cena = (double)reader["cena"],
                    Kolicina = (int)reader["kolicina"],
                    Iznos = (double)reader["iznos"],
                    Suplementacija = new Suplementacija
                    {
                        Id = (int)reader["idSuplementacija"],
                        Naziv = (string)reader["nazivSuplementacija"],
                        Brend = (string)reader["brendSuplementacija"],
                        Cena = (double)reader.GetValue(ordinalCenaSuplementacije),
                        NetoKolicina = (string)reader["netoKolicina"]
                    }
                };
                stavke.Add(s);
            }
            return stavke;
        }
    }
}
