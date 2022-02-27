//Laboratorium 6
//Jednostki cieniuj¹ce

#include <cstdlib>
#include <iostream>
#include <fstream>
#define GLUT_DISABLE_ATEXIT_HACK
#include "GL/glut.h"
#include "GL/glext.h"

using namespace std;


static int programHandle; // obiekt programu
static int vertexShaderHandle; // obiekt shadera wierzcho³ków
static int fragmentShaderHandle; // obiekt shadera fragmentów

//wskaŸniki funkcji
PFNGLCREATEPROGRAMPROC glCreateProgram = NULL;
PFNGLCREATESHADERPROC glCreateShader = NULL;
PFNGLSHADERSOURCEPROC glShaderSource = NULL;
PFNGLATTACHSHADERPROC glAttachShader = NULL;
PFNGLLINKPROGRAMPROC glLinkProgram = NULL;
PFNGLUSEPROGRAMPROC	glUseProgram = NULL;
PFNGLCOMPILESHADERPROC	glCompileShader = NULL;

PFNGLGETOBJECTPARAMETERIVARBPROC glGetObjectParameterivARB = NULL;
PFNGLGETINFOLOGARBPROC glGetInfoLogARB = NULL;

// funkcja do odczytu kodu shaderow
char* readShader(char* aShaderFile)
{
   FILE* filePointer = fopen(aShaderFile, "rb");	
   char* content = NULL;
   long numVal = 0;

   fseek(filePointer, 0L, SEEK_END);
   numVal = ftell(filePointer);
   fseek(filePointer, 0L, SEEK_SET);
   content = (char*) malloc((numVal+1) * sizeof(char)); 
   fread(content, 1, numVal, filePointer);
   content[numVal] = '\0';
   fclose(filePointer);
   return content;
}

// incjalizacja shaderów
void setShaders(char* vertexShaderFile, char* fragmentShaderFile)  
{
   char* vertexShader = readShader(vertexShaderFile);
   char* fragmentShader = readShader(fragmentShaderFile);

   programHandle = glCreateProgram(); // tworzenie obiektu programu
   vertexShaderHandle = glCreateShader(GL_VERTEX_SHADER); // shader wierzcho³ków
   fragmentShaderHandle = glCreateShader(GL_FRAGMENT_SHADER); // shader fragmentów

   glShaderSource(vertexShaderHandle, 1, (const char**) &vertexShader, NULL); // ustawianie Ÿród³a shadera wierzcho³ków
   glShaderSource(fragmentShaderHandle, 1, (const char**) &fragmentShader, NULL); // ustawianie Ÿród³a shadera fragmentów

   // kompilacja shaderów
   glCompileShader(vertexShaderHandle); 
   glCompileShader(fragmentShaderHandle); 

   /* error check */

   GLint status = 0;

   glGetObjectParameterivARB(vertexShaderHandle, GL_OBJECT_COMPILE_STATUS_ARB, &status);
   if (!status) {
	   const int maxInfoLogSize = 2048;
	   GLchar infoLog[maxInfoLogSize];
	   glGetInfoLogARB(vertexShaderHandle, maxInfoLogSize, NULL, infoLog);
	   std::cout << infoLog;
   }

   glGetObjectParameterivARB(fragmentShaderHandle, GL_OBJECT_COMPILE_STATUS_ARB, &status);
   if (!status) {
	   const int maxInfoLogSize = 2048;
	   GLchar infoLog[maxInfoLogSize];
	   glGetInfoLogARB(fragmentShaderHandle, maxInfoLogSize, NULL, infoLog);
	   std::cout << infoLog;
   }

   //dodanie shaderów do programu
   glAttachShader(programHandle, vertexShaderHandle); 
   glAttachShader(programHandle, fragmentShaderHandle); 

   glGetObjectParameterivARB(programHandle, GL_OBJECT_LINK_STATUS_ARB, &status);
   if (!status) {
	   const int maxInfoLogSize = 2048;
	   GLchar infoLog[maxInfoLogSize];
	   glGetInfoLogARB(programHandle, maxInfoLogSize, NULL, infoLog);
	   std::cout << infoLog;
   }

   //uruchomienie
   glLinkProgram(programHandle); 
   glUseProgram(programHandle); 
}


void setup(void)
{    
   glClearColor(1.0, 1.0, 1.0, 0.0); 
   glEnable(GL_DEPTH_TEST); 

   
   glEnable(GL_LIGHTING); 

   
   glEnable(GL_NORMALIZE); 

   // w³aœciwoœci œwiat³a
   float lightAmb[] = {0.0, 0.0, 0.0, 1.0};
   float lightDifAndSpec[] = {1.0, 1.0, 1.0, 0.0};
   float lightPos[] = {0.0, 1.0, 0.0, 0.0};
   float globAmb[] = {0.2, 0.2, 0.2, 1.0};

   //tylko Ÿród³o œwiata³ 0
   glLightfv(GL_LIGHT0, GL_AMBIENT, lightAmb);
   glLightfv(GL_LIGHT0, GL_DIFFUSE, lightDifAndSpec);
   glLightfv(GL_LIGHT0, GL_SPECULAR, lightDifAndSpec);
   glLightfv(GL_LIGHT0, GL_POSITION, lightPos);

   glEnable(GL_LIGHT0); 
   
   //œwiat³o globalne
   glLightModelfv(GL_LIGHT_MODEL_AMBIENT, globAmb); 

	//w³aœciwoœci materia³u
   float matAmbAndDif[] = {0.0, 0.5, 0.5, 1.0};
   float matSpec[] = {1.0, 1.0, 1.0, 1.0};
   float matShine[] = {50.0};

   
   glMaterialfv(GL_FRONT_AND_BACK, GL_AMBIENT_AND_DIFFUSE, matAmbAndDif);
   glMaterialfv(GL_FRONT_AND_BACK, GL_SPECULAR, matSpec);
   glMaterialfv(GL_FRONT_AND_BACK, GL_SHININESS, matShine);
}

//rysowanie sceny
void drawScene(void)
{
   int i = 0;
  
   glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

   glLoadIdentity();
   gluLookAt(0.0, 5.0, 30.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
       
   for(float v = 100.0; v > -100.0; v -= 1.0)
   {
      glBegin(GL_TRIANGLE_STRIP);
      for(float u = -100.0; u < 100.0; u += 1.0)
	  {
         glNormal3f(0.0, 1.0, 0.0); 
		 glVertex3f(u, 0.0, v - 1.0);
	     glVertex3f(u, 0.0, v);
		 i++;
	  }
      glEnd();
	  i++;
   }

   glutSwapBuffers();	
}


void resize(int w, int h)
{
   glViewport(0, 0, (GLsizei)w, (GLsizei)h);
   glMatrixMode(GL_PROJECTION);
   glLoadIdentity();
   glFrustum(-5.0, 5.0, -5.0, 5.0, 5.0, 100.0);
   glMatrixMode(GL_MODELVIEW);
   glLoadIdentity();
}


// sprawdzenie i przygotowanie obslugi wybranych rozszerzen
void extensionSetup()
{
    // pobranie numeru wersji biblioteki OpenGL
   const char * version =(char *) glGetString( GL_VERSION );
       
   if ((version[0] < '1') || ((version[0] == '1') && (version[2] < '5')) || (version[1] != '.'))  {
     printf("Bledny format wersji OpenGL\n");
     exit(0);
   }
   else {
     glCreateProgram = (PFNGLCREATEPROGRAMPROC) wglGetProcAddress("glCreateProgram");
	 glCreateShader = (PFNGLCREATESHADERPROC) wglGetProcAddress("glCreateShader");
     glShaderSource = (PFNGLSHADERSOURCEPROC) wglGetProcAddress("glShaderSource");
	 glAttachShader = (PFNGLATTACHSHADERPROC) wglGetProcAddress("glAttachShader");
	 glLinkProgram = (PFNGLLINKPROGRAMPROC) wglGetProcAddress("glLinkProgram");
	 glUseProgram = (PFNGLUSEPROGRAMPROC) wglGetProcAddress("glUseProgram");
	 glCompileShader = (PFNGLCOMPILESHADERPROC) wglGetProcAddress("glCompileShader");

	 glGetObjectParameterivARB = (PFNGLGETOBJECTPARAMETERIVARBPROC)wglGetProcAddress("glGetObjectParameterivARB");
	 glGetInfoLogARB = (PFNGLGETINFOLOGARBPROC)wglGetProcAddress("glGetInfoLogARB");
   }    
}



int main(int argc, char **argv) 
{
   glutInit(&argc, argv);
   glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_DEPTH);
   glutInitWindowSize(500, 500);
   glutInitWindowPosition(100, 100);
   glutCreateWindow("OpenGL - Laboratorium 6");
   setup();
   extensionSetup();
   glutDisplayFunc(drawScene);
   glutReshapeFunc(resize);
   setShaders("perVertexLightingSimple.vs", "passThrough.fs");
   glutMainLoop();
   return 0; 
}
