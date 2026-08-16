using Common;
using Common.Communication;
using Common.Domain;
using System.Diagnostics;
using System.Net.Sockets;

namespace Server
{
    /// <summary>
    /// Opsluzuje jednog klijenta. Prima zahteve, prosledjuje ih
    /// kontroleru aplikacione logike i vraca odgovor.
    /// </summary>
    public class ClientHandler
    {
        private readonly JsonNetworkSerializer serializer;
        private readonly Socket socket;
        private readonly Server server;

        public ClientHandler(Socket socket, Server server)
        {
            this.socket = socket;
            this.server = server;
            serializer = new JsonNetworkSerializer(socket);
        }

        public void HandleRequests()
        {
            try
            {
                while (true)
                {
                    Request zahtev = serializer.Receive<Request>();
                    Response odgovor = ProcessRequest(zahtev);
                    serializer.Send(odgovor);
                }
            }
            catch (SocketException)
            {
                Debug.WriteLine("Komunikacija sa klijentom je prekinuta.");
            }
            catch (IOException)
            {
                Debug.WriteLine("Komunikacija sa klijentom je prekinuta.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Neocekivana greska: " + ex.Message);
            }
            finally
            {
                if (socket.Connected)
                {
                    socket.Close();
                }
                server.RemoveClient(this);
            }
        }

        private Response ProcessRequest(Request zahtev)
        {
            Response odgovor = new Response();

            try
            {
                switch (zahtev.Operation)
                {
                    case Operation.PrijaviProdavac:
                        odgovor.Result = Controller.Instance.PrijaviProdavac(
                            serializer.ReadType<Prodavac>(zahtev.Argument));
                        break;

                    case Operation.VratiListuSviGrad:
                        odgovor.Result = Controller.Instance.VratiListuSviGrad();
                        break;

                    case Operation.VratiListuSviProdavac:
                        odgovor.Result = Controller.Instance.VratiListuSviProdavac();
                        break;

                    case Operation.VratiListuSviKupac:
                        odgovor.Result = Controller.Instance.VratiListuSviKupac();
                        break;

                    case Operation.VratiListuSviSuplementacija:
                        odgovor.Result = Controller.Instance.VratiListuSviSuplementacija();
                        break;

                    case Operation.UbaciKvalifikacija:
                        Controller.Instance.UbaciKvalifikacija(
                            serializer.ReadType<Kvalifikacija>(zahtev.Argument));
                        break;

                    case Operation.KreirajKupac:
                        odgovor.Result = Controller.Instance.KreirajKupac(
                            serializer.ReadType<Kupac>(zahtev.Argument));
                        break;

                    case Operation.PretraziKupac:
                        odgovor.Result = Controller.Instance.PretraziKupac(
                            serializer.ReadType<Kupac>(zahtev.Argument));
                        break;

                    case Operation.VratiListuKupac:
                        odgovor.Result = Controller.Instance.VratiListuKupac(
                            serializer.ReadType<Kupac>(zahtev.Argument));
                        break;

                    case Operation.PromeniKupac:
                        Controller.Instance.PromeniKupac(
                            serializer.ReadType<Kupac>(zahtev.Argument));
                        break;

                    case Operation.ObrisiKupac:
                        Controller.Instance.ObrisiKupac(
                            serializer.ReadType<Kupac>(zahtev.Argument));
                        break;

                    case Operation.KreirajRacun:
                        odgovor.Result = Controller.Instance.KreirajRacun(
                            serializer.ReadType<Racun>(zahtev.Argument));
                        break;

                    case Operation.PromeniRacun:
                        Controller.Instance.PromeniRacun(
                            serializer.ReadType<Racun>(zahtev.Argument));
                        break;

                    case Operation.ObrisiRacun:
                        Controller.Instance.ObrisiRacun(
                            serializer.ReadType<Racun>(zahtev.Argument));
                        break;

                    case Operation.PretraziRacun:
                        odgovor.Result = Controller.Instance.PretraziRacun(
                            serializer.ReadType<Racun>(zahtev.Argument));
                        break;

                    case Operation.VratiListuRacun:
                        odgovor.Result = Controller.Instance.VratiListuRacun(
                            serializer.ReadType<Racun>(zahtev.Argument));
                        break;

                    case Operation.VratiListuStavkaRacuna:
                        odgovor.Result = Controller.Instance.VratiListuStavkaRacuna(
                            serializer.ReadType<StavkaRacuna>(zahtev.Argument));
                        break;

                    default:
                        throw new Exception("Nepoznata sistemska operacija.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Greska pri izvrsenju operacije: " + ex.Message);
                odgovor.ExceptionMessage = ex.Message;
            }

            return odgovor;
        }

        internal void CloseSocket()
        {
            socket.Close();
        }
    }
}
