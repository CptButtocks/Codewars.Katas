using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars.Katas.Katas
{
    public static class MultiplesOfThreeAndFiveKata
    {
        public static int Solution(int value)
        {
            if (value < 0)
                return 0;

            int sum = 0;
            for (int i = 0; i < value; i++)
            {
                if (IsMultipleOfThreeOrFive(i)) sum += i;
            }

            return sum;
        }

        private static bool IsMultipleOfThreeOrFive(int value) => IsMultipleOf(value, 3) || IsMultipleOf(value, 5);

        private static bool IsMultipleOf(int value, int n) => value % n == 0;
    }

    [TestFixture]
    public class MultiplesOfThreeAndFiveKataTests
    {
        [Test]
        public void Test()
        {
            Assertion(expected: 23, input: 10);
            Assertion(expected: 78, input: 20);
            Assertion(expected: 9168, input: 200);
            Assertion(expected: 0, input: 0);
        }

        private static void Assertion(int expected, int input) =>
          Assert.AreEqual(
            expected,
            MultiplesOfThreeAndFiveKata.Solution(input),
            $"Value: {input}"
          );
    }
}
