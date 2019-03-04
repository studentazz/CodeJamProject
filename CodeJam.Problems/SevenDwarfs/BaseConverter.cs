using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeJam.Problems.SevenDwarfs
{
    public static class BaseConverter
    {
        private const string Symbols = "0123456789ABCDEF";

        public static bool TryParse(string s, int numBase, out long num)
        {
            
            var symbolsBase = new string(Symbols.Take(numBase).ToArray());

            var chars = s.ToUpper().ToCharArray().Reverse().ToArray();

            num = 0;
            for (var i = 0; i < chars.Length; i++)
            {
                var digit = symbolsBase.IndexOf(chars[i]);
                if (digit == -1) return false;

                num += digit * (long) Math.Pow(numBase, i);
            }

            return true;
        }

        public static string ToBase(long num, int numBase)
        {
            var chars = new List<char>();

            while (num > 0)
            {
                var digit = (int) (num % numBase);
                chars.Add(Symbols[digit]);

                num = num / numBase;
            }

            chars.Reverse();

            return new string(chars.ToArray());
        }
    }
}