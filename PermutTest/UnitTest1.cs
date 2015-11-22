using System;
using Permutation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace PermutTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Random rnd = new Random();
            int n = 50;
            int maxIndex = PermutationCalc.Factorial(n) - 1;
            int index = rnd.Next(0, maxIndex);
            int m = rnd.Next(1, Math.Max(maxIndex - index, 1));
            PermutationCalc.ShowPerms(n, index, m);
        }
    }
}
