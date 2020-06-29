using System;
using System.Net.Http;
using Oddity.API.Models.Launch.Rocket.FirstStage;
using Oddity.API.Models.Launch.Rocket.SecondStage.Orbit;
using Oddity.API.Models.Launchpad;
using Oddity.API.Models.Rocket;
using Oddity.Helpers;

namespace Oddity.API.Builders.Launches
{
    /// <summary>
    /// Represents an abstract class for all launch builders. Contains methods to the detailed filters that aren't present in other builders.
    /// </summary>
    /// <typeparam name="TBuilder">The launch builder type.</typeparam>
    /// <typeparam name="TReturn">The returned object type.</typeparam>
    public abstract class LaunchBuilderBase<TBuilder, TReturn> : BuilderBase<TReturn> where TBuilder: LaunchBuilderBase<TBuilder, TReturn> where TReturn: class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchBuilderBase{TBuilder,TReturn}"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        protected LaunchBuilderBase(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer) : base(httpClient, builderDelegatesContainer)
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
        /// Filters launches by UTC launch date. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved launch date filter.
        /// </summary>
        /// <param name="launchDateUtc">The UTC launch date.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithLaunchDateUtc(DateTime launchDateUtc)
        {
            AddFilter("launch_date_utc", launchDateUtc, DateFormatType.Long);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by local launch date. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved launch date filter.
        /// </summary>
        /// <param name="launchDateLocal">The local launch date.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithLaunchDateLocal(DateTime launchDateLocal)
        {
            AddFilter("launch_date_local", launchDateLocal, DateFormatType.Long);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by "to be dated" flag. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved rocket id filter.
        /// </summary>
        /// <param name="toBeDated">"To be dated" flag.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithToBeDated(bool toBeDated)
        {
            AddFilter("tbd", toBeDated);
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
        /// Filters launches by a landing success. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved core serial filter.
        /// </summary>
        /// <param name="landSuccess">Land success flag.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithLandSuccess(bool landSuccess)
        {
            AddFilter("land_success", landSuccess);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by landing intention. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved core serial filter.
        /// </summary>
        /// <param name="landingIntent">Landing intention flag.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithLandingIntent(bool landingIntent)
        {
            AddFilter("landing_intent", landingIntent);
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
        /// Filters launches by grid fins presence. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved block number filter.
        /// </summary>
        /// <param name="gridFins">Grid fins presence flag.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithGridFins(bool gridFins)
        {
            AddFilter("gridfins", gridFins);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by legs presence. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved block number filter.
        /// </summary>
        /// <param name="legs">Legs presence flag.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithLegs(bool legs)
        {
            AddFilter("legs", legs);
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
        /// Filters launches by fairings reuse. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved fairings reuse filter.
        /// </summary>
        /// <param name="fairingsReuse">The fairings reuse.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithFairingsReuse(bool fairingsReuse)
        {
            AddFilter("fairings_reused", fairingsReuse);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by fairings recovery attempt. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved fairings reuse filter.
        /// </summary>
        /// <param name="fairingsRecoveryAttempt">Fairings recovery attempt flag.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithFairingsRecoveryAttempt(bool fairingsRecoveryAttempt)
        {
            AddFilter("fairings_recovery_attempt", fairingsRecoveryAttempt);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by fairings recovery result. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved fairings reuse filter.
        /// </summary>
        /// <param name="fairingsRecovered">Fairings recovery status flag.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithFairingsRecovered(bool fairingsRecovered)
        {
            AddFilter("fairings_recovered", fairingsRecovered);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by fairings ship name. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved fairings reuse filter.
        /// </summary>
        /// <param name="fairingsShip">Fairings ship name.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithFairingsShip(string fairingsShip)
        {
            AddFilter("fairings_ship", fairingsShip);
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
        /// Filters launches by payload's NORAD ID. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved payload id filter.
        /// </summary>
        /// <param name="noradId">The payload NORAD ID.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithNoradId(int noradId)
        {
            AddFilter("norad_id", noradId);
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
        /// Filters launches by customer's nationality. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved customer name filter.
        /// </summary>
        /// <param name="nationality">The payload's customer nationality.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithNationality(string nationality)
        {
            AddFilter("nationality", nationality);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by payload's manufacturer. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved customer name filter.
        /// </summary>
        /// <param name="manufacturer">The payload's manufacturer name.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithManufacturer(string manufacturer)
        {
            AddFilter("manufacturer", manufacturer);
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
        /// Filters launches by reference system. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved orbit type filter.
        /// </summary>
        /// <param name="referenceSystem">The reference system.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithReferenceSystem(string referenceSystem)
        {
            AddFilter("reference_system", referenceSystem);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by orbit regime. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved orbit type filter.
        /// </summary>
        /// <param name="regime">The orbit regime.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithRegime(string regime)
        {
            AddFilter("regime", regime);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by orbit longitude. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved orbit type filter.
        /// </summary>
        /// <param name="longitude">The orbit longitude.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithLongitude(double longitude)
        {
            AddFilter("longitude", longitude);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by orbit semi major axis. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved orbit type filter.
        /// </summary>
        /// <param name="semiMajorAxis">The orbit semi major axis in kilometers.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithSemiMajorAxisKilometers(double semiMajorAxis)
        {
            AddFilter("semi_major_axis_km", semiMajorAxis);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by orbit eccentricity. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved orbit type filter.
        /// </summary>
        /// <param name="eccentricity">The orbit eccentricity.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithEccentricity(double eccentricity)
        {
            AddFilter("eccentricity", eccentricity);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by orbit periapsis. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved orbit type filter.
        /// </summary>
        /// <param name="periapsis">The orbit periapsis in kilometers.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithPeriapsisKilometers(double periapsis)
        {
            AddFilter("periapsis_km", periapsis);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by orbit apoapsis. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved orbit type filter.
        /// </summary>
        /// <param name="apoapsis">The orbit apoapsis in kilometers.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithApoapsisKilometers(double apoapsis)
        {
            AddFilter("apoapsis_km", apoapsis);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by orbit inclination. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved orbit type filter.
        /// </summary>
        /// <param name="inclination">The orbit inclination.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithInclinationDegrees(double inclination)
        {
            AddFilter("inclination_deg", inclination);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by orbit period time. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved orbit type filter.
        /// </summary>
        /// <param name="period">The orbit period time in minutes.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithPeriodMinutes(double period)
        {
            AddFilter("period_min", period);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by orbit lifespan. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved orbit type filter.
        /// </summary>
        /// <param name="lifespan">The orbit lifespan in years.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithLifespanYears(double lifespan)
        {
            AddFilter("lifespan_years", lifespan);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by orbit epoch. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved orbit type filter.
        /// </summary>
        /// <param name="epoch">The orbit epoch.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithEpoch(DateTime epoch)
        {
            AddFilter("epoch", epoch);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by orbit mean motion. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved orbit type filter.
        /// </summary>
        /// <param name="meanMotion">The orbit mean motion.</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithMeanMotion(double meanMotion)
        {
            AddFilter("mean_motion", meanMotion);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by orbit RAAN. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved orbit type filter.
        /// </summary>
        /// <param name="raan">The orbit RAAN (right ascension of the ascending node).</param>
        /// <returns>The launch builder.</returns>
        public TBuilder WithRaan(double raan)
        {
            AddFilter("raan", raan);
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
    }
}