using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars.Katas.Katas
{
    public static class VowelCountKata
    {
        private static readonly char[] _vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
        public static int GetVowelCount(string str)
        {
            int vowelCount = 0;

            foreach(char c in str.ToLower())
                if(_vowels.Contains(c)) vowelCount++;

            return vowelCount;
        }
    }

    [TestFixture]
    public class VowelCountKataTests
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(5, VowelCountKata.GetVowelCount("abracadabra"));
        }
    }
}
