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
    /// Represents a set of methods to filter all upcoming capsules information and download them from API.
    /// </summary>
    public class UpcomingCapsulesBuilder : CapsuleBuilderBase<UpcomingCapsulesBuilder, List<CapsuleInfo>>
    {
        private const string CapsuleInfoEndpoint = "capsules/upcoming";

        /// <summary>
        /// Initializes a new instance of the <see cref="UpcomingCapsulesBuilder"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public UpcomingCapsulesBuilder(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer) : base(httpClient, builderDelegatesContainer)
        {

        }

        /// <inheritdoc />
        protected override async Task<List<CapsuleInfo>> ExecuteBuilder()
        {
            var link = BuildLink(CapsuleInfoEndpoint);
            return await SendRequestToApi(link).ConfigureAwait(false);
        }
    }
}