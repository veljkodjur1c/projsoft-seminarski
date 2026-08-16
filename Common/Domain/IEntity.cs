using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    /// <summary>
    /// Interfejs koji implementiraju sve domenske klase.
    /// Preko njega Broker gradi SQL upite ne poznajuci konkretnu klasu.
    /// </summary>
    public interface IEntity
    {
        /// <summary>Naziv tabele u bazi podataka.</summary>
        string TableName { get; }

        /// <summary>Vrednosti atributa za INSERT, redosledom kolona u tabeli.</summary>
        string Values { get; }

        /// <summary>Alias glavne tabele i eventualni JOIN sa povezanim tabelama.</summary>
        string Join { get; }

        /// <summary>SET deo UPDATE naredbe.</summary>
        string Set { get; }

        string InsertCondition { get; set; }
        string UpdateCondition { get; set; }
        string DeleteCondition { get; set; }
        string SelectCondition { get; set; }

        /// <summary>Konvertuje redove iz citaca u listu objekata domenske klase.</summary>
        List<IEntity> GetReaderList(SqlDataReader reader);
    }
}
