using System.Collections.Generic;
using System.Linq;

namespace Fuyu.Platform.Common.Http
{
    public abstract class DynamicFuyuBehaviour : FuyuBehaviour
    {
        // ["", "files", "trader", "avatar", "{traderId}"]
        public string[] PathSegments { get; set; }

        // [{"traderId", 4}]
        public List<DynamicPathSegment> DynamicSegments { get; set; }

        // Logic is ran here in order to process before passing off to user implementation
        public override void Run(FuyuContext context)
        {
            var args = new Dictionary<string, string>();
            var split = context.GetPath().Split('/');
            foreach (var dynamicSegment in DynamicSegments)
            {
                args[dynamicSegment.Name] = split[dynamicSegment.Index];
            }

            RunDynamic(context, args);
        }

        // args where the key is the path's name and value is taken from query by index so
        // /files/trader/avatar/test would result in a dictionary of {{"traderId", "test"}}
        public abstract void RunDynamic(FuyuContext context, Dictionary<string, string> args);

        // No real reason to mark virtual other than modularity, checks the query to see
        // if this behaviour can handle it where dynamic segments are ignored and if the
        // rest of the query matches then the method will return true
        public virtual bool CanHandle(string path)
        {
            var inputSegments = path.Split('/');
            if (inputSegments.Length != PathSegments.Length)
            {
                return false;
            }

            for (var i = 0; i < inputSegments.Length; i++)
            {
                if (!IsDynamicSegment(i) && inputSegments[i] != PathSegments[i])
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsDynamicSegment(int index)
        {
            return DynamicSegments.Any(segment => segment.Index == index);
        }

        public struct DynamicPathSegment
        {
            public string Name { get; }
            public int Index { get; }

            public DynamicPathSegment(string name, int index)
            {
                Name = name;
                Index = index;
            }
        }
    }
}