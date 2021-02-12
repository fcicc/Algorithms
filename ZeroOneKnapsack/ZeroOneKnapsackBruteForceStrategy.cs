using System;
using System.Linq;

namespace Algorithms.ZeroOneKnapsack
{
    public class ZeroOneKnapsackBruteForceStrategy : IZeroOneKnapsackSolvingStrategy
    {
        public Item[] Solve(ReadOnlySpan<Item> items, int capacity)
        {
            return Knapsack(items, 0, capacity);
        }

        private Item[] Knapsack(ReadOnlySpan<Item> items, int index, int capacity)
        {
            // if there are no remaining items or capacity, returns empty
            if (index >= items.Length || capacity <= 0)
            {
                return new Item[0];
            }

            var currentItem = items[index];

            // computes solution considering that current item is ignored
            var ignoreCase = Knapsack(items, index + 1, capacity);

            // if current item exceeds remaining capacity, ignores it
            if (currentItem.Weight > capacity)
            {
                return ignoreCase;
            }
            else
            {
                // computes solution considering that current item is selected
                var selectCase = Knapsack(items, index + 1, capacity - currentItem.Weight);

                // chooses best solution
                // if it is better to select current item, concatenates with best solution and returns
                if (currentItem.Value + selectCase.Sum(i => i.Value) > ignoreCase.Sum(i => i.Value))
                {
                    var result = new Item[selectCase.Length + 1];
                    result[0] = currentItem;
                    for (var i = 0; i < selectCase.Length; i++)
                    {
                        result[i + 1] = selectCase[i];
                    }
                    return result;
                }
                // otherwise, returns best solution without concatenating current item
                else
                {
                    return ignoreCase;
                }
            }
        }
    }
}
