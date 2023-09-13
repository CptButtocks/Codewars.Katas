using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars.Katas.Katas
{
    public static class EvenOrOddKata
    {
        public static string EvenOrOdd(int number)
        {
            return number % 2 == 0 ? "Even" : "Odd";
        }
    }
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void ExampleTest()
        {
            Assert.AreEqual("Even", EvenOrOddKata.EvenOrOdd(2));
            Assert.AreEqual("Odd", EvenOrOddKata.EvenOrOdd(1));
            Assert.AreEqual("Even", EvenOrOddKata.EvenOrOdd(0));
            Assert.AreEqual("Odd", EvenOrOddKata.EvenOrOdd(7));
            Assert.AreEqual("Odd", EvenOrOddKata.EvenOrOdd(-1));
        }
    }
}
