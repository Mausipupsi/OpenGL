using System.Collections.Generic;
using System.Drawing;
using System;

// Клас для представлення параболи та обчислення точок перетину з відрізком
public class Parabola
{
    // Коефіцієнт A параболи
    public double A { get; set; } = 1;

    // Коефіцієнт B параболи
    public double B { get; set; } = 0;

    // Коефіцієнт C параболи
    public double C { get; set; } = 0;

    // Мінімальне значення параметра t
    public double TMin { get; set; } = -10;

    // Максимальне значення параметра t
    public double TMax { get; set; } = 10;

    // Метод для отримання точок перетину параболи з відрізком
    public List<PointF> GetIntersectionPoints(Segment segment, int numSegments = 100, double epsilon = 1e-6)
    {
        List<PointF> intersectionPoints = new List<PointF>();

        // Параметри параболи
        double tMin = TMin;
        double tMax = TMax;
        double deltaT = (tMax - tMin) / numSegments;

        // Параметри відрізка
        double x3 = segment.AX;
        double y3 = segment.AY;
        double x4 = segment.BX;
        double y4 = segment.BY;

        // Попередня точка на параболі
        double tPrev = tMin;
        double xPrev = tPrev;
        double yPrev = A * tPrev * tPrev + B * tPrev + C;

        for (int i = 1; i <= numSegments; i++)
        {
            double tCurr = tMin + i * deltaT;
            double xCurr = tCurr;
            double yCurr = A * tCurr * tCurr + B * tCurr + C;

            // Відрізок параболи
            double x1 = xPrev;
            double y1 = yPrev;
            double x2 = xCurr;
            double y2 = yCurr;

            // Вектори напрямку
            double s1_x = x2 - x1;
            double s1_y = y2 - y1;
            double s2_x = x4 - x3;
            double s2_y = y4 - y3;

            double denom = (-s2_x * s1_y + s1_x * s2_y);

            if (Math.Abs(denom) > epsilon)
            {
                double s = (-s1_y * (x1 - x3) + s1_x * (y1 - y3)) / denom;
                double t = (s2_x * (y1 - y3) - s2_y * (x1 - x3)) / denom;

                if (s >= 0 && s <= 1 && t >= 0 && t <= 1)
                {
                    // Перетин існує
                    double xi = x1 + t * s1_x;
                    double yi = y1 + t * s1_y;
                    intersectionPoints.Add(new PointF((float)xi, (float)yi));
                }
            }

            // Оновлюємо попередню точку
            tPrev = tCurr;
            xPrev = xCurr;
            yPrev = yCurr;
        }

        return intersectionPoints;
    }
}