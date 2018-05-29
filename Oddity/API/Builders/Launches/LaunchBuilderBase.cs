using System;
using System.Net.Http;
using Oddity.API.Models.Launch.Rocket.FirstStage;
using Oddity.API.Models.Launch.Rocket.SecondStage;
using Oddity.API.Models.Launchpad;
using Oddity.API.Models.Rocket;
using Oddity.Helpers;

namespace Oddity.API.Builders.Launches
{
    /// <summary>
    /// Represents an abstract class for all launch builders. Contains methods to the detailed filters that aren't present
    /// in other builders.
    /// </summary>
    /// <typeparam name="TBuilder">The launch builder type.</typeparam>
    /// <typeparam name="TReturn">The returned object type."/>.</typeparam>
    public abstract class LaunchBuilderBase<TBuilder, TReturn> : BuilderBase<TReturn> where TBuilder: LaunchBuilderBase<TBuilder, TReturn> where TReturn: class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchBuilderBase{TBuilder,TReturn}"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="deserializationError">The deserialization error delegate.</param>
        protected LaunchBuilderBase(HttpClient httpClient, DeserializationError deserializationError) : base(httpClient, deserializationError)
        {

        }

        /// <summary>
        /// Sorts launches ascending. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved ordering filter.
        /// </summary>
        /// <returns>The launch builder.</returns>
        public TBuilder Ascending()
        {
            AddFilter("order", "asc");
            return (TBuilder)this;
        }

        /// <summary>
        /// Sorts launches descending. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved ordering filter.
        /// </summary>
        /// <returns>The launch builder.</returns>
        public TBuilder Descending()
        {
            AddFilter("order", "desc");
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by date range. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved date range filter.
        /// </summary>
        /// <param name="from">Filter from the specified date.</param>
        /// <param name="to">Filter to the specified date.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithRange(DateTime from, DateTime to)
        {
            AddFilter("start", from, DateFormatType.Short);
            AddFilter("end", to, DateFormatType.Short);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by flight number. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved flight number filter.
        /// </summary>
        /// <param name="flightNumber">The launch flight number.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithFlightNumber(int flightNumber)
        {
            AddFilter("flight_number", flightNumber);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by launch year. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved launch year filter.
        /// </summary>
        /// <param name="year">The launch year.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithLaunchYear(int year)
        {
            AddFilter("launch_year", year);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by rocket id. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved rocket id filter.
        /// </summary>
        /// <param name="rocketId">The rocket ID (Falcon1, Falcon9, etc).</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithRocketId(RocketId rocketId)
        {
            AddFilter("rocket_id", rocketId.GetEnumMemberAttributeValue(rocketId));
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by rocket name. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved rocket name filter.
        /// </summary>
        /// <param name="rocketName">The rocket name (Falcon 1, Falcon 9, etc).</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithRocketName(string rocketName)
        {
            AddFilter("rocket_name", rocketName);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by rocket type. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved rocket type filter.
        /// </summary>
        /// <param name="rocketType">The rocket type (v1.0, FT, etc).</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithRocketType(string rocketType)
        {
            AddFilter("rocket_type", rocketType);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by core serial. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved core serial filter.
        /// </summary>
        /// <param name="coreSerial">The core serial (B0005, B1012, etc).</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithCoreSerial(string coreSerial)
        {
            AddFilter("core_serial", coreSerial);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by capsule serial. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved capsule serial filter.
        /// </summary>
        /// <param name="capsuleSerial">The rocket serial (C110, C113, etc).</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithCapsuleSerial(string capsuleSerial)
        {
            AddFilter("cap_serial", capsuleSerial);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by core flight number. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved core flight number filter.
        /// </summary>
        /// <param name="flightNumber">The core flight number.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithCoreFlightNumber(int flightNumber)
        {
            AddFilter("core_flight", flightNumber);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by block number. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved block number filter.
        /// </summary>
        /// <param name="blockNumber">The core block number.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithBlockNumber(int blockNumber)
        {
            AddFilter("block", blockNumber);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by core reuse. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved core reuse filter.
        /// </summary>
        /// <param name="coreReuse">The core reuse.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithCoreReuse(bool coreReuse)
        {
            AddFilter("core_reuse", coreReuse);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by first side core reuse. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved first side core reuse filter.
        /// </summary>
        /// <param name="sideCore1Reuse">The first side core reuse.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithSideCore1Reuse(bool sideCore1Reuse)
        {
            AddFilter("side_core1_reuse", sideCore1Reuse);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by second core reuse. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved second core reuse filter.
        /// </summary>
        /// <param name="sideCore2Reuse">The second side core reuse.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithSideCore2Reuse(bool sideCore2Reuse)
        {
            AddFilter("side_core2_reuse", sideCore2Reuse);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by fairings reuse. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved fairings reuse filter.
        /// </summary>
        /// <param name="fairingsReuse">The fairings reuse.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithFairingsReuse(bool fairingsReuse)
        {
            AddFilter("fairings_reuse", fairingsReuse);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by capsule reuse. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved capsule reuse filter.
        /// </summary>
        /// <param name="capsuleReuse">The capsule reuse.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithCapsuleReuse(bool capsuleReuse)
        {
            AddFilter("capsule_reuse", capsuleReuse);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by site id. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved site id filter.
        /// </summary>
        /// <param name="siteId">The launchpad ID (CcafsSlc40, Stls, etc).</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithSiteId(LaunchpadId siteId)
        {
            AddFilter("site_id", siteId.GetEnumMemberAttributeValue(siteId));
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by site name. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved site name filter.
        /// </summary>
        /// <param name="siteName">The launchpad name (KSC LC 39A, etc).</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithSiteName(string siteName)
        {
            AddFilter("site_name", siteName);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by long site name. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved long site name filter.
        /// </summary>
        /// <param name="longSiteName">The long launchpad name (Kennedy Space Center Historic Launch Complex 39A, etc).</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithLongSiteName(string longSiteName)
        {
            AddFilter("site_name_long", longSiteName);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by payload id. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved payload id filter.
        /// </summary>
        /// <param name="payloadId">The payload ID (RatSat, Iridium NEXT 2, etc).</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithPayloadId(string payloadId)
        {
            AddFilter("payload_id", payloadId);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by customer name. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved customer name filter.
        /// </summary>
        /// <param name="customer">The customer (Iridium Communications, USAF, etc).</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithCustomer(string customer)
        {
            AddFilter("customer", customer);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by payload type. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved payload type filter.
        /// </summary>
        /// <param name="payloadType">The customer (Satellite, Dragon 1.0, etc).</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithPayloadType(string payloadType)
        {
            AddFilter("payload_type", payloadType);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by orbit type. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved orbit type filter.
        /// </summary>
        /// <param name="orbit">The orbit type (LEO, ISS, etc).</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithOrbit(OrbitType orbit)
        {
            AddFilter("orbit", orbit.GetEnumMemberAttributeValue(orbit));
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by launch success. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved launch success filter.
        /// </summary>
        /// <param name="launchSuccess">The launch success.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithLaunchSuccess(bool launchSuccess)
        {
            AddFilter("launch_success", launchSuccess);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by reused flag. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved reused flag filter.
        /// </summary>
        /// <param name="reused">The reused.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithReused(bool reused)
        {
            AddFilter("reused", reused);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by success lands. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved success lands filter.
        /// </summary>
        /// <param name="reused">The land success.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithLandSuccess(bool landSuccess)
        {
            AddFilter("land_success", landSuccess);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by landing type. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved landing type filter.
        /// </summary>
        /// <param name="landingType">The landing type (ASDS, Ocean, etc).</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithLandingType(LandingType landingType)
        {
            AddFilter("landing_type", landingType.GetEnumMemberAttributeValue(landingType));
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by landing vehicle. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved landing vehicle filter.
        /// </summary>
        /// <param name="landingVehicle">The landing vehicle (OCISLY, LZ1, etc).</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithLandingVehicle(LandingVehicleType landingVehicle)
        {
            AddFilter("landing_vehicle", landingVehicle.GetEnumMemberAttributeValue(landingVehicle));
            return (TBuilder)this;
        }
    }
}
