using System;
using System.Security.Cryptography;
using System.Text;

namespace TodoListApp.Functions
{
    public class Hasher
    {
        private static SHA256 ha = SHA256.Create();

        public static string GetHash(string s)
        {
            byte[] data = ha.ComputeHash(Encoding.UTF8.GetBytes(s));

            var sb = new StringBuilder();

            for(int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            return sb.ToString();
        }

        public static bool VerifyHash(string s, string hash)
        {
            var inputHash = GetHash(s);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(inputHash, hash) == 0;
        }
    }
}

//Likely to be replaced with BCrypt
