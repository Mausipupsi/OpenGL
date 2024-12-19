using System.Collections.Generic;
using System.Drawing;
using System;

// Клас для представлення еліпса та обчислення точок перетину з відрізком
public class Ellipse
{
    // Координата X центру еліпса
    public double CenterX { get; set; } = 0;

    // Координата Y центру еліпса
    public double CenterY { get; set; } = 0;

    // Довжина великої піввісі
    public double SemiMajorAxis { get; set; } = 100;

    // Довжина малої піввісі
    public double SemiMinorAxis { get; set; } = 50;

    // Метод для отримання точок перетину еліпса з відрізком
    public List<PointF> GetIntersectionPoints(Segment segment, double epsilon = 1e-6)
    {
        List<PointF> intersectionPoints = new();

        double h = CenterX;
        double k = CenterY;
        double a = SemiMajorAxis;
        double b = SemiMinorAxis;

        double x1 = segment.AX;
        double y1 = segment.AY;
        double x2 = segment.BX;
        double y2 = segment.BY;

        double dx = x2 - x1;
        double dy = y2 - y1;

        // Параметричне рівняння прямої: x = x1 + t*dx, y = y1 + t*dy
        // Підставляємо в рівняння еліпса та вирішуємо щодо t
        double A = (dx * dx) / (a * a) + (dy * dy) / (b * b);
        double B = 2 * (dx * (x1 - h) / (a * a) + dy * (y1 - k) / (b * b));
        double C = ((x1 - h) * (x1 - h)) / (a * a) + ((y1 - k) * (y1 - k)) / (b * b) - 1;

        double discriminant = B * B - 4 * A * C;

        if (discriminant >= -epsilon)
        {
            if (discriminant < 0) discriminant = 0; // Урахування погрішності

            double sqrtDiscriminant = Math.Sqrt(discriminant);
            double t1 = (-B + sqrtDiscriminant) / (2 * A);
            double t2 = (-B - sqrtDiscriminant) / (2 * A);

            // Перевіряємо t1
            if (t1 >= 0 && t1 <= 1)
            {
                double xi = x1 + t1 * dx;
                double yi = y1 + t1 * dy;
                intersectionPoints.Add(new PointF((float)xi, (float)yi));
            }

            // Перевіряємо t2
            if (t2 >= 0 && t2 <= 1)
            {
                double xi = x1 + t2 * dx;
                double yi = y1 + t2 * dy;
                intersectionPoints.Add(new PointF((float)xi, (float)yi));
            }
        }

        return intersectionPoints;
    }
}