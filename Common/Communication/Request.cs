namespace Common.Communication
{
    /// <summary>
    /// Zahtev koji klijent salje serveru: koja operacija i sa kojim argumentom.
    /// </summary>
    public class Request
    {
        public Operation Operation { get; set; }
        public object Argument { get; set; }
    }
}
