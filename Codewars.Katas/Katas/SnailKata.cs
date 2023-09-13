using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars.Katas.Katas
{
    public static class SnailKata
    {
        public static int[] Snail(int[][] array)
        {
            Direction direction = Direction.Right;
            List<int> path = new List<int>(0);
            List<Point> visisted = new List<Point>();
            Point point = new Point(0, 0);
            int items = NumberOfItems(array);
            while(path.Count < items)
            {
                path.Add(array[point.Y][point.X]);
                visisted.Add(point);
                Point newPoint = Travel(point, direction);
                if (IsInBounds(newPoint, array) && !HasVisited(newPoint, visisted))
                {
                    point = newPoint;
                }
                else
                {
                    direction = NextDirection(direction);
                    point = Travel(point, direction);
                }
            }

            return path.ToArray();
        }

        public static int NumberOfItems(int[][] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    count++;
                }
            }

            return count;
        }

        public static Direction NextDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Left;
                case Direction.Left:
                    return Direction.Up;
                case Direction.Up:
                    return Direction.Right;
                default:
                    throw new ArgumentException($"Uknown direction: {direction}");
            }
        }

        public static Point Travel(Point point , Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:
                    return new Point(point.X + 1, point.Y);
                case Direction.Down:
                    return new Point(point.X, point.Y +1);
                case Direction.Left:
                    return new Point(point.X - 1, point.Y);
                case Direction.Up:
                    return new Point(point.X, point.Y - 1);
                default: throw new ArgumentException($"Unknown direction: {direction}");
            }
        }

        public static bool HasVisited(Point point, List<Point> visited) => visited.Where(p => p.X == point.X && p.Y == point.Y).Any();

        public static bool IsInBounds(Point point, int[][] field)
        {
            return point.X >= 0 && point.X < field[0].Length && point.Y >= 0 && point.Y < field.Length;
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public enum Direction
    {
        Left, Right, Up, Down
    }

    public class SnailKataTest
    {
        [Test]
        public void SnailTest1()
        {
            int[][] array =
            {
           new []{1, 2, 3},
           new []{4, 5, 6},
           new []{7, 8, 9}
       };
            var r = new[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
            Test(array, r);
        }

        public string Int2dToString(int[][] a)
        {
            return $"[{string.Join("\n", a.Select(row => $"[{string.Join(",", row)}]"))}]";
        }

        public void Test(int[][] array, int[] result)
        {
            var text = $"{Int2dToString(array)}\nshould be sorted to\n[{string.Join(",", result)}]\n";
            Console.WriteLine(text);
            Assert.AreEqual(result, SnailKata.Snail(array));
        }
    }
}
