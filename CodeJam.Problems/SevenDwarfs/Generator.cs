using System;

namespace CodeJam.Problems.SevenDwarfs
{
    public class Generator
    {
        private readonly long _minValue;
        private readonly int _minValueMagnitude;

        private readonly Random _random = new Random();

        public Generator(long minValue)
        {
            if (minValue < 0) throw new ArgumentException();

            _minValue = minValue;
            _minValueMagnitude = _minValue.ToString().Length;
        }

        public string GetRandom()
        {
            var num = RandomLongLogDistributed();
            var numBase = _random.Next(2, 17);
            return BaseConverter.ToBase(num, numBase);
        }

        private long RandomLongLogDistributed()
        {
            var digitCount = _random.Next(_minValueMagnitude, 19);
            var maxVal = (long)Math.Pow(10, digitCount);
            return RandomLong(_minValue, maxVal);
        }

        private long RandomLong(long min, long max)
        {
            var buf = new byte[8];
            _random.NextBytes(buf);
            var longRand = BitConverter.ToInt64(buf, 0);

            return Math.Abs(longRand % (max - min)) + min;
        }
    }
}