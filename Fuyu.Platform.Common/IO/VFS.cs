using System.IO;

namespace Fuyu.Platform.Common.IO
{
    public class VFS
    {
        public static bool Exists(string filepath)
        {
            return File.Exists(filepath) || Directory.Exists(filepath);
        }

        public static void WriteTextFile(string filepath, string text)
        {
            if (!Exists(filepath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filepath));
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