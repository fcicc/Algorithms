using System;

namespace Algorithms.FractionalKnapsack
{
    public class FractionalKnapsackGreedyStrategy : IFractionalKnapsackSolvingStrategy
    {
        public Item[] Solve(ReadOnlySpan<Item> items, int capacity)
        {
            Span<Item> sorted = stackalloc Item[items.Length];
            items.CopyTo(sorted);
            MergeSortDescending(sorted);

            Span<Item> solution = stackalloc Item[sorted.Length];
            var currentWeight = 0.0;
            int i;

            for (i = 0; i < sorted.Length; i++)
            {
                if (currentWeight + sorted[i].Weight <= capacity)
                {
                    currentWeight += sorted[i].Weight;
                    solution[i] = sorted[i];
                }
                else
                {
                    var remainingWeight = capacity - currentWeight;
                    solution[i] = new Item
                    {
                        Value = sorted[i].Value * (remainingWeight / sorted[i].Weight),
                        Weight = remainingWeight,
                        IsFraction = true
                    };
                    i++;
                    break;
                }
            }

            var result = new Item[i];
            for (var j = 0; j < i; j++)
            {
                result[j] = solution[j];
            }
            return result;
        }

        private void MergeSortDescending(Span<Item> items)
        {
            Span<Item> aux = stackalloc Item[items.Length];
            items.CopyTo(aux);
            SplitAndMerge(items, aux);
        }

        private void SplitAndMerge(Span<Item> items, Span<Item> aux)
        {
            if (items.Length > 1)
            {
                var iMiddle = items.Length / 2;
                var countRight = items.Length % 2 == 0 ? iMiddle : iMiddle + 1;

                var itemsLeft = items.Slice(0, iMiddle);
                var itemsRight = items.Slice(iMiddle, countRight);
                var auxLeft = aux.Slice(0, iMiddle);
                var auxRight = aux.Slice(iMiddle, countRight);

                SplitAndMerge(itemsLeft, auxLeft);
                SplitAndMerge(itemsRight, auxRight);

                Merge(auxLeft, auxRight, items);

                items.CopyTo(aux);
            }
        }

        private void Merge(ReadOnlySpan<Item> left, ReadOnlySpan<Item> right, Span<Item> dest)
        {
            var iLeft = 0;
            var iRight = 0;
            var iDest = 0;

            while (iDest < dest.Length)
            {
                if (iRight >= right.Length)
                {
                    dest[iDest++] = left[iLeft++];
                }
                else if (iLeft >= left.Length)
                {
                    dest[iDest++] = right[iRight++];
                }
                else
                {
                    dest[iDest++] = left[iLeft].CompareTo(right[iRight]) > 0
                        ? left[iLeft++]
                        : right[iRight++];
                }
            }
        }
    }
}
