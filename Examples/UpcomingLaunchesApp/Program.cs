using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Oddity;

namespace UpcomingLaunchesApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var oddity = new OddityCore();
            oddity.OnDeserializationError += OddityOnOnDeserializationError;

            await DisplayNextLaunch(oddity);
            await DisplayRestOfUpcomingLaunches(oddity);

            Console.Read();
        }
        
        private static async Task DisplayNextLaunch(OddityCore oddity)
        {
            var nextLaunchData = await oddity.LaunchesEndpoint.GetNext().ExecuteAsync();

            Console.WriteLine("Next launch data:");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Mission name     | " + nextLaunchData.Name);
            Console.WriteLine("Launchpad        | " + nextLaunchData.Launchpad.Value.FullName);
            Console.WriteLine("Launch date UTC  | " + nextLaunchData.DateUtc);
            Console.WriteLine("Rocket           | " + nextLaunchData.Rocket.Value.Name);
            Console.WriteLine("Payloads         | " + string.Join(',', nextLaunchData.Payloads.Select(p => p.Value.Name)));
            Console.WriteLine();
        }

        private static async Task DisplayRestOfUpcomingLaunches(OddityCore oddity)
        {
            var upcomingLaunches = await oddity.LaunchesEndpoint.GetUpcoming().ExecuteAsync();

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
