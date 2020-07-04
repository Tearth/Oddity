using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Oddity.API.Models.DetailedCore;
using Oddity.Helpers;

namespace Oddity.API.Builders.Cores
{
    /// <summary>
    /// Represents a set of methods to filter all cores information and download them from API.
    /// </summary>
    public class AllCoresBuilder : CoreBuilderBase<AllCoresBuilder, List<CoreInfo>>
    {
        private const string CapsuleInfoEndpoint = "cores";

        /// <summary>
        /// Initializes a new instance of the <see cref="AllCoresBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public AllCoresBuilder(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer) : base(httpClient, builderDelegatesContainer)
        {

        }

        /// <inheritdoc />
        protected override async Task<List<CoreInfo>> ExecuteBuilder()
        {
            var link = BuildLink(CapsuleInfoEndpoint);
            return await SendRequestToApi(link).ConfigureAwait(false);
        }
    }
}
