using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;
using Fuyu.Platform.Server.Databases;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameConfig : FuyuBehaviour
    {
        public override void Run(FuyuContext context)
        {
            var languages = EftDatabase.Locales.GetLanguages();
            var response = new ResponseBody<GameConfigResponse>
            {
                data = new GameConfigResponse()
                {
                    aid = 659885,
                    lang = "en",            // TODO: observe how this works
                    languages = languages,
                    ndaFree = false,
                    taxonomy = 6,
                    backend = new Backends()
                    {
                        Lobby = "http://localhost:8000",
                        Trading = "http://localhost:8000",
                        Messaging = "http://localhost:8000",
                        Main = "http://localhost:8000",
                        RagFair = "http://localhost:8000"
                    },
                    useProtobuf = false,
                    utc_time = 1724450891.010541,
                    reportAvailable = true,
                    twitchEventMember = false,
                    sessionMode = "pve",
                    purchasedGames = new PurchasedGames()
                    {
                        eft = true,
                        arena = true
                    },
                    isGameSynced = true
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}