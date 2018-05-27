using System;
using System.Net.Http;
using Oddity.API.Models.Launch.Rocket.FirstStage;
using Oddity.API.Models.Launch.Rocket.SecondStage;
using Oddity.API.Models.Launchpad;
using Oddity.API.Models.Rocket;
using Oddity.Helpers;

namespace Oddity.API.Builders.Launch
{
    /// <summary>
    /// Represents an abstract class for all launch builders. Contains methods to the detailed filters that aren't present
    /// in other builders.
    /// </summary>
    /// <typeparam name="T">The launch builder type.</typeparam>
    /// <typeparam name="R">The returned object type."/>.</typeparam>
    public abstract class LaunchBuilderBase<T, R> : BuilderBase<R> where T: LaunchBuilderBase<T, R> where R: class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchBuilderBase{T,R}"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        protected LaunchBuilderBase(HttpClient httpClient) : base(httpClient)
        {

        }

        /// <summary>
        /// Sorts launches ascending. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved ordering filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T Ascending()
        {
            AddFilter("order", "asc");
            return (T)this;
        }

        /// <summary>
        /// Sorts launches descending. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved ordering filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T Descending()
        {
            AddFilter("order", "desc");
            return (T)this;
        }

        /// <summary>
        /// Filters launches by date range. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved date range filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithRange(DateTime from, DateTime to)
        {
            AddFilter("start", from);
            AddFilter("end", to);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by flight number. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved flight number filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithFlightNumber(int flightNumber)
        {
            AddFilter("flight_number", flightNumber);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by launch year. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved launch year filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithLaunchYear(int year)
        {
            AddFilter("launch_year", year);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by rocket id. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved rocket id filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithRocketId(RocketId rocketId)
        {
            AddFilter("rocket_id", rocketId.GetEnumMemberAttributeValue(rocketId));
            return (T)this;
        }

        /// <summary>
        /// Filters launches by rocket name. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved rocket name filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithRocketName(string rocketName)
        {
            AddFilter("rocket_name", rocketName);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by rocket type. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved rocket type filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithRocketType(string rocketType)
        {
            AddFilter("rocket_type", rocketType);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by core serial. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved core serial filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithCoreSerial(string coreSerial)
        {
            AddFilter("core_serial", coreSerial);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by capsule serial. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved capsule serial filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithCapsuleSerial(string capsuleSerial)
        {
            AddFilter("cap_serial", capsuleSerial);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by core flight number. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved core flight number filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithCoreFlightNumber(int flightNumber)
        {
            AddFilter("core_flight", flightNumber);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by block number. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved block number filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithBlockNumber(int blockNumber)
        {
            AddFilter("block", blockNumber);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by core reuse. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved core reuse filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithCoreReuse(bool coreReuse)
        {
            AddFilter("core_reuse", coreReuse);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by first side core reuse. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved first side core reuse filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithSideCore1Reuse(bool sideCore1Reuse)
        {
            AddFilter("side_core1_reuse", sideCore1Reuse);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by second core reuse. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved second core reuse filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithSideCore2Reuse(bool sideCore2Reuse)
        {
            AddFilter("side_core2_reuse", sideCore2Reuse);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by fairings reuse. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved fairings reuse filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithFairingsReuse(bool fairingsReuse)
        {
            AddFilter("fairings_reuse", fairingsReuse);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by capsule reuse. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved capsule reuse filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithCapsuleReuse(bool capsuleReuse)
        {
            AddFilter("capsule_reuse", capsuleReuse);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by site id. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved site id filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithSiteId(LaunchpadId siteId)
        {
            AddFilter("site_id", siteId.GetEnumMemberAttributeValue(siteId));
            return (T)this;
        }

        /// <summary>
        /// Filters launches by site name. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved site name filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithSiteName(string siteName)
        {
            AddFilter("site_name", siteName);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by long site name. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved long site name filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithLongSiteName(string longSiteName)
        {
            AddFilter("site_name_long", longSiteName);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by payload id. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved payload id filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithPayloadId(string payloadId)
        {
            AddFilter("payload_id", payloadId);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by customer name. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved customer name filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithCustomer(string customer)
        {
            AddFilter("customer", customer);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by payload type. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved payload type filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithPayloadType(string payloadType)
        {
            AddFilter("payload_type", payloadType);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by orbit type. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved orbit type filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithOrbit(OrbitType orbit)
        {
            AddFilter("orbit", orbit.GetEnumMemberAttributeValue(orbit));
            return (T)this;
        }

        /// <summary>
        /// Filters launches by launch success. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved launch success filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithLaunchSuccess(bool launchSuccess)
        {
            AddFilter("launch_success", launchSuccess);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by reused flag. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved reused flag filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithReused(bool reused)
        {
            AddFilter("reused", reused);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by success lands. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved success lands filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithLandSuccess(bool landSuccess)
        {
            AddFilter("land_success", landSuccess);
            return (T)this;
        }

        /// <summary>
        /// Filters launches by landing type. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved landing type filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithLandingType(LandingType landingType)
        {
            AddFilter("landing_type", landingType.GetEnumMemberAttributeValue(landingType));
            return (T)this;
        }

        /// <summary>
        /// Filters launches by landing vehicle. Note that you have to call <see cref="BuilderBase{T}.Execute"/> or <see cref="BuilderBase{T}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved landing vehicle filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public T WithLandingVehicle(LandingVehicleType landingVehicle)
        {
            AddFilter("landing_vehicle", landingVehicle.GetEnumMemberAttributeValue(landingVehicle));
            return (T)this;
        }
    }
}
