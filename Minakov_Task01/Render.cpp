// glWinApp.cpp : Defines the entry point for the application.
#include "pch.h"
#include "glWinApp.h"

extern LPCSTR s1, s2, s3;

int LoadWindowDefaultFont()
{
    int id = glGenLists(256);
    wglUseFontBitmaps(wglGetCurrentDC(), 0, 256, id);
    return id;
}

void OutText(LPCSTR str, double x, double y, double z = 0)
{
    glRasterPos3d(x, y, z);
    glListBase(idFont);
    glCallLists(strlen(str), GL_UNSIGNED_BYTE, &str[0]);
}

void Render(RECT& clientRect)
{
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT | GL_STENCIL_BUFFER_BIT);
    glLoadIdentity();

    int Height = clientRect.bottom - clientRect.top;
    int Width = clientRect.right - clientRect.left;

    glViewport(0, 0, Width, Height);
    gluOrtho2D(0, Width - 1.0, Height - 1.0, 0);

    glColor3d(1, 1, 1);
    OutText(s1, 20, 30);
    OutText(s2, 20, 50);
    OutText(s3, 20, 70);

    // Rectangle example
    glColor3d(1, 0, 0);
    glLineWidth(3);
    glBegin(GL_LINE_LOOP);
    glVertex2d(4, 100);
    glVertex2d(Width - 5.0, 100);
    glColor3d(1, 1, 0);
    glVertex2d(Width - 5.0, Height - 5.0);
    glVertex2d(4, Height - 5.0);
    glEnd();
}
