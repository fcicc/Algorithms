using System;
using System.Linq;

namespace Algorithms.FractionalKnapsack
{
    public class FractionalKnapsackProblem : IProblem
    {
        private readonly IFractionalKnapsackSolvingStrategy _strategy;

        public FractionalKnapsackProblem(IFractionalKnapsackSolvingStrategy strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        public void Solve(IPlotter plotter)
        {
            ReadOnlySpan<Item> items = stackalloc Item[]
            {
                new Item { Weight = 40, Value = 40, IsFraction = false },
                new Item { Weight = 20, Value = 100, IsFraction = false },
                new Item { Weight = 10, Value = 60, IsFraction = false },
                new Item { Weight = 30, Value = 120, IsFraction = false }
            };

            var capacity = 50;

            var solution = _strategy.Solve(items, capacity);

            plotter.PlotValues(nameof(items), items);
            plotter.PlotValue(nameof(capacity), capacity);
            plotter.PlotValues(nameof(solution), (ReadOnlySpan<Item>)solution);
            plotter.PlotValue("total", solution.Sum(i => i.Value));
        }
    }
}
