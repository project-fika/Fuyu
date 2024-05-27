using System;
using Fuyu.Platform.Common.Models.EFT.Locations;
using Fuyu.Platform.Server.Databases;

namespace Fuyu.Platform.Server.Services
{
    public static class LocationService
    {
        public static WorldMap GetWorldMap()
        {
            return EftDatabase.Location.GetWorldMap();
        }

        public static Location GetLocation(string locationId, int variantId)
        {
            var worldMap = EftDatabase.Location.GetWorldMap();

            foreach (var location in worldMap.locations.Values)
            {
                if (location.Id == locationId)
                {
                    return location;
                }
            }

            throw new ArgumentException($"locationId");
        }
    }
}