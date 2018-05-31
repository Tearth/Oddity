using System;
using Newtonsoft.Json.Serialization;
using Oddity;
using Oddity.API.Models.Launch.Rocket.SecondStage;
using Oddity.API.Models.Rocket;

namespace OverviewApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var oddity = new OddityCore();

            // Optional.
            oddity.OnDeserializationError += OddityOnOnDeserializationError;

            // Get company information.
            var company = oddity.Company.GetInfo().Execute();

            // Get all history.
            var history = oddity.Company.GetHistory().Execute();

            // Get history from the last two years and ordered descending.
            var historyWithFilter = oddity.Company.GetHistory().WithRange(DateTime.Now.AddYears(-2), DateTime.Now).Descending().Execute();

            // Get data about Falcon Heavy.
            var falconHeavy = oddity.Rockets.GetAbout().WithType(RocketId.FalconHeavy).Execute();

            // Get list of all launchpads.
            var allLaunchpads = oddity.Launchpads.GetAll().Execute();

            // Get information about the next launch.
            var nextLaunch = oddity.Launches.GetNext().Execute();

            // Get data about all launches of Falcon 9 which has been launched to ISS and landed with success. Next, sort it ascending.
            var launchWithFilters = oddity.Launches.GetAll().WithRocketName("Falcon 9").WithOrbit(OrbitType.ISS).WithLandSuccess(true).Ascending().Execute();

            // Get capsule which has been launched 2015-04-14 at 20:10.
            var capsuleWithFilters = oddity.DetailedCapsules.GetAll().WithOriginalLaunch(new DateTime(2015, 4, 14, 20, 10, 0)).Execute();

            // Get all cores.
            var allCores = oddity.DetailedCores.GetAll().Execute();
        }

        private static void OddityOnOnDeserializationError(object sender, ErrorEventArgs errorEventArgs)
        {
            Console.WriteLine("Something went wrong.");

            // We don't want to stop all program, just leave problematic field as null.
            errorEventArgs.ErrorContext.Handled = true;
        }
    }
}