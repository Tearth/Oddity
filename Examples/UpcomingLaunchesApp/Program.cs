using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Oddity;
using Oddity.Models.Launches;
using Oddity.Models.Payloads;

namespace UpcomingLaunchesApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var oddity = new OddityCore();
            var stopWatch = Stopwatch.StartNew();

            oddity.OnDeserializationError += OddityOnOnDeserializationError;

            await DisplayNextLaunch(oddity);
            await DisplayRestOfUpcomingLaunches(oddity);

            Console.WriteLine($"Generated in {stopWatch.Elapsed.TotalSeconds:F1} seconds");
            Console.Read();
        }
        
        private static async Task DisplayNextLaunch(OddityCore oddity)
        {
            var nextLaunchData = await oddity.LaunchesEndpoint.GetNext().ExecuteAsync();
            var formattedDate = GetFormattedDate(nextLaunchData.DateUtc, nextLaunchData.DatePrecision);

            Console.WriteLine("Next launch data:");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Mission name     | " + nextLaunchData.Name);
            Console.WriteLine("Launchpad        | " + nextLaunchData.Launchpad.Value.FullName);
            Console.WriteLine("Launch date UTC  | " + formattedDate);
            Console.WriteLine("Rocket           | " + nextLaunchData.Rocket.Value.Name);
            Console.WriteLine("Payloads         | " + string.Join(", ", nextLaunchData.Payloads.Select(p => GetPayloadInfo(p.Value))));
            Console.WriteLine();

            var cores = await oddity.CoresEndpoint.Query().WithFieldEqual(a => a.Serial, nextLaunchData.Cores.First().Core.Value.Serial).ExecuteAsync();
            if (cores.Data.Count != 1)
                Console.WriteLine("Failed to find core!");
            else
            {
                var core = cores.Data[0];
                Console.WriteLine("Core:");
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("Serial           | " + core.Serial);
                Console.WriteLine("Resuse Count     | " + core.ReuseCount);
            }

            Console.WriteLine();
        }

        private static async Task DisplayRestOfUpcomingLaunches(OddityCore oddity)
        {
            var upcomingLaunches = await oddity.LaunchesEndpoint.GetUpcoming().ExecuteAsync();

            Console.WriteLine("All upcoming launches:");
            Console.WriteLine("---------------------------------------------------------------------------");

            foreach (var launch in upcomingLaunches)
            {
                var formattedDate = GetFormattedDate(launch.DateUtc, launch.DatePrecision);
                Console.WriteLine($"{launch.Name} ({formattedDate}) at {launch.Launchpad.Value.FullName}");
            }

            Console.WriteLine();
        }

        private static string GetPayloadInfo(PayloadInfo payload)
        {
            return payload.MassKilograms.HasValue ? $"{payload.Name} ({payload.MassKilograms} kg)" : payload.Name;
        }

        private static string GetFormattedDate(DateTime? date, DatePrecision? precision)
        {
            if (date == null || precision == null)
            {
                return null;
            }

            switch (precision)
            {
                case DatePrecision.Hour: return date.Value.ToString("f", CultureInfo.InvariantCulture);
                case DatePrecision.Day: return date.Value.ToString("D", CultureInfo.InvariantCulture);
                case DatePrecision.Month: return date.Value.ToString("Y", CultureInfo.InvariantCulture);
                default: return date.Value.ToString("yyyy", CultureInfo.InvariantCulture);
            }
        }

        private static void OddityOnOnDeserializationError(object sender, ErrorEventArgs errorEventArgs)
        {
            Console.WriteLine($"Error: {errorEventArgs.ErrorContext.Path}");
            errorEventArgs.ErrorContext.Handled = true;
        }
    }
}
