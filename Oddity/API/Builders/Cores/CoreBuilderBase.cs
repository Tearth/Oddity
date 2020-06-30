using System;
using System.Net.Http;
using Oddity.API.Models.DetailedCore;
using Oddity.Helpers;

namespace Oddity.API.Builders.Cores
{
    /// <summary>
    /// Represents an abstract class for all core builders. Contains methods to the detailed filters that aren't present in other builders.
    /// </summary>
    /// <typeparam name="TBuilder">The launch builder type.</typeparam>
    /// <typeparam name="TReturn">The returned object type.</typeparam>
    public abstract class CoreBuilderBase<TBuilder, TReturn> : BuilderBase<TReturn> where TBuilder : CoreBuilderBase<TBuilder, TReturn> where TReturn : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoreBuilderBase{TBuilder,TReturn}"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        protected CoreBuilderBase(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer) : base(httpClient, builderDelegatesContainer)
        {

        }

        /// <summary>
        /// Filters launches by core serial. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved core serial filter.
        /// </summary>
        /// <param name="coreSerial">The core serial (B0005, B1012, etc).</param>
        /// <returns>The all cores builder.</returns>
        public TBuilder WithCoreSerial(string coreSerial)
        {
            AddFilter("core_serial", coreSerial);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by core block number. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved core block number filter.
        /// </summary>
        /// <param name="block">The block number.</param>
        /// <returns>The all cores builder.</returns>
        public TBuilder WithBlock(int block)
        {
            AddFilter("block", block);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by core status. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved core status filter.
        /// </summary>
        /// <param name="status">The core status (active, destroyed, etc).</param>
        /// <returns>The all cores builder.</returns>
        public TBuilder WithStatus(CoreStatus status)
        {
            AddFilter("status", status.GetEnumMemberAttributeValue(status));
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by original launch. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved original launch filter.
        /// </summary>
        /// <param name="originalLaunch">The core original launch.</param>
        /// <returns>vThe all cores builder.</returns>
        public TBuilder WithOriginalLaunch(DateTime originalLaunch)
        {
            AddFilter("original_launch", originalLaunch, DateFormatType.Long);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by missions. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved missions filter.
        /// </summary>
        /// <param name="mission">The core mission.</param>
        /// <returns>The all cores builder.</returns>
        public TBuilder WithMission(string mission)
        {
            AddFilter("mission", mission);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by RTLS landing. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved RTLS landing filter.
        /// </summary>
        /// <param name="rtlsLandings">The core RTLS (return to launch site) landings count.</param>
        /// <returns>The all cores builder.</returns>
        public TBuilder WithRtlsLanding(int rtlsLandings)
        {
            AddFilter("rtls_landings", rtlsLandings);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by ASDS landing. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved ASDS landing filter.
        /// </summary>
        /// <param name="asdsLandings">The core ASDS (autonomous spaceport drone ship) landings count.</param>
        /// <returns>The all cores builder.</returns>
        public TBuilder WithAsdsLanding(int asdsLandings)
        {
            AddFilter("asds_landings", asdsLandings);
            return (TBuilder)this;
        }

        /// <summary>
        /// Filters launches by water landing. Note that you have to call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/>
        /// to get result from the API. Every next call of this method will override previously saved water landing filter.
        /// </summary>
        /// <param name="waterLanding">The core water landing.</param>
        /// <returns>The all cores builder.</returns>
        public TBuilder WithWaterLanding(bool waterLanding)
        {
            AddFilter("water_landing", waterLanding);
            return (TBuilder)this;
        }
    }
}