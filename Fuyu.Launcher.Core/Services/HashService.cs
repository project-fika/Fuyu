using System;
using System.Security.Cryptography;
using System.Text;

namespace Fuyu.Launcher.Core.Services
{
    public static class HashService
    {
        public static string GetSHA256(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            var sha256 = SHA256.HashData(bytes);
            var hash = Convert.ToHexString(sha256);
            return hash;
        }
    }
}
