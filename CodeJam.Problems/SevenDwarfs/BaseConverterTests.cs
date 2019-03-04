using System;
using System.Linq;
using NUnit.Framework;

namespace CodeJam.Problems.SevenDwarfs
{
    public class BaseConverterTests
    {
        [TestCase("101", 2, 5)]
        [TestCase("1587", 10, 1587)]
        [TestCase("1343", 7, 521)]
        [TestCase("11a178212bac5", 13, 26485657145615)]
        public void ParseTest(string s, int numBase, long expected)
        {
            Assert.IsTrue(BaseConverter.TryParse(s, numBase, out var result));
            Assert.AreEqual(expected, result);
        }

        [TestCase("101", 2, 5)]
        [TestCase("1587", 10, 1587)]
        [TestCase("1343", 7, 521)]
        [TestCase("11a178212bac5", 13, 26485657145615)]
        public void ConstructTest(string expected, int numBase, long num)
        {
            Assert.AreEqual(expected.ToUpper(), BaseConverter.ToBase(num, numBase));
        }

        [TestCase("101")]
        [TestCase("1011")]
        [TestCase("1587")]
        [TestCase("1343")]
        [TestCase("11a178212bac5")]
        public void IterateBases(string s)
        {
            for (var i = 2; i <= 16; i++)
            {
                Console.WriteLine(BaseConverter.TryParse(s, i, out var result)
                    ? $"{result}\t{result % 7}"
                    : "Out of bounds");
            }
        }

        [Test]
        public void RandomDataset()
        {
            var generator = new Generator(10);
            var data = Enumerable.Range(0, 100).Select(i => generator.GetRandom()).ToDictionary(i => i, IsDivisibleBy7);
            Console.WriteLine($"divisible values count: {data.Values.Count(v => v)}");
            Console.WriteLine(string.Join(Environment.NewLine, data.Keys));
            Console.WriteLine();
            Console.WriteLine(string.Join(Environment.NewLine, data.Values));
        }

        private bool IsDivisibleBy7(string s)
        {
            for (var numBase = 2; numBase <= 16; numBase++)
            {
                if (BaseConverter.TryParse(s, numBase, out var result) && result % 7 == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}