using System;

namespace Algorithms.CoinChange
{
    public interface ICoinChangeSolvingStrategy
    {
        int[] Solve(ReadOnlySpan<int> coins, int value);
    }
}
