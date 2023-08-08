using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

// 256 bit key generator based on  SecureRandom

namespace task3
{
    internal class KeyGenerator
    {
        static public string getRandom()
        {
            RandomNumberGenerator generator = RandomNumberGenerator.Create();
            byte[] output = new byte[32];
            generator.GetBytes(output);
            return BitConverter.ToString(output).Replace("-", "");
        }
    }
}
