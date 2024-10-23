using System.Text.RegularExpressions;

namespace Fuyu.Common.Networking
{
	public interface IRoutable
    {
		Regex Matcher { get; }
	}
}