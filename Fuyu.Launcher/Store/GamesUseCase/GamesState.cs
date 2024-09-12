using Fluxor;
using System.Collections.Generic;

namespace Fuyu.Launcher.Store.GamesUseCase
{
    [FeatureState]
    public class GamesState
	{
        public bool IsLoading { get; } = true;
        public Dictionary<string, int?> Games { get; } = new();

        public GamesState() { }
        public GamesState(bool isLoading, Dictionary<string, int?> games)
        {
            IsLoading = isLoading;
            Games = games;
        }
    }
}
