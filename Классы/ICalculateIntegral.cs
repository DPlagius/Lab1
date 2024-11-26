using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLab1.Классы
{
    public interface ICalculateIntegral
    {
        double Calculate(double lower, double upper, int count, Func<double, double> func);

        double ParalelCalculate(double lower, double upper, int count, Func<double, double> func);
    }
}
