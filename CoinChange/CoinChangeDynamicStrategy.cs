using System;

namespace Algorithms.CoinChange
{
    public class CoinChangeDynamicStrategy : ICoinChangeSolvingStrategy
    {
        public int[] Solve(ReadOnlySpan<int> coins, int value)
        {
            var matrix = ComputeMatrix(coins, value);

            var solution = new int[coins.Length];
            for (var i = 0; i < coins.Length; i++)
            {
                solution[i] = matrix[value, i];
            }
            return solution;
        }

        private int[,] ComputeMatrix(ReadOnlySpan<int> coins, int value)
        {
            // last column represents total of coins
            var matrix = new int[value + 1, coins.Length + 1];
            for (var i = 1; i <= value; i++)
            {
                matrix[i, coins.Length] = int.MaxValue;
            }

            for (var j = 0; j < coins.Length; j++)
            {
                for (var i = 1; i <= value; i++)
                {
                    var previousIndex = i - coins[j];
                    if (previousIndex >= 0)
                    {
                        var currentAmount = matrix[i, coins.Length];
                        var previousAmount = matrix[previousIndex, coins.Length];
                        if (previousAmount + 1 < currentAmount)
                        {
                            for (var k = 0; k < coins.Length; k++)
                            {
                                matrix[i, k] = matrix[previousIndex, k];
                            }
                            matrix[i, j]++;
                            matrix[i, coins.Length] = previousAmount + 1;
                        }
                    }
                }
            }

            return matrix;
        }
    }
}
