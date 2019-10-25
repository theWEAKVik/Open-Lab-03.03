using System;
using System.Collections;
using NUnit.Framework;

namespace Open_Lab_03._03
{
    [TestFixture]
    public class Tests
    {

        private Comparator comparator;

        private const int RandMaxDiff = 2;
        private const int RandNameMaxSize = 10;
        private const int RandSeed = 303303303;
        private const int RandTestCasesCount = 97;

        [OneTimeSetUp]
        public void Init() => comparator = new Comparator();

        [TestCase("AB", "CD", true)]
        [TestCase("ABC", "DE", false)]
        [TestCase("Test", "GitHub", false)]
        [TestCaseSource(nameof(GetRandom))]
        public void CompareCharactersCountTest(string str1, string str2, bool expectedOutput) =>
            Assert.That(comparator.CompareCharactersCount(str1, str2), Is.EqualTo(expectedOutput));

        private static IEnumerable GetRandom()
        {
            var random = new Random(RandSeed);

            for (var i = 0; i < RandTestCasesCount; i++)
            {
                var arrs = new char[2][];
                arrs[0] = new char[random.Next(RandNameMaxSize)];

                var size = arrs[0].Length + random.Next(RandMaxDiff * 2 + 1) - RandMaxDiff;
                arrs[1] = new char[size > RandNameMaxSize ? RandNameMaxSize : size < 0 ? 0 : size];

                for (var j = 0; j < 2; j++)
                    for (var k = 0; k < arrs[j].Length; k++)
                        arrs[j][k] = (char) random.Next('A', 'Z' + 1);

                yield return new TestCaseData(new string(arrs[0]), new string(arrs[1]), arrs[0].Length == arrs[1].Length);
            }
        }

    }
}
