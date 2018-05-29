using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.DetailedCore;
using Oddity.Helpers;

namespace Oddity.API.Builders.DetailedCores
{
    /// <summary>
    /// Represents a set of methods to filter detailed core information and download them from API.
    /// </summary>
    public class AllDetailedCoresBuilder : BuilderBase<List<DetailedCoreInfo>>
    {
        private const string CapsuleInfoEndpoint = "parts/cores";

        /// <summary>
        /// Initializes a new instance of the <see cref="AllDetailedCoresBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="deserializationError">The deserialization error delegate.</param>
        public AllDetailedCoresBuilder(HttpClient httpClient, DeserializationError deserializationError) : base(httpClient, deserializationError)
        {

        }

        /// <summary>
        /// Filters launches by core serial. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved core serial filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public AllDetailedCoresBuilder WithCoreSerial(string coreSerial)
        {
            AddFilter("core_serial", coreSerial);
            return this;
        }

        /// <summary>
        /// Filters launches by core block number. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved core block number filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public AllDetailedCoresBuilder WithBlock(int block)
        {
            AddFilter("block", block);
            return this;
        }

        /// <summary>
        /// Filters launches by core status. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved core status filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public AllDetailedCoresBuilder WithStatus(DetailedCoreStatus status)
        {
            AddFilter("status", status.GetEnumMemberAttributeValue(status));
            return this;
        }

        /// <summary>
        /// Filters launches by original launch. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved original launch filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public AllDetailedCoresBuilder WithOriginalLaunch(DateTime originalLaunch)
        {
            AddFilter("original_launch", originalLaunch);
            return this;
        }

        /// <summary>
        /// Filters launches by missions. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved missions filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public AllDetailedCoresBuilder WithMission(string mission)
        {
            AddFilter("missions", mission);
            return this;
        }

        /// <summary>
        /// Filters launches by RTLS attempt. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved RTLS attempt filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public AllDetailedCoresBuilder WithRtlsAttempt(bool rtlsAttempt)
        {
            AddFilter("rtls_attempt", rtlsAttempt);
            return this;
        }

        /// <summary>
        /// Filters launches by RTLS landing. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved RTLS landing filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public AllDetailedCoresBuilder WithRtlsLanding(int landings)
        {
            AddFilter("rtls_landings", landings);
            return this;
        }

        /// <summary>
        /// Filters launches by ASDS attempt. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved ASDS attempt filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public AllDetailedCoresBuilder WithAsdsAttempt(bool asdsAttempt)
        {
            AddFilter("asds_attempt", asdsAttempt);
            return this;
        }

        /// <summary>
        /// Filters launches by ASDS landing. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved ASDS landing filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public AllDetailedCoresBuilder WithAsdsLanding(int landings)
        {
            AddFilter("asds_landings", landings);
            return this;
        }

        /// <summary>
        /// Filters launches by water landing. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved water landing filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public AllDetailedCoresBuilder WithWaterLanding(bool waterLanding)
        {
            AddFilter("water_landing", waterLanding);
            return this;
        }

        /// <inheritdoc />
        public override List<DetailedCoreInfo> Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <inheritdoc />
        public override async Task<List<DetailedCoreInfo>> ExecuteAsync()
        {
            var link = BuildLink(CapsuleInfoEndpoint);
            return await RequestForObject(link);
        }
    }
}
