using Common;
using Common.Communication;
using Common.Domain;
using System.Net.Sockets;

namespace Client
{
    /// <summary>
    /// Jedina tacka preko koje klijent razgovara sa serverom.
    /// Za svaku sistemsku operaciju pravi zahtev, salje ga i vraca rezultat.
    /// </summary>
    public class Communication
    {
        #region Singleton

        private static Communication instance;

        public static Communication Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Communication();
                }
                return instance;
            }
        }

        private Communication() { }

        #endregion

        private Socket socket;
        private JsonNetworkSerializer serializer;

        public void Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);
            serializer = new JsonNetworkSerializer(socket);
        }

        public void Disconnect()
        {
            serializer?.Close();
            if (socket != null && socket.Connected)
            {
                socket.Close();
            }
        }

        /// <summary>
        /// Salje zahtev i vraca odgovor. Ako je server prijavio gresku,
        /// podize izuzetak sa porukom koju je server poslao.
        /// </summary>
        private Response Posalji(Operation operacija, object argument = null)
        {
            Request zahtev = new Request
            {
                Operation = operacija,
                Argument = argument
            };

            serializer.Send(zahtev);
            Response odgovor = serializer.Receive<Response>();

            if (odgovor.ExceptionMessage != null)
            {
                throw new Exception(odgovor.ExceptionMessage);
            }

            return odgovor;
        }

        // ---------- SK8 ----------
        public Prodavac PrijaviProdavac(Prodavac prodavac)
        {
            Response odgovor = Posalji(Operation.PrijaviProdavac, prodavac);
            return serializer.ReadType<Prodavac>(odgovor.Result);
        }

        // ---------- Ucitavanje listi ----------
        public List<Grad> VratiListuSviGrad()
        {
            Response odgovor = Posalji(Operation.VratiListuSviGrad);
            return serializer.ReadType<List<Grad>>(odgovor.Result);
        }

        public List<Prodavac> VratiListuSviProdavac()
        {
            Response odgovor = Posalji(Operation.VratiListuSviProdavac);
            return serializer.ReadType<List<Prodavac>>(odgovor.Result);
        }

        public List<Kupac> VratiListuSviKupac()
        {
            Response odgovor = Posalji(Operation.VratiListuSviKupac);
            return serializer.ReadType<List<Kupac>>(odgovor.Result);
        }

        public List<Suplementacija> VratiListuSviSuplementacija()
        {
            Response odgovor = Posalji(Operation.VratiListuSviSuplementacija);
            return serializer.ReadType<List<Suplementacija>>(odgovor.Result);
        }

        // ---------- SK21 ----------
        public void UbaciKvalifikacija(Kvalifikacija kvalifikacija)
        {
            Posalji(Operation.UbaciKvalifikacija, kvalifikacija);
        }

        // ---------- SK4, SK5, SK6, SK7 ----------
        public int KreirajKupac(Kupac kupac)
        {
            Response odgovor = Posalji(Operation.KreirajKupac, kupac);
            return serializer.ReadType<int>(odgovor.Result);
        }

        public Kupac PretraziKupac(Kupac kupac)
        {
            Response odgovor = Posalji(Operation.PretraziKupac, kupac);
            return serializer.ReadType<Kupac>(odgovor.Result);
        }

        public List<Kupac> VratiListuKupac(Kupac kupac)
        {
            Response odgovor = Posalji(Operation.VratiListuKupac, kupac);
            return serializer.ReadType<List<Kupac>>(odgovor.Result);
        }

        public void PromeniKupac(Kupac kupac)
        {
            Posalji(Operation.PromeniKupac, kupac);
        }

        public void ObrisiKupac(Kupac kupac)
        {
            Posalji(Operation.ObrisiKupac, kupac);
        }

        // ---------- SK1, SK2, SK3 ----------
        public int KreirajRacun(Racun racun)
        {
            Response odgovor = Posalji(Operation.KreirajRacun, racun);
            return serializer.ReadType<int>(odgovor.Result);
        }

        public void PromeniRacun(Racun racun)
        {
            Posalji(Operation.PromeniRacun, racun);
        }

        public void ObrisiRacun(Racun racun)
        {
            Posalji(Operation.ObrisiRacun, racun);
        }

        public Racun PretraziRacun(Racun racun)
        {
            Response odgovor = Posalji(Operation.PretraziRacun, racun);
            return serializer.ReadType<Racun>(odgovor.Result);
        }

        public List<Racun> VratiListuRacun(Racun racun)
        {
            Response odgovor = Posalji(Operation.VratiListuRacun, racun);
            return serializer.ReadType<List<Racun>>(odgovor.Result);
        }

        public List<StavkaRacuna> VratiListuStavkaRacuna(StavkaRacuna stavka)
        {
            Response odgovor = Posalji(Operation.VratiListuStavkaRacuna, stavka);
            return serializer.ReadType<List<StavkaRacuna>>(odgovor.Result);
        }
    }
}
