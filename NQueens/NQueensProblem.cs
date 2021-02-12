using System;

namespace Algorithms.NQueens
{
    public class NQueensProblem : IProblem
    {
        private readonly INQueensSolvingStrategy _strategy;

        public NQueensProblem(INQueensSolvingStrategy strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        public void Solve(IPlotter plotter)
        {
            const int size = 8;
            var board = _strategy.Solve(size);

            plotter.Plot(" ");
            for (var file = 1; file <= board.Size; file++)
            {
                plotter.Plot(" ");
                plotter.Plot(file.ToString());
            }
            plotter.PlotLine("");
            for (var rank = 1; rank <= board.Size; rank++)
            {
                plotter.Plot(rank.ToString());
                for (var file = 1; file <= board.Size; file++)
                {
                    plotter.Plot(" ");
                    plotter.Plot(board[rank, file].HasQueen ? "Q" : "-");
                }
                plotter.PlotLine("");
            }
        }
    }
}
