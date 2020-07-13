using System;
using System.Linq;
using Newtonsoft.Json.Serialization;
using Oddity;

namespace UpcomingLaunchesApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var oddity = new OddityCore();
            oddity.OnDeserializationError += OddityOnOnDeserializationError;

            DisplayNextLaunch(oddity);
            DisplayRestOfUpcomingLaunches(oddity);

            Console.Read();
        }
        
        private static void DisplayNextLaunch(OddityCore oddity)
        {
            var nextLaunchData = oddity.LaunchesEndpoint.GetNext().Execute();

            Console.WriteLine("Next launch data:");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Mission name     | " + nextLaunchData.Name);
            Console.WriteLine("Launchpad        | " + nextLaunchData.Launchpad.Value.FullName);
            Console.WriteLine("Launch date UTC  | " + nextLaunchData.DateUtc);
            Console.WriteLine("Rocket           | " + nextLaunchData.Rocket.Value.Name);
            Console.WriteLine("Payloads         | " + string.Join(',', nextLaunchData.Payloads.Select(p => p.Value.Name)));
            Console.WriteLine();
        }

        private static void DisplayRestOfUpcomingLaunches(OddityCore oddity)
        {
            var upcomingLaunches = oddity.LaunchesEndpoint.GetUpcoming().Execute();

            Console.WriteLine("All upcoming launches:");
            Console.WriteLine("---------------------------------------------------------------------------");
            foreach (var launch in upcomingLaunches)
            {
                Console.WriteLine($"{launch.Name} ({launch.DateUtc}) at {launch.Launchpad.Value.FullName}");
            }
        }

        private static void OddityOnOnDeserializationError(object sender, ErrorEventArgs errorEventArgs)
        {
            Console.WriteLine($"Error: {errorEventArgs.ErrorContext.Path}");
            errorEventArgs.ErrorContext.Handled = true;
        }
    }
}
