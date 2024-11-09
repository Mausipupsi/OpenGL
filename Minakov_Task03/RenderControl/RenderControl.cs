using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Minakov_Task03.OpenGL;

namespace Minakov_Task03
{
    public partial class RenderControl : OpenGL
    {
        public RenderControl()
        {
            InitializeComponent();
        }

        private void RenderControl_Render(object sender, EventArgs e)
        {
            if (this.FindForm() is not MainForm mainForm)
                return;

            double Xmin = mainForm.Xmin;
            double Xmax = mainForm.Xmax;
            int Points = mainForm.Points;
            bool AutoY = mainForm.AutoY;
            FunctionBase function = mainForm.CurrentFunction;

            double[] xValues = new double[Points];
            double[] yValues = new double[Points];

            double step = (Xmax - Xmin) / (Points - 1);

            double calculatedYmin = double.MaxValue;
            double calculatedYmax = double.MinValue;

            for (int i = 0; i < Points; i++)
            {
                double x = Xmin + step * i;
                double y = function.Evaluate(x);

                xValues[i] = x;
                yValues[i] = y;

                if (!double.IsNaN(y) && !double.IsInfinity(y))
                {
                    if (y < calculatedYmin) calculatedYmin = y;
                    if (y > calculatedYmax) calculatedYmax = y;
                }
            }

            // Завжди оновлюємо автоматичний діапазон Y
            mainForm.SetAutoYRange(calculatedYmin, calculatedYmax);

            double Ymin, Ymax;

            if (AutoY)
            {
                Ymin = calculatedYmin;
                Ymax = calculatedYmax;
            }
            else
            {
                Ymin = mainForm.Ymin;
                Ymax = mainForm.Ymax;
            }

            if (Ymin == Ymax)
            {
                Ymin -= 1;
                Ymax += 1;
            }

            glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
            glViewport(0, 0, Width, Height);
            glMatrixMode(GL_PROJECTION);
            glLoadIdentity();

            // Налаштування системи координат
            glOrtho(Xmin, Xmax, Ymin, Ymax, -1, 1);

            // Установка модельно-видової матриці
            glMatrixMode(GL_MODELVIEW);
            glLoadIdentity();
            glColor3d(0.8, 0.8, 0.8); // Світло-сірий колір для сітки
            glLineWidth(1f);

            double gridSpacing = 1.0; // Інтервал між лініями сітки

            // Вертикальні лінії сітки
            glBegin(GL_LINES);
            double xGridStart = Math.Floor(Xmin / gridSpacing) * gridSpacing;
            double xGridEnd = Xmax;
            for (double x = xGridStart; x <= xGridEnd; x += gridSpacing)
            {
                glVertex2d(x, Ymin);
                glVertex2d(x, Ymax);
            }
            glEnd();

            // Горизонтальні лінії сітки
            glBegin(GL_LINES);
            double yGridStart = Math.Floor(Ymin / gridSpacing) * gridSpacing;
            double yGridEnd = Ymax;
            for (double y = yGridStart; y <= yGridEnd; y += gridSpacing)
            {
                glVertex2d(Xmin, y);
                glVertex2d(Xmax, y);
            }
            glEnd();

            // Рисуємо осі
            glColor3d(0.0, 0.0, 0.0); // Чорний колір
            glLineWidth(2f);

            glBegin(GL_LINES);
            // Ось X
            glVertex2d(Xmin, 0);
            glVertex2d(Xmax, 0);
            // Ось Y
            glVertex2d(0, Ymin);
            glVertex2d(0, Ymax);
            glEnd();

            // Знаходимо точки розриву
            List<double> discontinuities = function.GetDiscontinuities(Xmin, Xmax);

            if (discontinuities.Count > 0)
            {
                glEnable(GL_LINE_STIPPLE);
                glLineStipple(1, 0x00FF); // Шаблон пунктирної лінії
                glColor3d(0.0, 0.8, 0.0); // Темно-зелений колір
                glLineWidth(2f);

                foreach (double xDisc in discontinuities)
                {
                    glBegin(GL_LINES);
                    glVertex2d(xDisc, Ymin);
                    glVertex2d(xDisc, Ymax);
                    glEnd();
                }

                glDisable(GL_LINE_STIPPLE);
            }

            // Рисуємо графік функції
            glColor3d(1.0, 0.0, 0.0); // Червоний колір
            glLineWidth(1f);

            glBegin(GL_LINE_STRIP);
            for (int i = 0; i < Points; i++)
            {
                double x = xValues[i];
                double y = yValues[i];
                if (!double.IsNaN(y) && !double.IsInfinity(y))
                {
                    glVertex2d(x, y);
                }
                else
                {
                    // Прериваємо лінію при розриві
                    glEnd();
                    glBegin(GL_LINE_STRIP);
                }
            }
            glEnd();

            // Знаходимо та відмічаємо нулі функції
            glColor3d(0.0, 0.0, 1.0); // Синій колір

            glPointSize(7.0f); // Розмір точки

            glBegin(GL_POINTS);
            for (int i = 1; i < Points; i++)
            {
                double y1 = yValues[i - 1];
                double y2 = yValues[i];

                if ((y1 >= 0 && y2 <= 0) || (y1 <= 0 && y2 >= 0))
                {
                    // Оцінка нуля за допомогою лінійної інтерполяції
                    double x1 = xValues[i - 1];
                    double x2 = xValues[i];
                    double t = y1 / (y1 - y2);
                    double zeroX = x1 + t * (x2 - x1);
                    double zeroY = 0;

                    // Рисуємо точку в місці перетину з віссю X
                    glVertex2d(zeroX, zeroY);
                }
            }
            glEnd();
            glFlush();
        }
    }
}