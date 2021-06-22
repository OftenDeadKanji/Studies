#include <iostream>

#include <QApplication>
#include "RS232.h"
#include "mainwindow.h"

int main(int argc, char *argv[])
{

    //std::cout << "Hello, World!" << std::endl;
    //RS232 temp("/dev/pts/2");
    //temp.send("420");
    //return 0;

    QApplication a(argc, argv);

    MainWindow w;
    w.show();

    return a.exec();
}
