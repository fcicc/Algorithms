using System;

namespace Algorithms
{
    public class ConsolePlotter : IPlotter
    {
        public void Plot(string value)
        {
            Console.Write(value);
        }

        public void PlotLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
