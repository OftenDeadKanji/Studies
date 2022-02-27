#ifndef COMMON_H
#define COMMON_H					//normal pch is problematic when used with generated moc files

#include <iostream>
#include <cassert>
#include <sstream>
#include <fstream>
#include <vector>
#include <list>
#include <string>
#include <windows.h>

//dx
#include <d3dcompiler.h>
#include <d3d11.h>
//dxtk utils
#include <SimpleMath.h>
#include <WICTextureLoader.h>

#define SAFE_RELEASE(x) { if(x) { (x)->Release(); (x)=NULL; } }
#define NOMINMAX

#endif
