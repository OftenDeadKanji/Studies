cmake_minimum_required(VERSION 3.15)
project(IWSK2)

set(CMAKE_CXX_STANDARD 20)

set(CMAKE_AUTOMOC ON)
set(CMAKE_INCLUDE_CURRENT_DIR ON)
set(CMAKE_AUTOUIC ON)

find_package(Qt5Widgets REQUIRED)

set(CMAKE_PREFIX_PATH "PATH_TO_QT/QT_VERSION/QT_ARCH/lib/cmake")

add_executable(IWSK2 main.cpp mainwindow.cpp mainwindow.h master.cpp master.h slave.cpp slave.h ASCIImodbus.cpp ASCIImodbus.h RS232.cpp RS232.h emptyMessageException.cpp emptyMessageException.h)
set( UI_SOURCES  mainwindow.ui master.ui slave.ui )
target_link_libraries(IWSK2 Qt5::Core)
target_link_libraries(IWSK2 Qt5::Widgets)