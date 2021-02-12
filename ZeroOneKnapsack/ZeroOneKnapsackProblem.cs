using System;
using System.Linq;

namespace Algorithms.ZeroOneKnapsack
{
    public class ZeroOneKnapsackProblem : IProblem
    {
        private readonly IZeroOneKnapsackSolvingStrategy _strategy;

        public ZeroOneKnapsackProblem(IZeroOneKnapsackSolvingStrategy strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        public void Solve(IPlotter plotter)
        {
            ReadOnlySpan<Item> items = stackalloc Item[]
            {
                new Item { Weight = 1, Value = 1 },
                new Item { Weight = 2, Value = 6 },
                new Item { Weight = 3, Value = 10 },
                new Item { Weight = 5, Value = 16 }
            };

            var capacity = 7;

            var solution = _strategy.Solve(items, capacity);

            plotter.PlotValues(nameof(items), items);
            plotter.PlotValue(nameof(capacity), capacity);
            plotter.PlotValues(nameof(solution), (ReadOnlySpan<Item>)solution);
            plotter.PlotValue("total", solution.Sum(i => i.Value));
        }
    }
}
