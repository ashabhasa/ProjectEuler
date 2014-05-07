using System.Linq;
using NUnit.Framework;

namespace ProjectEuler
{
    [TestFixture]
    public class MultipleOfThreeOrFiveTests
    {
        [TestCase(1, 0)]
        [TestCase(2, 0)]
        [TestCase(3, 0)]
        [TestCase(4, 3)]
        [TestCase(5, 3)]
        [TestCase(6, 8)]
        [TestCase(7, 14)]
        [TestCase(8, 14)]
        [TestCase(9, 14)]
        [TestCase(10, 23)]
        [TestCase(15, 45)]
        [TestCase(1000, 233168)]
        public void SumOfMultiplesOf3And5LessThan(int n, int expectedSum)
        {
            Assert.AreEqual(expectedSum, MultipleOfThreeAndFive.Sum(n));
        }
    }

    public static class MultipleOfThreeAndFive
    {
        public static int Sum(int number)
        {
            var result = 0;
            Enumerable.Range(1, number - 1).ToList().ForEach(num =>
            {
                if (MultipleOf3(num) || MultipleOf5(num))
                    result += num;
            });
            return result;
        }

        private static bool MultipleOf5(int i)
        {
            return i % 5 == 0;
        }

        private static bool MultipleOf3(int i)
        {
            return i % 3 == 0;
        }
    }
}