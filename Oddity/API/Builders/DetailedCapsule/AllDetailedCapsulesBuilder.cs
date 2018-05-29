using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Oddity.API.Builders.Capsule;
using Oddity.API.Builders.Capsule.Exceptions;
using Oddity.API.Models.Capsule;
using Oddity.API.Models.DetailedCapsule;
using Oddity.Helpers;

namespace Oddity.API.Builders.DetailedCapsule
{
    /// <summary>
    /// Represents a set of methods to filter detailed capsule information and download them from API.
    /// </summary>
    public class AllDetailedCapsulesBuilder : BuilderBase<List<DetailedCapsuleInfo>>
    {
        private const string CapsuleInfoEndpoint = "parts/caps";

        /// <summary>
        /// Initializes a new instance of the <see cref="AllDetailedCapsulesBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="deserializationError">The deserialization error delegate.</param>
        public AllDetailedCapsulesBuilder(HttpClient httpClient, DeserializationError deserializationError) : base(httpClient, deserializationError)
        {

        }

        /// <summary>
        /// Filters launches by capsule serial. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved capsule serial filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public AllDetailedCapsulesBuilder WithCapsuleSerial(string capsuleSerial)
        {
            AddFilter("capsule_serial", capsuleSerial);
            return this;
        }

        /// <summary>
        /// Filters launches by capsule id. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved capsule id filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public AllDetailedCapsulesBuilder WithCapsuleId(CapsuleId capsuleId)
        {
            AddFilter("capsule_serial", capsuleId.GetEnumMemberAttributeValue(capsuleId));
            return this;
        }

        /// <summary>
        /// Filters launches by capsule status. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved capsule status filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public AllDetailedCapsulesBuilder WithStatus(DetailedCapsuleStatus status)
        {
            AddFilter("status", status.GetEnumMemberAttributeValue(status));
            return this;
        }

        /// <summary>
        /// Filters launches by original launch. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved original launch filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public AllDetailedCapsulesBuilder WithOriginalLaunch(DateTime originalLaunch)
        {
            AddFilter("original_launch", originalLaunch);
            return this;
        }

        /// <summary>
        /// Filters launches by missions. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved missions filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public AllDetailedCapsulesBuilder WithMission(string mission)
        {
            AddFilter("missions", mission);
            return this;
        }

        /// <summary>
        /// Filters launches by landings count. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved landings count filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public AllDetailedCapsulesBuilder WithLandingsCount(int landingsCount)
        {
            AddFilter("landings", landingsCount);
            return this;
        }

        /// <summary>
        /// Filters launches by capsule type. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved capsule type filter.
        /// </summary>
        /// <returns>The builder.</returns>
        public AllDetailedCapsulesBuilder WithCapsuleType(string capsuleType)
        {
            AddFilter("type", capsuleType);
            return this;
        }

        /// <inheritdoc />
        public override List<DetailedCapsuleInfo> Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <inheritdoc />
        public override async Task<List<DetailedCapsuleInfo>> ExecuteAsync()
        {
            var link = BuildLink(CapsuleInfoEndpoint);
            return await RequestForObject(link);
        }
    }
}
