using System;
using System.Security.Cryptography;

namespace SuperTrader.Core.Security
{
    public static class SecurityKeyGenerator
    {
        public static string GenerateSecurityKey(int keySize = 256)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var keyBytes = new byte[keySize / 8];
                rng.GetBytes(keyBytes);
                return Convert.ToBase64String(keyBytes);
            }
        }
        public static  string GenerateSaltAsString(int size = 16)
        {
            return Convert.ToBase64String(GenerateSalt(size));
        }
        public static byte[] GenerateSalt(int size = 16)
        {
            var saltBytes = new byte[size];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return saltBytes;
        }
    }
}
