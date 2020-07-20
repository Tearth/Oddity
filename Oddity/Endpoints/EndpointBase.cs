using Oddity.Cache;
using Oddity.Models;

namespace Oddity.Endpoints
{
    /// <summary>
    /// Represents a base class for all endpoints.
    /// </summary>
    /// <typeparam name="TData">Type of the data returned from API.</typeparam>
    public abstract class EndpointBase<TData> where TData : ModelBase, IIdentifiable
    {
        protected readonly OddityCore Context;
        protected readonly CacheService<TData> Cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointBase{TData}"/> class.
        /// </summary>
        /// <param name="context">The Oddity context used to interact with API.</param>
        /// <param name="cacheLifetime">The builder delegates container.</param>
        protected EndpointBase(OddityCore context, int cacheLifetime)
        {
            Context = context;
            Cache = new CacheService<TData>(cacheLifetime);
        }

        /// <summary>
        /// Clears all cached data.
        /// </summary>
        /// <returns>Number of purged cached elements.</returns>
        public int ClearCache()
        {
            return Cache.Clear();
        }
    }
}
