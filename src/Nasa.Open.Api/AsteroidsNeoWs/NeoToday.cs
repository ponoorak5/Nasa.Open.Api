﻿namespace Nasa.Open.Api.AsteroidsNeoWs
{
    using System.Threading.Tasks;
    using Attributes;
    using Models;

    [EndPoint(Consts.BASE_URL1, "neo/rest/v1/feed/today")]
    internal class NeoToday : Connection, INeoToday
    {
        public NeoToday(string apiKey, NasaOpenApiState state) : base(apiKey, state)
        {
        }

        public async Task<AsteroidsFeedData> GetAsync()
        {
            var result = await Request<AsteroidsFeedData>();
            return result;
        }
    }
}
