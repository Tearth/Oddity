﻿using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Builders.Capsules;

namespace Oddity.API
{
    /// <summary>
    /// Represents a set of methods to get capsules information.
    /// </summary>
    public class Capsules
    {
        private readonly HttpClient _httpClient;
        private readonly BuilderDelegatesContainer _builderDelegatesContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Capsules"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="builderDelegatesContainer">The builder delegates container.</param>
        public Capsules(HttpClient httpClient, BuilderDelegatesContainer builderDelegatesContainer)
        {
            _httpClient = httpClient;
            _builderDelegatesContainer = builderDelegatesContainer;
        }

        /// <summary>
        /// Gets information about the specified capsule. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <param name="capsuleSerial">The capsule serial.</param>
        /// <returns>The capsule builder.</returns>
        public CapsuleBuilder GetAbout(string capsuleSerial)
        {
            return new CapsuleBuilder(_httpClient, _builderDelegatesContainer).WithSerial(capsuleSerial);
        }

        /// <summary>
        /// Gets detailed information about all capsules. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all capsules builder.</returns>
        public AllCapsulesBuilder GetAll()
        {
            return new AllCapsulesBuilder(_httpClient, _builderDelegatesContainer);
        }

        /// <summary>
        /// Gets detailed information about upcoming capsules. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all capsules builder.</returns>
        public UpcomingCapsulesBuilder GetUpcoming()
        {
            return new UpcomingCapsulesBuilder(_httpClient, _builderDelegatesContainer);
        }

        /// <summary>
        /// Gets detailed information about past capsules. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all capsules builder.</returns>
        public PastCapsulesBuilder GetPast()
        {
            return new PastCapsulesBuilder(_httpClient, _builderDelegatesContainer);
        }
    }
}