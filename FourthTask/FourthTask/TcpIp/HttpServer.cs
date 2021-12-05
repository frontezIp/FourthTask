using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FourthTask
{
    public class HttpServer : Server
    {
        private ProcessData _dataProc;

        private string _possibleHeader;

        private string _possibleBody;

        private byte[] _data;

        private int _currentCounter;

        public HttpServer(int port): base(port)
        { 

            _currentCounter = 0;
        }

        /// <summary>
        /// Validate http request
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ValidateHttpRequest(byte[] data)
        {
            _data = data;
            foreach(var piece in data)
            {
                _currentCounter++;
                byte[] buffer = new byte[1];
                buffer[0] = piece;
                _possibleHeader += Encoding.UTF8.GetString(buffer);
                if (_possibleHeader.Contains("\r\n\r\n"))
                {
                    return true;
                }
            }
            ResetReceivedData();
            return false;
        }

        /// <summary>
        /// Parse body of the http request
        /// </summary>
        /// <returns></returns>
        public string ParseBody()
        {

            int contentLength = FindLenghOfTheContent();
            byte[] body = new byte[contentLength];
            Array.Copy(_data, _currentCounter, body, 0, contentLength);
            _currentCounter = 0;
            _possibleBody += Encoding.ASCII.GetString(body);
            return _possibleBody;
        }

        /// <summary>
        /// Find length of the content segment
        /// </summary>
        /// <returns></returns>
        public int FindLenghOfTheContent()
        {
            Regex reg = new Regex("\\\r\nContent-Length: (.*?)\\\r\n");
            Match m = reg.Match(_possibleHeader);
            int contentLength = int.Parse(m.Groups[1].ToString());
            return contentLength;
        }

        /// <summary>
        /// Reset all data
        /// </summary>
        public void ResetReceivedData()
        {
            _possibleBody = null;
            _possibleHeader = null;
            _currentCounter = 0;
        }


    }
}
