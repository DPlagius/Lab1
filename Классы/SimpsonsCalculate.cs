using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLab1.Классы
{
    public class SimpsonsCalculate : ICalculateIntegral
    {
        //private object _lock = new();

        public double Calculate(double lower, double upper, int count, Func<double, double> func)
        {
            if (lower > upper || lower <= 0 || count <= 0 || func == null)
                throw new ArgumentException("Wrong argumets");
            double step = (upper - lower) / count;
            double sum = func(lower) + func(upper);
            double x = lower + step;
            for (int i = 1; i < count; i++)
            {
                sum += (i % 2 == 0 ? 2 : 4) * func(x);
                x += step;
            }
            return sum * step / 3;
        }

        public double ParalelCalculate(double lower, double upper, int count, Func<double, double> func)
        {
            if (lower > upper || lower <= 0 || count <= 0 || func == null)
                throw new ArgumentException("Wrong argumets");
            double step = (upper - lower) / count;
            //double sum1 = 0;
            //double sum2 = 0;
            double sum = 0;
            sum = ParallelEnumerable.Range(1, count).Sum(i => (i % 2 == 0 ? 2 : 4) * func(lower + i * step));
            sum += (func(lower) + func(upper));
            /*Parallel.For(1, count / 2 + 1, i =>
            {
                lock (_lock)
                {
                    sum1 += func(lower + 2 * i * step);
                }
            });

            Parallel.For(1, count / 2, i =>
            {
                lock (_lock)
                {
                    sum2 += func(lower + (2 * i - 1) * step);
                }
            });*/
            return sum * step / 3;
        }
    }
}
