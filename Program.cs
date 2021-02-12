using Algorithms.CoinChange;

namespace Algorithms
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            IPlotter plotter = new ConsolePlotter();
            IProblem problem = new CoinChangeProblem(
                new CoinChangeDynamicStrategy()
            );
            problem.Solve(plotter);
        }
    }
}
