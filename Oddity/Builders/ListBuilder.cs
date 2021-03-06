﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Oddity.Cache;
using Oddity.Models;

namespace Oddity.Builders
{
    /// <summary>
    /// Represents a list builder used to retrieve data (collection of objects) without any filters.
    /// </summary>
    /// <typeparam name="TReturn">Type which will be returned after successful API request.</typeparam>
    public class ListBuilder<TReturn> : BuilderBase<List<TReturn>> where TReturn : ModelBase, IIdentifiable, new()
    {
        private readonly CacheService<TReturn> _cache;
        private readonly string _endpoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListBuilder{TReturn}"/> class.
        /// </summary>
        /// <param name="context">The Oddity context used to interact with API.</param>
        /// <param name="cache">Cache service used to speed up requests.</param>
        /// <param name="endpoint">The endpoint used in this instance to retrieve data from API.</param>
        public ListBuilder(OddityCore context, CacheService<TReturn> cache, string endpoint) : base(context)
        {
            _cache = cache;
            _endpoint = endpoint;
        }

        /// <inheritdoc />
        public override List<TReturn> Execute()
        {
            return ExecuteAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public override bool Execute(List<TReturn> model)
        {
            return ExecuteAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public override async Task<List<TReturn>> ExecuteAsync()
        {
            var model = new List<TReturn>();
            await ExecuteAsync(model);

            return model;
        }

        /// <inheritdoc />
        public override async Task<bool> ExecuteAsync(List<TReturn> models)
        {
            if (Context.CacheEnabled && _cache.GetListIfAvailable(out var list, _endpoint))
            {
                models.AddRange(list);

                if (Context.StatisticsEnabled)
                {
                    Context.Statistics.CacheHits += (uint)list.Count;
                }

                return true;
            }

            var content = await GetResponseFromEndpoint($"{_endpoint}");
            if (content == null)
            {
                return false;
            }

            DeserializeJson(content, models);

            foreach (var deserializedObject in models)
            {
                deserializedObject.SetContext(Context);
            }

            if (Context.CacheEnabled)
            {
                _cache.UpdateList(models, _endpoint);

                if (Context.StatisticsEnabled)
                {
                    Context.Statistics.CacheUpdates += (uint)models.Count;
                }
            }

            return true;
        }
    }
}
