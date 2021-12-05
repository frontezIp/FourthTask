using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthTask
{
    public class GaussianHandler
    {
        private event EventHandler<Slae> dataCalculateEvent;

        public event EventHandler<Slae> DataCalculateEvent
        {
            add { dataCalculateEvent += value; }
            remove { dataCalculateEvent -= value; }
        }

        /// <summary>
        /// Invoke all subscribed processors of the Slae
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="matrix"></param>
        public void GaussSolve(object obj, string matrix)
        {
            dataCalculateEvent?.Invoke(this, new Slae(matrix));
        }

        /// <summary>
        /// Connect processor
        /// </summary>
        /// <param name="process"></param>
        public void ConnectProcess(IGaussianProcess process)
        {
            DataCalculateEvent += process.Process;
        }

        /// <summary>
        /// Disconnect processor
        /// </summary>
        /// <param name="process"></param>
        public void DisconnectProcess(IGaussianProcess process)
        {
            DataCalculateEvent -= process.Process;
        }

    }
}
