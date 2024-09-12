using Fluxor;

namespace Fuyu.Launcher.Store.GamesUseCase
{
	public static class Reducers
	{
        [ReducerMethod]
        public static GamesState ReduceGetGamesAction(GamesState state, GetGamesAction action)
        {
            return new GamesState(true, new());
        }

        [ReducerMethod]
        public static GamesState ReduceGetGamesResultAction(GamesState state, GetGamesResultAction action)
        {
            return new GamesState(false, action.Games);
        }

        [ReducerMethod]
        public static GamesState ReduceAddGameAction(GamesState state, AddGameAction action)
        {
            state.Games.Add(action.GameId, action.AccountId);

            return new GamesState(false, state.Games);
        }
    }
}
