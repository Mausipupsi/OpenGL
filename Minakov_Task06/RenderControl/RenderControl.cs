using System;
using System.Windows.Forms;
using System.Drawing;
using static Minakov_Task06.OpenGL;
using System.Runtime.InteropServices;

namespace Minakov_Task06
{
    // Клас для представлення точки в двовимірному просторі
    public class Point2D
    {
        // Властивості координат X та Y
        public double X { get; set; }
        public double Y { get; set; }

        // Конструктор для ініціалізації точки
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        // Метод для обчислення відстані до іншої точки
        public double DistanceTo(Point2D other)
        {
            double dx = other.X - X;
            double dy = other.Y - Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        // Статичний метод для обчислення довжини вектора
        public static double Length(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }
    }

    // Клас, що представляє модель робочої руки маніпулятора
    public class RobotArm
    {
        // Довжини ланок маніпулятора
        private double a;
        private double b;
        private double c;

        // Параметри руху
        private double S;
        private double oldS;
        private double psi;
        private double oldPsi;

        // Точки кінематичної схеми
        private Point2D O;
        private Point2D B;
        private Point2D C;
        private Point2D A;

        // Конструктор для ініціалізації робочої руки
        public RobotArm(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            S = 0.0;
            oldS = 0.0;
            psi = 0.0;
            oldPsi = 0.0;

            O = new Point2D(0.0, 0.0);
            B = new Point2D(c, S);
            C = new Point2D(0.0, 0.0);
            A = new Point2D(0.0, 0.0);
        }

        // Методи для встановлення параметрів S та psi
        public void SetS(double newS)
        {
            S = newS;
        }

        public void SetPsi(double newPsi)
        {
            psi = newPsi;
        }

        // Гетери для параметрів S та psi
        public double GetS() { return S; }
        public double GetPsi() { return psi; }

        // Гетери для точок O, B, C, A
        public Point2D GetO() { return O; }
        public Point2D GetB() { return B; }
        public Point2D GetC() { return C; }
        public Point2D GetA() { return A; }

        // Метод для оновлення положення маніпулятора
        public void UpdateArm()
        {
            // Оновлюємо координати точки B
            B.X = c;
            B.Y = S;

            // Обчислюємо відстань між точками O та B
            double D = O.DistanceTo(B);

            // Перевіряємо, чи не перевищує відстань максимально допустимий
            if (D > 2 * a)
            {
                S = oldS;
                B.X = c; B.Y = S;
                D = O.DistanceTo(B);
            }

            // Обчислюємо точку C на основі поточних координат O та B
            Point2D computedC = ComputeC(O, B, a);
            if (computedC == null)
            {
                // Якщо обчислення не вдалося, відновлюємо попередні значення
                S = oldS;
                psi = oldPsi;

                B.X = c; B.Y = S;
                D = O.DistanceTo(B);
                computedC = ComputeC(O, B, a);
            }

            C = computedC;

            // Обчислюємо координати точки A з урахуванням кута psi
            double psiRad = Math.PI * psi / 180.0;
            A.X = C.X + b * Math.Cos(psiRad);
            A.Y = C.Y + b * Math.Sin(psiRad);

            // Перевіряємо перетин сегментів, щоб уникнути некоректних положень
            if (SegmentsIntersect(O.X, O.Y, B.X, B.Y, C.X, C.Y, A.X, A.Y))
            {
                // Якщо відбувається перетин, відновлюємо попередні значення
                S = oldS;
                psi = oldPsi;

                B.X = c; B.Y = S;
                computedC = ComputeC(O, B, a);
                C = computedC;

                psiRad = Math.PI * psi / 180.0;
                A.X = C.X + b * Math.Cos(psiRad);
                A.Y = C.Y + b * Math.Sin(psiRad);
            }

            // Оновлюємо попередні значення, якщо все коректно
            if (O.DistanceTo(B) <= 2 * a && !SegmentsIntersect(O.X, O.Y, B.X, B.Y, C.X, C.Y, A.X, A.Y))
            {
                oldS = S;
                oldPsi = psi;
            }
        }

        // Метод для обчислення точки C
        private Point2D ComputeC(Point2D O, Point2D B, double a)
        {
            double D = O.DistanceTo(B);
            if (D > 2 * a) return null;

            double Mx = (O.X + B.X) / 2.0;
            double My = (O.Y + B.Y) / 2.0;
            double h = Math.Sqrt(a * a - (D * D / 4.0));

            double By = B.Y - O.Y;
            double Bx = B.X - O.X;

            double len = Point2D.Length(Bx, By);
            if (len < 1e-12) return null;

            double ux = -By / len;
            double uy = Bx / len;

            double C1x = Mx + h * ux;
            double C1y = My + h * uy;
            double C2x = Mx - h * ux;
            double C2y = My - h * uy;

            double Cx, Cy;

            // Вибір правильного положення точки C
            if (C1y < 0 && C2y < 0)
            {
                Cx = C2x; Cy = C2y;
            }
            else if (C1y < 0)
            {
                Cx = C1x; Cy = C1y;
            }
            else
            {
                Cx = C2x; Cy = C2y;
            }

            return new Point2D(Cx, Cy);
        }

        // Метод для перевірки перетину двох сегментів
        private bool SegmentsIntersect(double x1, double y1, double x2, double y2,
                                       double x3, double y3, double x4, double y4)
        {
            double denom = (y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1);
            if (Math.Abs(denom) < 1e-12) return false;

            double ua = ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3)) / denom;
            double ub = ((x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3)) / denom;

            return (ua >= 0 && ua <= 1 && ub >= 0 && ub <= 1);
        }
    }

    // Частковий клас для відображення та рендерингу моделі маніпулятора
    public partial class RenderControl : OpenGL
    {
        // Об'єкт робочої руки
        private RobotArm robotArm;

        // Параметри для обертання та масштабування сцени
        private double ay = 0;
        private double ax = 0;
        private double m = 1.0;
        private bool MoveAxes = false;
        private int dx;
        private int dy;

        // Квадричний об'єкт для малювання сфер
        private IntPtr quadric;

        // Параметри освітлення
        float[] light_pos = { 1.0f, 1.0f, 1.0f, 0.0f };
        float[] floorPlane = { 0.0f, 1.0f, 0.0f, 1.0f };

        // Конструктор контролу рендерингу
        public RenderControl()
        {
            InitializeComponent();

            // Ініціалізуємо робочу руку з заданими параметрами
            robotArm = new RobotArm(0.46, 0.82, 0.6);

            // Підписуємося на події миші та клавіатури
            MouseDown += Mouse_Down;
            MouseUp += Mouse_Up;
            MouseMove += Mouse_Move;
            PreviewKeyDown += Key_Down;

            // Створюємо таймер для регулярного оновлення сцени
            var timer = new Timer();
            timer.Interval = 16; // Приблизно 60 FPS
            timer.Tick += OnRender;
            timer.Start();
        }

        // Обробник події створення контролу
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            quadric = gluNewQuadric(); // Створюємо квадричний об'єкт
        }

        // Обробник події знищення контролу
        protected override void OnHandleDestroyed(EventArgs e)
        {
            gluDeleteQuadric(quadric); // Видаляємо квадричний об'єкт
            quadric = IntPtr.Zero;
            base.OnHandleDestroyed(e);
        }

        // Метод для рендерингу сцени
        private void OnRender(object sender, EventArgs e)
        {
            // Оновлюємо положення маніпулятора
            robotArm.UpdateArm();

            glEnable(GL_DEPTH_TEST); // Увімкнути тест глибини
            glClearColor(0.9f, 0.9f, 0.95f, 1f); // Встановлюємо колір фону
            glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT | GL_STENCIL_BUFFER_BIT); // Очищуємо буфери
            glViewport(0, 0, ClientSize.Width, ClientSize.Height); // Встановлюємо область перегляду

            // Налаштування перспективної проекції
            glMatrixMode(GL_PROJECTION);
            glLoadIdentity();
            double aspect = (double)ClientSize.Width / (double)ClientSize.Height;
            gluPerspective(45.0, aspect, 0.1, 20.0);

            // Налаштування моделі перегляду
            glMatrixMode(GL_MODELVIEW);
            glLoadIdentity();
            gluLookAt(0.0, 0.0, 5.0, // Позиція камери
                      0.0, 0.0, 0.0, // Точка, на яку дивиться камера
                      0.0, 1.0, 0.0); // Напрямок "вгору"

            // Обертання та масштабування сцени
            glRotated(ax, 1, 0, 0);
            glRotated(ay, 0, 1, 0);
            glScaled(m, m, m);

            // Налаштування освітлення
            SetupLighting();

            // Малюємо підлогу
            DrawFloor();

            // Малюємо маніпулятор з освітленням
            DrawManipulator(true);

            // Малюємо осі координат і текстові позначки
            glDisable(GL_LIGHTING);
            Axes(1.7);
            glEnable(GL_LIGHTING);

            // Малюємо тінь маніпулятора
            DrawShadow();

            glFlush(); // Завершуємо рендеринг
        }

        // Метод для налаштування освітлення сцени
        private void SetupLighting()
        {
            glEnable(GL_LIGHTING); // Увімкнути освітлення
            glEnable(GL_LIGHT0); // Увімкнути перше джерело світла
            glLightModeli(GL_LIGHT_MODEL_TWO_SIDE, 1); // Двостороннє освітлення

            // Встановлюємо компоненти освітлення
            float[] lightAmbient = { 0.2f, 0.2f, 0.2f, 1f };
            float[] lightDiffuse = { 0.8f, 0.8f, 0.8f, 1f };
            float[] lightSpecular = { 1.0f, 1.0f, 1.0f, 1f };

            glLightfv(GL_LIGHT0, GL_POSITION, light_pos);
            glLightfv(GL_LIGHT0, GL_AMBIENT, lightAmbient);
            glLightfv(GL_LIGHT0, GL_DIFFUSE, lightDiffuse);
            glLightfv(GL_LIGHT0, GL_SPECULAR, lightSpecular);

            glEnable(GL_NORMALIZE); // Нормалізувати нормалі
            glShadeModel(GL_SMOOTH); // Гладке затінення
        }

        // Метод для малювання підлоги
        private void DrawFloor()
        {
            glDisable(GL_LIGHTING); // Вимкнути освітлення для підлоги
            glColor3f(0.7f, 0.7f, 0.7f); // Встановлюємо колір підлоги
            double size = 5.0; // Розмір підлоги
            double y = -1.0; // Висота підлоги

            glBegin(GL_QUADS);
            glNormal3d(0, 1, 0); // Нормаль до поверхні
            glVertex3d(-size, y, -size);
            glVertex3d(size, y, -size);
            glVertex3d(size, y, size);
            glVertex3d(-size, y, size);
            glEnd();

            glEnable(GL_LIGHTING); // Знову увімкнути освітлення
        }

        // Метод для малювання маніпулятора
        private void DrawManipulator(bool withLighting)
        {
            // Отримуємо поточні точки маніпулятора
            Point2D O = robotArm.GetO();
            Point2D B = robotArm.GetB();
            Point2D C = robotArm.GetC();
            Point2D A = robotArm.GetA();

            // Встановлюємо матеріал для вузлів, якщо потрібне освітлення
            if (withLighting)
                SetMaterial(1.0, 0.5, 0.0, 1.0);

            // Малюємо бази маніпулятора
            DrawCube(O.X, O.Y, 0, 0.1, 1.0, 0.5, 0.0, 1.0);
            DrawCube(B.X, B.Y, 0, 0.1, 1.0, 0.5, 0.0, 1.0);

            // Малюємо ланки маніпулятора
            DrawCuboidSegment(O.X, O.Y, C.X, C.Y, 1.0, 0.0, 0.0, 1.0);
            DrawCuboidSegment(C.X, C.Y, B.X, B.Y, 0.0, 1.0, 0.0, 1.0);
            DrawCuboidSegment(C.X, C.Y, A.X, A.Y, 0.0, 0.0, 1.0, 1.0);

            // Малюємо сферу в точці C
            DrawSphere(C.X, C.Y, 0, 0.07, 1.0, 1.0, 0.0, 1.0);
        }

        // Метод для малювання тіні маніпулятора
        private void DrawShadow()
        {
            float[] shadowMat = new float[16];
            ShadowMatrix(shadowMat, floorPlane, light_pos);

            glPushMatrix();

            // Налаштування для малювання тіні
            glDisable(GL_LIGHTING); // Вимкнути освітлення
            glColor3f(0.0f, 0.0f, 0.0f); // Колір тіні
            glEnable(GL_POLYGON_OFFSET_FILL); // Увімкнути зсув полігонів
            glPolygonOffset(-1.0f, -1.0f); // Налаштування зсуву

            glMultMatrixf(shadowMat); // Застосувати матрицю тіні
            // Малюємо тільки маніпулятор без осей і тексту
            DrawManipulator(false);

            // Відновлюємо попередні налаштування
            glDisable(GL_POLYGON_OFFSET_FILL);
            glEnable(GL_LIGHTING);
            glPopMatrix();
        }

        // Метод для створення матриці тіні
        private void ShadowMatrix(float[] mat, float[] plane, float[] light)
        {
            float dot = plane[0] * light[0] + plane[1] * light[1] + plane[2] * light[2] + plane[3] * light[3];

            mat[0] = dot - light[0] * plane[0];
            mat[4] = -light[0] * plane[1];
            mat[8] = -light[0] * plane[2];
            mat[12] = -light[0] * plane[3];

            mat[1] = -light[1] * plane[0];
            mat[5] = dot - light[1] * plane[1];
            mat[9] = -light[1] * plane[2];
            mat[13] = -light[1] * plane[3];

            mat[2] = -light[2] * plane[0];
            mat[6] = -light[2] * plane[1];
            mat[10] = dot - light[2] * plane[2];
            mat[14] = -light[2] * plane[3];

            mat[3] = -light[3] * plane[0];
            mat[7] = -light[3] * plane[1];
            mat[11] = -light[3] * plane[2];
            mat[15] = dot - light[3] * plane[3];
        }

        // Метод для встановлення матеріалу об'єктів
        private void SetMaterial(double r, double g, double b, double a)
        {
            float[] mat_ambient = { (float)(r * 0.2f), (float)(g * 0.2f), (float)(b * 0.2f), (float)a };
            float[] mat_diffuse = { (float)r, (float)g, (float)b, (float)a };
            float[] mat_specular = { 1.0f, 1.0f, 1.0f, (float)a };
            float[] mat_shininess = { 50.0f };

            glMaterialfv(GL_FRONT_AND_BACK, GL_AMBIENT, mat_ambient);
            glMaterialfv(GL_FRONT_AND_BACK, GL_DIFFUSE, mat_diffuse);
            glMaterialfv(GL_FRONT_AND_BACK, GL_SPECULAR, mat_specular);
            glMaterialfv(GL_FRONT_AND_BACK, GL_SHININESS, mat_shininess);
        }

        // Метод для малювання сегмента кубоїда між двома точками
        private void DrawCuboidSegment(double x1, double y1, double x2, double y2, double r, double g, double b, double alpha)
        {
            double dx = x2 - x1;
            double dy = y2 - y1;
            double length = Math.Sqrt(dx * dx + dy * dy);
            double angle = Math.Atan2(dy, dx) * 180.0 / Math.PI;
            double thickness = 0.05;

            glPushMatrix();
            glTranslated(x1, y1, 0); // Переміщення до початкової точки
            glRotated(angle, 0, 0, 1); // Обертання сегмента
            SetMaterial(r, g, b, alpha); // Встановлення матеріалу

            double half = thickness / 2.0;

            glBegin(GL_QUADS);
            // Верхня грань
            glNormal3d(0, 1, 0);
            glVertex3d(0, half, half);
            glVertex3d(length, half, half);
            glVertex3d(length, half, -half);
            glVertex3d(0, half, -half);

            // Нижня грань
            glNormal3d(0, -1, 0);
            glVertex3d(0, -half, -half);
            glVertex3d(length, -half, -half);
            glVertex3d(length, -half, half);
            glVertex3d(0, -half, half);

            // Передня грань
            glNormal3d(0, 0, 1);
            glVertex3d(0, -half, half);
            glVertex3d(length, -half, half);
            glVertex3d(length, half, half);
            glVertex3d(0, half, half);

            // Задня грань
            glNormal3d(0, 0, -1);
            glVertex3d(0, half, -half);
            glVertex3d(length, half, -half);
            glVertex3d(length, -half, -half);
            glVertex3d(0, -half, -half);

            // Права грань
            glNormal3d(1, 0, 0);
            glVertex3d(length, -half, half);
            glVertex3d(length, -half, -half);
            glVertex3d(length, half, -half);
            glVertex3d(length, half, half);

            // Ліва грань
            glNormal3d(-1, 0, 0);
            glVertex3d(0, half, half);
            glVertex3d(0, half, -half);
            glVertex3d(0, -half, -half);
            glVertex3d(0, -half, half);
            glEnd();

            glPopMatrix();
        }

        // Метод для малювання куба
        private void DrawCube(double x, double y, double z, double size, double r, double g, double b, double alpha)
        {
            double half = size / 2.0;
            glPushMatrix();
            glTranslated(x, y, z); // Переміщення до позиції куба
            SetMaterial(r, g, b, alpha); // Встановлення матеріалу

            glBegin(GL_QUADS);
            // Передня грань
            glNormal3d(0, 0, 1);
            glVertex3d(-half, -half, half);
            glVertex3d(half, -half, half);
            glVertex3d(half, half, half);
            glVertex3d(-half, half, half);

            // Задня грань
            glNormal3d(0, 0, -1);
            glVertex3d(-half, half, -half);
            glVertex3d(half, half, -half);
            glVertex3d(half, -half, -half);
            glVertex3d(-half, -half, -half);

            // Ліва грань
            glNormal3d(-1, 0, 0);
            glVertex3d(-half, -half, -half);
            glVertex3d(-half, -half, half);
            glVertex3d(-half, half, half);
            glVertex3d(-half, half, -half);

            // Права грань
            glNormal3d(1, 0, 0);
            glVertex3d(half, -half, half);
            glVertex3d(half, -half, -half);
            glVertex3d(half, half, -half);
            glVertex3d(half, half, half);

            // Верхня грань
            glNormal3d(0, 1, 0);
            glVertex3d(-half, half, half);
            glVertex3d(half, half, half);
            glVertex3d(half, half, -half);
            glVertex3d(-half, half, -half);

            // Нижня грань
            glNormal3d(0, -1, 0);
            glVertex3d(-half, -half, -half);
            glVertex3d(half, -half, -half);
            glVertex3d(half, -half, half);
            glVertex3d(-half, -half, half);
            glEnd();

            glPopMatrix();
        }

        // Метод для малювання сфери
        private void DrawSphere(double x, double y, double z, double radius, double r, double g, double b, double alpha)
        {
            glPushMatrix();
            glTranslated(x, y, z); // Переміщення до позиції сфери
            SetMaterial(r, g, b, alpha); // Встановлення матеріалу
            gluSphere(quadric, radius, 20, 20); // Малюємо сферу
            glPopMatrix();
        }

        // Метод для малювання осей координат
        private void Axes(double size)
        {
            glColor3d(1, 1, 1); // Встановлюємо колір осей
            glBegin(GL_LINES);
            // Вісь X
            glVertex3d(-size * 0.1, 0.0, 0.0); glVertex3d(size, 0.0, 0.0);
            // Вісь Y
            glVertex3d(0.0, -size * 0.1, 0.0); glVertex3d(0.0, size, 0.0);
            // Вісь Z
            glVertex3d(0.0, 0.0, -size * 0.1); glVertex3d(0.0, 0.0, size);
            glEnd();
            // Додаємо текстові позначки до осей
            DrawText("X", size * 1.05, 0, 0);
            DrawText("Y", 0, size * 1.05, 0);
            DrawText("Z", 0, 0, size * 1.05);
        }

        // Обробник події натискання кнопки миші
        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            MoveAxes = (e.Button == MouseButtons.Left); // Визначаємо, чи рухаються осі
            dx = e.X; dy = e.Y; // Зберігаємо початкові координати миші
        }

        // Обробник події відпускання кнопки миші
        private void Mouse_Up(object sender, MouseEventArgs e)
        {
            MoveAxes = MoveAxes && (e.Button != MouseButtons.Left); // Зупиняємо рух осей, якщо кнопка відпущена
        }

        // Обробник події руху миші
        private void Mouse_Move(object sender, MouseEventArgs e)
        {
            if (MoveAxes)
            {
                ay += (e.X - dx) / 2.0; // Оновлюємо кут обертання по осі Y
                ax += (e.Y - dy) / 2.0; // Оновлюємо кут обертання по осі X
                dx = e.X; dy = e.Y; // Оновлюємо поточні координати миші
                Invalidate(); // Запитуємо перерисовку сцени
            }
        }

        // Обробник події натискання клавіш
        private void Key_Down(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.PageUp:
                    robotArm.SetS(robotArm.GetS() + 0.01); // Збільшуємо параметр S
                    break;
                case Keys.PageDown:
                    robotArm.SetS(robotArm.GetS() - 0.01); // Зменшуємо параметр S
                    break;
                case Keys.Left:
                    robotArm.SetPsi(robotArm.GetPsi() - 1); // Зменшуємо кут psi
                    break;
                case Keys.Right:
                    robotArm.SetPsi(robotArm.GetPsi() + 1); // Збільшуємо кут psi
                    break;
            }
            Invalidate(); // Запитуємо перерисовку сцени
        }
    }
}