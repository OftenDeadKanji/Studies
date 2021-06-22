#include "mainwindow.h"
#include "ASCIImodbus.h"
#include <QApplication>
#include <tuple>
int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    MainWindow w;
    w.show();
    //SCIImodbus temp0 ("/dev/pts/1");
    //ASCIImodbus temp1 ("/dev/pts/2");

    //auto temp420 = temp0.sendAdressed("4200", 69, 1);
    //auto temp69 =temp1.read();
    //return 0;
    return a.exec();
}
