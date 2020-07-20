# Oddity
[![GitHub release](https://img.shields.io/github/release/Tearth/Oddity.svg)](https://github.com/Tearth/Oddity/releases)
[![Build](https://api.travis-ci.org/Tearth/Oddity.svg?branch=master)](https://travis-ci.org/Tearth/Oddity)
[![NuGet downloads](https://img.shields.io/nuget/dt/Oddity.svg)](https://www.nuget.org/packages/Oddity/)
[![GitHub issues](https://img.shields.io/github/issues/Tearth/Oddity.svg)](https://github.com/Tearth/Oddity/issues)
[![GitHub stars](https://img.shields.io/github/stars/Tearth/Oddity.svg)](https://github.com/Tearth/Oddity/stargazers)
[![GitHub license](https://img.shields.io/github/license/Tearth/Oddity.svg)](https://github.com/Tearth/Oddity/blob/master/LICENSE)
[![Doxygen](https://img.shields.io/badge/Doxygen-gh--pages-blue)](https://tearth.github.io/Oddity/)

.NET wrapper for **[unofficial SpaceX API project](https://github.com/r-spacex/SpaceX-API)** v4 (with full support for all endpoints and query subsystem), providing information about everyting related to the company. Thanks to this library, you can easily get any data without messing with HTTP requests, JSON deserializators or constructing query bodies. You can use the following endpoints:

 - **Capsules** - detailed information about Dragon capsules.
 - **Company** - detailed information about SpaceX as a company.
 - **Cores** - detalied information about first stage cores.
 - **Crew** - detailed information about Dragon crew members.
 - **Dragons** - detailed information about Dragon capsule versions.
 - **Landpads** - detailed information about landing pads and ships.
 - **Launches** - detailed information about launches.
 - **Launchpads** - detailed information about launchpads.
 - **Payloads** - detailed information about launch payloads.
 - **Roadster** - detailed information about Elon's Tesla Roadster.
 - **Rockets** - detailed information about rocket versions.
 - **Ships** - detailed information about ships in the SpaceX fleet.
 - **Starlink** - detailed information about Starlink satellites and orbits.

To learn how to use this library, look at this set of examples:

 - **[OverviewApp](/Examples/OverviewApp)** - a test of all endpoints, lazy properties and cache. It's not a real app that does anything useful but allows us to introduce into library architecture.
 - **[UpcomingLaunchesApp](/Examples/UpcomingLaunchesApp)** - displays upcoming launches and the most important information about the next launch.
 - **[StarlinkApp](/Examples/StarlinkApp)** - displays sample Starlink statistics: the lowest perigee, the highest apogee, the lowest velocity, the highest velocity.

Feel free to make issues or pull request to improve library - Oddity v2 has been rewritten from scratch and it can potentially contain some bugs.

# Features
 - **smart models** which allow us to retrieve linked models from API using lazy properties. No more manual picking objects using their IDs.
 - **support for query subsystem** - v4 API has introduced **[the new query system](https://github.com/r-spacex/SpaceX-API/blob/master/docs/v4/queries.md)** (using **[mongoose-paginate](https://github.com/aravindnc/mongoose-paginate-v2)**) which allows user for more flexible queries. Oddity wraps it with the easy to use classes and provides the most important filters.
 - **internal cache** - this is the nice addition to the smart models and their lazy properties - it allows to reduce the time needed for making and processing API requests by caching deserialized objects for a period specified **[in the API docs](https://github.com/r-spacex/SpaceX-API/blob/master/docs/v4/README.md#caching)**.

# Minimal requirements
Library is built on [.NET Standard 1.1](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) which contains support for:
 * .NET Framework 4.5 or higher
 * .NET Core 1.0 or higher
 * Mono 4.6 or higher
 * Xamarin.iOS 10.0 or higher
 * Xamarin.Mac 3.0 or higher
 * Xamarin.Android 7.0 or higher
 * Universal Windows Platform 10.0 or higher
 
**External dependencies:**
 * [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)

# Installation
 * download from NuGet: https://www.nuget.org/packages/Oddity/

or

 * search "Oddity" in Package Manager

or

 * run `Install-Package Oddity` in the Package Manager Console

# Software using Oddity
 - [**InElonWeTrust**](https://github.com/Tearth/InElonWeTrust) - SpaceX Discord bot providing information about launches, notifications and other commands related to SpaceX and Elon Musk.
 - [**Launchpad**](https://github.com/skyffx/Launchpad) - Get brief overview about SpaceX missions.

# Example usage
```csharp
using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Oddity;
using Oddity.Events;

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

            // Test of the /capsules endpoint
            var allCapsules = await oddity.CapsulesEndpoint.GetAll().ExecuteAsync();
            var capsule = await oddity.CapsulesEndpoint.Get("5e9e2c5bf35918ed873b2664").ExecuteAsync();
            var capsuleLaunch = capsule.Launches[0].Value;

            // Test of the /company endpoint
            var company = await oddity.CompanyEndpoint.Get().ExecuteAsync();

            // Test of the /cores endpoint
            var allCores = await oddity.CoresEndpoint.GetAll().ExecuteAsync();
            var core = await oddity.CoresEndpoint.Get("5e9e28a6f35918c0803b265c").ExecuteAsync();
            var coreLaunch1 = core.Launches[0].Value;
            var coreLaunch2 = core.Launches[1].Value;
            var coreLaunch3 = core.Launches[2].Value;
            var coreLaunch4 = core.Launches[3].Value;

            // Test of the /crew endpoint
            var allCrew = await oddity.CrewEndpoint.GetAll().ExecuteAsync();
            var crewMember = await oddity.CrewEndpoint.Get("5ebf1b7323a9a60006e03a7b").ExecuteAsync();
            var crewMemberLaunch = crewMember.Launches[0].Value;

            // Test of the /landpads endpoint
            var allLandpads = await oddity.LandpadsEndpoint.GetAll().ExecuteAsync();
            var landpad = await oddity.LandpadsEndpoint.Get("5e9e3032383ecb90a834e7c8").ExecuteAsync();
            var landpadLaunch = landpad.Launches[0].Value;

            // Test of the /launches endpoint
            var launch = await oddity.LaunchesEndpoint.Get("5eb87d44ffd86e000604b386").ExecuteAsync();
            var allLaunches = await oddity.LaunchesEndpoint.GetAll().ExecuteAsync();
            var pastLaunches = await oddity.LaunchesEndpoint.GetPast().ExecuteAsync();
            var upcomingLaunches = await oddity.LaunchesEndpoint.GetUpcoming().ExecuteAsync();
            var latestLaunch = await oddity.LaunchesEndpoint.GetLatest().ExecuteAsync();
            var nextLaunch = await oddity.LaunchesEndpoint.GetNext().ExecuteAsync();

            // Test of the /crew endpoint
            var crewLaunch = await oddity.LaunchesEndpoint.Get("5eb87d46ffd86e000604b388").ExecuteAsync();
            var crewLaunchCore = crewLaunch.Cores[0].Core.Value;
            var crewLaunchLandpad = crewLaunch.Cores[0].Landpad.Value;
            var crewLaunchRocket = crewLaunch.Rocket.Value;
            var crewLaunchCrew = crewLaunch.Crew[0].Value;
            var crewLaunchShip = crewLaunch.Ships[0].Value;
            var crewLaunchCapsule = crewLaunch.Capsules[0].Value;
            var crewLaunchPayload = crewLaunch.Payloads[0].Value;
            var crewLaunchLaunchpad = crewLaunch.Launchpad.Value;

            // Test of the /launches endpoint
            var commercialLaunch = await oddity.LaunchesEndpoint.Get("5eb87d46ffd86e000604b389").ExecuteAsync();
            var commercialLaunchCore = commercialLaunch.Cores[0].Core.Value;
            var commercialLaunchLandpad = commercialLaunch.Cores[0].Landpad.Value;
            var commercialLaunchFairingShips = commercialLaunch.Fairings.Ships[0].Value;
            var commercialLaunchRocket = commercialLaunch.Rocket.Value;
            var commercialLaunchShip = commercialLaunch.Ships[0].Value;
            var commercialLaunchPayload = commercialLaunch.Payloads[0].Value;
            var commercialLaunchLaunchpad = commercialLaunch.Launchpad.Value;

            // Test of the /launchpads endpoint
            var allLaunchpads = await oddity.LaunchpadsEndpoint.GetAll().ExecuteAsync();
            var launchpad = await oddity.LaunchpadsEndpoint.Get("5e9e4502f509092b78566f87").ExecuteAsync();
            var launchpadLaunch1 = launchpad.Launches[0].Value;
            var launchpadLaunch2 = launchpad.Launches[1].Value;
            var launchpadLaunch3 = launchpad.Launches[2].Value;
            var launchpadLaunch4 = launchpad.Launches[3].Value;
            var launchpadRocket = launchpad.Rockets[0].Value;

            // Test of the /payloads endpoint
            var allPayloads = await oddity.PayloadsEndpoint.GetAll().ExecuteAsync();
            var payload = await oddity.PayloadsEndpoint.Get("5eb0e4bbb6c3bb0006eeb1ed").ExecuteAsync();
            var payloadLaunch = payload.Launch.Value;
            var payloadCapsule = payload.Dragon.Capsule.Value;

            // Test of the /roadster endpoint
            var roadster = await oddity.RoadsterEndpoint.Get().ExecuteAsync();

            // Test of the /rockets endpoint
            var allRockets = await oddity.RocketsEndpoint.GetAll().ExecuteAsync();
            var rocket = await oddity.RocketsEndpoint.Get("5e9d0d95eda69974db09d1ed").ExecuteAsync();

            // Test of the /ships endpoint
            var allShips = await oddity.ShipsEndpoint.GetAll().ExecuteAsync();
            var ship = await oddity.ShipsEndpoint.Get("5ea6ed2e080df4000697c90a").ExecuteAsync();
            var shipLaunch1 = ship.Launches[0].Value;
            var shipLaunch2 = ship.Launches[1].Value;
            var shipLaunch3 = ship.Launches[2].Value;
            var shipLaunch4 = ship.Launches[3].Value;

            // Test of the /starlink endpoint
            var allStarlinks = await oddity.StarlinkEndpoint.GetAll().ExecuteAsync();
            var starlink = await oddity.StarlinkEndpoint.Get("5eed7716096e590006985825").ExecuteAsync();
            var starlinkLaunch = starlink.Launch.Value;

            // Test of the pagination
            var queryStarlink = await oddity.StarlinkEndpoint.Query()
                .WithFieldGreaterThan(p => p.SpaceTrack.Apoapsis, 500)
                .WithLimit(100)
                .SortBy(p => p.SpaceTrack.Apoapsis, false)
                .ExecuteAsync();
            await queryStarlink.GoToNextPage();
            await queryStarlink.GoToNextPage();
            await queryStarlink.GoToNextPage();
            await queryStarlink.GoToPrevPage();
            await queryStarlink.GoToPrevPage();
            await queryStarlink.GoToPrevPage();
            await queryStarlink.GoToLastPage();
            await queryStarlink.GoToFirstPage();

            // Test of cache
            var queryLaunch = await oddity.LaunchesEndpoint.Query().WithLimit(1).ExecuteAsync();
            var queryLaunchCached = await oddity.LaunchesEndpoint.Get("5eb87cd9ffd86e000604b32a").ExecuteAsync();

            var launchCached = await oddity.LaunchesEndpoint.Get("5eb87d44ffd86e000604b386").ExecuteAsync();
            var allLaunchesCached = await oddity.LaunchesEndpoint.GetAll().ExecuteAsync();
            var pastLaunchesCached = await oddity.LaunchesEndpoint.GetPast().ExecuteAsync();
            var upcomingLaunchesCached = await oddity.LaunchesEndpoint.GetUpcoming().ExecuteAsync();
            var latestLaunchCached = await oddity.LaunchesEndpoint.GetLatest().ExecuteAsync();
            var nextLaunchCached = await oddity.LaunchesEndpoint.GetNext().ExecuteAsync();

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

            if (e.Query != null)
            {
                Console.WriteLine($"Query: {e.Query}");
            }
        }

        private static void OddityOnResponseReceive(object sender, ResponseReceiveEventArgs e)
        {
            Console.WriteLine($"Response received! Status code: {e.StatusCode}");
            Console.WriteLine($"Raw content: {e.Response}");
            Console.WriteLine();
        }
    }
}
```

# Why Oddity?
https://www.youtube.com/watch?v=iYYRH4apXDo