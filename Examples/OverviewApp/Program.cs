using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Oddity;
using Oddity.API.Builders;
using Oddity.API.Models.Launch.Rocket.SecondStage.Orbit;
using Oddity.API.Models.Rocket;

namespace OverviewApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var oddity = new OddityCore();

            // Optional
            oddity.OnDeserializationError += OddityOnDeserializationError;
            oddity.OnRequestSend += Oddity_OnRequestSend;
            oddity.OnResponseReceive += OddityOnResponseReceive;

            // Get company information
            var company = await oddity.Company.GetInfo().ExecuteAsync();

            // Get all history
            var history = await oddity.Company.GetHistory().ExecuteAsync();

            // Get history from the last two years and ordered descending
            var historyWithFilter = await oddity.Company.GetHistory()
                .WithRange(DateTime.Now.AddYears(-2), DateTime.Now)
                .Descending()
                .ExecuteAsync();

            // Get data about Falcon Heavy
            var falconHeavy = await oddity.Rockets.GetAbout(RocketId.FalconHeavy).ExecuteAsync();

            // Get list of all launchpads
            var allLaunchpads = await oddity.Launchpads.GetAll().ExecuteAsync();

            // Get information about the next launch
            var nextLaunch = await oddity.Launches.GetNext().ExecuteAsync();

            // Get data about all launches of Falcon 9 which has been launched to ISS. Next, sort it ascending
            var launchWithFilters = await oddity.Launches.GetAll()
                .WithRocketName("Falcon 9")
                .WithOrbit(OrbitType.ISS)
                .Ascending()
                .ExecuteAsync();

            // Get all capsule types
            var capsuleTypes = await oddity.Capsules.GetAll().ExecuteAsync();

            // Get capsule which has been launched 2015-04-14 at 20:10
            var capsuleWithFilters = await oddity.DetailedCapsules.GetAll()
                .WithOriginalLaunch(new DateTime(2015, 4, 14, 20, 10, 0))
                .ExecuteAsync();

            // Get all cores
            var allCores = await oddity.DetailedCores.GetAll().ExecuteAsync();

            // Get Roadster info
            var roadster = await oddity.Roadster.Get().ExecuteAsync();

            Console.Read();
        }

        private static void OddityOnDeserializationError(object sender, ErrorEventArgs errorEventArgs)
        {
            Console.WriteLine("Something went wrong.");

            // We don't want to stop program, just leave problematic field as null
            errorEventArgs.ErrorContext.Handled = true;
        }

        private static void Oddity_OnRequestSend(object sender, RequestSendEventArgs e)
        {
            Console.WriteLine($"Sending request... URL: {e.Url}");
        }

        private static void OddityOnResponseReceive(object sender, ResponseReceiveEventArgs e)
        {
            Console.WriteLine($"Response received! Status code: {e.StatusCode}");
            Console.WriteLine($"Raw content: {e.Response}");
            Console.WriteLine();
        }
    }
}