using Fluxor;

namespace Fuyu.Launcher.Store.ActiveGameUseCase
{
    [FeatureState]
    public class ActiveGameState
    {
        public string GameId { get; } = string.Empty;

        public ActiveGameState()
        {
        }

        public ActiveGameState(string gameId)
        {
            GameId = gameId;
        }
    }
}
