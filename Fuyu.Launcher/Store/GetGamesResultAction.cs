using System.Collections.Generic;

namespace Fuyu.Launcher.Store
{
    public class GetGamesResultAction
    {
        public Dictionary<string, int?> Games { get; }

        public GetGamesResultAction(Dictionary<string, int?> games) {
            Games = games;
        }
    }
}
