namespace Algorithms.NQueens
{
    public class NQueensBacktrackingStrategy : INQueensSolvingStrategy
    {
        public Board Solve(int size)
        {
            // creates an empty board instance to work with
            var board = new Board(size);

            // executes algorithm
            // if a solution is found, returns the board in its current state
            if (SearchForSolution(board, 1))
            {
                return board;
            }

            // if no solution is found, returns nothing
            return null;
        }

        private bool SearchForSolution(Board board, int rank)
        {
            // if passed last rank, a solution was found
            if (rank > board.Size)
            {
                return true;
            }

            for (var j = 1; j <= board.Size; j++)
            {
                // looks for a file where the queen can be placed at
                if (CanPlaceQueenAt(board, rank, j))
                {
                    // places the queen
                    board[rank, j].HasQueen = true;

                    // passes to next rank
                    // if a solution is found, ends the algorithm
                    if (SearchForSolution(board, rank + 1))
                    {
                        return true;
                    }

                    // if no solution is found, removes the queen and continues
                    // searching in the remaining files
                    board[rank, j].HasQueen = false;
                }
            }

            // if no solution possible solution is found in this rank, returns to previous rank
            // so it can search for other solutions
            return false;
        }

        private bool CanPlaceQueenAt(Board board, int rank, int file)
        {
            int i, j, k;

            for (i = rank - 1, j = file - 1, k = file + 1;
                 i >= 1;
                 i--, j--, k++)
            {
                if (board[i, file].HasQueen)
                {
                    return false;
                }
                if (j >= 1 && board[i, j].HasQueen)
                {
                    return false;
                }
                if (k <= board.Size && board[i, k].HasQueen)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
