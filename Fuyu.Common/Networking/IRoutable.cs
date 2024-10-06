using System.Collections.Generic;

namespace Fuyu.Common.Networking
{
	public interface IRoutable
    {
        Dictionary<string, EPathSegment> Path { get; }
	}
}