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
          
            Buzzer buzzer = new Buzzer(output);

            CookController cooker = new CookController(timer, display, powerTube);

            UserInterface ui = new UserInterface(powerButton, timeButton, startCancelButton, door, display, light, cooker, buzzer);

            // Finish the double association
            cooker.UI = ui;

            // Simulate a simple sequence

            powerButton.Press();

            timeButton.Press();

            startCancelButton.Press();


            string n = "1";

            while (n != "0")
            {
                Console.WriteLine("Press 1 to add 1 minut | Press 2 to add 5 seconds | Press 0 to set  permanent time");

                n = Console.ReadLine();

                switch (n)
                {
                    case "1":
                        // Minuts:
                        cooker.OnExtendTime(true);
                        break;
                    case "2":
                        // Seconds
                        cooker.OnExtendTime(false);
                        break;
                    default:
                        // Quit
                        n = "0";
                        break;
                }

            }

            // The simple sequence should now run

            System.Console.WriteLine("When you press enter, the program will stop");
            // Wait for input

            System.Console.ReadLine();
        }
    }
}
