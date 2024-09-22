using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLab1.Классы
{
    internal class MidRectangleCalculate : ICalculateIntegral
    {
        public double Calculate(double lower, double upper, int count, Func<double, double> func)
        {
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
    }
}
