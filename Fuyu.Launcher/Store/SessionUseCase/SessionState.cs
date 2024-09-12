using Fluxor;

namespace Fuyu.Launcher.Store.SessionUseCase
{
    [FeatureState]
    public class SessionState
	{
        public string UserName { get; }

        public bool IsLoggedIn { get; }

        public SessionState() { }
        public SessionState(string username, bool isLoggedIn)
        {
            UserName = username;
            IsLoggedIn = isLoggedIn;
        }
    }
}
