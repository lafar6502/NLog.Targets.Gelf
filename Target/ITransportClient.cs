using System.Net;
using System;

namespace NLog.Targets.Gelf
{
    public interface ITransportClient : IDisposable
    {
        void Send(byte[] datagram, int bytes, IPEndPoint ipEndPoint);
    }
}
