using System.Collections.Concurrent;
using System.IO;

namespace Fuyu.Common.IO
{
    public static class VFS
    {
        private static readonly ConcurrentDictionary<string, object> _writeLock;

        static VFS()
        {
            _writeLock = new ConcurrentDictionary<string, object>();
        }

        public static bool DirectoryExists(string filepath)
        {
            return Directory.Exists(filepath);
        }

        public static bool FileExists(string filepath)
        {
            return File.Exists(filepath);
        }

        public static string[] GetFiles(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"Directory {path} doesn't exist.");
            }

            return Directory.GetFiles(path);
        }

        public static void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public static string ReadTextFile(string filepath)
        {
            var path = Path.GetDirectoryName(filepath);

            if (!DirectoryExists(path))
            {
                throw new DirectoryNotFoundException($"Directory {path} doesn't exist.");
            }

            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException($"File {filepath} doesn't exist.");
            }

            using (var fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.None)) 
            {
                using (var sr = new StreamReader(fs))
                {
                    var text = sr.ReadToEnd();
                    return text;
                }
            }
        }

        // NOTE: we must prevent threads from accessing the same file at the
        //       same time. This way we can prevent data corruption when
        //       writing to the same file.
        public static void WriteTextFile(string filepath, string text, bool append = false)
        {
            // create directory
            var path = Path.GetDirectoryName(filepath);

            if (!DirectoryExists(path))
            {
                CreateDirectory(path);
            }

            // get write mode
            FileMode mode;

            if (append)
            {
                mode = FileMode.Append;
            }
            else
            {
                mode = FileMode.Create;
            }

            // get thread lock
            _writeLock.TryAdd(filepath, new object());

            // write text
            lock (_writeLock[filepath])
            {
                using (var fs = new FileStream(filepath, mode, FileAccess.Write, FileShare.None)) 
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        sw.Write(text);
                    }
                }
            }

            // release thread lock
            _writeLock.TryRemove(filepath, out _);
        }
    }
}