using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microwave.Classes.Interfaces
{
    public interface ICookController
    {
        public event EventHandler ExtendTimeMin;
        public event EventHandler ExtendTimeSec;
        public void OnExtendTime(bool state);
        void StartCooking(int power, int time);
        void Stop();
    }
}
