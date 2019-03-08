using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace CodeJam.Problems.SevenDwarfs
{
    public class BaseConverterTests
    {
        [TestCase("101", 2, 5)]
        [TestCase("1587", 10, 1587)]
        [TestCase("1343", 7, 521)]
        [TestCase("27CBC", 13, 74684)]
        [TestCase("11a178212bac5", 13, 26485657145615)]
        public void ParseTest(string s, int numBase, long expected)
        {
            Assert.IsTrue(BaseConverter.TryParse(s, numBase, out var result));
            Assert.AreEqual(expected, result);
        }

        [TestCase("1587", 7, 1587)]
        [TestCase("27CBC", 12, 26485657145615)]
        [TestCase("11a178212bac5", 12, 26485657145615)]
        public void OutOfBoundsParseTest(string s, int numBase, long expected)
        {
            Assert.IsFalse(BaseConverter.TryParse(s, numBase, out var result));
        }

        [TestCase("101", 2, 5)]
        [TestCase("1587", 10, 1587)]
        [TestCase("1343", 7, 521)]
        [TestCase("11a178212bac5", 13, 26485657145615)]
        public void ConstructTest(string expected, int numBase, long num)
        {
            Assert.AreEqual(expected.ToUpper(), BaseConverter.ToBase(num, numBase));
        }

        [TestCase("11")]
        [TestCase("101")]
        [TestCase("1011")]
        [TestCase("1587")]
        [TestCase("1343")]
        [TestCase("27CBC")]
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
            var generator = new StringBasedGenerator();
            var data = Enumerable.Range(0, 1000).Select(i => generator.GetRandom(1, 16)).Distinct().Take(100).ToList();
            Console.WriteLine($"divisible values count: {data.Count(IsDivisibleBy7)}");
            Console.WriteLine(string.Join(Environment.NewLine, data));
            Console.WriteLine();
            Console.WriteLine(string.Join(Environment.NewLine, data.Select(IsDivisibleBy7)));
        }

        [Test]
        public void CreateInputOutput()
        {
            var generator = new StringBasedGenerator();
            var testCaseCount = 100;
            var inputLines = Enumerable.Range(0, 10000).Select(i => generator.GetRandom(1, 16)).Distinct().Take(testCaseCount).ToList();
            
            Console.WriteLine(testCaseCount);
            foreach (var inputLine in inputLines)
            {
                Console.WriteLine(inputLine);
            }
            
            Console.WriteLine();

            for (var i = 0; i < inputLines.Count; i++)
            {
                var answer = IsDivisibleBy7(inputLines[i]) ? "TAIP" : "NE";
                Console.WriteLine($"Testas #{i+1}: {answer}");
            }
        }

        [Test]
        public void ProblemTest()
        {
            var problem = new SnowWhiteProblem();

            using (var reader = new StringReader(problem.Input))
            using (var writer = new StringWriter())
            {
                var testCaseCount = int.Parse(reader.ReadLine());
                for (var i = 0; i < testCaseCount; i++)
                {
                    var answer = IsDivisibleBy7(reader.ReadLine()) ? "TAIP" : "NE";
                    writer.WriteLine($"Testas #{i+1}: {answer}");
                }

                Assert.IsTrue(problem.CheckOutput(writer.ToString()));
            }
        }

        [Test]
        public void IncorrectProblemTest()
        {
            var problem = new SnowWhiteProblem();

            using (var reader = new StringReader(problem.Input))
            using (var writer = new StringWriter())
            {
                var testCaseCount = int.Parse(reader.ReadLine());
                for (var i = 0; i < testCaseCount; i++)
                {
                    var answer = IsDivisibleBy7(reader.ReadLine()) ? "TEIP" : "NE";
                    writer.WriteLine($"Testas #{i + 1}: {answer}");
                }

                Assert.IsFalse(problem.CheckOutput(writer.ToString()));
            }
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