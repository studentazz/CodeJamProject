using System;
using System.Linq;

namespace CodeJam.Interfaces.SevenDwarfs
{
    public class StringBasedGenerator
    {
        private const string Symbols = "0123456789ABCDEF";

        private readonly Random _random = new Random();

        public string GetRandom(int minLength, int maxLength)
        {
            var length = _random.Next(minLength, maxLength);
            var numBase = _random.Next(2, 17);

            var chars = Enumerable.Range(0, length).Select(_ => Symbols[_random.Next(numBase)]).ToArray();
            if (chars[0] == '0') chars[0] = '1';

            return new string(chars);
        }
    }
}