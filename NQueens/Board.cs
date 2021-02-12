using System;

namespace Algorithms.NQueens
{
    public class Board
    {
        private readonly Square[,] _squares;

        public Board(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size should be greater than zero.", nameof(size));
            }

            _squares = new Square[size, size];
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    _squares[i, j] = new Square();
                }
            }
        }

        public Square this[int rank, int file] => _squares[rank - 1, file - 1];

        public int Size => _squares.GetLength(0);
    }
}
