using Fluxor;

namespace Fuyu.Launcher.Store.SessionUseCase
{
    public static class Reducers
    {
        [ReducerMethod]
        public static SessionState ReduceLoginSessionAction(SessionState state, LoginSessionAction action)
        {
            return new SessionState(action.UserName, action.IsLoggedIn);
        }

        [ReducerMethod]
        public static SessionState ReduceLogoutSessionAction(SessionState state, LogoutSessionAction action)
        {
            return new SessionState(action.UserName, action.IsLoggedIn);
        }
    }
}
