using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfLab1.Классы;
using static WpfLab1.MainWindow;

namespace WpfLab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        private void btCalculate_Click(object sender, RoutedEventArgs e)
        {
            Func<double, double> f = (x => 31 * x - Math.Log(5 * x) + 5);
            double lowerLimit = Convert.ToDouble(tbLowerLimit.Text);
            double upperLimit = Convert.ToDouble(tbUpperLimit.Text);
            int count = Convert.ToInt32(tbCount.Text);
            ICalculateIntegral integral = method();

            Stopwatch time = System.Diagnostics.Stopwatch.StartNew();
            tbAnswer.Text = Convert.ToString(integral.Calculate(lowerLimit, upperLimit, count, f));
            time.Stop();
            tbTime.Text = Convert.ToString(time.ElapsedMilliseconds) + "ms";

            time.Restart();
            tbParalelAnswer.Text = Convert.ToString(integral.ParalelCalculate(lowerLimit, upperLimit, count, f));
            time.Stop();
            tbParalelTime.Text = Convert.ToString(time.ElapsedMilliseconds) + "ms";
        }

        public ICalculateIntegral method()
        {
            if (cmbMethod.SelectedIndex == 0)
                return new SimpsonsCalculate();
            return new MidRectangleCalculate();
        }
    }
}
