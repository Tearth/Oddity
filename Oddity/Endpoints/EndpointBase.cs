using System.Net.Http;
using Oddity.Events;

namespace Oddity.Endpoints
{
    public abstract class EndpointBase
    {
        protected readonly HttpClient HttpClient;
        protected readonly OddityCore Context;
        protected readonly BuilderDelegates BuilderDelegates;

        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointBase"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        protected EndpointBase(HttpClient httpClient, OddityCore context, BuilderDelegates builderDelegates)
        {
            HttpClient = httpClient;
            Context = context;
            BuilderDelegates = builderDelegates;
        }
    }
}
