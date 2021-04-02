using Two.Line.Elements;
using Two.Line.Elements.Model;

namespace Nasa.Open.Api.Extensions.TLE
{
    using System;
    using Api.TLE.Models;

    public static class TleExtensions
    {
        public static TwoLineElementsModel ToSatelliteCoordinates(this TleMember value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.Line1) || string.IsNullOrWhiteSpace(value.Line2))
            {
                throw new ArgumentNullException("TleMember is wrong or missing Line1, Line2");
            }

            return TwoLineElements.Parse(value.Line1, value.Line2);
        }
    }
}
