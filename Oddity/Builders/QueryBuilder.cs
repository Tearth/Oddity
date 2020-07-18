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
        private readonly string _endpoint;
        private readonly QueryModel _query;
        private readonly CacheService<TReturn> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder{TReturn}"/> class.
        /// </summary>
        /// <param name="context">The Oddity context which will be used for lazy properties in models.</param>
        /// <param name="cache"></param>
        /// <param name="endpoint">The endpoint used in this instance to retrieve data from API.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegates">The builder delegates container.</param>
        public QueryBuilder(OddityCore context, CacheService<TReturn> cache, string endpoint)
            : base(context)
        {
            _endpoint = endpoint;
            _query = new QueryModel();
            _cache = cache;
        }

        /// <summary>
        /// Adds a filter for the specified field which have to have an exact value.
        /// </summary>
        /// <typeparam name="TField">Type of the field.</typeparam>
        /// <param name="fieldPath">Name of the field (naming convention same as in models).</param>
        /// <param name="value">Value of the field to match.</param>
        /// <returns>Builder instance.</returns>
        public QueryBuilder<TReturn> WithFieldEqual<TField>(Expression<Func<TReturn, TField>> selector, TField value)
        {
            var fieldPath = GetPathFromExpression(selector);
            _query.Filters.Add(fieldPath, value);
            return this;
        }

        /// <summary>
        /// Adds a filter for the specified field which have to have an value greater than specified.
        /// </summary>
        /// <typeparam name="TField">Type of the field.</typeparam>
        /// <param name="fieldPath">Name of the field (naming convention same as in models).</param>
        /// <param name="value">Max value of the field.</param>
        /// <returns>Builder instance.</returns>
        public QueryBuilder<TReturn> WithFieldGreaterThan<TField>(Expression<Func<TReturn, TField>> selector, TField value)
        {
            var fieldPath = GetPathFromExpression(selector);
            _query.Filters.Add(fieldPath, new GreaterThanFilter<TField>(value));
            return this;
        }

        /// <summary>
        /// Adds a filter for the specified field which have to have an value less than specified.
        /// </summary>
        /// <typeparam name="TField">Type of the field.</typeparam>
        /// <param name="fieldPath">Name of the field (naming convention same as in models).</param>
        /// <param name="value">Min value of the field.</param>
        /// <returns>Builder instance.</returns>
        public QueryBuilder<TReturn> WithFieldLessThan<TField>(Expression<Func<TReturn, TField>> selector, TField value)
        {
            var fieldPath = GetPathFromExpression(selector);
            _query.Filters.Add(fieldPath, new LessThanFilter<TField>(value));
            return this;
        }

        /// <summary>
        /// Adds a filter for the specified field which have to have an value within the specified range.
        /// </summary>
        /// <typeparam name="TField">Type of the field.</typeparam>
        /// <param name="fieldPath">Name of the field (naming convention same as in models).</param>
        /// <param name="from">Left side of the range.</param>
        /// <param name="to">Right side of the range.</param>
        /// <returns>Builder instance.</returns>
        public QueryBuilder<TReturn> WithFieldBetween<TField>(Expression<Func<TReturn, TField>> selector, TField from, TField to)
        {
            var fieldPath = GetPathFromExpression(selector);
            _query.Filters.Add(fieldPath, new BetweenFilter<TField>(from, to));
            return this;
        }

        /// <summary>
        /// Adds a filter for the specified field which have to have an value same as one of the specified.
        /// </summary>
        /// <typeparam name="TField">Type of the field.</typeparam>
        /// <param name="fieldPath">Name of the field (naming convention same as in models).</param>
        /// <param name="values">Values which have to be matched.</param>
        /// <returns>Builder instance.</returns>
        public QueryBuilder<TReturn> WithFieldIn<TField>(Expression<Func<TReturn, TField>> selector, params TField[] values)
        {
            var fieldPath = GetPathFromExpression(selector);
            _query.Filters.Add(fieldPath, new InFilter<TField>(values));
            return this;
        }

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

        // TODO: don't use with skip
        public QueryBuilder<TReturn> WithPage(uint page)
        {
            _query.Options.Page = page;
            _query.Options.Offset = null;
            return this;
        }

        public QueryBuilder<TReturn> WithLimit(uint limit)
        {
            _query.Options.Limit = limit;
            return this;
        }

        // TODO: don't use with page
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
                _cache.Update(deserializedObject, deserializedObject.Id);
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
                    members.Insert(0, memberExpression.Member.Name);
                }

                memberExpression = memberExpression.Expression as MemberExpression;
            }

            return string.Join(".", members);
        }
    }
}