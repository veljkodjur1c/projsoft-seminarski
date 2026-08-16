namespace Common.Communication
{
    /// <summary>
    /// Odgovor servera. Ako je ExceptionMessage razlicit od null,
    /// operacija nije uspela i klijent prikazuje poruku o gresci.
    /// </summary>
    public class Response
    {
        public object Result { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
