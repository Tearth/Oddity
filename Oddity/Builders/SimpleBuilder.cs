﻿using System.Threading.Tasks;
using Oddity.Cache;
using Oddity.Models;

namespace Oddity.Builders
{
    /// <summary>
    /// Represents a simple builder used to retrieve data without any filters.
    /// </summary>
    /// <typeparam name="TReturn">Type which will be returned after successful API request.</typeparam>
    public class SimpleBuilder<TReturn> : BuilderBase<TReturn> where TReturn : ModelBase, IIdentifiable, new()
    {
        private readonly CacheService<TReturn> _cache;
        private readonly string _endpoint;
        private readonly string _id;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleBuilder{TReturn}"/> class.
        /// </summary>
        /// <param name="context">The Oddity context used to interact with API.</param>
        /// <param name="cache">Cache service used to speed up requests.</param>
        /// <param name="endpoint">The endpoint used in this instance to retrieve data from API.</param>
        /// <param name="id">The ID of the specified object to retrieve from API.</param>
        public SimpleBuilder(OddityCore context, CacheService<TReturn> cache, string endpoint, string id) : base(context)
        {
            _cache = cache;
            _endpoint = endpoint;
            _id = id;
        }

        /// <inheritdoc />
        public override TReturn Execute()
        {
            return ExecuteAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public override bool Execute(TReturn model)
        {
            return ExecuteAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public override async Task<TReturn> ExecuteAsync()
        {
            var model = new TReturn();
            if (await ExecuteAsync(model))
            {
                return model;
            }

            return null;
        }

        /// <inheritdoc />
        public override async Task<bool> ExecuteAsync(TReturn model)
        {
            if (_id == null)
            {
                return false;
            }

            var cacheId = _id != "" ? _id : _endpoint;
            if (Context.CacheEnabled && _cache.GetIfAvailable(out var data, cacheId))
            {
                data.CopyTo(model);

                if (Context.StatisticsEnabled)
                {
                    Context.Statistics.CacheHits++;
                }

                return true;
            }

            var content = await GetResponseFromEndpoint($"{_endpoint}/{_id}");
            if (content == null)
            {
                return false;
            }

            DeserializeJson(content, model);
            model.SetContext(Context);

            if (Context.CacheEnabled)
            {
                _cache.Update(model, cacheId);

                if (Context.StatisticsEnabled)
                {
                    Context.Statistics.CacheUpdates++;
                }
            }

            return true;
        }
    }
}
