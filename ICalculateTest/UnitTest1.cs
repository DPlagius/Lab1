using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfLab1.Классы;

namespace ICalculateTest
{

    [TestClass]
    public class CalculateIntegralTest
    {
        private ICalculateIntegral midRectCalc = new MidRectangleCalculate();
        private ICalculateIntegral simpsCalc = new SimpsonsCalculate();
        private Func<double, double> _func = x => 31 * x - Math.Log(5 * x) + 5;

        [TestMethod]
        public void Calculate_Integral_Equality()
        {
            double lower = 1;
            double upper = 10000;
            int count = 10000;

            double rect = midRectCalc.Calculate(lower, upper, count, _func);
            double simps = simpsCalc.Calculate(lower, upper, count, _func);

            Assert.AreEqual(simps, rect, 0.1);
        }

        [TestMethod]
        public void Calculate_Integral_Equality_Rectangle_To_Actual()
        {
            double lower = 1;
            double upper = 100;
            int count = 10000;

            double rect = midRectCalc.Calculate(lower, upper, count, _func);
            double actual = 154958.65;

            Assert.AreEqual(actual, rect, 0.01);
        }

        [TestMethod]
        public void Calculate_Integral_Equality_Simpson_To_Actual()
        {
            double lower = 1;
            double upper = 100;
            int count = 10000;

            double simps = simpsCalc.Calculate(lower, upper, count, _func);
            double actual = 154958.65;

            Assert.AreEqual(actual, simps, 0.01);
        }

        [TestMethod]
        public void Lower_Is_Upper_Then_Upper_Exception_In_Rect()
        {
            double lower = 10000;
            double upper = 100;
            int count = 10000;

            Assert.ThrowsException<ArgumentException>(() => midRectCalc.Calculate(lower, upper, count, _func));
        }

        [TestMethod]
        public void Lower_Is_Upper_Then_Upper_Exception_In_Simps()
        {
            double lower = 10000;
            double upper = 100;
            int count = 10000;

            Assert.ThrowsException<ArgumentException>(() => simpsCalc.Calculate(lower, upper, count, _func));
        }
        [TestMethod]
        public void Count_Is_Lower_Then_Zero_Exception_In_Simps()
        {
            double lower = 10000;
            double upper = 100;
            int count = -1;

            Assert.ThrowsException<ArgumentException>(() => simpsCalc.Calculate(lower, upper, count, _func));
        }

        [TestMethod]
        public void Count_Is_Lower_Then_Zero_Exception_In_Rect()
        {
            double lower = 10000;
            double upper = 100;
            int count = -1;

            Assert.ThrowsException<ArgumentException>(() => midRectCalc.Calculate(lower, upper, count, _func));
        }

        [TestMethod]
        public void There_Is_No_Function_In_Rect()
        {
            double lower = 10000;
            double upper = 100;
            int count = 10000;
            Func<double, double> func = null;

            Assert.ThrowsException<ArgumentException>(() => midRectCalc.Calculate(lower, upper, count, func));
        }

        [TestMethod]
        public void There_Is_No_Function_In_Simps()
        {
            double lower = 10000;
            double upper = 100;
            int count = 10000;
            Func<double, double> func = null;

            Assert.ThrowsException<ArgumentException>(() => simpsCalc.Calculate(lower, upper, count, func));
        }
    }
}
