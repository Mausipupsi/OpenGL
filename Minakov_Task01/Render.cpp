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
    glColor3dv(color); // ������������ ������� ���
    glLineWidth(lineWidth); // ������������ ������ ���

    glEnableClientState(GL_VERTEX_ARRAY); // ��������� ������ ������
    glVertexPointer(2, GL_DOUBLE, 0, vertices.data()); // ������������ ��������� �� ����� ������
    glDrawArrays(GL_LINES, 0, static_cast<GLsizei>(vertices.size() / 2)); // ��������� ���
    glDisableClientState(GL_VERTEX_ARRAY); // ��������� ������ ������
}

void DrawGrid(double xMin, double xMax, double yMin, double yMax, double step) {
    glEnable(GL_LINE_STIPPLE); // ��������� ������ ���������� ���
    glLineStipple(1, 0x00FF); // ������������ ������� ���������� ���

    vector<double> vertices; // ��������� ������� ��� ��������� ������ ����
    for (double x = xMin; x <= xMax; x += step) {
        vertices.push_back(x); // ��������� ��������� ������ ���� �� �� X
        vertices.push_back(yMin - 1); // ��������� ��������� ������ ���� �� �� Y
        vertices.push_back(x); // ��������� ��������� ������ ���� �� �� X
        vertices.push_back(yMax + 1); // ��������� ��������� ������ ���� �� �� Y
    }
    for (double y = yMin; y <= yMax; y += step) {
        vertices.push_back(xMin - 0.9); // ��������� ��������� ������ ���� �� �� X
        vertices.push_back(y); // ��������� ��������� ������ ���� �� �� Y
        vertices.push_back(xMax + 0.9); // ��������� ��������� ������ ���� �� �� X
        vertices.push_back(y); // ��������� ��������� ������ ���� �� �� Y
    }

    double gridColor[] = { 0.7, 0.7, 0.7 }; // ���� ����
    SetupAndDrawLines(vertices, 1, gridColor); // ������������ �� ��������� ��� ����

    glDisable(GL_LINE_STIPPLE); // ��������� ������ ���������� ���
}

void DrawAxes(double xMin, double xMax, double yMin, double yMax) {
    vector<double> vertices = {
        xMin - 0.9, 0, xMax + 0.9, 0, // ���������� ������ �� X
        0, yMin - 1, 0, yMax + 1 // ���������� ������ �� Y
    };

    double axesColor[] = { 1, 1, 0 }; // ���� ����
    SetupAndDrawLines(vertices, 4, axesColor); // ������������ �� ��������� ����

    vector<double> customLines = {
        xMin - 0.9, yMin - 0.3, xMin - 0.9, yMax + 1, // ���������� ���������� ���
        xMin - 0.3, yMin - 1, xMax + 0.9, yMin - 1 // ���������� ���������� ���
    };

    double customLinesColor[] = { 1, 1, 1 }; // ���� ���������� ���
    SetupAndDrawLines(customLines, 5, customLinesColor); // ������������ �� ��������� ���������� ���

    glLineWidth(3); // ������������ ������ ���
    glBegin(GL_LINES); // ������� ��������� ���
    glVertex2d(xMin - 0.9, yMax + 1.05); // ���������� ������ ������ �� Y
    glVertex2d(xMin - 1.1, yMax + 0.6); // ���������� ������ ������ �� Y
    glVertex2d(xMin - 0.9, yMax + 1.05); // ���������� ������ ������ �� Y
    glVertex2d(xMin - 0.7, yMax + 0.6); // ���������� ������ ������ �� Y

    glVertex2d(xMax + 0.95, yMin - 1); // ���������� ������ ������ �� X
    glVertex2d(xMax + 0.6, yMin - 1.2); // ���������� ������ ������ �� X
    glVertex2d(xMax + 0.95, yMin - 1); // ���������� ������ ������ �� X
    glVertex2d(xMax + 0.6, yMin - 0.8); // ���������� ������ ������ �� X
    glEnd(); // ʳ���� ��������� ���

    glLineWidth(3); // ������������ ������ ���
    glBegin(GL_LINES); // ������� ��������� ���
    for (double y = yMin; y <= yMax; y++) {
        glVertex2d(xMin - 0.9, y); // ���������� ������ ������ �� Y
        glVertex2d(xMin - 1.12, y); // ���������� ������ ������ �� Y
    }
    for (double x = xMin; x <= xMax; x++) {
        glVertex2d(x, yMin - 1.22); // ���������� ������ ������ �� X
        glVertex2d(x, yMin - 1); // ���������� ������ ������ �� X
    }
    glEnd(); // ʳ���� ��������� ���

    OutText("Y1", xMin - 1.5, yMin - 0.1); // ³���������� ������ "Y1" �� �� Y
    OutText("Y2", xMin - 1.5, yMax - 0.1); // ³���������� ������ "Y2" �� �� Y
    OutText("X1", xMin - 0.1, yMin - 1.5); // ³���������� ������ "X1" �� �� X
    OutText("X2", xMax - 0.1, yMin - 1.5); // ³���������� ������ "X2" �� �� X
}

class Point {
public:
    double x, y; // ���������� �����

    Point(double x = 0, double y = 0) : x(x), y(y) {} // ����������� � ����������� �� �������������

    void draw() const {
        glColor3d(1, 0, 0); // ������������ ��������� ������� ��� �����
        glPointSize(15); // ������������ ������ �����
        glBegin(GL_POINTS); // ������� ��������� �����
        glVertex2d(x, y); // ������������ ��������� �����
        glEnd(); // ʳ���� ��������� �����
    }
};

class MyPolygon {
public:
    vector<Point> points; // ������ �����, �� ��������� ������

    MyPolygon(const vector<Point>& points) : points(points) {} // ����������� � ������������ ������� �����

    void draw() const {
        glColor3d(0, 0, 1); // ������������ ������� ������� ��� �������
        glLineWidth(7); // ������������ ������ ��� �������
        glBegin(GL_LINE_STRIP); // ������� ��������� �������
        for (const auto& point : points) {
            glVertex2d(point.x, point.y); // ������������ ��������� ����� �������
        }
        glEnd(); // ʳ���� ��������� �������
    }
};

void Render(RECT& clientRect) {
    glClearColor(0.2f, 0.2f, 0.2f, 1.0f); // ������������ ������� ����
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT | GL_STENCIL_BUFFER_BIT); // �������� ������ �������, ������� �� ���������
    glLoadIdentity(); // �������� ������� �������

    int Height = clientRect.bottom - clientRect.top; // ���������� ������ ����
    int Width = clientRect.right - clientRect.left; // ���������� ������ ����

    double xMin = -2, xMax = 7, yMin = -4, yMax = 0; // ������������ ��� ����������� �������
    glViewport(0, 0, Width, Height); // ������������ ������ ���������
    gluOrtho2D(xMin - 2.0, xMax + 2.0, yMin - 2.0, yMax + 2.0); // ������������ ������������ ��������

    DrawGrid(xMin, xMax, yMin, yMax, 1.0); // ��������� ����
    DrawAxes(xMin, xMax, yMin, yMax); // ��������� ����

    vector<Point> polygonPoints = {
        Point(-1, -4), Point(-2, -2), Point(-2, -1), Point(-1, 0), Point(1, -2), Point(1, -3), Point(0, -4), Point(-1, -4)
    }; // ���������� ����� �������

    vector<Point> points = {
        Point(4, -4), Point(3, -2), Point(3, -1), Point(4, 0), Point(6, -2), Point(6, -3), Point(5, -4), Point(4, -4)
    }; // ���������� ������� �����

    MyPolygon polygon(polygonPoints); // ��������� ��'���� �������
    polygon.draw(); // ��������� �������

    for (const auto& point : points) {
        point.draw(); // ��������� ������� �����
    }
}