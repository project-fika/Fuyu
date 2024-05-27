using System.Collections.Generic;
using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours
{
    public class Languages : FuyuBehaviour
    {
        public override void Run(FuyuContext context)
        {
            var response = new ResponseBody<Dictionary<string, string>>()
            {
                // TODO: generate this from loaded locales
                data = new Dictionary<string, string>()
                {
                    { "ch",    "Chinese"        },
                    { "cz",    "Czech"          },
                    { "en",    "English"        },
                    { "fr",    "French"         },
                    { "ge",    "German"         },
                    { "hu",    "Hungarian"      },
                    { "it",    "Italian"        },
                    { "jp",    "Japanese"       },
                    { "kr",    "Korean"         },
                    { "pl",    "Polish"         },
                    { "po",    "Portugal"       },
                    { "sk",    "Slovak"         },
                    { "es",    "Spanish"        },
                    { "es-mx", "Spanish Mexico" },
                    { "tu",    "Turkish"        },
                    { "ru",    "Русский"        },
                    { "ro",    "Romanian"       }
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}