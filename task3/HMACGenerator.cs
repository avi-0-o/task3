using System;
using System.Collections.Generic;
using Org.BouncyCastle.Crypto.Digests;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;

namespace task3
{
    internal class HMACGenerator
    {
        static public string Hmac(byte[] key,string input)
        {
            byte[] data = Encoding.UTF8.GetBytes(input);

            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                byte[] hashBytes = hmac.ComputeHash(data);
                string hash = BitConverter.ToString(hashBytes).Replace("-", "");
                return hash;
            }

        }
    }
}
