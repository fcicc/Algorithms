using Algorithms.NQueens;

namespace Algorithms
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            IPlotter plotter = new ConsolePlotter();
            IProblem problem = new NQueensProblem(
                new NQueensBacktrackingStrategy()
            );
            problem.Solve(plotter);
        }
    }
}
