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
        static public string Hmac(string input)
        {
            {
            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                byte[] hashBytes = hmac.ComputeHash(data);
                string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                Console.WriteLine(hash);
            }
        

        
            Sha3Digest sha3 = new Sha3Digest(256);
            byte[] inputbyte = Encoding.UTF8.GetBytes(input);
            sha3.BlockUpdate(inputbyte, 0, inputbyte.Length);
            byte[] temp = new byte[sha3.GetDigestSize()];
            sha3.DoFinal(temp, 0);
            return BitConverter.ToString(temp).Replace("-", "");
        }
    }
}
