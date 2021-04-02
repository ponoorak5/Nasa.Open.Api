using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Nasa.Open.Api.APOD;
using Nasa.Open.Api.AsteroidsNeoWs;
using Nasa.Open.Api.Earth;
using Nasa.Open.Api.Mars.Photos;
using Nasa.Open.Api.Mars.Weather;
using Nasa.Open.Api.TLE;

namespace Nasa.Open.Api.Extensions
{
    public static class Integration
    {//MarsPhotos
        public static IServiceCollection AddApod(this IServiceCollection services, string apiKey)
        {
            return services.AddScoped<IApod, Apod>(sb => new Apod(apiKey, NasaOpenApi.NasaOpenApiState));
        }

        public static IServiceCollection AddNeoBrowse(this IServiceCollection services, string apiKey)
        {
            return services.AddScoped<INeoBrowse, NeoBrowse>(sb => new NeoBrowse(apiKey, NasaOpenApi.NasaOpenApiState));
        }

        public static IServiceCollection AddNeoFeed(this IServiceCollection services, string apiKey)
        {
            return services.AddScoped<INeoFeed, NeoFeed>(sb => new NeoFeed(apiKey, NasaOpenApi.NasaOpenApiState));
        }

        public static IServiceCollection AddNeoLookup(this IServiceCollection services, string apiKey)
        {
            return services.AddScoped<INeoLookup, NeoLookup>(sb => new NeoLookup(apiKey, NasaOpenApi.NasaOpenApiState));
        }
        public static IServiceCollection AddNeoSentry(this IServiceCollection services, string apiKey)
        {
            return services.AddScoped<INeoSentry, NeoSentry>(sb => new NeoSentry(apiKey, NasaOpenApi.NasaOpenApiState));
        }
        public static IServiceCollection AddNeoStats(this IServiceCollection services, string apiKey)
        {
            return services.AddScoped<INeoStats, NeoStats>(sb => new NeoStats(apiKey, NasaOpenApi.NasaOpenApiState));
        }
        public static IServiceCollection AddNeoToday(this IServiceCollection services, string apiKey)
        {
            return services.AddScoped<INeoToday, NeoToday>(sb => new NeoToday(apiKey, NasaOpenApi.NasaOpenApiState));
        }
        public static IServiceCollection AddNeo(this IServiceCollection services, string apiKey)
        {
            return services
                .AddNeoBrowse(apiKey)
                .AddNeoFeed(apiKey)
                .AddNeoSentry(apiKey)
                .AddNeoStats(apiKey)
                .AddNeoToday(apiKey)
                .AddNeoLookup(apiKey);
        }

        public static IServiceCollection AddEarthImage(this IServiceCollection services, string apiKey)
        {
            return services.AddScoped<IEarthImage, EarthImage>(sb => new EarthImage(apiKey, NasaOpenApi.NasaOpenApiState));
        }

        public static IServiceCollection AddEarthAssete(this IServiceCollection services, string apiKey)
        {
            return services.AddScoped<IEarthAssets, EarthAssets>(sb => new EarthAssets(apiKey, NasaOpenApi.NasaOpenApiState));
        }

        public static IServiceCollection AddEarth(this IServiceCollection services, string apiKey)
        {
            return services
                .AddEarthImage(apiKey)
                .AddEarthAssete(apiKey);
        }

        public static IServiceCollection AddMarsMarsPhotos(this IServiceCollection services, string apiKey)
        {
            return services.AddScoped<IMarsPhotos, MarsPhotos>(sb => new MarsPhotos(apiKey, NasaOpenApi.NasaOpenApiState));
        }

        public static IServiceCollection AddMarsWeather(this IServiceCollection services, string apiKey)
        {
            return services.AddScoped<IMarsWeather, MarsWeather>(sb => new MarsWeather(apiKey, NasaOpenApi.NasaOpenApiState));
        }

        public static IServiceCollection AddMars(this IServiceCollection services, string apiKey)
        {
            return services
                .AddMarsMarsPhotos(apiKey)
                .AddMarsWeather(apiKey);
        }

        public static IServiceCollection AddTle(this IServiceCollection services)
        {
            return services.AddScoped<ITle, Tle>(sb => new Tle(NasaOpenApi.NasaOpenApiState));
        }
        public static IServiceCollection AddNasaOpenApi(this IServiceCollection services, string apiKey)
        {
            return services
                .AddApod(apiKey)
                .AddNeo(apiKey)
                .AddEarth(apiKey)
                .AddMars(apiKey)
                .AddTle();
        }
    }
}
