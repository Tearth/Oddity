using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Oddity;
using Oddity.API.Builders;
using Oddity.API.Models.Dragon;
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

            // Get API information
            var apiInfo = await oddity.Api.GetInfo().ExecuteAsync();

            // Get company information
            var company = await oddity.Company.GetInfo().ExecuteAsync();

            // Get all history
            var history = await oddity.History.GetAll().ExecuteAsync();

            // Get history from the last two years and ordered descending
            var historyWithFilter = await oddity.History.GetAll()
                .WithRange(DateTime.Now.AddYears(-2), DateTime.Now)
                .Descending()
                .ExecuteAsync();

            // Get single history event
            var historyEvent = await oddity.History.GetEvent(5).ExecuteAsync();

            // Get data about Falcon Heavy
            var falconHeavy = await oddity.Rockets.GetAbout(RocketId.FalconHeavy).ExecuteAsync();

            // Get list of all launchpads
            var allLaunchpads = await oddity.Launchpads.GetAll().ExecuteAsync();

            // Get information about the next launch
            var nextLaunch = await oddity.Launches.GetNext().ExecuteAsync();

            // Get information about the specified launch
            var specifiedLaunch = await oddity.Launches.Get(65).ExecuteAsync();

            // Get data about all launches of Falcon 9 which has been launched to ISS. Next, sort it ascending
            var launchWithFilters = await oddity.Launches.GetAll()
                .WithRocketName("Falcon 9")
                .WithOrbit(OrbitType.ISS)
                .Ascending()
                .ExecuteAsync();

            // Get all Dragon types
            var dragonTypes = await oddity.Dragons.GetAll().ExecuteAsync();

            // Get all Dragon types
            var crewDragon = await oddity.Dragons.GetAbout(DragonId.Dragon2).ExecuteAsync();

            // Get all capsules
            var allCapsules = await oddity.Capsules.GetAll().ExecuteAsync();

            // Past capsules
            var pastCapsules = await oddity.Capsules.GetPast().ExecuteAsync();

            // Upcoming capsules
            var upcomingCapsules = await oddity.Capsules.GetUpcoming().ExecuteAsync();

            // Get capsule which has been launched 2015-04-14 at 20:10
            var capsuleWithFilters = await oddity.Capsules.GetAll()
                .WithOriginalLaunch(new DateTime(2015, 4, 14, 20, 10, 0))
                .ExecuteAsync();

            // Get all cores
            var allCores = await oddity.Cores.GetAll().ExecuteAsync();

            // Get past cores
            var pastCores = await oddity.Cores.GetPast().ExecuteAsync();

            // Get upcoming cores
            var upcomingCores = await oddity.Cores.GetUpcoming().ExecuteAsync();

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