using System;

namespace Minakov_Task03
{
    public class Function1 : FunctionBase
    {
        // Перевизначаємо метод Evaluate для обчислення f1(x)
        public override double Evaluate(double x)
        {
            return Math.Cos(x) / Math.Sqrt(Math.Cos(6 * x) + 1.01);
        }
    }
}