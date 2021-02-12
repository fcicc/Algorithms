using System;

namespace Algorithms.CoinChange
{
    public class CoinChangeProblem : IProblem
    {
        private readonly ICoinChangeSolvingStrategy _strategy;

        public CoinChangeProblem(ICoinChangeSolvingStrategy strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        public void Solve(IPlotter plotter)
        {
            // Given an array of numbers that represent the values of each coin
            // Given an amount
            // Find the minimum number of coins that are needed to make that amount

            ReadOnlySpan<int> coins = stackalloc int[] { 1, 5, 10, 25, 50 };
            const int value = 74;

            var solution = _strategy.Solve(coins, value);

            plotter.PlotValue(nameof(value), value);
            for (var i = 0; i < coins.Length; i++)
            {
                plotter.PlotLine($"{solution[i]} coin(s) of {coins[i]}");
            }
        }
    }
}
