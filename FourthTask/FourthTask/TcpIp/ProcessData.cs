using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthTask
{
    public class ProcessData
    {
        private Server _server;

        private Client _client;

        private event EventHandler<string> dataReadyToCalculateEvent;

        public event EventHandler<string> DataReadyToCalculateEvent
        {
            add { dataReadyToCalculateEvent += value; }
            remove { dataReadyToCalculateEvent -= value; }
        }

        private HttpServer _http;

        private GaussianHandler _gauss;

        public Server Server { get => _server; set => _server = value; }
        public Client Client { get => _client; set => _client = value; }
        public GaussianHandler Gauss { get => _gauss; }

        public ProcessData(GaussianHandler gaussian,HttpServer http,Server server, Client client)
        {
            _server = server;

            _client = client;

            _gauss = gaussian;

            server.DataReceivingEvent += Process;

            _http = http;
        }

        /// <summary>
        /// Process data depends on which kind of data this is
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        public void Process(object sender, byte[] data)
        {
            if (_http.ValidateHttpRequest(data))
            {
                string matrix = _http.ParseBody();
                dataReadyToCalculateEvent?.Invoke(this, matrix);
            }
            else
            {
                dataReadyToCalculateEvent?.Invoke(this, Encoding.UTF8.GetString(data));
            }

        }
    }
}
