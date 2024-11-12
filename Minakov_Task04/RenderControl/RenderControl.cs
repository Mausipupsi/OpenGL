using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Minakov_Task04
{
    public partial class RenderControl : OpenGL
    {
        // Властивості для зберігання об'єктів
        public bool IsEllipseSelected { get; set; } = true;
        public Ellipse Ellipse { get; set; } = new Ellipse();
        public Parabola Parabola { get; set; } = new Parabola();
        public Segment Segment { get; set; } = new Segment();

        // Epsilon для обчислень
        public double Epsilon { get; set; } = 1e-6;

        // Флаг для визначення, яку точку встановлюємо
        private bool isSettingPointA = true;

        // Подія для повідомлення про зміну точок відрізка
        public event EventHandler SegmentPointsChanged;

        public RenderControl()
        {
            InitializeComponent();
        }

        // Метод рендерингу графіки
        private void RenderControl_Render(object sender, EventArgs e)
        {
            // Налаштування системи координат OpenGL
            glViewport(0, 0, Width, Height);
            glMatrixMode(GL_PROJECTION);
            glLoadIdentity();

            double worldWidth = 200;
            double worldHeight = 200;

            double aspectRatio = (double)Width / Height;
            if (aspectRatio >= 1.0)
            {
                worldWidth = 200 * aspectRatio;
            }
            else
            {
                worldHeight = 200 / aspectRatio;
            }

            glOrtho(-worldWidth / 2, worldWidth / 2, -worldHeight / 2, worldHeight / 2, -1, 1);

            glMatrixMode(GL_MODELVIEW);
            glLoadIdentity();
            glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
            glLineWidth(1.0f);
            // Малюємо сітку
            DrawGrid(worldWidth, worldHeight, 10);

            // Малюємо осі координат
            glLineWidth(3.0f);
            glColor3f(0.5f, 0.5f, 0.5f);
            glBegin(GL_LINES);
            // Ось X
            glVertex2d(-worldWidth / 2, 0);
            glVertex2d(worldWidth / 2, 0);
            // Ось Y
            glVertex2d(0, -worldHeight / 2);
            glVertex2d(0, worldHeight / 2);
            glEnd();

            // Малюємо відрізок
            glColor3f(0.0f, 1.0f, 0.0f); // Зелений колір
            glBegin(GL_LINES);
            glVertex2d(Segment.AX, Segment.AY);
            glVertex2d(Segment.BX, Segment.BY);
            glEnd();

            // Малюємо точки A і B
            glPointSize(8.5f);
            glBegin(GL_POINTS);
            // Точка A
            glColor3f(1.0f, 0.5f, 0.0f); // Помаранчевий
            glVertex2d(Segment.AX, Segment.AY);
            // Точка B
            glColor3f(0.0f, 0.5f, 1.0f); // Блакитний
            glVertex2d(Segment.BX, Segment.BY);
            glEnd();
            glLineWidth(1.5f);

            if (IsEllipseSelected)
            {
                // Малюємо еліпс
                glColor3f(0.0f, 0.0f, 1.0f); // Синій колір
                int numSegments = 100;
                double theta = 0.0;
                double deltaTheta = 2 * Math.PI / numSegments;
                glBegin(GL_LINE_LOOP);
                for (int i = 0; i < numSegments; i++)
                {
                    double x = Ellipse.CenterX + Ellipse.SemiMajorAxis * Math.Cos(theta);
                    double y = Ellipse.CenterY + Ellipse.SemiMinorAxis * Math.Sin(theta);
                    glVertex2d(x, y);
                    theta += deltaTheta;
                }
                glEnd();

                // Обчислення і малювання точок перетину
                List<PointF> intersectionPoints = Ellipse.GetIntersectionPoints(Segment, Epsilon);

                // Малюємо точки перетину
                glPointSize(8.5f);
                glColor3f(1.0f, 0.0f, 0.0f); // Червоний колір
                glBegin(GL_POINTS);
                foreach (PointF p in intersectionPoints)
                {
                    glVertex2d(p.X, p.Y);
                }
                glEnd();
            }
            else
            {
                // Малюємо параболу
                glColor3f(0.0f, 0.0f, 1.0f); // Синій колір
                int numSegments = 100;
                double tMin = Parabola.TMin;
                double tMax = Parabola.TMax;
                double deltaT = (tMax - tMin) / numSegments;
                glBegin(GL_LINE_STRIP);
                for (int i = 0; i <= numSegments; i++)
                {
                    double t = tMin + i * deltaT;
                    double x = t;
                    double y = Parabola.A * t * t + Parabola.B * t + Parabola.C;
                    glVertex2d(x, y);
                }
                glEnd();

                // Обчислення і малювання точок перетину
                List<PointF> intersectionPoints = Parabola.GetIntersectionPoints(Segment, numSegments, Epsilon);

                // Малюємо точки перетину
                glPointSize(8.5f);
                glColor3f(1.0f, 0.0f, 0.0f); // Червоний колір
                glBegin(GL_POINTS);
                foreach (PointF p in intersectionPoints)
                {
                    glVertex2d(p.X, p.Y);
                }
                glEnd();
            }
        }

        // Обробник події кліку миші
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // Перетворюємо координати курсора в світові координати
            double worldX, worldY;
            ScreenToWorld(e.X, e.Y, out worldX, out worldY);

            if (isSettingPointA)
            {
                // Встановлюємо точку A
                Segment.AX = worldX;
                Segment.AY = worldY;
                isSettingPointA = false; // Наступний клік встановить точку B
            }
            else
            {
                // Встановлюємо точку B
                Segment.BX = worldX;
                Segment.BY = worldY;
                isSettingPointA = true; // Скидання флагу
            }

            // Повідомляємо підписників про зміну точок відрізка
            SegmentPointsChanged?.Invoke(this, EventArgs.Empty);

            // Перемальовуємо контроль
            Invalidate();
        }

        // Метод для перетворення екранних координат у світові
        private void ScreenToWorld(int xScreen, int yScreen, out double xWorld, out double yWorld)
        {
            int viewportWidth = Width;
            int viewportHeight = Height;

            double worldWidth = 200;
            double worldHeight = 200;

            double aspectRatio = (double)viewportWidth / viewportHeight;
            if (aspectRatio >= 1.0)
            {
                worldWidth = 200 * aspectRatio;
            }
            else
            {
                worldHeight = 200 / aspectRatio;
            }

            xWorld = (double)xScreen / viewportWidth * worldWidth - worldWidth / 2;
            yWorld = -(double)yScreen / viewportHeight * worldHeight + worldHeight / 2;
        }

        // Метод для малювання сітки
        private static void DrawGrid(double worldWidth, double worldHeight, double gridSpacing)
        {
            glColor3f(0.85f, 0.85f, 0.85f); // Світло-сірий колір
            glBegin(GL_LINES);

            // Вертикальні лінії
            for (double x = 0; x <= worldWidth / 2; x += gridSpacing)
            {
                // Позитивні X
                glVertex2d(x, -worldHeight / 2);
                glVertex2d(x, worldHeight / 2);

                // Негативні X
                if (x != 0)
                {
                    glVertex2d(-x, -worldHeight / 2);
                    glVertex2d(-x, worldHeight / 2);
                }
            }

            // Горизонтальні лінії
            for (double y = 0; y <= worldHeight / 2; y += gridSpacing)
            {
                // Позитивні Y
                glVertex2d(-worldWidth / 2, y);
                glVertex2d(worldWidth / 2, y);

                // Негативні Y
                if (y != 0)
                {
                    glVertex2d(-worldWidth / 2, -y);
                    glVertex2d(worldWidth / 2, -y);
                }
            }

            glEnd();
        }
    }
}