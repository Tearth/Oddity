using System;
using System.Collections.Generic;
using Oddity.Models;

namespace Oddity.Cache
{
    /// <summary>
    /// Represents an cache service used to manage cached data.
    /// </summary>
    /// <typeparam name="TData">Type of the cached data.</typeparam>
    public class CacheService<TData> where TData : ModelBase, IIdentifiable
    {
        /// <summary>
        /// Gets or sets the number of seconds after which the data should be updated (retrieved from API again).
        /// </summary>
        public int LifetimeSeconds { get; set; }

        private readonly Dictionary<string, CacheItem<TData>> _cachedData;
        private readonly Dictionary<string, CacheItem<List<TData>>> _cachedLists;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheService{TData}"/> class.
        /// </summary>
        /// <param name="lifetimeSeconds">The number of seconds after which the data should be updated (retrieved from API again).</param>
        public CacheService(int lifetimeSeconds)
        {
            LifetimeSeconds = lifetimeSeconds;

            _cachedData = new Dictionary<string, CacheItem<TData>>();
            _cachedLists = new Dictionary<string, CacheItem<List<TData>>>();
        }

        /// <summary>
        /// Checks if there is a cached model with the specified parameter. If yes, then appropriate flag is returned and
        /// out parameter is filled.
        /// </summary>
        /// <param name="data">Out parameter which will be used to return cached model (or null if the parameter is new).</param>
        /// <param name="parameter">The parameter used for the identification of the cached model.</param>
        /// <returns>True if the cached model has been found and returned in the out parameter, otherwise false.</returns>
        public bool GetIfAvailable(out TData data, string parameter)
        {
            if (_cachedData.ContainsKey(parameter))
            {
                var item = _cachedData[parameter];
                if ((DateTime.Now - item.UpdateTime).TotalSeconds < LifetimeSeconds)
                {
                    data = item.Data;
                    return true;
                }
            }

            data = default;
            return false;
        }

        /// <summary>
        /// Checks if there is a cached list of models with the specified parameter. If yes, then appropriate flag is returned and
        /// out parameter is filled.
        /// </summary>
        /// <param name="data">Out parameter which will be used to return cached list of models (or null if the parameter is new).</param>
        /// <param name="parameter">The parameter used for the identification of the cached list of models.</param>
        /// <returns>True if the cached list of models has been found and returned in the out parameter, otherwise false.</returns>
        public bool GetListIfAvailable(out List<TData> data, string parameter)
        {
            if (_cachedLists.ContainsKey(parameter))
            {
                var item = _cachedLists[parameter];
                if ((DateTime.Now - item.UpdateTime).TotalSeconds < LifetimeSeconds)
                {
                    data = item.Data;
                    return true;
                }
            }

            data = default;
            return false;
        }

        /// <summary>
        /// Updates a model with the specified parameter.
        /// </summary>
        /// <param name="data">The model which will be cached.</param>
        /// <param name="parameter">The parameter used for model identification.</param>
        public void Update(TData data, string parameter)
        {
            _cachedData[parameter] = new CacheItem<TData>(data, DateTime.Now);
        }

        /// <summary>
        /// Updates a list of models with the specified parameter.
        /// </summary>
        /// <param name="data">The list of models which will be cached.</param>
        /// <param name="parameter">The parameter used for list of models identification.</param>
        public void UpdateList(List<TData> data, string parameter)
        {
            _cachedLists[parameter] = new CacheItem<List<TData>>(data, DateTime.Now);

            foreach (var item in data)
            {
                Update(item, item.Id);
            }
        }

        /// <summary>
        /// Clears all cached data.
        /// </summary>
        public void Clear()
        {
            _cachedLists.Clear();
            _cachedLists.Clear();
        }
    }
}
