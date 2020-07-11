﻿using System.Collections.Generic;
using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Events;
using Oddity.API.Models.Crew;
using Oddity.API.Models.Launches;
using Oddity.API.Models.Launchpads;
using Oddity.API.Models.Payloads;

namespace Oddity.API.Endpoints
{
    /// <summary>
    /// Represents an entry point for /launches endpoint.
    /// </summary>
    public class LaunchesEndpoint
    {
        private readonly HttpClient _httpClient;
        private readonly BuilderDelegatesContainer _builderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchesEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public LaunchesEndpoint(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            _httpClient = httpClient;
            _builderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Gets data about the specified launch from the /launches/:id endpoint.
        /// </summary>
        /// <param name="id">ID of the specified launch.</param>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<LaunchInfo> Get(string id)
        {
            return new SimpleBuilder<LaunchInfo>(_httpClient, "launches", id, _builderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about the latest launch from the /launches/latest endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<LaunchInfo> GetLatest()
        {
            return new SimpleBuilder<LaunchInfo>(_httpClient, "launches/latest", _builderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about the next launch from the /launches/latest endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public SimpleBuilder<LaunchInfo> GetNext()
        {
            return new SimpleBuilder<LaunchInfo>(_httpClient, "launches/next", _builderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about all launches from the /launches endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<LaunchInfo> GetAll()
        {
            return new ListBuilder<LaunchInfo>(_httpClient, "launches", _builderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about all past launches from the /launches endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<LaunchInfo> GetPast()
        {
            return new ListBuilder<LaunchInfo>(_httpClient, "launches/past", _builderDelegatesContainer);
        }

        /// <summary>
        /// Gets data about all upcoming launches from the /launches endpoint.
        /// </summary>
        /// <returns>Deserialized JSON returned from the API.</returns>
        public ListBuilder<LaunchInfo> GetUpcoming()
        {
            return new ListBuilder<LaunchInfo>(_httpClient, "launches/upcoming", _builderDelegatesContainer);
        }
    }
}