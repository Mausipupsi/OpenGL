using System;
using System.Windows.Forms;
using static Minakov_Task05.OpenGL;

namespace Minakov_Task05
{
    public partial class RenderControl : OpenGL
    {
        // Кути обертання по осях X та Y
        private float angleX = 0;
        private float angleY = 0;
        // Режим рендерингу: заповнений (true) або каркасний (false)
        private bool isFilledMode = false;

        // Параметри плоскості відсічення
        private bool clippingEnabled = false;
        private double[] clipPlane = { 1.0, 0.0, 0.0, 0.0 };

        // Режим проекції: ортографічна (true) або перспективна (false)
        private bool isOrthographic = true;

        // Ідентифікатори списків відображення для фігур
        private uint sphereListFilled;
        private uint coneListFilled;
        private uint diskListFilled;

        private uint sphereListWireframe;
        private uint coneListWireframe;
        private uint diskListWireframe;

        // Флаг ініціалізації списків відображення
        private bool displayListsInitialized = false;

        public RenderControl()
        {
            InitializeComponent();
            // Ініціалізація списків відображення перенесена в окремий метод
        }

        // Встановлює кути обертання
        public void SetRotation(float x, float y)
        {
            angleX = x;
            angleY = y;
        }

        // Встановлює режим рендерингу
        public void SetRenderingMode(bool filled)
        {
            isFilledMode = filled;
            Invalidate(); // Перерисовуємо контрол
        }

        // Встановлює параметри плоскості відсічення
        public void SetClippingPlane(bool enabled, double[] planeEquation)
        {
            clippingEnabled = enabled;
            if (planeEquation != null && planeEquation.Length == 4)
            {
                clipPlane = planeEquation;
            }
            Invalidate(); // Перерисовуємо контрол
        }

        // Встановлює режим проекції
        public void SetProjectionMode(bool orthographic)
        {
            isOrthographic = orthographic;
            Invalidate(); // Перерисовуємо контрол
        }

        // Метод рендерингу сцени
        private void RenderControl_Render(object sender, EventArgs e)
        {
            // Перевіряємо, чи ініціалізовані списки відображення
            if (!displayListsInitialized)
            {
                InitializeDisplayLists();
                displayListsInitialized = true;
            }

            // Очищення буферів кольору та глибини
            glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

            // Увімкнення тесту глибини
            glEnable(GL_DEPTH_TEST);

            // Встановлення області перегляду (viewport) для ізотропної системи координат
            int side = Math.Min(Width, Height);
            int viewportX = (Width - side) / 2;
            int viewportY = (Height - side) / 2;
            glViewport(viewportX, viewportY, side, side);

            // Встановлення матриці проекції
            glMatrixMode(GL_PROJECTION);
            glLoadIdentity();

            if (isOrthographic)
            {
                // Встановлення ортографічної проекції
                glOrtho(-10, 10, -10, 10, -10, 10);
            }
            else
            {
                // Встановлення перспективної проекції
                gluPerspective(45.0, 1.0, 1.0, 100.0);
            }

            // Встановлення матриці моделі-вид
            glMatrixMode(GL_MODELVIEW);
            glLoadIdentity();

            if (!isOrthographic)
            {
                // Переміщення камери назад для перспективної проекції
                glTranslatef(0.0f, 0.0f, -20.0f);
            }

            // Застосування обертання на основі кутів
            glRotatef(angleX, 1.0f, 0.0f, 0.0f);
            glRotatef(angleY, 0.0f, 1.0f, 0.0f);

            // Встановлення режиму полігонів для осей та сітки
            glPolygonMode(GL_FRONT_AND_BACK, GL_LINE);

            // Малюємо координатні осі
            DrawCoordinateAxes();

            // Малюємо координатну сітку в площині X0Z
            DrawGrid();

            // Встановлюємо режим полігонів для фігур
            if (isFilledMode)
            {
                glPolygonMode(GL_FRONT_AND_BACK, GL_FILL);
            }
            else
            {
                glPolygonMode(GL_FRONT_AND_BACK, GL_LINE);
            }

            // Увімкнення освітлення
            glEnable(GL_LIGHTING);
            glEnable(GL_LIGHT0);
            glDisable(GL_COLOR_MATERIAL);

            // Налаштування параметрів освітлення
            SetupLighting();

            // Малюємо три квадратичні фігури
            DrawFigures();

            // Вимкнення освітлення
            glDisable(GL_LIGHT0);
            glDisable(GL_LIGHTING);

            // Вимкнення тесту глибини (за потребою)
            //glDisable(GL_DEPTH_TEST);
        }

        // Ініціалізація списків відображення для фігур
        private void InitializeDisplayLists()
        {
            // Генерація ідентифікаторів списків відображення
            sphereListFilled = glGenLists(1);
            coneListFilled = glGenLists(1);
            diskListFilled = glGenLists(1);

            sphereListWireframe = glGenLists(1);
            coneListWireframe = glGenLists(1);
            diskListWireframe = glGenLists(1);

            // Створення квадрика для малювання фігур
            IntPtr quadric = gluNewQuadric();

            // Створення списків відображення для заповнених фігур
            gluQuadricDrawStyle(quadric, GLU_FILL);

            // Сфера (заповнена)
            glNewList(sphereListFilled, GL_COMPILE);
            gluSphere(quadric, 1.5, 16, 16);
            glEndList();

            // Конус (заповнений)
            glNewList(coneListFilled, GL_COMPILE);
            gluCylinder(quadric, 3.0, 1.0, 2.5, 16, 16);
            glEndList();

            // Диск (заповнений)
            glNewList(diskListFilled, GL_COMPILE);
            gluPartialDisk(quadric, 0.0, 2.0, 16, 1, 225.0, 180.0);
            glEndList();

            // Створення списків відображення для каркасних фігур
            gluQuadricDrawStyle(quadric, GLU_LINE);

            // Сфера (каркасна)
            glNewList(sphereListWireframe, GL_COMPILE);
            gluSphere(quadric, 1.5, 16, 16);
            glEndList();

            // Конус (каркасний)
            glNewList(coneListWireframe, GL_COMPILE);
            gluCylinder(quadric, 3.0, 1.0, 2.5, 16, 16);
            glEndList();

            // Диск (каркасний)
            glNewList(diskListWireframe, GL_COMPILE);
            gluPartialDisk(quadric, 0.0, 2.0, 16, 1, 225.0, 180.0);
            glEndList();

            // Видалення квадрика після створення списків
            gluDeleteQuadric(quadric);
        }

        // Метод для малювання координатних осей
        private void DrawCoordinateAxes()
        {
            glLineWidth(2.0f);

            glBegin(GL_LINES);

            // Вісь X (червона)
            glColor3d(1, 0, 0);
            glVertex3d(0, 0, 0);
            glVertex3d(5, 0, 0);

            // Вісь Y (зелена)
            glColor3d(0, 1, 0);
            glVertex3d(0, 0, 0);
            glVertex3d(0, 5, 0);

            // Вісь Z (синя)
            glColor3d(0, 0, 1);
            glVertex3d(0, 0, 0);
            glVertex3d(0, 0, 5);

            glEnd();
        }

        // Метод для малювання координатної сітки в площині X0Z
        private void DrawGrid()
        {
            glColor3d(0.7, 0.7, 0.7); // Світло-сірий колір
            glLineWidth(1.0f);

            int gridSize = 10; // Розмір сітки

            glBegin(GL_LINES);

            for (int i = -gridSize; i <= gridSize; i++)
            {
                // Лінії паралельні осі X
                glVertex3d(-gridSize, 0, i);
                glVertex3d(gridSize, 0, i);

                // Лінії паралельні осі Z
                glVertex3d(i, 0, -gridSize);
                glVertex3d(i, 0, gridSize);
            }

            glEnd();
        }

        // Метод для налаштування параметрів освітлення
        private void SetupLighting()
        {
            // Параметри позиції світла
            float[] lightPosition = { 5.0f, 10.0f, 5.0f, 1.0f };
            // Параметри навколишнього освітлення
            float[] lightAmbient = { 0.3f, 0.3f, 0.3f, 1.0f };
            // Параметри дифузного освітлення
            float[] lightDiffuse = { 0.8f, 0.8f, 0.8f, 1.0f };
            // Параметри спекулярного освітлення
            float[] lightSpecular = { 1.0f, 1.0f, 1.0f, 1.0f };

            // Встановлення параметрів світла
            glLightfv(GL_LIGHT0, GL_POSITION, lightPosition);
            glLightfv(GL_LIGHT0, GL_AMBIENT, lightAmbient);
            glLightfv(GL_LIGHT0, GL_DIFFUSE, lightDiffuse);
            glLightfv(GL_LIGHT0, GL_SPECULAR, lightSpecular);

            // Нормалізація нормалей
            glEnable(GL_NORMALIZE);
        }

        // Метод для малювання фігур
        private void DrawFigures()
        {
            // Увімкнення плоскості відсічення, якщо необхідно
            if (clippingEnabled)
            {
                glEnable(GL_CLIP_PLANE0);
                glClipPlane(GL_CLIP_PLANE0, clipPlane);
            }

            // Сфера (розташована паралельно осі Z)
            glPushMatrix();
            glTranslated(2.5, 1.0, -2.5);

            // Встановлення матеріалу для сфери
            float[] sphereAmbient = { 0.25f, 0.0f, 0.0f, 1.0f };
            float[] sphereDiffuse = { 0.8f, 0.0f, 0.0f, 1.0f }; // Червоний колір
            float[] sphereSpecular = { 0.9f, 0.9f, 0.9f, 1.0f };
            float sphereShininess = 50.0f;

            glMaterialfv(GL_FRONT, GL_AMBIENT, sphereAmbient);
            glMaterialfv(GL_FRONT, GL_DIFFUSE, sphereDiffuse);
            glMaterialfv(GL_FRONT, GL_SPECULAR, sphereSpecular);
            glMaterialf(GL_FRONT, GL_SHININESS, sphereShininess);

            // Виклик відповідного списку відображення
            if (isFilledMode)
            {
                glCallList(sphereListFilled);
            }
            else
            {
                glCallList(sphereListWireframe);
            }

            glPopMatrix();

            // Вимкнення плоскості відсічення
            if (clippingEnabled)
            {
                glDisable(GL_CLIP_PLANE0);
            }

            // Усічений конус (розташований паралельно осі Y)
            glPushMatrix();
            glTranslated(-3.0, -2.5, -4.5);
            glRotated(-90, 1, 0, 0);

            // Встановлення матеріалу для конуса
            float[] coneAmbient = { 0.0f, 0.25f, 0.0f, 1.0f };
            float[] coneDiffuse = { 0.0f, 0.8f, 0.0f, 1.0f }; // Зелений колір
            float[] coneSpecular = { 0.9f, 0.9f, 0.9f, 1.0f };
            float coneShininess = 30.0f;

            glMaterialfv(GL_FRONT, GL_AMBIENT, coneAmbient);
            glMaterialfv(GL_FRONT, GL_DIFFUSE, coneDiffuse);
            glMaterialfv(GL_FRONT, GL_SPECULAR, coneSpecular);
            glMaterialf(GL_FRONT, GL_SHININESS, coneShininess);

            if (isFilledMode)
            {
                glCallList(coneListFilled);
            }
            else
            {
                glCallList(coneListWireframe);
            }

            glPopMatrix();

            // Частковий диск (розташований паралельно осі X)
            glPushMatrix();
            glTranslated(-3.5, 0.5, 2.0);
            glRotated(-90, 0, 1, 0);

            // Встановлення матеріалу для диска
            float[] diskAmbient = { 0.0f, 0.0f, 0.25f, 1.0f };
            float[] diskDiffuse = { 0.0f, 0.0f, 0.8f, 1.0f }; // Синій колір
            float[] diskSpecular = { 0.9f, 0.9f, 0.9f, 1.0f };
            float diskShininess = 80.0f;

            glMaterialfv(GL_FRONT, GL_AMBIENT, diskAmbient);
            glMaterialfv(GL_FRONT, GL_DIFFUSE, diskDiffuse);
            glMaterialfv(GL_FRONT, GL_SPECULAR, diskSpecular);
            glMaterialf(GL_FRONT, GL_SHININESS, diskShininess);

            if (isFilledMode)
            {
                glCallList(diskListFilled);
            }
            else
            {
                glCallList(diskListWireframe);
            }

            glPopMatrix();
        }
    }
}