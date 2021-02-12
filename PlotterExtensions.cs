using System;

namespace Algorithms
{
    public static class PlotterExtensions
    {
        public static void PlotValue<T>(this IPlotter plotter, string name, T value)
        {
            plotter.PlotLine($"{name}: {value}");
        }

        public static void PlotValues<T>(this IPlotter plotter, string name, ReadOnlySpan<T> values)
        {
            plotter.PlotLine($"{name}:");
            for (var i = 0; i < values.Length; i++)
            {
                plotter.PlotValue($"  {i}", values[i]);
            }
        }
    }
}
