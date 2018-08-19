using System;
using Newtonsoft.Json.Serialization;
using Oddity;
using Oddity.API.Builders;
using Oddity.API.Models.Launch.Rocket.SecondStage.Orbit;
using Oddity.API.Models.Rocket;

namespace OverviewApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var oddity = new OddityCore();

            // Optional.
            oddity.OnDeserializationError += OddityOnDeserializationError;
            oddity.OnRequestSend += Oddity_OnRequestSend;
            oddity.OnResponseReceive += OddityOnResponseReceive;

            // Get company information.
            var company = oddity.Company.GetInfo().Execute();

            // Get all history.
            var history = oddity.Company.GetHistory().Execute();

            // Get history from the last two years and ordered descending.
            var historyWithFilter = oddity.Company.GetHistory().WithRange(DateTime.Now.AddYears(-2), DateTime.Now).Descending().Execute();

            // Get data about Falcon Heavy.
            var falconHeavy = oddity.Rockets.GetAbout(RocketId.FalconHeavy).Execute();

            // Get list of all launchpads.
            var allLaunchpads = oddity.Launchpads.GetAll().Execute();

            // Get all launches.
            var allLaunches = oddity.Launches.GetAll().Execute();

            // Get information about the next launch.
            var nextLaunch = oddity.Launches.GetNext().Execute();

            // Get data about all launches of Falcon 9 which has been launched to ISS and landed with success. Next, sort it ascending.
            var launchWithFilters = oddity.Launches.GetAll().WithRocketName("Falcon 9").WithOrbit(OrbitType.ISS).WithLandSuccess(true).Ascending().Execute();

            // Get all capsule types.
            var capsuleTypes = oddity.Capsules.GetAll().Execute();

            // Get capsule which has been launched 2015-04-14 at 20:10.
            var capsuleWithFilters = oddity.DetailedCapsules.GetAll().WithOriginalLaunch(new DateTime(2015, 4, 14, 20, 10, 0)).Execute();

            // Get all cores.
            var allCores = oddity.DetailedCores.GetAll().Execute();

            // Get Roadster info.
            var roadster = oddity.Roadster.Get().Execute();

            Console.Read();
        }

        private static void OddityOnDeserializationError(object sender, ErrorEventArgs errorEventArgs)
        {
            Console.WriteLine("Something went wrong.");

            // We don't want to stop program, just leave problematic field as null.
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