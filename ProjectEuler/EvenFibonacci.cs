using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ProjectEuler
{
    [TestFixture]
    public class EvenFibonacciTests
    {
        [TestCase(1, new[] { 1 })]
        [TestCase(2, new[] { 1, 1 })]
        [TestCase(3, new[] { 1, 1, 2 })]
        [TestCase(4, new[] { 1, 1, 2, 3 })]
        [TestCase(5, new[] { 1, 1, 2, 3, 5 })]
        [TestCase(6, new[] { 1, 1, 2, 3, 5, 8 })]
        [TestCase(7, new[] { 1, 1, 2, 3, 5, 8, 13 })]
        [TestCase(8, new[] { 1, 1, 2, 3, 5, 8, 13, 21 })]
        [TestCase(9, new[] { 1, 1, 2, 3, 5, 8, 13, 21, 34 })]
        [TestCase(10, new[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 })]
        public void GetFibonaciSequenceOfLength(int n, int[] expectedList)
        {
            Assert.That(EvenFibonacci.FibonaciSequence(n), Is.EquivalentTo(expectedList.ToList()));
        }

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 3)]
        [TestCase(5, 5)]
        [TestCase(6, 8)]
        [TestCase(7, 13)]
        [TestCase(8, 21)]
        [TestCase(9, 34)]
        [TestCase(10, 55)]
        public void GetFibonaciElement(int n, int expectedElement)
        {
            Assert.That(EvenFibonacci.FibonaciElement(n), Is.EqualTo(expectedElement));
        }

        [TestCase(1, 0)]
        [TestCase(2, 2)]
        [TestCase(3, 2)]
        [TestCase(4, 2)]
        [TestCase(5, 2)]
        [TestCase(6, 2)]
        [TestCase(7, 2)]
        [TestCase(8, 10)]
        [TestCase(9, 10)]
        [TestCase(10, 10)]
        [TestCase(1000, 798)]
        [TestCase(4000000, 4613732)]
        public void SumOfEvenFibonacciElementsNotExceeding(int maxLength, int expectedResult)
        {
            Assert.That(EvenFibonacci.SumOfEvenFibonacciElementsNotExceeding(maxLength), Is.EqualTo(expectedResult));
        }
    }

    public static class EvenFibonacci
    {
        public static List<int> FibonaciSequence(int n)
        {
            var fibonacciSequence = new List<int>();

            Enumerable.Range(1, n)
                      .ToList()
                      .ForEach(e => fibonacciSequence.Add(FibonaciElement(e)));
            return fibonacciSequence;

        }

        public static int FibonaciElement(int n)
        {

            if (n < 3)
                return 1;

            return FibonaciElement(n - 1) + FibonaciElement(n - 2);
        }

        public static int SumOfEvenFibonacciElementsNotExceeding(int n)
        {
            var sum = 0;
            var current = 1;
            var i = 2;
            while (current <= n)
            {
                if (current % 2 == 0)
                    sum += current;

                current = FibonaciElement(i);
                i++;
            }
            return sum;
        }

    }
}