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

            startCancelButton.Press();

            string n = "1";
            while (n != "0")
            {

                Console.WriteLine("Press 1 to add time | Press 0 to stop");

                n = Console.ReadLine();
                if (n != "0")
                {
                    timeButton.Press();
                    
                }
            }
            // The simple sequence should now run

            System.Console.WriteLine("When you press enter, the program will stop");
            // Wait for input


            System.Console.ReadLine();
        }
    }
}
