using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microwave.Classes.Interfaces
{
    public interface ITimer
    {
        int TimeRemaining { get; }
        event EventHandler Expired;
        event EventHandler TimerTick;
        public void ExtendTimerMinEvent(object sender, EventArgs e);
        public void ExtendTimerSecEvent(object sender, EventArgs e);
        void Start(int time);
        void Stop();
    }
}
