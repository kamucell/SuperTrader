using System;
using System.Security.Cryptography;
using System.Text;

namespace SuperTrader.Core.Security
{
    public class PasswordHashingHmacsha512
    {
        private const int SaltSize = 16; 

        // Generate a salt
       

        
        private static byte[] HashPassword(string password, byte[] salt)
        {
            using (var hmac = new HMACSHA512(salt))
            {
                return hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static string CreateSaltedHash(string password)
        {
            byte[] salt = SecurityKeyGenerator.GenerateSalt();
            byte[] hash = HashPassword(password, salt);
            byte[] saltedHash = new byte[SaltSize + hash.Length];
            Array.Copy(salt, 0, saltedHash, 0, SaltSize);
            Array.Copy(hash, 0, saltedHash, SaltSize, hash.Length);
            return Convert.ToBase64String(saltedHash);
        }
        public static bool VerifyPassword(string password, string storedSaltedHash)
        {
            byte[] saltedHashBytes = Convert.FromBase64String(storedSaltedHash);
            byte[] salt = new byte[SaltSize];
            Array.Copy(saltedHashBytes, 0, salt, 0, SaltSize);
            byte[] storedHash = new byte[saltedHashBytes.Length - SaltSize];
            Array.Copy(saltedHashBytes, SaltSize, storedHash, 0, storedHash.Length);
            byte[] hash = HashPassword(password, salt);
            for (int i = 0; i < storedHash.Length; i++)
                if (hash[i] != storedHash[i])
                    return false;

            return true;
        }
        }
}
