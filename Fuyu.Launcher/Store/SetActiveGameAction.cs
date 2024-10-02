namespace Fuyu.Launcher.Store
{
    public class SetActiveGameAction
    {
        public readonly string GameId;

        public SetActiveGameAction(string gameId)
        {
            GameId = gameId;
        }
    }
}
