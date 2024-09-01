using System;
using System.Security.Cryptography;
using System.Text;

namespace CS.Common.Helpers
{
    public class PasswordSecurityHelper
    {
        private const string Alg = "HmacSHA256";

        private const string Salt = "rz8LuOtFBXphj9WQfvFh";

        public static string GetHashedPassword(string password)
        {
            var s = string.Join(":", password, "rz8LuOtFBXphj9WQfvFh");
            using var hMAC = HMAC.Create("HmacSHA256");
            hMAC.Key = Encoding.UTF8.GetBytes("rz8LuOtFBXphj9WQfvFh");
            hMAC.ComputeHash(Encoding.UTF8.GetBytes(s));
            var stringBuilder = new StringBuilder();
            var hash = hMAC.Hash;
            foreach (var b in hash) stringBuilder.AppendFormat("{0:X2}", b);

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(stringBuilder.ToString()));
        }

        public static string GetHashedPassword(object defaultPassword)
        {
            throw new NotImplementedException();
        }
    }
}