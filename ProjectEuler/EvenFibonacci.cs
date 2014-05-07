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
        [TestCase(2, 0)]
        [TestCase(3, 2)]
        [TestCase(4, 2)]
        [TestCase(5, 2)]
        [TestCase(6, 10)]
        [TestCase(7, 10)]
        [TestCase(8, 10)]
        [TestCase(9, 44)]
        [TestCase(10, 44)]
        [TestCase(100000, 7203226363417812526)]
        [TestCase(1000000, 7203226363417812526)]
        public void SumOfEvenFibonacciSequenceOfLength1(int length, ulong expectedResult)
        {
            Assert.That(EvenFibonacci.SumOfEvenElements(length), Is.EqualTo(expectedResult));
        }
    }

    public static class EvenFibonacci
    {
        public static List<ulong> FibonaciSequence(int n)
        {
            var fibonacciSequence = new List<ulong>();

            Enumerable.Range(1, n)
                      .ToList()
                      .ForEach(e => fibonacciSequence.Add(FibonaciElement(e)));
            return fibonacciSequence;

        }

        public static ulong FibonaciElement(int n)
        {
            //recursive version
            //if (n < 3)
            //    return 1;

            //return FibonaciElement(n - 1) + FibonaciElement(n - 2);

            ulong prev = 0;
            ulong next = 1;
            for (var i = 1; i < n; i++)
            {
                var sum = prev + next;
                prev = next;
                next = sum;
            }
            return next;
        }

        public static ulong SumOfEvenElements(int n)
        {
            return FibonaciSequence(n).Where(el => el%2 == 0).Aggregate<ulong, ulong>(0, (current, el) => current + el);
            //return FibonaciSequence(n).Where(element => element % 2 == 0).Sum();
        }
    }
}