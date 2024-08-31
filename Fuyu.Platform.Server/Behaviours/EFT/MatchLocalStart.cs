using System.Collections.Generic;
using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Requests;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class MatchLocalStart : FuyuBehaviour
    {
        private readonly Dictionary<string, string> _locations;

        public MatchLocalStart() : base("/client/match/local/start")
        {
            _locations = new Dictionary<string, string>()
            {
                { "bigmap",         Resx.GetText("eft", "database.eft.locations.bigmap.json")          },
                { "factory4_day",   Resx.GetText("eft", "database.eft.locations.bigmap.json")          },
                { "factory4_night", string.Empty                                                    },
                { "interchange",    Resx.GetText("eft", "database.eft.locations.interchange.json")     },
                { "laboratory",     string.Empty                                                    },
                { "lighthouse",     Resx.GetText("eft", "database.eft.locations.lighthouse.json")      },
                { "rezervbase",     Resx.GetText("eft", "database.eft.locations.rezervbase.json")      },
                { "sandbox",        Resx.GetText("eft", "database.eft.locations.sandbox.json")         },
                { "shorline",       Resx.GetText("eft", "database.eft.locations.shorline.json")        },
                { "tarkovstreets",  Resx.GetText("eft", "database.eft.locations.tarkovstreets.json")   },
                { "woods",          Resx.GetText("eft", "database.eft.locations.woods.json")           }
            };
        }

        public override void Run(FuyuContext context)
        {
            var request = context.GetJson<MatchLocalStartRequest>();
            var location = request.location;

            SendJson(context, _locations[location]);
        }
    }
}