using System.Collections.Generic;

namespace CodeJam.Problems.SevenDwarfs
{
    public static class BaseConverter
    {
        private const string Symbols = "0123456789ABCDEF";

        public static bool TryParse(string s, int numBase, out long num)
        {
            num = 0;

            foreach (var c in s.ToUpper())
            {
                var digit = Symbols.IndexOf(c);
                if (digit == -1 || digit >= numBase) return false;

                num = num * numBase + digit;
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