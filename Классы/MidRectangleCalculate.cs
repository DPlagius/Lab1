using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfLab1.Классы
{
    public class MidRectangleCalculate : ICalculateIntegral
    {
        //private object _lock = new();

        public double Calculate(double lower, double upper, int count, Func<double, double> func)
        {
            if (lower > upper || lower <= 0 || count <= 0 || func == null)
                throw new ArgumentException("Wrong argumets");
            double step = (upper - lower) / count;
            double sum = 0;
            double x = lower + step / 2;
            for (int i = 0; i < count; i++)
            {
                sum += func(x);
                x += step;
            }
            return sum * step;
        }

        public double ParalelCalculate(double lower, double upper, int count, Func<double, double> func)
        {
            
            if (lower > upper || lower <= 0 || count <= 0 || func == null)
                throw new ArgumentException("Wrong argumets");
            double step = (upper - lower) / count;
            double sum = 0;
            sum = ParallelEnumerable.Range(0, count).Sum(i => func(lower + (i + 0.5) * step));
            /*Parallel.For(0, count, i =>
            {
                lock (_lock)
                {
                    sum += func(lower + (i + 0.5) * step);
                }
            });*/
            return sum * step;
        }
    }
}
