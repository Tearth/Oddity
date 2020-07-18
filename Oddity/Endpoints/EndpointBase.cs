using Oddity.Cache;
using Oddity.Models;

namespace Oddity.Endpoints
{
    public abstract class EndpointBase<T> where T : ModelBase, IIdentifiable
    {
        protected readonly OddityCore Context;
        protected readonly CacheService<T> Cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointBase"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        protected EndpointBase(OddityCore context, int cacheLifetime)
        {
            Context = context;
            Cache = new CacheService<T>(cacheLifetime);
        }

        public void ClearCache()
        {
            Cache.Clear();
        }
    }
}
