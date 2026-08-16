namespace Common.Communication
{
    /// <summary>
    /// Spisak sistemskih operacija koje klijent moze da zatrazi od servera.
    /// Svakoj vrednosti odgovara po jedna klasa u projektu Server/SystemOperation.
    /// </summary>
    public enum Operation
    {
        // SK8 - Prijavi prodavca
        PrijaviProdavac,

        // SK1, SK3 - Kreiraj / Promeni racun
        KreirajRacun,
        PromeniRacun,
        ObrisiRacun,
        VratiListuSviProdavac,
        VratiListuSviKupac,
        VratiListuSviSuplementacija,

        // SK2, SK3 - Pretrazi racun
        PretraziRacun,
        VratiListuRacun,
        VratiListuStavkaRacuna,

        // SK4, SK6 - Kreiraj / Promeni kupca
        KreirajKupac,
        PromeniKupac,
        VratiListuSviGrad,

        // SK5, SK6, SK7 - Pretrazi / Promeni / Obrisi kupca
        PretraziKupac,
        VratiListuKupac,
        ObrisiKupac,

        // SK21 - Ubaci kvalifikaciju
        UbaciKvalifikacija
    }
}
