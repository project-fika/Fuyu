using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Fuyu.Common.IO
{
    public static class Resx
    {
        private static readonly Dictionary<string, Assembly> _assemblies;
        private static readonly Dictionary<string, string[]> _fullpaths;

        static Resx()
        {
            _assemblies = new Dictionary<string, Assembly>();
            _fullpaths = new Dictionary<string, string[]>();
        }

        // NOTE: If a file's format is 'path.to.file.<localeId>.json', it will generate a sattelite assembly.
        //       Rename to 'path.to.file-<localeId>.json' to fix it.
        public static void SetSource(string id, Assembly assembly)
        {
            // validate assembly
            if (assembly == null)
            {
                throw new ArgumentNullException($"Assembly");
            }

            // modify sources
            var paths = assembly.GetManifestResourceNames();

            if (_assemblies.ContainsKey(id))
            {
                // replace existing entry
                _assemblies[id] = assembly;
                _fullpaths[id] = paths;
            }
            else
            {
                // add new entry
                _assemblies.Add(id, assembly);
                _fullpaths.Add(id, paths);
            }
        }

        public static Stream GetStream(string id, string path)
        {
            // validate assembly
            var hasAssembly = _assemblies.TryGetValue(id, out var assembly);

            if (!hasAssembly)
            {
                throw new ArgumentException($"Source {id} is not registered for assemblies");
            }

            // validate fullpaths
            var hasFullpath = _fullpaths.TryGetValue(id, out var fullpaths);

            if (!hasFullpath)
            {
                throw new ArgumentException($"Source {id} is not registered for paths");
            }

            // find target
            var target = $"{assembly.GetName().Name}.embedded.{path}";

            foreach (var fullpath in fullpaths)
            {
                if (fullpath == target)
                {
                    // target found
                    return assembly.GetManifestResourceStream(target);
                }
            }

            // target not found
            throw new FileNotFoundException($"Cannot find resource {path}");
        }

        public static string GetText(string id, string path)
        {
            using (var rs = GetStream(id, path))
            {
                using (var sr = new StreamReader(rs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
