using System;
using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Requests;

namespace Fuyu.Platform.Server.Behaviours
{
    public class MatchOfflineStart : FuyuBehaviour
    {
        private readonly string bigmap;
        private readonly string factory4_day;
        private readonly string factory4_night;
        private readonly string interchange;
        private readonly string laboratory;
        private readonly string lighthouse;
        private readonly string rezervbase;
        private readonly string sandbox;
        private readonly string shoreline;
        private readonly string tarkovstreets;
        private readonly string woods;

        public MatchOfflineStart()
        {
            bigmap = Resx.GetText("fuyu", "database.locations.bigmap.json");
            factory4_day = Resx.GetText("fuyu", "database.locations.factory4_day.json");
            factory4_night = string.Empty;
            interchange = Resx.GetText("fuyu", "database.locations.interchange.json");
            laboratory = string.Empty;
            lighthouse = Resx.GetText("fuyu", "database.locations.lighthouse.json");
            rezervbase = Resx.GetText("fuyu", "database.locations.rezervbase.json");
            sandbox = Resx.GetText("fuyu", "database.locations.sandbox.json");
            shoreline = Resx.GetText("fuyu", "database.locations.shoreline.json");
            tarkovstreets = Resx.GetText("fuyu", "database.locations.tarkovstreets.json");
            woods = Resx.GetText("fuyu", "database.locations.woods.json");
        }

        public override void Run(FuyuContext context)
        {
            var request = context.GetJson<MatchOfflineStartRequest>();
            var location = request.location;

            if (location == "factory")
            {
                location = "factory4_day";
            }

            var response = string.Empty;
            switch (location)
            {
                case "bigmap": response = bigmap; break;
                case "factory4_day": response = factory4_day; break;
                case "factory4_night": response = factory4_night; break;
                case "interchange": response = interchange; break;
                case "laboratory": response = laboratory; break;
                case "lighthouse": response = lighthouse; break;
                case "rezervbase": response = rezervbase; break;
                case "sandbox": response = sandbox; break;
                case "shorline": response = shoreline; break;
                case "tarkovstreets": response = tarkovstreets; break;
                case "woods": response = woods; break;
                default:
                    throw new Exception($"Location {location} not found");
            }

            SendJson(context, response);
        }
    }
}