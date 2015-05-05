using System.Net;
using System.Net.Sockets;
using System;

namespace NLog.Targets.Gelf
{
    public class UdpTransportClient : ITransportClient
    {
        
        private UdpClient _myClient = new UdpClient();

        public void Send(byte[] datagram, int bytes, IPEndPoint ipEndPoint)
        {
            try
            {
                var cl = _myClient;
                cl.Send(datagram, bytes, ipEndPoint);
            }
            catch (Exception)
            {
                lock (this)
                {
                    if (_myClient != null) _myClient.Close();
                    _myClient = new UdpClient();
                }
                throw;
            }
            
        }

        public void Dispose()
        {
           
        }
    }
}
