using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    /// <summary>
    /// Osluskuje mrezne zahteve i za svakog klijenta pokrece zasebnu nit.
    /// </summary>
    public class Server
    {
        private readonly Socket socket;
        private readonly List<ClientHandler> handlers = new List<ClientHandler>();
        private readonly object kljuc = new object();

        public Server()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            string ip = ConfigurationManager.AppSettings["ip"] ?? "127.0.0.1";
            int port = int.Parse(ConfigurationManager.AppSettings["port"] ?? "9999");

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            socket.Bind(endPoint);
            socket.Listen(1000);

            Debug.WriteLine($"Server osluskuje na {ip}:{port}");

            Thread nit = new Thread(AcceptClient);
            nit.IsBackground = true;
            nit.Start();
        }

        private void AcceptClient()
        {
            try
            {
                while (true)
                {
                    Socket klijentskiSocket = socket.Accept();
                    ClientHandler handler = new ClientHandler(klijentskiSocket, this);

                    lock (kljuc)
                    {
                        handlers.Add(handler);
                    }

                    Thread klijentskaNit = new Thread(handler.HandleRequests);
                    klijentskaNit.IsBackground = true;
                    klijentskaNit.Start();

                    Debug.WriteLine("Novi klijent je povezan.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Server je prestao da prihvata klijente: " + ex.Message);
            }
        }

        public void Stop()
        {
            // Radi se nad kopijom liste, jer zatvaranje soketa uklanja
            // handler iz originalne liste dok se po njoj prolazi.
            List<ClientHandler> kopija;
            lock (kljuc)
            {
                kopija = new List<ClientHandler>(handlers);
            }

            foreach (ClientHandler handler in kopija)
            {
                handler.CloseSocket();
            }

            lock (kljuc)
            {
                handlers.Clear();
            }

            socket.Close();
        }

        internal void RemoveClient(ClientHandler handler)
        {
            lock (kljuc)
            {
                handlers.Remove(handler);
            }
        }
    }
}
