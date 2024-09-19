using System;

namespace Fuyu.Common.Networking
{
    public class RouteNotFoundException : Exception
    {
        public RouteNotFoundException(string message) : base(message)
        {
        }
    }
}