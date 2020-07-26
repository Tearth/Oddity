using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oddity.Cache;
using Oddity.Models;
using Oddity.Models.Query;
using Oddity.Models.Query.Filters;

namespace Oddity.Builders
{
    /// <summary>
    /// Represents a query builder used to retrieve data with filters specified by the user.
    /// </summary>
    /// <typeparam name="TReturn">Type which will be returned after successful API request.</typeparam>
    public class QueryBuilder<TReturn> : BuilderBase<PaginatedModel<TReturn>> where TReturn : ModelBase, IIdentifiable, new()
    {
        private readonly CacheService<TReturn> _cache;
        private readonly string _endpoint;
        private readonly QueryModel _query;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder{TReturn}"/> class.
        /// </summary>
        /// <param name="context">The Oddity context used to interact with API.</param>
        /// <param name="cache">Cache service used to speed up requests.</param>
        /// <param name="endpoint">The endpoint used in this instance to retrieve data from API.</param>
        public QueryBuilder(OddityCore context, CacheService<TReturn> cache, string endpoint) : base(context)
        {
            _cache = cache;
            _endpoint = endpoint;
            _query = new QueryModel();
        }

        /// <summary>
        /// Adds an "equal" filter for the specified field. API will return all models with a field
        /// value equal to the specified in the parameter.
        /// </summary>
        /// <typeparam name="TField">Type of the property (JSON field).</typeparam>
        /// <param name="selector">Property (JSON field) selector.</param>
        /// <param name="value">Value of the field to match.</param>
        /// <returns>Builder instance.</returns>
        public QueryBuilder<TReturn> WithFieldEqual<TField>(Expression<Func<TReturn, TField>> selector, TField value)
        {
            var fieldPath = GetPathFromExpression(selector);
            _query.Filters.Add(fieldPath, value);
            return this;
        }

        /// <summary>
        /// Adds a "greater than" filter for the specified field. API will return all models with a field
        /// value greater than the specified in the parameter.
        /// </summary>
        /// <typeparam name="TField">Type of the property (JSON field).</typeparam>
        /// <param name="selector">Property (JSON field) selector.</param>
        /// <param name="value">Value of the field to match.</param>
        /// <returns>Builder instance.</returns>
        public QueryBuilder<TReturn> WithFieldGreaterThan<TField>(Expression<Func<TReturn, TField>> selector, TField value)
        {
            var fieldPath = GetPathFromExpression(selector);
            _query.Filters.Add(fieldPath, new GreaterThanFilter<TField>(value));
            return this;
        }

        /// <summary>
        /// Adds a "less than" filter for the specified field. API will return all models with a field
        /// value less than the specified in the parameter.
        /// </summary>
        /// <typeparam name="TField">Type of the property (JSON field).</typeparam>
        /// <param name="selector">Property (JSON field) selector.</param>
        /// <param name="value">Value of the field to match.</param>
        /// <returns>Builder instance.</returns>
        public QueryBuilder<TReturn> WithFieldLessThan<TField>(Expression<Func<TReturn, TField>> selector, TField value)
        {
            var fieldPath = GetPathFromExpression(selector);
            _query.Filters.Add(fieldPath, new LessThanFilter<TField>(value));
            return this;
        }

        /// <summary>
        /// Adds a "between" filter for the specified field. API will return all models with a field
        /// value greater than the bounds specified in the parameters.
        /// </summary>
        /// <typeparam name="TField">Type of the property (JSON field).</typeparam>
        /// <param name="selector">Property (JSON field) selector.</param>
        /// <param name="from">Left bound of the value to match.</param>
        /// <param name="to">Right bound of the value to match.</param>
        /// <returns>Builder instance.</returns>
        public QueryBuilder<TReturn> WithFieldBetween<TField>(Expression<Func<TReturn, TField>> selector, TField from, TField to)
        {
            var fieldPath = GetPathFromExpression(selector);
            _query.Filters.Add(fieldPath, new BetweenFilter<TField>(from, to));
            return this;
        }

        /// <summary>
        /// Adds an "in" filter for the specified field. API will return all models with a field
        /// value containing one of the specified in the parameter.
        /// </summary>
        /// <typeparam name="TField">Type of the property (JSON field).</typeparam>
        /// <param name="selector">Property (JSON field) selector.</param>
        /// <param name="values">List of values to match.</param>
        /// <returns>Builder instance.</returns>
        public QueryBuilder<TReturn> WithFieldIn<TField>(Expression<Func<TReturn, TField>> selector, params TField[] values)
        {
            var fieldPath = GetPathFromExpression(selector);
            _query.Filters.Add(fieldPath, new InFilter<TField>(values));
            return this;
        }


        /// <summary>
        /// Sorts result using the specified field and order (ascending/descending).
        /// </summary>
        /// <typeparam name="TField">Type of the property (JSON field).</typeparam>
        /// <param name="selector">Property (JSON field) selector.</param>
        /// <param name="ascending">Sort order (ascending/descending).</param>
        /// <returns>Builder instance.</returns>
        public QueryBuilder<TReturn> SortBy<TField>(Expression<Func<TReturn, TField>> selector, bool ascending = true)
        {
            var fieldPath = GetPathFromExpression(selector);
            if (_query.Options.Sort == null)
            {
                _query.Options.Sort = new Dictionary<string, SortMode>();
            }

            var sortMode = ascending ? SortMode.Ascending : SortMode.Descending;

            _query.Options.Sort[fieldPath] = sortMode;
            return this;
        }

        /// <summary>
        /// Sets page number which will be returned from API. Don't use this method together with <see cref="WithOffset"/> (offset will
        /// be set to null in this case).
        /// </summary>
        /// <param name="page">Selected page number (starting from 1).</param>
        /// <returns>Builder instance.</returns>
        public QueryBuilder<TReturn> WithPage(uint page)
        {
            _query.Options.Page = page;
            _query.Options.Offset = null;
            return this;
        }

        /// <summary>
        /// Sets how many elements should be returned from API in the single page.
        /// </summary>
        /// <param name="limit">Number of elements to return.</param>
        /// <returns>Builder instance.</returns>
        public QueryBuilder<TReturn> WithLimit(uint limit)
        {
            _query.Options.Limit = limit;
            return this;
        }

        /// <summary>
        /// Sets page number which will be returned from API. Don't use this method together with <see cref="WithPage"/> (page will
        /// be set to null in this case).
        /// </summary>
        /// <param name="offset">Number of elements to skip.</param>
        /// <returns>Builder instance.</returns>
        public QueryBuilder<TReturn> WithOffset(uint offset)
        {
            _query.Options.Offset = offset;
            _query.Options.Page = null;
            return this;
        }

        /// <inheritdoc />
        public override PaginatedModel<TReturn> Execute()
        {
            return ExecuteAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public override bool Execute(PaginatedModel<TReturn> model)
        {
            return ExecuteAsync(model).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public override async Task<PaginatedModel<TReturn>> ExecuteAsync()
        {
            var model = new PaginatedModel<TReturn>();
            await ExecuteAsync(model);

            return model;
        }

        /// <inheritdoc />
        public override async Task<bool> ExecuteAsync(PaginatedModel<TReturn> paginatedModel)
        {
            var serializedQuery = SerializeJson(_query);
            var content = await GetResponseFromEndpoint($"{_endpoint}", serializedQuery);
            if (content == null)
            {
                return false;
            }

            DeserializeJson(content, paginatedModel);

            foreach (var deserializedObject in paginatedModel.Data)
            {
                deserializedObject.SetContext(Context);

                if (Context.CacheEnabled)
                {
                    _cache.Update(deserializedObject, deserializedObject.Id);
                }
            }

            if (Context.CacheEnabled && Context.StatisticsEnabled)
            {
                Context.Statistics.CacheUpdates += (uint)paginatedModel.Data.Count;
            }

            paginatedModel.SetBuilder(this);
            return true;
        }

        private string GetPathFromExpression<TField>(Expression<Func<TReturn, TField>> selector)
        {
            var members = new List<string>();
            var memberExpression = (MemberExpression) selector.Body;

            while (memberExpression != null)
            {
                var customAttributes = memberExpression.Member.CustomAttributes;
                var jsonPropertyAttribute = customAttributes.FirstOrDefault(p => p.AttributeType == typeof(JsonPropertyAttribute));

                if (jsonPropertyAttribute != null && jsonPropertyAttribute.ConstructorArguments.Count > 0)
                {
                    members.Insert(0, (string) jsonPropertyAttribute.ConstructorArguments[0].Value);
                }
                else
                {
                    members.Insert(0, memberExpression.Member.Name.ToLower());
                }

                memberExpression = memberExpression.Expression as MemberExpression;
            }

            return string.Join(".", members);
        }
    }
}