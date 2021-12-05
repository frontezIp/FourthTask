using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthTask
{
    public class ProcessingResults
    {
        static private string _solution;

        static public string Solution { get => _solution; }
        static public string TimeUsage { get => _timeUsage;  }

        static private string _timeUsage;

        /// <summary>
        /// Set results of the given process
        /// </summary>
        /// <param name="sender">Name of the process</param>
        /// <param name="res">result</param>
        /// <param name="time">used time to process</param>
        static public void SetResults(string sender,double[] res, long time)
        {
            if (_solution == null)
            {
                _solution = String.Join(",", res);
            }
            if(_timeUsage == null)
                _timeUsage += sender +":" +$"{Convert.ToString(time)}";
            else
                _timeUsage += ", "+sender + ":" + $"{Convert.ToString(time)}";
        }

        /// <summary>
        /// Get current results
        /// </summary>
        /// <returns></returns>
        static public string GetResults() => _solution + ". " + _timeUsage;

        /// <summary>
        /// Reset results
        /// </summary>
        static public void Reset()
        {
            _solution = null;
            _timeUsage = null;
        }

    }
}
