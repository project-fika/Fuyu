namespace Fuyu.Launcher.Store
{
    public class AddGameAction
    {
        public readonly string GameId;
        public readonly int AccountId;

        public AddGameAction(string gameId, int accountId)
        {
            GameId = gameId;
            AccountId = accountId;
        }
    }
}
