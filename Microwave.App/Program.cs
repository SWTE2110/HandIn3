using System;
using Microwave.Classes.Boundary;
using Microwave.Classes.Controllers;

namespace Microwave.App
{
    class Program
    {

        static void Main(string[] args)
        {

            Button startCancelButton = new Button();
            Button powerButton = new Button();
            Button timeButton = new Button();

            Door door = new Door();

            Output output = new Output();

            Display display = new Display(output);

            PowerTube powerTube = new PowerTube(output);

            Light light = new Light(output);

            Timer timer = new Timer();

            CookController cooker = new CookController(timer, display, powerTube);

            cooker.ExtendTimeMin += timer.ExtendTimerMinEvent;
            cooker.ExtendTimeSec += timer.ExtendTimerSecEvent;

            UserInterface ui = new UserInterface(powerButton, timeButton, startCancelButton, door, display, light, cooker);

            // Finish the double association
            cooker.UI = ui;

            // Simulate a simple sequence

            powerButton.Press();

            timeButton.Press();

            startCancelButton.Press();

            string n = "1";

            while (n != "3")
            {
                Console.WriteLine("Press 1 to add 1 minut | Press 2 to add 5 seconds | Press 3 to set  permanent Time");

                n = Console.ReadLine();

                // Minuts:
                if (n == "1")
                    cooker.OnExtendTime(true);

                // Seconds
                if (n == "2")
                    cooker.OnExtendTime(false);

            }
            // The simple sequence should now run

            System.Console.WriteLine("When you press enter, the program will stop");
            // Wait for input


            System.Console.ReadLine();
        }
    }
}
