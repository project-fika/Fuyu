using System;
using System.IO;

namespace Fuyu.Common.IO
{
    public class VFS
    {
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

        public static void WriteTextFile(string filepath, string text)
        {
            var path = Path.GetDirectoryName(filepath);

            if (!DirectoryExists(path))
            {
                CreateDirectory(path);
            }

            using (var fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None)) 
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.Write(text);
                }
            }
        }
    }
}