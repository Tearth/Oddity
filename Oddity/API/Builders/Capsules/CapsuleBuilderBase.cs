using System;
using System.Net.Http;
using Oddity.API.Models.Capsule;
using Oddity.API.Models.Dragon;
using Oddity.Helpers;

namespace Oddity.API.Builders.Capsules
{
    /// <summary>
    /// Represents an abstract class for all capsule builders. Contains methods to the detailed filters that aren't present in other builders.
    /// </summary>
    /// <typeparam name="TBuilder">The launch builder type.</typeparam>
    /// <typeparam name="TReturn">The returned object type.</typeparam>
    public abstract class CapsuleBuilderBase<TBuilder, TReturn> : BuilderBase<TReturn> where TBuilder : CapsuleBuilderBase<TBuilder, TReturn> where TReturn : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CapsuleBuilderBase{TBuilder,TReturn}"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        protected CapsuleBuilderBase(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer) : base(httpClient, builderDelegatesContainer)
        {

        }

        /// <summary>
        /// Filters launches by capsule serial. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved capsule serial filter.
        /// </summary>
        /// <param name="capsuleSerial">The capsule serial (C101, C102, etc).</param>
        /// <returns>The capsules builder.</returns>
        public TBuilder WithCapsuleSerial(string capsuleSerial)
        {
            AddFilter("capsule_serial", capsuleSerial);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by capsule id. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved capsule id filter.
        /// </summary>
        /// <param name="capsuleId">The capsule id (Dragon 1, Dragon 2 etc).</param>
        /// <returns>The capsules builder.</returns>
        public TBuilder WithCapsuleId(DragonId capsuleId)
        {
            AddFilter("capsule_id", capsuleId.GetEnumMemberAttributeValue(capsuleId));
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by capsule status. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved capsule status filter.
        /// </summary>
        /// <param name="status">The capsule status (active, retired etc).</param>
        /// <returns>The capsules builder.</returns>
        public TBuilder WithStatus(CapsuleStatus status)
        {
            AddFilter("status", status.GetEnumMemberAttributeValue(status));
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by original launch. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved original launch filter.
        /// </summary>
        /// <param name="originalLaunch">The capsule original launch.</param>
        /// <returns>The capsules builder.</returns>
        public TBuilder WithOriginalLaunch(DateTime originalLaunch)
        {
            AddFilter("original_launch", originalLaunch, DateFormatType.Long);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by missions. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved missions filter.
        /// </summary>
        /// <param name="mission">The capsule mission (SpaceX CRS-8, ZUMA, etc).</param>
        /// <returns>The capsules builder.</returns>
        public TBuilder WithMission(string mission)
        {
            AddFilter("mission", mission);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by landings count. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved landings count filter.
        /// </summary>
        /// <param name="landingsCount">Landing count.</param>
        /// <returns>The capsules builder.</returns>
        public TBuilder WithLandingsCount(int landingsCount)
        {
            AddFilter("landings", landingsCount);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by capsule type. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved capsule type filter.
        /// </summary>
        /// <param name="capsuleType">The capsule type (Dragon 1.1, Dragon 2.0, etc).</param>
        /// <returns>The capsules builder.</returns>
        public TBuilder WithCapsuleType(string capsuleType)
        {
            AddFilter("type", capsuleType);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by reuse count. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved landings count filter.
        /// </summary>
        /// <param name="reuseCount">Reuse count.</param>
        /// <returns>The capsules builder.</returns>
        public TBuilder WithReuseCount(int reuseCount)
        {
            AddFilter("reuse_count", reuseCount);
            return (TBuilder)this;
        }
    }
}