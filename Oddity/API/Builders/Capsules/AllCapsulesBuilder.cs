using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.Capsule;
using Oddity.API.Models.Dragon;
using Oddity.Helpers;

namespace Oddity.API.Builders.Capsules
{
    /// <summary>
    /// Represents a set of methods to filter all capsules information and download them from API.
    /// </summary>
    public class AllCapsulesBuilder : BuilderBase<List<CapsuleInfo>>
    {
        private const string CapsuleInfoEndpoint = "capsules";

        /// <summary>
        /// Initializes a new instance of the <see cref="AllCapsulesBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public AllCapsulesBuilder(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer) : base(httpClient, builderDelegatesContainer)
        {

        }

        /// <summary>
        /// Filters launches by capsule serial. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved capsule serial filter.
        /// </summary>
        /// <param name="capsuleSerial">The capsule serial (C101, C102, etc).</param>
        /// <returns>The capsules builder.</returns>
        public AllCapsulesBuilder WithCapsuleSerial(string capsuleSerial)
        {
            AddFilter("capsule_serial", capsuleSerial);
            return this;
        }

        /// <summary>
        /// Filters launches by capsule id. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved capsule id filter.
        /// </summary>
        /// <param name="capsuleId">The capsule id (Dragon 1, Dragon 2 etc).</param>
        /// <returns>The capsules builder.</returns>
        public AllCapsulesBuilder WithCapsuleId(DragonId capsuleId)
        {
            AddFilter("capsule_id", capsuleId.GetEnumMemberAttributeValue(capsuleId));
            return this;
        }

        /// <summary>
        /// Filters launches by capsule status. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved capsule status filter.
        /// </summary>
        /// <param name="status">The capsule status (active, retired etc).</param>
        /// <returns>The capsules builder.</returns>
        public AllCapsulesBuilder WithStatus(CapsuleStatus status)
        {
            AddFilter("status", status.GetEnumMemberAttributeValue(status));
            return this;
        }

        /// <summary>
        /// Filters launches by original launch. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved original launch filter.
        /// </summary>
        /// <param name="originalLaunch">The capsule original launch.</param>
        /// <returns>The capsules builder.</returns>
        public AllCapsulesBuilder WithOriginalLaunch(DateTime originalLaunch)
        {
            AddFilter("original_launch", originalLaunch, DateFormatType.Long);
            return this;
        }

        /// <summary>
        /// Filters launches by missions. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved missions filter.
        /// </summary>
        /// <param name="mission">The capsule mission (SpaceX CRS-8, ZUMA, etc).</param>
        /// <returns>The capsules builder.</returns>
        public AllCapsulesBuilder WithMission(string mission)
        {
            AddFilter("mission", mission);
            return this;
        }

        /// <summary>
        /// Filters launches by landings count. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved landings count filter.
        /// </summary>
        /// <param name="landingsCount">Landing count.</param>
        /// <returns>The capsules builder.</returns>
        public AllCapsulesBuilder WithLandingsCount(int landingsCount)
        {
            AddFilter("landings", landingsCount);
            return this;
        }

        /// <summary>
        /// Filters launches by capsule type. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved capsule type filter.
        /// </summary>
        /// <param name="capsuleType">The capsule type (Dragon 1.1, Dragon 2.0, etc).</param>
        /// <returns>The capsules builder.</returns>
        public AllCapsulesBuilder WithCapsuleType(string capsuleType)
        {
            AddFilter("type", capsuleType);
            return this;
        }

        /// <summary>
        /// Filters launches by reuse count. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved landings count filter.
        /// </summary>
        /// <param name="reuseCount">Reuse count.</param>
        /// <returns>The capsules builder.</returns>
        public AllCapsulesBuilder WithReuseCount(int reuseCount)
        {
            AddFilter("reuse_count", reuseCount);
            return this;
        }

        /// <inheritdoc />
        protected override async Task<List<CapsuleInfo>> ExecuteBuilder()
        {
            var link = BuildLink(CapsuleInfoEndpoint);
            return await SendRequestToApi(link).ConfigureAwait(false);
        }
    }
}
