/********************************************************************************
** Form generated from reading UI file 'mainwindow.ui'
**
** Created: Sun 28. Oct 21:26:10 2012
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QCheckBox>
#include <QtGui/QHeaderView>
#include <QtGui/QLCDNumber>
#include <QtGui/QMainWindow>
#include <QtGui/QMenuBar>
#include <QtGui/QSlider>
#include <QtGui/QSplitter>
#include <QtGui/QToolBar>
#include <QtGui/QWidget>
#include "renderwidget.h"

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QWidget *centralWidget;
    QSplitter *splitter;
    RenderWidget *renderWidget;
    QWidget *toolsWidget;
    QLCDNumber *lcdNumber;
    QSlider *posXSlider;
    QSlider *posYSlider;
    QSlider *posZSlider;
    QCheckBox *useGSCheckBox;
    QMenuBar *menuBar;
    QToolBar *mainToolBar;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName(QString::fromUtf8("MainWindow"));
        MainWindow->resize(1000, 600);
        centralWidget = new QWidget(MainWindow);
        centralWidget->setObjectName(QString::fromUtf8("centralWidget"));
        splitter = new QSplitter(centralWidget);
        splitter->setObjectName(QString::fromUtf8("splitter"));
        splitter->setGeometry(QRect(140, 70, 701, 451));
        splitter->setOrientation(Qt::Horizontal);
        renderWidget = new RenderWidget(splitter);
        renderWidget->setObjectName(QString::fromUtf8("renderWidget"));
        splitter->addWidget(renderWidget);
        toolsWidget = new QWidget(splitter);
        toolsWidget->setObjectName(QString::fromUtf8("toolsWidget"));
        lcdNumber = new QLCDNumber(toolsWidget);
        lcdNumber->setObjectName(QString::fromUtf8("lcdNumber"));
        lcdNumber->setEnabled(true);
        lcdNumber->setGeometry(QRect(0, 0, 64, 23));
        lcdNumber->setFrameShadow(QFrame::Plain);
        lcdNumber->setMidLineWidth(0);
        lcdNumber->setSegmentStyle(QLCDNumber::Flat);
        posXSlider = new QSlider(toolsWidget);
        posXSlider->setObjectName(QString::fromUtf8("posXSlider"));
        posXSlider->setGeometry(QRect(20, 120, 160, 16));
        posXSlider->setMinimum(-20);
        posXSlider->setMaximum(20);
        posXSlider->setOrientation(Qt::Horizontal);
        posYSlider = new QSlider(toolsWidget);
        posYSlider->setObjectName(QString::fromUtf8("posYSlider"));
        posYSlider->setGeometry(QRect(20, 150, 160, 16));
        posYSlider->setMinimum(-20);
        posYSlider->setMaximum(20);
        posYSlider->setOrientation(Qt::Horizontal);
        posZSlider = new QSlider(toolsWidget);
        posZSlider->setObjectName(QString::fromUtf8("posZSlider"));
        posZSlider->setGeometry(QRect(20, 180, 160, 16));
        posZSlider->setMinimum(-20);
        posZSlider->setMaximum(20);
        posZSlider->setOrientation(Qt::Horizontal);
        useGSCheckBox = new QCheckBox(toolsWidget);
        useGSCheckBox->setObjectName(QString::fromUtf8("useGSCheckBox"));
        useGSCheckBox->setGeometry(QRect(50, 230, 71, 18));
        splitter->addWidget(toolsWidget);
        MainWindow->setCentralWidget(centralWidget);
        menuBar = new QMenuBar(MainWindow);
        menuBar->setObjectName(QString::fromUtf8("menuBar"));
        menuBar->setGeometry(QRect(0, 0, 1000, 18));
        MainWindow->setMenuBar(menuBar);
        mainToolBar = new QToolBar(MainWindow);
        mainToolBar->setObjectName(QString::fromUtf8("mainToolBar"));
        MainWindow->addToolBar(Qt::TopToolBarArea, mainToolBar);

        retranslateUi(MainWindow);

        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QApplication::translate("MainWindow", "PwAG - D3D11 - Lab04", 0, QApplication::UnicodeUTF8));
        useGSCheckBox->setText(QApplication::translate("MainWindow", "Use GS", 0, QApplication::UnicodeUTF8));
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
