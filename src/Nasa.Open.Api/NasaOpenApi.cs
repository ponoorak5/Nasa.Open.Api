namespace Nasa.Open.Api
{
    using System;
    using APOD;
    using AsteroidsNeoWs;
    using Configuration;
    using Earth;
    using Mars.Photos;
    using Mars.Weather;
    using TLE;

    public class NasaOpenApiState
    {
        public int Remaining { get; internal set; }
        public int Limit { get; internal set; }
    }

    public interface INasaOpenApi
    {
        /// <summary>
        /// Get Remaining calls available (depend from api key)
        /// </summary>
        int Remaining { get; }

        /// <summary>
        /// Get Limit calls tu use (depend from api key)
        /// http://api.nasa.gov
        /// </summary>
        int Limit { get; }

        /// <summary>
        /// Interface for APOD https://apod.nasa.gov/apod/astropix.html
        /// </summary>
        /// <see cref="IApod"/>
        IApod Apod { get; }

        /// <summary>
        /// Retrieve a list of Asteroids based on their closest approach date to Earth
        /// </summary>
        /// <see cref="INeoFeed"/>
        INeoFeed NeoFeed { get; }

        /// <summary>
        /// Lookup a specific Asteroid based on its NASA JPL small body (SPK-ID) 
        /// </summary>
        /// <see cref="INeoLookup"/>
        INeoLookup NeoLookup { get; }

        /// <summary>
        /// Near Earth Objects Today
        /// </summary>
        ///<see cref="INeoToday"/>
        INeoToday NeoToday { get; }

        /// <summary>
        /// Nasa Earth Impact Monitoring
        /// </summary>
        /// <see cref="INeoSentry"/>
        INeoSentry NeoSentry { get; }

        /// <summary>
        /// Browse the overall Asteroid data-set
        /// </summary>
        /// <see cref="INeoBrowse"/>
        INeoBrowse NeoBrowse { get; }

        INeoStats NeoStats { get; }

        /// <summary>
        /// This API is designed to collect image data gathered by NASA's Curiosity, Opportunity, and Spirit rovers on Mars
        /// </summary>
        /// <see cref="IMarsPhotos"/>
        IMarsPhotos MarsPhotos { get; }

        /// <summary>
        /// This API provides per-Sol summary data for each of the last seven available Sols (UNSTABLE!)
        /// </summary>
        /// <see cref="MarsWeather"/>
        IMarsWeather MarsWeather { get; }

        /// <summary>
        /// This endpoint retrieves the Landsat 8 image for the supplied location and date. 
        /// </summary>
        /// <see cref="IEarthImage"/>
        IEarthImage EarthImage { get; }

        /// <summary>
        /// this endpoint retrieves the date-times and asset names for closest available imagery for a supplied location and date.
        /// </summary>
        IEarthAssets EarthAssets { get; }

        /// <summary>
        /// The TLE API provides up to date two line element set records, the data is updated daily from CelesTrak and served in JSON format
        /// </summary>
        ITle Tle { get; }
    }

    public class NasaOpenApi : INasaOpenApi
    {
        /// <summary>
        /// Get Remaining calls available (depend from api key)
        /// </summary>
        public int Remaining => NasaOpenApiState.Remaining;

        /// <summary>
        /// Get Limit calls tu use (depend from api key)
        /// http://api.nasa.gov
        /// </summary>
        public int Limit => NasaOpenApiState.Limit;

        private static readonly Lazy<NasaOpenApiState> _nasaOpenApiState =
            new Lazy<NasaOpenApiState>(() => new NasaOpenApiState());

        public static NasaOpenApiState NasaOpenApiState => _nasaOpenApiState.Value;
        /// <summary>
        /// Initialize using api_key
        /// </summary>
        /// <param name="apiKey"></param>
        public NasaOpenApi(string apiKey)
        {
            //8 = DEMO_KEY
            if (string.IsNullOrWhiteSpace(apiKey) || apiKey.Length < 8)
            {
                throw new ArgumentException("Provided api_key is invalid, genere new key using https://api.nasa.gov/");
            }

            Apod = new Apod(apiKey, NasaOpenApiState);
            NeoFeed = new NeoFeed(apiKey, NasaOpenApiState);
            NeoLookup = new NeoLookup(apiKey, NasaOpenApiState);
            NeoToday = new NeoToday(apiKey, NasaOpenApiState);
            NeoSentry = new NeoSentry(apiKey, NasaOpenApiState);
            NeoBrowse = new NeoBrowse(apiKey, NasaOpenApiState);
            NeoStats = new NeoStats(apiKey, NasaOpenApiState);
            MarsPhotos = new MarsPhotos(apiKey, NasaOpenApiState);
            EarthImage = new EarthImage(apiKey, NasaOpenApiState);
            EarthAssets = new EarthAssets(apiKey, NasaOpenApiState);
            MarsWeather = new MarsWeather(apiKey, NasaOpenApiState);
            Tle = new Tle(NasaOpenApiState);
        }

        /// <summary>
        /// Initialize using config
        /// </summary>
        /// <param name="config"></param>
        public NasaOpenApi(NasaOpenApiConfiguration config) : this(config.ApiKey)
        {
        }

        /// <summary>
        /// Interface for APOD https://apod.nasa.gov/apod/astropix.html
        /// </summary>
        /// <see cref="IApod"/>
        public IApod Apod { get; }

        /// <summary>
        /// Retrieve a list of Asteroids based on their closest approach date to Earth
        /// </summary>
        /// <see cref="INeoFeed"/>
        public INeoFeed NeoFeed { get; }

        /// <summary>
        /// Lookup a specific Asteroid based on its NASA JPL small body (SPK-ID) 
        /// </summary>
        /// <see cref="INeoLookup"/>
        public INeoLookup NeoLookup { get; }

        /// <summary>
        /// Near Earth Objects Today
        /// </summary>
        ///<see cref="INeoToday"/>
        public INeoToday NeoToday { get; }

        /// <summary>
        /// Nasa Earth Impact Monitoring
        /// </summary>
        /// <see cref="INeoSentry"/>
        public INeoSentry NeoSentry { get; }

        /// <summary>
        /// Browse the overall Asteroid data-set
        /// </summary>
        /// <see cref="INeoBrowse"/>
        public INeoBrowse NeoBrowse { get; }

        public INeoStats NeoStats { get; }

        /// <summary>
        /// This API is designed to collect image data gathered by NASA's Curiosity, Opportunity, and Spirit rovers on Mars
        /// </summary>
        /// <see cref="IMarsPhotos"/>
        public IMarsPhotos MarsPhotos { get; }

        /// <summary>
        /// This API provides per-Sol summary data for each of the last seven available Sols (UNSTABLE!)
        /// </summary>
        /// <see cref="MarsWeather"/>
        public IMarsWeather MarsWeather { get; }

        /// <summary>
        /// This endpoint retrieves the Landsat 8 image for the supplied location and date. 
        /// </summary>
        /// <see cref="IEarthImage"/>
        public IEarthImage EarthImage { get; }

        /// <summary>
        /// this endpoint retrieves the date-times and asset names for closest available imagery for a supplied location and date.
        /// </summary>
        public IEarthAssets EarthAssets { get; }

        /// <summary>
        /// The TLE API provides up to date two line element set records, the data is updated daily from CelesTrak and served in JSON format
        /// </summary>
        public ITle Tle { get; }
    }
}
