cmake_minimum_required(VERSION 3.15)
project(rs232)

set(CMAKE_CXX_STANDARD 20)


set(CMAKE_AUTOMOC ON)
set(CMAKE_INCLUDE_CURRENT_DIR ON)
set(CMAKE_AUTOUIC ON)

find_package(Qt5Widgets REQUIRED)

set(CMAKE_PREFIX_PATH "PATH_TO_QT/QT_VERSION/QT_ARCH/lib/cmake")

add_executable(rs232 main.cpp RS232.cpp RS232.h mainwindow.cpp mainwindow.h transmition.cpp transmition.h transmition.ui)
set( UI_SOURCES transmition.ui)
target_link_libraries(rs232 Qt5::Core)
target_link_libraries(rs232 Qt5::Widgets)