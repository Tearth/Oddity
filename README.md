# Oddity
[![GitHub release](https://img.shields.io/github/release/Tearth/Oddity.svg)](https://github.com/Tearth/Oddity/releases)
[![Build](https://api.travis-ci.org/Tearth/Oddity.svg?branch=master)](https://travis-ci.org/Tearth/Oddity)
[![NuGet downloads](https://img.shields.io/nuget/dt/Oddity.svg)](https://www.nuget.org/packages/Oddity/)
[![GitHub issues](https://img.shields.io/github/issues/Tearth/Oddity.svg)](https://github.com/Tearth/Oddity/issues)
[![GitHub stars](https://img.shields.io/github/stars/Tearth/Oddity.svg)](https://github.com/Tearth/Oddity/stargazers)
[![GitHub license](https://img.shields.io/github/license/Tearth/Oddity.svg)](https://github.com/Tearth/Oddity/blob/master/LICENSE)
[![GitHub license](https://img.shields.io/badge/Doxygen-gh--pages-blue)](https://tearth.github.io/Oddity/)

.NET SpaceX API wrapper for https://github.com/r-spacex/SpaceX-API project, providing information about company, rockets and launches. To learn more, you can use [Doxygen](https://tearth.github.io/Oddity/) or directly documentation of the API (method names are very familiar with endpoints):

https://docs.spacexdata.com/

**Available data overview:**
 * company data, history with most important events
 * detailed information about rockets (Falcon 1, Falcon 9, Falcon Heavy, BFR) and capsules (Dragon 1, Dragon 2, crew Dragon)
 * launchpads data
 * launches: latest, next, all past, all upcoming
 * information about the specified cores and capsules
 * Elon's Roadster data 

Most of the endpoints contains a lot of filters which are applied on the API side to save bandwidth. Look at the example and [wiki](https://github.com/Tearth/Oddity/wiki) for more information.

# Minimal requirements
Library is build on [.NET Standard 1.1](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) which contains support for:
 * .NET Framework 4.5 or higher
 * .NET Core 1.0 or higher
 * Mono 4.6 or higher
 * Xamarin.iOS 10.0 or higher
 * Xamarin.Mac 3.0 or higher
 * Xamarin.Android 7.0 or higher
 * Universal Windows Platform 10.0 or higher
 
**External dependencies:**
 * Newtonsoft.Json

# Installation
 * download from NuGet: https://www.nuget.org/packages/Oddity/

or

 * search "Oddity" in Package Manager

or

 * run `Install-Package Oddity` in the Package Manager Console

# Software using Oddity
 - [**InElonWeTrust**](https://github.com/Tearth/InElonWeTrust) - SpaceX Discord bot providing information about launches, notifications and other commands related to SpaceX and Elon Musk.

# Example usage
```csharp
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

            // Optional
            oddity.OnDeserializationError += OddityOnDeserializationError;
            oddity.OnRequestSend += Oddity_OnRequestSend;
            oddity.OnResponseReceive += OddityOnResponseReceive;

            // Get company information
            var company = oddity.Company.GetInfo().Execute();

            // Get all history
            var history = oddity.Company.GetHistory().Execute();

            // Get history from the last two years and ordered descending
            var historyWithFilter = oddity.Company.GetHistory().WithRange(DateTime.Now.AddYears(-2), DateTime.Now).Descending().Execute();

            // Get data about Falcon Heavy
            var falconHeavy = oddity.Rockets.GetAbout(RocketId.FalconHeavy).Execute();

            // Get list of all launchpads
            var allLaunchpads = oddity.Launchpads.GetAll().Execute();

            // Get information about the next launch
            var nextLaunch = oddity.Launches.GetNext().Execute();

            // Get data about all launches of Falcon 9 which has been launched to ISS and landed with success. Next, sort it ascending
            var launchWithFilters = oddity.Launches.GetAll().WithRocketName("Falcon 9").WithOrbit(OrbitType.ISS).WithLandSuccess(true).Ascending().Execute();

            // Get all capsule types
            var capsuleTypes = oddity.Capsules.GetAll().Execute();

            // Get capsule which has been launched 2015-04-14 at 20:10
            var capsuleWithFilters = oddity.DetailedCapsules.GetAll().WithOriginalLaunch(new DateTime(2015, 4, 14, 20, 10, 0)).Execute();

            // Get all cores
            var allCores = oddity.DetailedCores.GetAll().Execute();

            // Get Roadster info
            var roadster = oddity.Roadster.Get().Execute();

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
```

# Why Oddity?
https://www.youtube.com/watch?v=iYYRH4apXDo