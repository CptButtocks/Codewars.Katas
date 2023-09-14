using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars.Katas.Katas
{
    public static class MakeASpiralKata
    {
        public static int[,] Spiralize(int size)
        {
            int[,] spiral = new int[size, size];
            spiral = Spiralize(size, spiral, 0, 0, 0, 1, 1);

            return spiral;
        }

        public static int[,] Spiralize(int size, int[,] spiral, int x, int y, int dx, int dy, int padding)
        {
            if(IsSpiralComplete(size, spiral, x, y, dx, dy))
                return spiral;

            spiral[x, y] = 1;
            if(x + dx < 0 || x + dx >= size)
            {
                dy = dx == 1 ? -1 : 1;
                dx = 0;
            }

            if(y + dy < 0 || y + dy >= size)
            {
                dx = dy == 1 ? 1 : -1;
                dy = 0;
            }

            if(dx != 0 && x < size -2 && x >= 2 && spiral[x + dx + (padding * dx), y] == 1)
            {
                dy = dx == 1 ? -1 : 1;
                dx = 0;
            }

            if (dy != 0 && y < size - 2 && y >= 2 && spiral[x, y + dy + (dy * padding)] == 1)
            {
                dx = dy == 1 ? 1 : -1;
                dy = 0;
            }

            x += dx;
            y += dy;

            return Spiralize(size, spiral, x, y, dx, dy, padding);
        }

        public static bool IsSpiralComplete(int size, int[,] spiral, int x, int y, int dx, int dy)
        {
            if ((spiral[x, y] == 1)) return true;
            if (dx != 0 && x < size - 1 && x >= 1)
            {
                if(spiral[x + dx, y] == 1) return true;
                else if (dx == 1) return spiral[x + dx, y -1] == 1;
                else if (dx == -1) return spiral[x + dx, y + 1] == 1;
            }
            if (dy != 0 && y < size - 1 && y >= 1)
            {
                if (spiral[x, y + dy] == 1) return true;
                else if (dy == 1) return spiral[x + 1, y + dy] == 1;
                else if (dy == -1) return spiral[x - 1, y + dy] == 1;
            }

            return false;
        }

        public static string Print(int[,] spiral)
        {
            StringBuilder sb = new StringBuilder();
            long length = spiral.GetLongLength(1);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    string addition = j < length - 1 ? ", " : string.Empty;
                    sb.Append($"{spiral[i, j]}{addition}");
                }

                sb.Append('\n');
            }

            return sb.ToString();
        }
    }

    [TestFixture]
    public class MakeASpiralKataTest
    {

        [Test]
        public void Test05()
        {
            int input = 5;
            int[,] expected = new int[,]{
            {1, 1, 1, 1, 1},
            {0, 0, 0, 0, 1},
            {1, 1, 1, 0, 1},
            {1, 0, 0, 0, 1},
            {1, 1, 1, 1, 1}
        };

            int[,] actual = MakeASpiralKata.Spiralize(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test08()
        {
            int input = 8;
            int[,] expected = new int[,]{
            {1, 1, 1, 1, 1, 1, 1, 1},
            {0, 0, 0, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 0, 1},
            {1, 0, 0, 0, 0, 1, 0, 1},
            {1, 0, 1, 0, 0, 1, 0, 1},
            {1, 0, 1, 1, 1, 1, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 1, 1},
        };

            int[,] actual = MakeASpiralKata.Spiralize(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
