using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars.Katas.Katas
{
    internal class HumanReadableDataFormatKata
    {
        public static readonly int _secondsInMinute = 60;
        public static readonly int _secondsInHour = 3600;
        public static readonly int _secondsInDay = 86400;
        public static readonly int _secondsInYear = 31536000;

        public static readonly string _second = "second";
        public static readonly string _seconds = "seconds";

        public static readonly string _minute = "minute";
        public static readonly string _minutes = "minutes";

        public static readonly string _hour = "hour";
        public static readonly string _hours = "hours";


        public static readonly string _day = "day";
        public static readonly string _days = "days";

        public static readonly string _year = "year";
        public static readonly string _years = "years";

        public static string FormatDuration(int seconds)
        {
            string date = string.Empty;
            if (seconds == 0) return "now";

            date += GetDateBit(seconds, _secondsInYear, _year, _years, out int yearsDecrement);
            seconds -= yearsDecrement;

            date += GetDateBit(seconds, _secondsInDay, _day, _days, out int daysDecrement);
            seconds -= daysDecrement;

            date += GetDateBit(seconds, _secondsInHour, _hour, _hours, out int hoursDecrement);
            seconds -= hoursDecrement;

            date += GetDateBit(seconds, _secondsInMinute, _minute, _minutes, out int minutesDecrement);
            seconds -= minutesDecrement;
            
            date += GetDateBit(seconds, 1, _second, _seconds, out int _);

            date = date.Remove(date.Length - 2, 2);
            return PostProcessDateString(date);
        }

        public static string PostProcessDateString(string dateString)
        {
            string[] dateBits = dateString.Split(',');
            if(dateBits.Length <= 1)
                return dateString;

            string lastBit = dateBits[dateBits.Length - 1].Remove(0, 1);
            string formattedBit = $"and {lastBit}";

            string finalProduct = string.Empty;
            for (int i = 0; i < dateBits.Length; i++)
            {
                string bit = dateBits[i][0] == ' ' ? dateBits[i].Remove(0, 1) : dateBits[i];
                if (i == dateBits.Length - 2)
                    finalProduct += bit;
                else if (i < dateBits.Length - 1)
                    finalProduct += $"{bit}, ";
                else if (i == dateBits.Length - 1)
                    finalProduct += $" {formattedBit}";
            }

            return finalProduct;
        }

        public static string GetDateBit(int seconds, int timeframe, string singular, string plural, out int decrement)
        {
            int fits = FitsIn(seconds, timeframe);

            decrement = fits * timeframe;

            if (fits == 1) return $"{fits} {singular}, ";
            if(fits > 1) return $"{fits} {plural}, ";

            return string.Empty;
        }

        public static int FitsIn(int subject, int container)
        {
            double division = subject / container;
            return (int)Math.Floor(division);
        }
    }

    [TestFixture]
    public class HumanReadableDataFormatKataTests
    {
        [Test]
        public void basicTests()
        {
            Assert.AreEqual("now", HumanReadableDataFormatKata.FormatDuration(0));
            Assert.AreEqual("1 second", HumanReadableDataFormatKata.FormatDuration(1));
            Assert.AreEqual("1 minute and 2 seconds", HumanReadableDataFormatKata.FormatDuration(62));
            Assert.AreEqual("2 minutes", HumanReadableDataFormatKata.FormatDuration(120));
            Assert.AreEqual("1 hour, 1 minute and 2 seconds", HumanReadableDataFormatKata.FormatDuration(3662));
            Assert.AreEqual("182 days, 1 hour, 44 minutes and 40 seconds", HumanReadableDataFormatKata.FormatDuration(15731080));
            Assert.AreEqual("4 years, 68 days, 3 hours and 4 minutes", HumanReadableDataFormatKata.FormatDuration(132030240));
            Assert.AreEqual("6 years, 192 days, 13 hours, 3 minutes and 54 seconds", HumanReadableDataFormatKata.FormatDuration(205851834));
            Assert.AreEqual("8 years, 12 days, 13 hours, 41 minutes and 1 second", HumanReadableDataFormatKata.FormatDuration(253374061));
            Assert.AreEqual("7 years, 246 days, 15 hours, 32 minutes and 54 seconds", HumanReadableDataFormatKata.FormatDuration(242062374));
            Assert.AreEqual("3 years, 85 days, 1 hour, 9 minutes and 26 seconds", HumanReadableDataFormatKata.FormatDuration(101956166));
            Assert.AreEqual("1 year, 19 days, 18 hours, 19 minutes and 46 seconds", HumanReadableDataFormatKata.FormatDuration(33243586));
        }
    }
}
