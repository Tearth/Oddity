using System;
using System.Net.Http;
using Oddity.API.Models.Launch.Rocket.FirstStage;
using Oddity.API.Models.Launch.Rocket.SecondStage;
using Oddity.API.Models.Launchpad;
using Oddity.API.Models.Rocket;
using Oddity.Helpers;

namespace Oddity.API.Builders.Launch
{
    public abstract class LaunchBuilderBase<T> : BuilderBase where T: LaunchBuilderBase<T>
    {
        protected LaunchBuilderBase(HttpClient httpClient) : base(httpClient)
        {

        }

        public T Ascending()
        {
            AddFilter("order", "asc");
            return (T)this;
        }

        public T Descending()
        {
            AddFilter("order", "desc");
            return (T)this;
        }

        public T WithRange(DateTime from, DateTime to)
        {
            AddFilter("start", from);
            AddFilter("end", to);
            return (T)this;
        }

        public T WithFlightNumber(int flightNumber)
        {
            AddFilter("flight_number", flightNumber);
            return (T)this;
        }

        public T WithLaunchYear(int year)
        {
            AddFilter("launch_year", year);
            return (T)this;
        }

        public T WithRocketId(RocketId rocketId)
        {
            AddFilter("rocket_id", rocketId.GetEnumMemberAttrValue(rocketId));
            return (T)this;
        }

        public T WithRocketName(string rocketName)
        {
            AddFilter("rocket_name", rocketName);
            return (T)this;
        }

        public T WithRocketType(string rocketType)
        {
            AddFilter("rocket_type", rocketType);
            return (T)this;
        }

        public T WithCoreSerial(string coreSerial)
        {
            AddFilter("core_serial", coreSerial);
            return (T)this;
        }

        public T WithCapsuleSerial(string capsuleSerial)
        {
            AddFilter("cap_serial", capsuleSerial);
            return (T)this;
        }

        public T WithCoreFlightNumber(int flightNumber)
        {
            AddFilter("core_flight", flightNumber);
            return (T)this;
        }

        public T WithBlockNumber(int blockNumber)
        {
            AddFilter("block", blockNumber);
            return (T)this;
        }

        public T WithCoreReuse(bool coreReuse)
        {
            AddFilter("core_reuse", coreReuse);
            return (T)this;
        }

        public T WithSideCore1Reuse(bool sideCore1Reuse)
        {
            AddFilter("side_core1_reuse", sideCore1Reuse);
            return (T)this;
        }

        public T WithSideCore2Reuse(bool sideCore2Reuse)
        {
            AddFilter("side_core2_reuse", sideCore2Reuse);
            return (T)this;
        }

        public T WithFairingsReuse(bool fairingsReuse)
        {
            AddFilter("fairings_reuse", fairingsReuse);
            return (T)this;
        }

        public T WithCapsuleReuse(bool capsuleReuse)
        {
            AddFilter("capsule_reuse", capsuleReuse);
            return (T)this;
        }

        public T WithSiteId(LaunchpadId siteId)
        {
            AddFilter("site_id", siteId.GetEnumMemberAttrValue(siteId));
            return (T)this;
        }

        public T WithSiteName(string siteName)
        {
            AddFilter("site_name", siteName);
            return (T)this;
        }

        public T WithLongSiteName(string longSiteName)
        {
            AddFilter("site_name_long", longSiteName);
            return (T)this;
        }

        public T WithPayloadId(string payloadId)
        {
            AddFilter("payload_id", payloadId);
            return (T)this;
        }

        public T WithCustomer(string customer)
        {
            AddFilter("customer", customer);
            return (T)this;
        }

        public T WithPayloadType(string payloadType)
        {
            AddFilter("payload_type", payloadType);
            return (T)this;
        }

        public T WithOrbit(OrbitType orbit)
        {
            AddFilter("orbit", orbit.GetEnumMemberAttrValue(orbit));
            return (T)this;
        }

        public T WithLaunchSuccess(bool launchSuccess)
        {
            AddFilter("launch_success", launchSuccess);
            return (T)this;
        }

        public T WithReused(bool reused)
        {
            AddFilter("reused", reused);
            return (T)this;
        }

        public T WithLandSuccess(bool landSuccess)
        {
            AddFilter("land_success", landSuccess);
            return (T)this;
        }

        public T WithLandingType(LandingType landingType)
        {
            AddFilter("landing_type", landingType.GetEnumMemberAttrValue(landingType));
            return (T)this;
        }

        public T WithLandingVehicle(LandingVehicleType landingVehicle)
        {
            AddFilter("landing_vehicle", landingVehicle.GetEnumMemberAttrValue(landingVehicle));
            return (T)this;
        }
    }
}
