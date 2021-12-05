using System;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;

namespace FourthTask
{
    public class Client
    {
        public event EventHandler<byte[]> DataReceivedEvent;

        private int _port;

        private bool _noDataToSend;

        private bool _isCreated;

        private IPEndPoint _ip;

        private List<string> results;

        private Socket _socket;

        public IPEndPoint Ip { get => _ip;  }
        public Socket Socket { get => _socket;  }

        public Client(int port)
        {
            _port = port;
        }


        /// <summary>
        /// Create client
        /// </summary>
        public void CreateClient()
        {
            if (_isCreated == false)
            {
               _ip = new IPEndPoint(IPAddress.Loopback, _port);
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _isCreated = true;
            }
        }
        
        /// <summary>
        /// Start client to sending messages
        /// </summary>
        public void StartClient()
        {
            if (_isCreated == true)
            {
                Socket.Connect(Ip);

                while (true)
                {
                    string dataToSend = GetData();
                    int bytesRead = 0;
                    byte[] data = Encoding.UTF8.GetBytes(dataToSend);
                    Socket.Send(data);

                    data = new byte[1024];
                    StringBuilder builder = new StringBuilder();
                    int bytesToRead = 0;

                    do
                    {
                        bytesRead = Socket.Receive(data, data.Length, 0);
                        results.Add(Encoding.UTF8.GetString(data));
                    }
                    while (Socket.Available > 0);

                    if (_noDataToSend)
                        StopServer();
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
            _socket= null;
            _isCreated = false;
        }

        /// <summary>
        /// Gets required data
        /// </summary>
        /// <returns></returns>
        public string GetData()
        {
            string data = "";
            return data;
        }

        
    }
}
