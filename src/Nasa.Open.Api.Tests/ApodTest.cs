namespace Nasa.Open.Api.Tests
{
    using System;
    using Xunit;

    public class ApodTest
    {
        [Fact (Skip = "Need Internet Connection... fix to moc")]
        public void DateTest()
        {
            string apiKey = "DEMO_KEY";

            DateTime searchDate = DateTime.Parse("1999-12-31"); 

            string titleExpect = "The Millennium that Defined Earth";
            Uri urlExcept = new Uri("https://apod.nasa.gov/apod/image/9912/earthrise_apollo8.jpg");
            Uri hdUrlExcept = new Uri("https://apod.nasa.gov/apod/image/9912/earthrise_apollo8_big.gif");
            var actual = new NasaOpenApi(apiKey).Apod.GetAsync(searchDate).Result;

            Assert.Equal(titleExpect, actual.Title);
            Assert.Equal(urlExcept, actual.Url);
            Assert.Equal(hdUrlExcept, actual.HighQualityUrl);
            Assert.Equal(searchDate, actual.Date);
        }
    }
}
