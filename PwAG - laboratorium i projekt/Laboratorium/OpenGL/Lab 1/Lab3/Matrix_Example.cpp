#include <windows.h>
#include <stdlib.h>
#include <math.h>
#include<GL/gl.h>
#include<GL/glu.h>
#include<GL/glaux.h>

#define M_PI 3.14159265358979323846

void DrawScene(GLfloat xRot, GLfloat yRot)
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	glMatrixMode(GL_MODELVIEW);

	GLfloat xRotRad = xRot * M_PI / 180.0f;
	GLfloat yRotRad = yRot * M_PI / 180.0f;
	//LoadIdentity()
	GLfloat identityMat[] = {		1.0f,	0.0f,	0.0f,	0.0f,
									0.0f,	1.0f,	0.0f,	0.0f,
									0.0f,	0.0f,	1.0f,	0.0f,
									0.0f,	0.0f,	0.0f,	1.0f
	};
	//glRotatef(xRot, 1.0f, 0.0f, 0.0f)
	GLfloat rotateXMat[] = {		1.0f,			0.0f,			0.0f,			0.0f,
									0.0f,			cosf(xRotRad),	sinf(xRotRad),	0.0f,
									0.0f,			-sinf(xRotRad),	cosf(xRotRad),	0.0f,
									0.0f,			0.0f,			0.0f,			1.0f
	};
	//glRotatef(yRot, 0.0f, 1.0f, 0.0f)
	GLfloat rotateYMat[] = {		cosf(yRotRad),	0.0f,			-sinf(yRotRad),	0.0f,
									0.0f,			1.0f,			0.0f,			0.0f,
									sinf(yRotRad),	0.0f,			cosf(yRotRad),	0.0f,
									0.0f,			0.0f,			0.0f,			1.0f
	};

	//glTranslatef(0, 3, 0)
	GLfloat translate1Mat[] = {		1.0f,	0.0f,	0.0f,	0.0f,
									0.0f,	1.0f,	0.0f,	0.0f,
									0.0f,	0.0f,	1.0f,	0.0f,
									0.0f,	3.0f,	0.0f,	1.0f
	};
	//glTranslatef(0, 3, 5)
	GLfloat translate2Mat[] = {		1.0f,	0.0f,	0.0f,	0.0f,
									0.0f,	1.0f,	0.0f,	0.0f,
									0.0f,	0.0f,	1.0f,	0.0f,
									0.0f,	3.0f,	5.0f,	1.0f
	};
	//glTranslatef(0, 3, 0)
	GLfloat translate3Mat[] = {		1.0f,	0.0f,	0.0f,	0.0f,
									0.0f,	1.0f,	0.0f,	0.0f,
									0.0f,	0.0f,	1.0f,	0.0f,
									0.0f,	-3.0f,	-1.0f,	1.0f
	};
	glPushMatrix();
		//glLoadIdentity();
		glLoadMatrixf(identityMat);

		//glRotatef(xRot, 1.0f, 0.0f, 0.0f);
		glMultMatrixf(rotateXMat);

		//glRotatef(yRot, 0.0f, 1.0f, 0.0f);
		glMultMatrixf(rotateYMat);

		auxWireCube(5);
		auxWireCube(1);
	glPopMatrix();

	glPushMatrix();
		//glLoadIdentity();
		glLoadMatrixf(identityMat);

		//glRotatef(xRot, 1.0f, 0.0f, 0.0f);
		glMultMatrixf(rotateXMat);
		//glRotatef(yRot, 0.0f, 1.0f, 0.0f);
		glMultMatrixf(rotateYMat);
		
		//glTranslatef(0, 3, 0);
		glMultMatrixf(translate1Mat);

		auxWireCube(2);
	glPopMatrix();

	glPushMatrix();
		//glLoadIdentity();
		glLoadMatrixf(identityMat);

		//glTranslatef(0, 3, 5);
		glMultMatrixf(translate2Mat);

		auxWireCube(2);
	glPopMatrix();

	glPushMatrix();
		//glLoadIdentity();
		glLoadMatrixf(identityMat);

		//glTranslatef(0, -3, -1);
		glMultMatrixf(translate3Mat);

		auxWireCube(2);
	glPopMatrix();

	glFinish();
}

void SetMyPixelFormat(HDC hdc)
{
	PIXELFORMATDESCRIPTOR pfd;
	ZeroMemory(&pfd, sizeof(pfd));
	pfd.nSize = sizeof(pfd);
	pfd.dwFlags = PFD_DRAW_TO_WINDOW | PFD_SUPPORT_OPENGL | PFD_DOUBLEBUFFER;
	pfd.iPixelType = PFD_TYPE_RGBA;
	pfd.cColorBits = 32;
	pfd.cDepthBits = 16;
	pfd.iLayerType = PFD_MAIN_PLANE;

	int nPixelFormat = ChoosePixelFormat(hdc, &pfd);
	SetPixelFormat(hdc, nPixelFormat, &pfd);
}
void ResizeWindow(int width, int height)
{
	if (height * width == 0) return;
	glViewport(0, 0, width, height);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	glOrtho(-10, 10, -10, 10, -10, 10);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	glEnable(GL_DEPTH_TEST);
}
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	PAINTSTRUCT ps;
	HDC hdc;
	static HGLRC hrc;
	static GLfloat xRot = 0.0f;
	static GLfloat yRot = 0.0f;

	switch (message)
	{
	case WM_SIZE:
		ResizeWindow(LOWORD(lParam), HIWORD(lParam));
		break;
	case WM_CREATE:
		hdc = GetDC(hWnd);
		SetMyPixelFormat(hdc);
		hrc = wglCreateContext(hdc);
		wglMakeCurrent(hdc, hrc);
		ReleaseDC(hWnd, hdc);
		break;
	case WM_KEYDOWN:
		if (wParam == VK_UP) xRot -= 5.0f;
		if (wParam == VK_DOWN) xRot += 5.0f;
		if (wParam == VK_LEFT) yRot -= 5.0f;
		if (wParam == VK_RIGHT) yRot += 5.0f;

		if (xRot > 356.0f) xRot = 0.0f;
		if (xRot < -1.0f) xRot = 355.0f;
		if (yRot > 356.0f) yRot = 0.0f;
		if (yRot < -1.0f) yRot = 355.0f;

		InvalidateRect(hWnd, NULL, FALSE);
		break;
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &ps);
		DrawScene(xRot, yRot);
		SwapBuffers(hdc);
		EndPaint(hWnd, &ps);
		break;
	case WM_ERASEBKGND:
		return 1;
		break;
	case WM_DESTROY:
		wglMakeCurrent(NULL, NULL);
		wglDeleteContext(hrc);
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}
ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;
	wcex.cbSize = sizeof(WNDCLASSEX);
	wcex.style = CS_HREDRAW | CS_VREDRAW | CS_OWNDC;
	wcex.lpfnWndProc = (WNDPROC)WndProc;
	wcex.cbClsExtra = 0;
	wcex.cbWndExtra = 0;
	wcex.hInstance = hInstance;
	wcex.hIcon = NULL;
	wcex.hCursor = LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wcex.lpszMenuName = NULL;
	wcex.lpszClassName = "Matrix";
	wcex.hIconSm = NULL;
	return RegisterClassEx(&wcex);
}
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
	HWND hWnd;
	hWnd = CreateWindow("Matrix", "Matrix", WS_OVERLAPPEDWINDOW, 50, 50, 550, 550, NULL, NULL, hInstance, NULL);
	if (!hWnd) return FALSE;
	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);
	return TRUE;
}
int APIENTRY WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPTSTR lpCmdLine, int nCmdShow)
{
	MSG msg;
	MyRegisterClass(hInstance);
	if (!InitInstance(hInstance, nCmdShow)) return FALSE;
	while (GetMessage(&msg, NULL, 0, 0)) {
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return (int)msg.wParam;
}