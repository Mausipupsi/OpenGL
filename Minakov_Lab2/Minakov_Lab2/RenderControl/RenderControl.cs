using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Minakov_Lab2.OpenGL;
using static Minakov_Lab2.RenderControl;

namespace Minakov_Lab2
{
    public partial class RenderControl : OpenGL
    {
        // Кількість плиток по горизонталі та вертикалі
        private int horizontalCount = 1;
        private int verticalCount = 1;
        // Поточний режим рендерингу
        private RenderMode currentMode = RenderMode.Fill;

        // Перелік можливих режимів рендерингу
        public enum RenderMode
        {
            Fill,
            Line,
            Point
        }

        // Подія зміни режиму рендерингу
        public event EventHandler<RenderModeChangedEventArgs> RenderModeChanged;

        // Клас аргументів для події зміни режиму рендерингу
        public class RenderModeChangedEventArgs : EventArgs
        {
            public RenderMode NewRenderMode { get; private set; }

            public RenderModeChangedEventArgs(RenderMode newRenderMode)
            {
                NewRenderMode = newRenderMode;
            }
        }

        // Список кнопок для вибору режиму рендерингу
        private readonly List<Button> buttons = new();

        // Конструктор контролу рендерингу
        public RenderControl()
        {
            InitializeComponent();
            InitializeButtons();
            // Підписка на події зміни розміру, натискання миші та малювання
            this.Resize += new EventHandler(RenderControl_Resize);
            this.MouseDown += new MouseEventHandler(RenderControl_MouseDown);
            this.Paint += new PaintEventHandler(RenderControl_Paint);
            this.DoubleBuffered = false;
            SetStyle(ControlStyles.Opaque, true);
        }

        // Обробник події зміни розміру контролу
        private void RenderControl_Resize(object sender, EventArgs e)
        {
            InitializeButtons();
            Invalidate();
        }

        // Обробник події натискання миші
        private void RenderControl_MouseDown(object sender, MouseEventArgs e)
        {
            float mouseX = e.X;
            float mouseY = Height - e.Y;

            // Перевірка, чи натиснута кнопка
            foreach (var button in buttons)
            {
                if (button.IsPointInside(mouseX, mouseY))
                {
                    if (currentMode != button.Mode)
                    {
                        currentMode = button.Mode;
                        Invalidate();
                        OnRenderModeChanged(new RenderModeChangedEventArgs(currentMode));
                    }
                    break;
                }
            }
        }

        // Метод виклику події зміни режиму рендерингу
        protected virtual void OnRenderModeChanged(RenderModeChangedEventArgs e)
        {
            RenderModeChanged?.Invoke(this, e);
        }

        // Обробник події малювання контролу
        private void RenderControl_Paint(object sender, PaintEventArgs e)
        {
            RenderControl_Render(sender, e);
        }

        // Ініціалізація кнопок вибору режиму рендерингу
        private void InitializeButtons()
        {
            buttons.Clear();
            float buttonWidth = 80f;
            float buttonHeight = 30f;
            float spacing = 10f;
            float totalWidth = 3 * buttonWidth + 2 * spacing;
            float startX = (Width - totalWidth) / 2f;
            float startY = Height - buttonHeight - 10f;

            // Створення трьох кнопок: Fill, Line, Point
            buttons.Add(new Button(startX, startY, startX + buttonWidth, startY + buttonHeight, "Fill", RenderMode.Fill));
            buttons.Add(new Button(startX + buttonWidth + spacing, startY, startX + 2 * buttonWidth + spacing, startY + buttonHeight, "Line", RenderMode.Line));
            buttons.Add(new Button(startX + 2 * (buttonWidth + spacing), startY, startX + 3 * buttonWidth + 2 * spacing, startY + buttonHeight, "Point", RenderMode.Point));
        }

        // Метод рендерингу контролу
        private void RenderControl_Render(object sender, EventArgs e)
        {
            glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT); // Очищення буферів
            SetupViewport();
            DrawButtons(); // Малювання кнопок
            DrawFigures(); // Малювання фігур
            glFlush();
        }

        // Налаштування в'юпорту та проекції
        private void SetupViewport()
        {
            glViewport(0, 0, Width, Height);
            glMatrixMode(GL_PROJECTION);
            glLoadIdentity();
            glOrtho(0, Width, 0, Height, -1, 1);
            glMatrixMode(GL_MODELVIEW);
            glLoadIdentity();
        }

        // Метод малювання кнопок
        private void DrawButtons()
        {
            glPolygonMode(GL_FRONT_AND_BACK, GL_FILL);
            glLineWidth(1f);
            glPointSize(1f);
            glDisable(GL_LINE_STIPPLE);
            glDisable(GL_POINT_SMOOTH);

            // Малювання кожної кнопки
            foreach (var button in buttons)
            {
                bool isSelected = button.Mode == currentMode;
                button.Draw(isSelected);
            }
        }

        // Метод малювання фігур залежно від режиму
        private void DrawFigures()
        {
            glMatrixMode(GL_PROJECTION);
            glLoadIdentity();
            float aspectRatio = (float)Width / Height;
            float a = 1000;
            float figureWidth = a * 2f;
            float figureHeight = (float)(2f * Math.Sqrt(a * a - a * a / 4f));
            float horizontalSpacing = a + a / 2f;
            float totalWidth = figureWidth + (horizontalCount - 1) * horizontalSpacing;
            float totalHeight = figureHeight * verticalCount;
            float maxDimension = Math.Max(totalWidth, totalHeight);
            float halfSize = maxDimension * 0.75f;

            // Налаштування ортотичної проекції з урахуванням співвідношення сторін
            if (aspectRatio >= 1.0f)
            {
                glOrtho(-halfSize * aspectRatio, halfSize * aspectRatio, -halfSize, halfSize, -1, 1);
            }
            else
            {
                glOrtho(-halfSize, halfSize, -halfSize / aspectRatio, halfSize / aspectRatio, -1, 1);
            }

            glMatrixMode(GL_MODELVIEW);
            glLoadIdentity();

            float startX = -totalWidth / 2f;
            float startY = totalHeight / 2f - figureHeight / 2f;

            // Малювання сітки фігур
            for (int row = 0; row < verticalCount; row++)
            {
                float xPos = startX;
                float yPos = startY - row * figureHeight;
                for (int col = 0; col < horizontalCount; col++)
                {
                    var figure = new ComplexFigure(xPos, yPos, a, figureHeight);
                    figure.Draw(currentMode);

                    // Зміщення позиції
                    if (col % 2 == 0)
                    {
                        xPos += horizontalSpacing;
                        yPos -= figureHeight / 2f;
                    }
                    else
                    {
                        xPos += horizontalSpacing;
                        yPos += figureHeight / 2f;
                    }
                }
            }
        }

        // Метод оновлення кількості плиток та перемалювання
        public void UpdateTileCount(int horizontal, int vertical)
        {
            horizontalCount = horizontal;
            verticalCount = vertical;
            Invalidate();
        }

        // Метод встановлення нового режиму рендерингу
        public void SetRenderMode(RenderMode mode)
        {
            if (currentMode != mode)
            {
                currentMode = mode;
                Invalidate();
                OnRenderModeChanged(new RenderModeChangedEventArgs(currentMode));
            }
        }
    }

    // Клас, що представляє кнопку вибору режиму рендерингу
    public class Button
    {
        public float X1 { get; set; }
        public float Y1 { get; set; }
        public float X2 { get; set; }
        public float Y2 { get; set; }
        public string Text { get; set; }
        public RenderControl.RenderMode Mode { get; set; }

        // Конструктор кнопки
        public Button(float x1, float y1, float x2, float y2, string text, RenderControl.RenderMode mode)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            Text = text;
            Mode = mode;
        }

        // Метод малювання кнопки
        public void Draw(bool isSelected)
        {
            // Встановлення кольору фону кнопки
            if (isSelected)
            {
                glColor3f(0.4f, 0.4f, 0.4f); // Темніший фон для вибраної кнопки
            }
            else
            {
                glColor3f(0.9f, 0.9f, 0.9f); // Світліший фон для невибраних кнопок
            }

            // Малювання прямокутника кнопки
            glBegin(GL_QUADS);
            glVertex2f(X1, Y1);
            glVertex2f(X2, Y1);
            glVertex2f(X2, Y2);
            glVertex2f(X1, Y2);
            glEnd();

            // Встановлення кольору обводки в залежності від режиму
            switch (Mode)
            {
                case RenderMode.Fill:
                    glColor3f(1f, 0f, 0f); // Червоний для Fill
                    break;
                case RenderMode.Line:
                    glColor3f(0f, 1f, 0f); // Зелений для Line
                    break;
                case RenderMode.Point:
                    glColor3f(0f, 0f, 1f); // Синій для Point
                    break;
                default:
                    glColor3f(0f, 0f, 0f); // Чорний за замовчуванням
                    break;
            }

            // Малювання обводки кнопки
            glLineWidth(3f);
            glBegin(GL_LINE_LOOP);
            glVertex2f(X1, Y1);
            glVertex2f(X2, Y1);
            glVertex2f(X2, Y2);
            glVertex2f(X1, Y2);
            glEnd();
        }

        // Метод перевірки, чи знаходиться точка всередині кнопки
        public bool IsPointInside(float x, float y)
        {
            return x >= X1 && x <= X2 && y >= Y1 && y <= Y2;
        }
    }

    // Клас, що представляє фігуру для малювання
    public class ComplexFigure
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float A { get; set; }
        public float FigureHeight { get; set; }

        // Конструктор фігури
        public ComplexFigure(float x, float y, float a, float figureHeight)
        {
            X = x;
            Y = y;
            A = a;
            FigureHeight = figureHeight / 2f;
        }

        // Метод малювання фігури залежно від режиму
        public void Draw(RenderControl.RenderMode mode)
        {
            SetRenderMode(mode);

            // Встановлення кольору для ліній або точок
            if (mode == RenderControl.RenderMode.Line || mode == RenderControl.RenderMode.Point)
            {
                glColor3f(0f, 0f, 0f); // Чорний колір
            }

            // Малювання трикутників
            glBegin(GL_TRIANGLES);
            if (mode == RenderControl.RenderMode.Fill)
            {
                DrawTriangle(X + A + A / 2f, Y + FigureHeight, X + A + A, Y, X + A, Y, 1f, 1f, 0f);
                DrawTriangle(X + A + A / 2f, Y - FigureHeight, X + A + A, Y, X + A, Y, 1f, 0f, 0f);
            }
            else
            {
                DrawTriangle(X + A + A / 2f, Y + FigureHeight, X + A + A, Y, X + A, Y, 0f, 0f, 0f);
                DrawTriangle(X + A + A / 2f, Y - FigureHeight, X + A + A, Y, X + A, Y, 0f, 0f, 0f);
            }
            glEnd();

            // Малювання квадрейтрипів
            glBegin(GL_QUAD_STRIP);
            if (mode == RenderControl.RenderMode.Fill)
            {
                DrawQuadStrip(X, Y, X + A / 2f, Y + FigureHeight, X + A, Y, X + A + A / 2f, Y + FigureHeight, 0f, 1f, 0f);
                DrawQuadStrip(X, Y, X + A, Y, X + A / 2f, Y - FigureHeight, X + A + A / 2f, Y - FigureHeight, 0f, 0f, 1f);
            }
            else
            {
                DrawQuadStrip(X, Y, X + A / 2f, Y + FigureHeight, X + A, Y, X + A + A / 2f, Y + FigureHeight, 0f, 0f, 0f);
                DrawQuadStrip(X, Y, X + A, Y, X + A / 2f, Y - FigureHeight, X + A + A / 2f, Y - FigureHeight, 0f, 0f, 0f);
            }
            glEnd();
        }

        // Допоміжний метод малювання трикутника з кольором
        private static void DrawTriangle(float x1, float y1, float x2, float y2, float x3, float y3, float r, float g, float b)
        {
            glColor3f(r, g, b);
            glVertex2f(x1, y1);
            glVertex2f(x2, y2);
            glVertex2f(x3, y3);
        }

        // Допоміжний метод малювання квадрейтрипа з кольором
        private static void DrawQuadStrip(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, float r, float g, float b)
        {
            glColor3f(r, g, b);
            glVertex2f(x1, y1);
            glVertex2f(x2, y2);
            glVertex2f(x3, y3);
            glVertex2f(x4, y4);
        }

        // Метод встановлення режиму рендерингу
        private static void SetRenderMode(RenderControl.RenderMode mode)
        {
            switch (mode)
            {
                case RenderControl.RenderMode.Fill:
                    glPolygonMode(GL_FRONT_AND_BACK, GL_FILL);
                    glLineWidth(1f);
                    glPointSize(1f);
                    break;
                case RenderControl.RenderMode.Line:
                    glPolygonMode(GL_FRONT_AND_BACK, GL_LINE);
                    glLineWidth(5f);
                    glPointSize(1f);
                    break;
                case RenderControl.RenderMode.Point:
                    glPolygonMode(GL_FRONT_AND_BACK, GL_POINT);
                    glLineWidth(1f);
                    glPointSize(10f);
                    break;
            }
        }
    }
}