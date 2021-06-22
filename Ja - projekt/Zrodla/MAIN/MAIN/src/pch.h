#ifndef PCH_H
#define PCH_H

#define BACKGROUND_COLOR 255, 193, 51
#define CONTROL_COLOR 34, 177, 76
#define CONTROL_LIGHT_COLOR 123, 230, 155

#ifdef _WIN64
#include <windows.h>
#elif __linux__
#include <X11/Xlib.h>
#endif

#include <iostream>
#include <fstream>
#include <exception>
#include <vector>
#include <array>
#include <map>
#include <list>
#include <thread>
#include <ctime>
#include <sstream>
#include <iomanip>
#include <mutex>

#include <allegro5/allegro.h>
#include <allegro5/allegro_font.h>
#include <allegro5/allegro_primitives.h>
#include <allegro5/allegro_ttf.h>
#include <allegro5/allegro_native_dialog.h>

#include "system/system.h"

#include "exceptions/exceptions.h"
#include "enum/enums.h"

#include "view/control.h"
#include "view/slider.h"
#include "view/text.h"
#include "view/radioButtons.h"
#include "view/button.h"
#include "view/PrzyciskPlik.h"
#include "view/display.h"

#include <seidelC.h>
extern "C" void _stdcall SeidelAsm(float** A, float* B, float** alfa, float* beta, int n, float* xOld, float* xNew, int lowerBound, int upperBound, float* condition, bool** isReady, float precision, int maxIterations, int threadsNumber);

#include "model/solver.h"
#include "model/model.h"
#include "view/view.h"
#include "controller/controller.h"

#endif