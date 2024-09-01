using System;
using System.Security.Cryptography;
using System.Text;

namespace CS.Common.Helpers
{
    public class TokenSecurityHelper
    {
        private const string Alg = "HmacSHA256";

        private const int ExpirationMinutes = 10;

        public static string GenerateToken(string username, string password, string ip, string userAgent, long ticks)
        {
            var s = string.Join(":", username, ip, userAgent, ticks.ToString());
            string text;
            string text2;
            using (var hMAC = HMAC.Create("HmacSHA256"))
            {
                hMAC.Key = Encoding.UTF8.GetBytes(PasswordSecurityHelper.GetHashedPassword(password));
                hMAC.ComputeHash(Encoding.UTF8.GetBytes(s));
                text = Convert.ToBase64String(hMAC.Hash);
                text2 = string.Join(":", username, ticks.ToString());
            }

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(":", text, text2)));
        }
    }
}