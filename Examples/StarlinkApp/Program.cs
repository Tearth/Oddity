using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Oddity;
using Oddity.Models.Starlink;

namespace StarlinkApp
{
    public class Program
    {
        private static uint SatellitesPerTable = 4;

        public static async Task Main()
        {
            var oddity = new OddityCore();
            var stopWatch = Stopwatch.StartNew();

            oddity.OnDeserializationError += OddityOnOnDeserializationError;

            await DisplayWithHighestApoapsis(oddity, SatellitesPerTable);
            await DisplayWithLowestPeriapsis(oddity, SatellitesPerTable);
            await DisplayWithHighestSpeed(oddity, SatellitesPerTable);
            await DisplayWithLowestSpeed(oddity, SatellitesPerTable);

            Console.WriteLine($"Generated in {stopWatch.Elapsed.TotalSeconds:F1} seconds");
            Console.Read();
        }

        private static async Task DisplayWithHighestApoapsis(OddityCore oddity, uint count)
        {
            var satellites = await oddity.StarlinkEndpoint.Query()
                .SortBy(p => p.SpaceTrack.Apoapsis, false)
                .WithLimit(count)
                .ExecuteAsync();

            DisplaySatelliteData(satellites.Data, "Satellites with the highest apoapsis:");
        }

        private static async Task DisplayWithLowestPeriapsis(OddityCore oddity, uint count)
        {
            var satellites = await oddity.StarlinkEndpoint.Query()
                .SortBy(p => p.SpaceTrack.Periapsis)
                .WithLimit(count)
                .ExecuteAsync();

            DisplaySatelliteData(satellites.Data, "Satellites with the lowest periapsis:");
        }

        private static async Task DisplayWithHighestSpeed(OddityCore oddity, uint count)
        {
            var satellites = await oddity.StarlinkEndpoint.Query()
                .SortBy(p => p.VelocityKilometersPerSecond, false)
                .WithLimit(count)
                .ExecuteAsync();

            DisplaySatelliteData(satellites.Data, "Satellites with the highest speed:");
        }

        private static async Task DisplayWithLowestSpeed(OddityCore oddity, uint count)
        {
            var satellites = await oddity.StarlinkEndpoint.Query()
                .WithFieldGreaterThan(p => p.VelocityKilometersPerSecond, 0.0)
                .SortBy(p => p.VelocityKilometersPerSecond)
                .WithLimit(count)
                .ExecuteAsync();

            DisplaySatelliteData(satellites.Data, "Satellites with the lowest speed:");
        }

        private static void DisplaySatelliteData(IEnumerable<StarlinkInfo> satellitesList, string header)
        {
            Console.WriteLine(header);
            Console.WriteLine("---------------------------------------------------------------------------");

            foreach (var satellite in satellitesList)
            {
                var launch = satellite.Launch.Value;
                var name = launch.Name;
                var version = satellite.Version;
                var date = launch.DateUtc;
                var apoapsis = satellite.SpaceTrack.Apoapsis;
                var periapsis = satellite.SpaceTrack.Periapsis;
                var velocity = satellite.VelocityKilometersPerSecond;

                Console.WriteLine($"{name} ({version}) launched at {date}): {apoapsis:F} km x {periapsis:F} km, " +
                                  $"{velocity ?? double.NaN:F} km/s");
            }

            Console.WriteLine();
        }

        private static void OddityOnOnDeserializationError(object sender, ErrorEventArgs errorEventArgs)
        {
            Console.WriteLine($"Error: {errorEventArgs.ErrorContext.Path}");
            errorEventArgs.ErrorContext.Handled = true;
        }
    }
}
