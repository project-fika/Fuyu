namespace Fuyu.Launcher.Store
{
	public class LoginSessionAction
	{
		public readonly string UserName;

		public readonly bool IsLoggedIn = true;

		public LoginSessionAction(string userName)
		{
			UserName = userName;
		}
	}
}
