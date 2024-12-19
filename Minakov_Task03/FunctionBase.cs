using System;
using System.Collections.Generic;

namespace Minakov_Task03
{
    public abstract class FunctionBase
    {
        // Абстрактний метод для обчислення значення функції в точці x
        public abstract double Evaluate(double x);

        // Віртуальний метод для отримання точок розриву функції
        public virtual List<double> GetDiscontinuities(double Xmin, double Xmax)
        {
            // За замовчуванням повертаємо порожній список
            return new List<double>();
        }
    }
}