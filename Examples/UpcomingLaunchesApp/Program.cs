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
            /*
            var oddity = new OddityCore();
            oddity.OnDeserializationError += OddityOnOnDeserializationError;

            DisplayNextLaunch(oddity);
            DisplayRestOfUpcomingLaunches(oddity);

            Console.Read();
            */
        }
        /*
        private static void DisplayNextLaunch(OddityCore oddity)
        {
            var nextLaunchData = oddity.Launches.GetNext().Execute();

            Console.WriteLine("Next launch data:");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Mission name     | " + nextLaunchData.MissionName);
            Console.WriteLine("Launchpad        | " + nextLaunchData.LaunchSite.SiteLongName);
            Console.WriteLine("Launch date UTC  | " + nextLaunchData.LaunchDateUtc);
            Console.WriteLine("Rocket           | " + nextLaunchData.Rocket.RocketName);
            Console.WriteLine("Payloads         | " + string.Join(',', nextLaunchData.Rocket.SecondStage.Payloads.Select(p => p.PayloadId)));
            Console.WriteLine();
        }

        private static void DisplayRestOfUpcomingLaunches(OddityCore oddity)
        {
            var upcomingLaunches = oddity.Launches.GetUpcoming().Execute();

            Console.WriteLine("All upcoming launches:");
            Console.WriteLine("---------------------------------------------------------------------------");
            foreach (var launch in upcomingLaunches)
            {
                Console.WriteLine($"{launch.MissionName} ({launch.LaunchDateUtc}) at {launch.LaunchSite.SiteName}");
            }
        }

        private static void OddityOnOnDeserializationError(object sender, ErrorEventArgs errorEventArgs)
        {
            Console.WriteLine($"Error: {errorEventArgs.ErrorContext.Path}");
            errorEventArgs.ErrorContext.Handled = true;
        }
        */
    }
}
