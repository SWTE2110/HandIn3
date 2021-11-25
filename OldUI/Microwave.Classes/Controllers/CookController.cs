using System;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Controllers
{
    public class CookController : ICookController
    {
        // Since there is a 2-way association, this cannot be set until the UI object has been created
        // It also demonstrates property dependency injection
        public IUserInterface UI { set; private get; }

        private bool isCooking = false;

        private IDisplay myDisplay;
        private IPowerTube myPowerTube;
        private ITimer myTimer;


        public event EventHandler ExtendTimeMin;
        public event EventHandler ExtendTimeSec;


        public CookController(
            ITimer timer,
            IDisplay display,
            IPowerTube powerTube,
            IUserInterface ui) : this(timer, display, powerTube)
        {
            UI = ui;
        }

        public CookController(
            ITimer timer,
            IDisplay display,
            IPowerTube powerTube)
        {
            myTimer = timer;
            myDisplay = display;
            myPowerTube = powerTube;

            ExtendTimeMin += timer.ExtendTimerMinEvent;
            ExtendTimeSec += timer.ExtendTimerSecEvent;

            timer.Expired += new EventHandler(OnTimerExpired);
            timer.TimerTick += new EventHandler(OnTimerTick);
        }

        public void StartCooking(int power, int time)
        {
            myPowerTube.TurnOn(power);
            myTimer.Start(time);
            isCooking = true;
        }

        public void Stop()
        {
            isCooking = false;
            myPowerTube.TurnOff();
            myTimer.Stop();
        }

        public int GetMaxPower()
        {
            return myPowerTube.MaxPower;
        }
        public void OnExtendTime(bool state)
        {
            
            switch (state)
            {
                case true:
                    ExtendTimeMin?.Invoke(this, EventArgs.Empty);
                    break;
                case false:
                    ExtendTimeSec?.Invoke(this, EventArgs.Empty);
                    break;
            }
                
            isCooking = true;
        }


        public void OnTimerExpired(object sender, EventArgs e)
        {
            if (isCooking)
            {
                isCooking = false;
                myPowerTube.TurnOff();
                UI.CookingIsDone();
            }
        }

        public void OnTimerTick(object sender, EventArgs e)
        {
            if (isCooking)
            {
                int remaining = myTimer.TimeRemaining;
                myDisplay.ShowTime(remaining / 60, remaining % 60);
            }
        }

    }
}