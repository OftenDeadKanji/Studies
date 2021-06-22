#-------------------------------------------------
#
# Project created by QtCreator 2020-09-12T20:39:44
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = IWSK2
TEMPLATE = app

# The following define makes your compiler emit warnings if you use
# any feature of Qt which has been marked as deprecated (the exact warnings
# depend on your compiler). Please consult the documentation of the
# deprecated API in order to know how to port your code away from it.
DEFINES += QT_DEPRECATED_WARNINGS

# You can also make your code fail to compile if you use deprecated APIs.
# In order to do so, uncomment the following line.
# You can also select to disable deprecated APIs only up to a certain version of Qt.
#DEFINES += QT_DISABLE_DEPRECATED_BEFORE=0x060000    # disables all the APIs deprecated before Qt 6.0.0


SOURCES += \
    ASCIImodbus.cpp \
    RS232.cpp \
    emptyMessageException.cpp \
        main.cpp \
        mainwindow.cpp \
    master.cpp \
    slave.cpp

HEADERS += \
    ASCIImodbus.h \
    RS232.h \
    emptyMessageException.h \
        mainwindow.h \
    master.h \
    slave.h

FORMS += \
        mainwindow.ui \
    master.ui \
    slave.ui
