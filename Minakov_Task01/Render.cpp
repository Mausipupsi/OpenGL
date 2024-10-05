#include "pch.h"
#include "glWinApp.h"
#include <vector>
using namespace std;

extern LPCSTR s1, s2, s3;

int LoadWindowDefaultFont() {
    GLuint id = glGenLists(256);
    wglUseFontBitmaps(wglGetCurrentDC(), 0, 256, id);
    return id;
}

void OutText(LPCSTR str, double x, double y, double z = 0) {
    glRasterPos3d(x, y, z);
    glListBase(idFont);
    glCallLists(static_cast<GLsizei>(strlen(str)), GL_UNSIGNED_BYTE, str);
}

void SetupAndDrawLines(const vector<double>& vertices, float lineWidth, const double* color) {
    glColor3dv(color); // Встановлення кольору ліній
    glLineWidth(lineWidth); // Встановлення ширини ліній

    glEnableClientState(GL_VERTEX_ARRAY); // Включення масиву вершин
    glVertexPointer(2, GL_DOUBLE, 0, vertices.data()); // Встановлення вказівника на масив вершин
    glDrawArrays(GL_LINES, 0, static_cast<GLsizei>(vertices.size() / 2)); // Малювання ліній
    glDisableClientState(GL_VERTEX_ARRAY); // Вимкнення масиву вершин
}

void DrawGrid(double xMin, double xMax, double yMin, double yMax, double step) {
    glEnable(GL_LINE_STIPPLE); // Включення режиму пунктирних ліній
    glLineStipple(1, 0x00FF); // Встановлення шаблону пунктирних ліній

    vector<double> vertices; // Створення вектора для зберігання вершин сітки
    for (double x = xMin; x <= xMax; x += step) {
        vertices.push_back(x); // Додавання координат вершин сітки по осі X
        vertices.push_back(yMin - 1); // Додавання координат вершин сітки по осі Y
        vertices.push_back(x); // Додавання координат вершин сітки по осі X
        vertices.push_back(yMax + 1); // Додавання координат вершин сітки по осі Y
    }
    for (double y = yMin; y <= yMax; y += step) {
        vertices.push_back(xMin - 0.9); // Додавання координат вершин сітки по осі X
        vertices.push_back(y); // Додавання координат вершин сітки по осі Y
        vertices.push_back(xMax + 0.9); // Додавання координат вершин сітки по осі X
        vertices.push_back(y); // Додавання координат вершин сітки по осі Y
    }

    double gridColor[] = { 0.7, 0.7, 0.7 }; // Колір сітки
    SetupAndDrawLines(vertices, 1, gridColor); // Налаштування та малювання ліній сітки

    glDisable(GL_LINE_STIPPLE); // Вимкнення режиму пунктирних ліній
}

void DrawAxes(double xMin, double xMax, double yMin, double yMax) {
    vector<double> vertices = {
        xMin - 0.9, 0, xMax + 0.9, 0, // Координати вершин осі X
        0, yMin - 1, 0, yMax + 1 // Координати вершин осі Y
    };

    double axesColor[] = { 1, 1, 0 }; // Колір осей
    SetupAndDrawLines(vertices, 4, axesColor); // Налаштування та малювання осей

    vector<double> customLines = {
        xMin - 0.9, yMin - 0.3, xMin - 0.9, yMax + 1, // Координати додаткових ліній
        xMin - 0.3, yMin - 1, xMax + 0.9, yMin - 1 // Координати додаткових ліній
    };

    double customLinesColor[] = { 1, 1, 1 }; // Колір додаткових ліній
    SetupAndDrawLines(customLines, 5, customLinesColor); // Налаштування та малювання додаткових ліній

    glLineWidth(3); // Встановлення ширини ліній
    glBegin(GL_LINES); // Початок малювання ліній
    glVertex2d(xMin - 0.9, yMax + 1.05); // Координати вершин стрілок осі Y
    glVertex2d(xMin - 1.1, yMax + 0.6); // Координати вершин стрілок осі Y
    glVertex2d(xMin - 0.9, yMax + 1.05); // Координати вершин стрілок осі Y
    glVertex2d(xMin - 0.7, yMax + 0.6); // Координати вершин стрілок осі Y

    glVertex2d(xMax + 0.95, yMin - 1); // Координати вершин стрілок осі X
    glVertex2d(xMax + 0.6, yMin - 1.2); // Координати вершин стрілок осі X
    glVertex2d(xMax + 0.95, yMin - 1); // Координати вершин стрілок осі X
    glVertex2d(xMax + 0.6, yMin - 0.8); // Координати вершин стрілок осі X
    glEnd(); // Кінець малювання ліній

    glLineWidth(3); // Встановлення ширини ліній
    glBegin(GL_LINES); // Початок малювання ліній
    for (double y = yMin; y <= yMax; y++) {
        glVertex2d(xMin - 0.9, y); // Координати вершин поділок осі Y
        glVertex2d(xMin - 1.12, y); // Координати вершин поділок осі Y
    }
    for (double x = xMin; x <= xMax; x++) {
        glVertex2d(x, yMin - 1.22); // Координати вершин поділок осі X
        glVertex2d(x, yMin - 1); // Координати вершин поділок осі X
    }
    glEnd(); // Кінець малювання ліній

    OutText("Y1", xMin - 1.5, yMin - 0.1); // Відображення тексту "Y1" на осі Y
    OutText("Y2", xMin - 1.5, yMax - 0.1); // Відображення тексту "Y2" на осі Y
    OutText("X1", xMin - 0.1, yMin - 1.5); // Відображення тексту "X1" на осі X
    OutText("X2", xMax - 0.1, yMin - 1.5); // Відображення тексту "X2" на осі X
}

class Point {
public:
    double x, y; // Координати точки

    Point(double x = 0, double y = 0) : x(x), y(y) {} // Конструктор з параметрами за замовчуванням

    void draw() const {
        glColor3d(1, 0, 0); // Встановлення червоного кольору для точки
        glPointSize(15); // Встановлення розміру точки
        glBegin(GL_POINTS); // Початок малювання точки
        glVertex2d(x, y); // Встановлення координат точки
        glEnd(); // Кінець малювання точки
    }
};

class MyPolygon {
public:
    vector<Point> points; // Вектор точок, що складають полігон

    MyPolygon(const vector<Point>& points) : points(points) {} // Конструктор з ініціалізацією вектора точок

    void draw() const {
        glColor3d(0, 0, 1); // Встановлення синього кольору для полігону
        glLineWidth(7); // Встановлення ширини ліній полігону
        glBegin(GL_LINE_STRIP); // Початок малювання полігону
        for (const auto& point : points) {
            glVertex2d(point.x, point.y); // Встановлення координат точок полігону
        }
        glEnd(); // Кінець малювання полігону
    }
};

void Render(RECT& clientRect) {
    glClearColor(0.2f, 0.2f, 0.2f, 1.0f); // Встановлення кольору фону
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT | GL_STENCIL_BUFFER_BIT); // Очищення буферів кольору, глибини та трафарету
    glLoadIdentity(); // Скидання поточної матриці

    int Height = clientRect.bottom - clientRect.top; // Визначення висоти вікна
    int Width = clientRect.right - clientRect.left; // Визначення ширини вікна

    double xMin = -2, xMax = 7, yMin = -4, yMax = 0; // Встановлення меж координатної системи
    glViewport(0, 0, Width, Height); // Встановлення області перегляду
    gluOrtho2D(xMin - 2.0, xMax + 2.0, yMin - 2.0, yMax + 2.0); // Встановлення ортогональної проекції

    DrawGrid(xMin, xMax, yMin, yMax, 1.0); // Малювання сітки
    DrawAxes(xMin, xMax, yMin, yMax); // Малювання осей

    vector<Point> polygonPoints = {
        Point(-1, -4), Point(-2, -2), Point(-2, -1), Point(-1, 0), Point(1, -2), Point(1, -3), Point(0, -4), Point(-1, -4)
    }; // Визначення точок полігону

    vector<Point> points = {
        Point(4, -4), Point(3, -2), Point(3, -1), Point(4, 0), Point(6, -2), Point(6, -3), Point(5, -4), Point(4, -4)
    }; // Визначення окремих точок

    MyPolygon polygon(polygonPoints); // Створення об'єкта полігону
    polygon.draw(); // Малювання полігону

    for (const auto& point : points) {
        point.draw(); // Малювання окремих точок
    }
}