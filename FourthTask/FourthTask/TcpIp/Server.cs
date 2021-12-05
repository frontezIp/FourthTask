using System;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Text;

namespace FourthTask
{
    public class Server
    {
        private event EventHandler<byte[]> dataReceivingEvent;

        public event EventHandler<byte[]> DataReceivingEvent
        {
            add { dataReceivingEvent += value; }
            remove { dataReceivingEvent -= value; }
        }

        private int _port;

        private bool _isCreated;

        private IPEndPoint _ip;

        private Socket _socket;

        public IPEndPoint IP { get => _ip;}
        public Socket Socket { get => _socket; }

        public Server(int port)
        {
            _port = port;
            _isCreated = false;
            dataReceivingEvent = null;
        }

        /// <summary>
        /// Launch server
        /// </summary>
        public void CreateServer()
        {
            if(_isCreated == false) 
            {
                _ip = new IPEndPoint(IPAddress.Loopback, _port);
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _isCreated = true;
            }
        }

        /// <summary>
        /// Start server
        /// </summary>
        public void StartServer()
        {
            if (_isCreated == true)
            {
                Socket.Bind(IP);
                Socket.Listen(128);

                while (true)
                {
                    Socket handler = Socket.Accept();
                    StringBuilder builder = new StringBuilder();
                    int bytesRead = 0;
                    byte[] data = new byte[1024];

                    do
                    {
                        bytesRead = handler.Receive(data);
                        dataReceivingEvent?.Invoke(this, data);
                    }
                    while (handler.Available > 0);
                    handler.Send(data);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
        }

        /// <summary>
        /// Stop server
        /// </summary>
        public void StopServer()
        {
            Socket.Shutdown(SocketShutdown.Both);
            Socket.Close();
            _socket = null;
            _isCreated = false;
        }
    }
}
