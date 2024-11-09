using System;
using System.Collections.Generic;

namespace Minakov_Task03
{
    public class Function2 : FunctionBase
    {
        // Перевизначаємо метод Evaluate для обчислення f2(x)
        public override double Evaluate(double x)
        {
            return Math.Log(1 + Math.Cos(x)) * Math.Log10(2 + Math.Sin(5 * x));
        }

        // Перевизначаємо метод GetDiscontinuities для визначення точок розриву
        public override List<double> GetDiscontinuities(double Xmin, double Xmax)
        {
            List<double> discontinuities = new();

            int nStart = (int)Math.Ceiling((Xmin - Math.PI) / (2 * Math.PI));
            int nEnd = (int)Math.Floor((Xmax - Math.PI) / (2 * Math.PI));

            for (int n = nStart; n <= nEnd; n++)
            {
                double xDisc = Math.PI + 2 * Math.PI * n;
                if (xDisc >= Xmin && xDisc <= Xmax)
                {
                    discontinuities.Add(xDisc);
                }
            }

            return discontinuities;
        }
    }
}