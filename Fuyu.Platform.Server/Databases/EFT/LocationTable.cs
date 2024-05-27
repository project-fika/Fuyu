using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Locations;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Databases.Tables
{
    public class LocationTable
    {
        private WorldMap _worldMap;

        public WorldMap GetWorldMap()
        {
            return _worldMap;
        }

        public void LoadWorldMap()
        {
            var text = Resx.GetText("fuyu", "database.client.locations.json");
            var json = Json.Parse<ResponseBody<WorldMap>>(text);
            _worldMap = json.data;
        }

        public void Load()
        {
            LoadWorldMap();
        }
    }
}