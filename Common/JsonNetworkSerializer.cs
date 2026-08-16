using System.Net.Sockets;
using System.Text.Json;

namespace Common
{
    /// <summary>
    /// Salje i prima objekte preko soketa u JSON formatu,
    /// jedan objekat po redu teksta.
    /// </summary>
    public class JsonNetworkSerializer
    {
        private readonly Socket socket;
        private readonly NetworkStream stream;
        private readonly StreamReader reader;
        private readonly StreamWriter writer;

        public JsonNetworkSerializer(Socket socket)
        {
            this.socket = socket;
            stream = new NetworkStream(socket);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { AutoFlush = true };
        }

        public void Send(object obj)
        {
            writer.WriteLine(JsonSerializer.Serialize(obj));
        }

        public T Receive<T>()
        {
            string json = reader.ReadLine();
            if (json == null)
            {
                throw new IOException("Veza sa drugom stranom je prekinuta.");
            }
            return JsonSerializer.Deserialize<T>(json);
        }

        /// <summary>
        /// Pretvara podatak koji je stigao kao JsonElement u trazeni tip.
        /// Koristi se za Request.Argument i Response.Result.
        /// </summary>
        public T ReadType<T>(object podaci)
        {
            if (podaci == null)
            {
                return default;
            }

            if (podaci is not JsonElement element)
            {
                return (T)podaci;
            }

            if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
            {
                if (element.ValueKind == JsonValueKind.Number)
                {
                    return (T)Convert.ChangeType(element.GetInt32(), typeof(int));
                }
                if (element.ValueKind == JsonValueKind.String &&
                    int.TryParse(element.GetString(), out int parsirano))
                {
                    return (T)Convert.ChangeType(parsirano, typeof(int));
                }
                throw new InvalidCastException("Podatak ne moze da se konvertuje u int.");
            }

            if (typeof(T) == typeof(bool))
            {
                return (T)Convert.ChangeType(element.GetBoolean(), typeof(bool));
            }

            if (typeof(T) == typeof(string))
            {
                return (T)Convert.ChangeType(element.GetString(), typeof(string));
            }

            if (typeof(T) == typeof(JsonElement))
            {
                return (T)(object)element;
            }

            return JsonSerializer.Deserialize<T>(element.GetRawText());
        }

        public void Close()
        {
            reader?.Close();
            writer?.Close();
            stream?.Close();
        }
    }
}
