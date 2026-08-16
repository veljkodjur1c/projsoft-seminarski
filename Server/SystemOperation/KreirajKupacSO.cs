using Common.Domain;

namespace Server.SystemOperation
{
    /// <summary>
    /// KreirajKupac(Kupac) - veza sa SK4.
    /// Pravi nov (prazan) slog kupca i vraca dodeljeni identifikator.
    /// Podaci se popunjavaju kasnije, operacijom PromeniKupac.
    /// </summary>
    public class KreirajKupacSO : SystemOperationBase
    {
        private readonly Kupac kupac;
        public int Result { get; set; }

        public KreirajKupacSO(Kupac kupac)
        {
            this.kupac = kupac;
        }

        protected override void ExecuteConcreteOperation()
        {
            // Vrednosti su privremene i moraju da zadovolje ogranicenja tabele.
            // Grad se uzima kao prvi iz sifarnika, jer je strani kljuc obavezan.
            kupac.InsertCondition =
                "OUTPUT inserted.idKupac SELECT '-', '-', '@', '-', MIN(idGrad) FROM grad";

            Result = broker.Create(kupac);

            if (Result <= 0)
            {
                throw new Exception("Sistem ne moze da kreira kupca");
            }
        }
    }
}
