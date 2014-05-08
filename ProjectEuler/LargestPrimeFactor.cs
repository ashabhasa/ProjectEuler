using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ProjectEuler
{
    [TestFixture]
    public class LargestPrimeFactorTests
    {
        [TestCase(3, 3)]
        [TestCase(5, 5)]
        [TestCase(7, 7)]
        [TestCase(13, 13)]
        [TestCase(17, 17)]
        [TestCase(19, 19)]
        [TestCase(23, 23)]
        public void LargestPrimeFactorOfPrime(int prime, int expectedResult)
        {
            Assert.AreEqual(expectedResult, LargestPrimeFactor.Of(prime));
        }
        [TestCase(6, 3)]
        [TestCase(210, 7)]
        [TestCase(13195, 29)]
        public void LargestPrimeFactorOfCompositeNumber(int composite, int expectedResult)
        {
            Assert.AreEqual(expectedResult, LargestPrimeFactor.Of(composite));
        }
    }

    public class LargestPrimeFactor
    {
        public static int Of(int number, int divisor = 2)
        {
            var primeSet = new List<int>();
            primeSet = GetList(number, divisor,ref  primeSet);
            return primeSet.Max();
        }

        private static List<int> GetList(int number, int divisor, ref List<int> primeList)
        {
            var primeSet = primeList;

            if (number % divisor == 0)
            {
                number /= divisor;
                if (number == 1)
                {
                    primeSet.Add(divisor);
                }
                else
                {
                    primeSet.AddRange(GetList(number, divisor, ref primeSet));
                }
            }
            else
            {
                primeSet.AddRange(GetList(number, divisor + 1, ref primeSet));
            }
            return primeSet;
        }
    }
}