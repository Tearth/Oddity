using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Oddity;
using Oddity.API.Events;

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

            var allCapsules = await oddity.CapsulesEndpoint.GetAll().ExecuteAsync();
            var capsule = await oddity.CapsulesEndpoint.Get("5e9e2c5bf35918ed873b2664").ExecuteAsync();
            var capsuleLaunch = capsule.Launches[0].Value;

            var allCrew = await oddity.CrewEndpoint.GetAll().ExecuteAsync();
            var crewMember = await oddity.CrewEndpoint.Get("5ebf1b7323a9a60006e03a7b").ExecuteAsync();
            var crewMemberLaunch = crewMember.Launches[0].Value;

            var company = await oddity.CompanyEndpoint.Get().ExecuteAsync();

            var allCores = await oddity.CoresEndpoint.GetAll().ExecuteAsync();
            var core = await oddity.CoresEndpoint.Get("5e9e28a6f35918c0803b265c").ExecuteAsync();
            var coreLaunch1 = core.Launches[0].Value;
            var coreLaunch2 = core.Launches[1].Value;
            var coreLaunch3 = core.Launches[2].Value;
            var coreLaunch4 = core.Launches[3].Value;

            var allLandpads = await oddity.LandpadsEndpoint.GetAll().ExecuteAsync();
            var landpad = await oddity.LandpadsEndpoint.Get("5e9e3032383ecb90a834e7c8").ExecuteAsync();
            var landpadLaunch = landpad.Launches[0].Value;

            var allLaunches = await oddity.LaunchesEndpoint.GetAll().ExecuteAsync();
            var pastLaunches = await oddity.LaunchesEndpoint.GetPast().ExecuteAsync();
            var upcomingLaunches = await oddity.LaunchesEndpoint.GetUpcoming().ExecuteAsync();
            var latestLaunch = await oddity.LaunchesEndpoint.GetPast().ExecuteAsync();
            var nextLaunch = await oddity.LaunchesEndpoint.GetNext().ExecuteAsync();

            var crewLaunch = await oddity.LaunchesEndpoint.Get("5eb87d46ffd86e000604b388").ExecuteAsync();
            var crewLaunchCore = crewLaunch.Cores[0].Core.Value;
            var crewLaunchLandpad = crewLaunch.Cores[0].Landpad.Value;
            var crewLaunchRocket = crewLaunch.Rocket.Value;
            var crewLaunchCrew = crewLaunch.Crew[0].Value;
            var crewLaunchShip = crewLaunch.Ships[0].Value;
            var crewLaunchCapsule = crewLaunch.Capsules[0].Value;
            var crewLaunchPayload = crewLaunch.Payloads[0].Value;
            var crewLaunchLaunchpad = crewLaunch.Launchpad.Value;

            var commercialLaunch = await oddity.LaunchesEndpoint.Get("5eb87d46ffd86e000604b389").ExecuteAsync();
            var commercialLaunchCore = commercialLaunch.Cores[0].Core.Value;
            var commercialLaunchLandpad = commercialLaunch.Cores[0].Landpad.Value;
            var commercialLaunchFairingShips = commercialLaunch.Fairings.Ships[0].Value;
            var commercialLaunchRocket = commercialLaunch.Rocket.Value;
            var commercialLaunchShip = commercialLaunch.Ships[0].Value;
            var commercialLaunchPayload = commercialLaunch.Payloads[0].Value;
            var commercialLaunchLaunchpad = commercialLaunch.Launchpad.Value;

            var allLaunchpads = await oddity.LaunchpadsEndpoint.GetAll().ExecuteAsync();
            var launchpad = await oddity.LaunchpadsEndpoint.Get("5e9e4502f509092b78566f87").ExecuteAsync();
            var launchpadLaunch1 = launchpad.Launches[0].Value;
            var launchpadLaunch2 = launchpad.Launches[1].Value;
            var launchpadLaunch3 = launchpad.Launches[2].Value;
            var launchpadLaunch4 = launchpad.Launches[3].Value;
            var launchpadRocket = launchpad.Rockets[0].Value;

            var allPayloads = await oddity.PayloadsEndpoint.GetAll().ExecuteAsync();
            var payload = await oddity.PayloadsEndpoint.Get("5eb0e4bbb6c3bb0006eeb1ed").ExecuteAsync();
            var payloadLaunch = payload.Launch.Value;
            var payloadCapsule = payload.Dragon.Capsule.Value;

            var roadster = await oddity.RoadsterEndpoint.Get().ExecuteAsync();

            var allRockets = await oddity.RocketsEndpoint.GetAll().ExecuteAsync();
            var rocket = await oddity.RocketsEndpoint.Get("5e9d0d95eda69974db09d1ed").ExecuteAsync();

            var allShips = await oddity.ShipsEndpoint.GetAll().ExecuteAsync();
            var ship = await oddity.ShipsEndpoint.Get("5ea6ed2e080df4000697c90a").ExecuteAsync();
            var shipLaunch1 = ship.Launches[0].Value;
            var shipLaunch2 = ship.Launches[1].Value;
            var shipLaunch3 = ship.Launches[2].Value;
            var shipLaunch4 = ship.Launches[3].Value;

            var allStarlinks = await oddity.StarlinkEndpoint.GetAll().ExecuteAsync();
            var starlink = await oddity.StarlinkEndpoint.Get("5eed7716096e590006985825").ExecuteAsync();
            var starlinkLaunch = starlink.Launch.Value;

            Console.Read();
        }

        private static void OddityOnDeserializationError(object sender, ErrorEventArgs errorEventArgs)
        {
            Console.WriteLine("Something went wrong");

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