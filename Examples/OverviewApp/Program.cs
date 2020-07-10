using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Oddity;
using Oddity.API.Builders;
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

            // var allCrew = await oddity.CrewEndpoint.GetAll().ExecuteAsync();
            // var crewMember = await oddity.CrewEndpoint.Get("5ebf1b7323a9a60006e03a7b").ExecuteAsync();

            var company = await oddity.CompanyEndpoint.Get().ExecuteAsync();

            // var allLandpads = await oddity.LandpadsEndpoint.GetAll().ExecuteAsync();
            // var landpad = await oddity.LandpadsEndpoint.Get("5e9e3032383ecb90a834e7c8").ExecuteAsync();

            // var allLaunchpads = await oddity.LaunchpadsEndpoint.GetAll().ExecuteAsync();
            // var launchpad = await oddity.LaunchpadsEndpoint.Get("5e9e4502f509092b78566f87").ExecuteAsync();

            // var allPayloads = await oddity.PayloadsEndpoint.GetAll().ExecuteAsync();
            // var payloads = await oddity.PayloadsEndpoint.Get("5eb0e4bbb6c3bb0006eeb1ed").ExecuteAsync();

            // var roadster = await oddity.RoadsterEndpoint.Get().ExecuteAsync();

            // var allShips = await oddity.ShipsEndpoint.GetAll().ExecuteAsync();
            // var ship = await oddity.ShipsEndpoint.Get("5ea6ed2e080df4000697c90a").ExecuteAsync();

            // var allStarlinks = await oddity.StarlinkEndpoint.GetAll().ExecuteAsync();
            // var starlink = await oddity.StarlinkEndpoint.Get("5eed7716096e590006985825").ExecuteAsync();

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