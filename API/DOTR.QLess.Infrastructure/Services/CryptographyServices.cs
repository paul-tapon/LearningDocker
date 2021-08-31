using DOTR.QLess.Application.Common.Services;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DOTR.QLess.Infrastructure.Services
{
    public class CryptographyService : ICryptographyService
    {
        public string GenerateRandomPassword()
        {
            int targetLength = 8;
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[targetLength];
            for (int i = 0; i < targetLength; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }

        //public string GenerateSalt()
        //{
        //    int targetLength = 8;
        //    var salt = new byte[targetLength];
        //    using (var random = new RNGCryptoServiceProvider())
        //    {
        //        random.GetNonZeroBytes(salt);
        //    }
        //    return Convert.ToBase64String(salt); 
        //}

        public string HashPassword(string password, string salt)
        {
            var hashInBytes = PasswordHashProvider.CreateHash(password, ByteConverter.GetHexBytes(salt));


            return ByteConverter.GetHexString(hashInBytes);
        }

        public string GenerateHashedPasswordWithSalt(string password, ref string salt)
        {

            var passwordContainer = PasswordHashProvider.CreateHash(password);
            salt = ByteConverter.GetHexString(passwordContainer.Salt);

            return ByteConverter.GetHexString(passwordContainer.HashedPassword);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
