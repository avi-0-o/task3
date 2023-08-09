using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;


namespace task3
{
    internal class KeyGenerator
    {
        byte[] key = Array.Empty<byte>();
        public byte[] SetRandomKey()
        {
            RandomNumberGenerator generator = RandomNumberGenerator.Create();
            key = new byte[32];
            generator.GetBytes(key);
            return key;
        }
        public string GetKey()
        {
            if (key.Length == 0)
            {
                Console.WriteLine("You must at first set the random key");
                return " ";
            }
            return BitConverter.ToString(key).Replace("-", "");
        }

    }
}
