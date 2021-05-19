using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        Socket osluskujuciSoket;
        
        internal bool PokreniServer()
        {
            try
            {
                osluskujuciSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                osluskujuciSoket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1945));
                Thread nitOsluskuj = new Thread(osluskuj);
                nitOsluskuj.Start();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }

        }

        private void osluskuj()
        {

            try
            {
                while (true)
                {
                    osluskujuciSoket.Listen(5);
                    Socket klijentskiSoket = osluskujuciSoket.Accept();
                    ObradaKlijenta obrada = new ObradaKlijenta(klijentskiSoket);
                    Thread nitKlijenta = new Thread(obrada.ObradaZahteva);
                    nitKlijenta.Start();
                }
            }
            catch (SocketException se)
            {
                Debug.WriteLine(se.Message);
            }
        }

        internal void ZaustaviServer()
        {
            try
            {
                osluskujuciSoket.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
