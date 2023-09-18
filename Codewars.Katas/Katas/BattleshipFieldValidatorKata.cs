using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Codewars.Katas.Katas
{
    public class BattleshipFieldValidatorKata
    {
        public static bool ValidateBattlefield(int[,] field)
        {
            Board board = new Board(field);
            return true;
        }
    }

    public class Board : IEnumerable<Cell>
    {
        private Cell[,] _cells { get; set; }

        public Board(int[,] field)
        {
            int size = field.GetLength(0);
            _cells = new Cell[size, size];

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    _cells[y, x] = new Cell() { IsOccupied = field[y, x] == 1 };
                }
            }

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if(y > 0)
                        _cells[y, x].Top = _cells[y - 1, x];
                    if (x > 0)
                        _cells[y, x].Left = _cells[y, x - 1];
                    if(x > 0 && y > 0)
                        _cells[y, x].TopLeft = _cells[y - 1, x - 1];
                    if(y < size - 1)
                        _cells[y, x].Bottom = _cells[y + 1, x];
                    if(x < size - 1)
                        _cells[y, x].Right = _cells[y, x + 1];
                    if(x < size -1 && y < size - 1)
                        _cells[y, x].BottomRight = _cells[y + 1, x + 1];
                    if (y > 0 && x < size - 1)
                        _cells[y, x].TopRight = _cells[y - 1, x + 1];
                    if (y < size - 1 && x > 0)
                        _cells[y, x].BottomLeft = _cells[y + 1, x - 1];
                }
            }
        }

        public IEnumerator<Cell> GetEnumerator()
        {
            int size = _cells.GetLength(0);
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    yield return (_cells[x, y]);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class Cell
    {
        public bool IsOccupied { get; set; }
        public Cell? Top { get; set; }
        public Cell? Bottom { get; set; }
        public Cell? Left { get; set; }
        public Cell? Right { get; set; }

        public Cell? TopRight { get; set; }
        public Cell? BottomRight { get; set; }
        public Cell? TopLeft { get; set;}
        public Cell? BottomLeft { get; set; }
    }

    [TestFixture]
    public class BattleshipFieldValidatorKataTest
    {
        [Test]
        public void TestCase()
        {
            int[,] field = new int[10, 10]
                {{1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
            Assert.IsTrue(BattleshipFieldValidatorKata.ValidateBattlefield(field));
        }
    }
}
