using Fluxor;
using Fuyu.Launcher.Core.Services;
using System.Threading.Tasks;

namespace Fuyu.Launcher.Store.GamesUseCase
{
    public class Effects
    {
        [EffectMethod]
        public async Task HandleGetGamesAction(GetGamesAction action, IDispatcher dispatcher)
        {
            var games = RequestService.GetGames();
            dispatcher.Dispatch(new GetGamesResultAction(games));
        }
    }
}
