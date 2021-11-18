using System;
using Microwave.Classes.Boundary;
using Microwave.Classes.Controllers;

namespace Microwave.App
{
    class Program
    {

        enum timeState
        {
            TimerOn, SetTime, ExtendTime
        }

        static void Main(string[] args)
        {

            timeState State = timeState.TimerOn; ;

            Button startCancelButton = new Button();
            Button powerButton = new Button();
            Button timeButton = new Button();

            Door door = new Door();

            Output output = new Output();

            Display display = new Display(output);

            PowerTube powerTube = new PowerTube(output);

            Light light = new Light(output);

            Microwave.Classes.Boundary.Timer timer = new Timer();

            CookController cooker = new CookController(timer, display, powerTube);

            UserInterface ui = new UserInterface(powerButton, timeButton, startCancelButton, door, display, light, cooker, timer);

            // Finish the double association
            cooker.UI = ui;

            // Simulate a simple sequence

            powerButton.Press();

            timeButton.Press();
            timeButton.Press();
            timeButton.Press();
            timeButton.Press();
            //string n = "1";
            //while (n != "0")
            //{
            //    switch (State)
            //    {
            //        case timeState.TimerOn:
            //            timeButton.Press();
            //            State = timeState.SetTime;
            //            break;
            //        case timeState.SetTime:
            //            timeButton.Press();
            //            State = timeState.ExtendTime;
            //            break;
            //        case timeState.ExtendTime:
            //            Console.WriteLine("Press 1 to add a minut");
            //            n = Console.ReadLine();
            //            timeButton.Press();
            //            break;
            //    }
            //}

            startCancelButton.Press();

            // The simple sequence should now run

            System.Console.WriteLine("When you press enter, the program will stop");
            // Wait for input

            System.Console.ReadLine();
        }
    }
}
