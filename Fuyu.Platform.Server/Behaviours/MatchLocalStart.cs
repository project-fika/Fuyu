using System;
using System.Collections.Generic;
using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.EFT.Requests;

namespace Fuyu.Platform.Server.Behaviours
{
    public class MatchLocalStart : FuyuBehaviour
    {
        private readonly Dictionary<string, string> _locations;

        public MatchLocalStart()
        {
            _locations = new Dictionary<string, string>()
            {
                { "bigmap",         Resx.GetText("fuyu", "database.locations.bigmap.json")          },
                { "factory4_day",   Resx.GetText("fuyu", "database.locations.bigmap.json")          },
                { "factory4_night", string.Empty                                                    },
                { "interchange",    Resx.GetText("fuyu", "database.locations.interchange.json")     },
                { "laboratory",     string.Empty                                                    },
                { "lighthouse",     Resx.GetText("fuyu", "database.locations.lighthouse.json")      },
                { "rezervbase",     Resx.GetText("fuyu", "database.locations.rezervbase.json")      },
                { "sandbox",        Resx.GetText("fuyu", "database.locations.sandbox.json")         },
                { "shorline",       Resx.GetText("fuyu", "database.locations.shorline.json")        },
                { "tarkovstreets",  Resx.GetText("fuyu", "database.locations.tarkovstreets.json")   },
                { "woods",          Resx.GetText("fuyu", "database.locations.woods.json")           }
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