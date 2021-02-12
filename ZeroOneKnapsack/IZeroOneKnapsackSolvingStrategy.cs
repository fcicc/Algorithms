using System;

namespace Algorithms.ZeroOneKnapsack
{
    public interface IZeroOneKnapsackSolvingStrategy
    {
        Item[] Solve(ReadOnlySpan<Item> items, int capacity);
    }
}
