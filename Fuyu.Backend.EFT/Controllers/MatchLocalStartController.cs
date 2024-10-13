using System.Threading.Tasks;
using System.Collections.Generic;
using Fuyu.Common.IO;
using Fuyu.Common.Networking;
using Fuyu.Backend.EFT.DTO.Requests;

namespace Fuyu.Backend.EFT.Controllers
{
    public class MatchLocalStartController : HttpController<MatchLocalStartRequest>
    {
        private readonly Dictionary<string, string> _locations;

        public MatchLocalStartController() : base("/client/match/local/start")
        {
            _locations = new Dictionary<string, string>()
            {
                { "bigmap",         Resx.GetText("eft", "database.locations.bigmap.json")          },
                { "factory4_day",   Resx.GetText("eft", "database.locations.factory4_day.json")    },
                { "factory4_night", string.Empty                                                   },
                { "interchange",    Resx.GetText("eft", "database.locations.interchange.json")     },
                { "laboratory",     string.Empty                                                   },
                { "lighthouse",     Resx.GetText("eft", "database.locations.lighthouse.json")      },
                { "rezervbase",     Resx.GetText("eft", "database.locations.rezervbase.json")      },
                { "sandbox",        Resx.GetText("eft", "database.locations.sandbox.json")         },
                { "shorline",       Resx.GetText("eft", "database.locations.shorline.json")        },
                { "tarkovstreets",  Resx.GetText("eft", "database.locations.tarkovstreets.json")   },
                { "woods",          Resx.GetText("eft", "database.locations.woods.json")           }
            };
        }

        public override Task RunAsync(HttpContext context, MatchLocalStartRequest request)
        {
            var location = request.location;

            return context.SendJsonAsync(_locations[location]);
        }
    }
}