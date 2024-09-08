using System.Security.Cryptography;
using System.Text;

namespace Fuyu.Common.Hashing
{
    public static class Sha256
    {
        public static string Generate(string text)
        {
            using (var sha256 = SHA256.Create())
            {
                var sb = new StringBuilder();
                var bytes = Encoding.UTF8.GetBytes(text);
                var hash = sha256.ComputeHash(bytes);

                foreach (var b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
