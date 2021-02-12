using System;

namespace Algorithms.FractionalKnapsack
{
    public interface IFractionalKnapsackSolvingStrategy
    {
        Item[] Solve(ReadOnlySpan<Item> items, int capacity);
    }
}
