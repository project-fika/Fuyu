using Fluxor;

namespace Fuyu.Launcher.Store.ActiveGameUseCase
{
    public static class Reducers
    {
        [ReducerMethod]
        public static ActiveGameState ReduceGetGamesAction(ActiveGameState state, SetActiveGameAction action)
        {
            return new ActiveGameState(action.GameId);
        }
    }
}
