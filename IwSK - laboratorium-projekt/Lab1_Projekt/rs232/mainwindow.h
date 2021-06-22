#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "transmition.h"
#include "RS232.h"

namespace Ui {
class MainWindow;
//class Communication;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT
    RS232* rs;
public:
    Transmition* t;
    explicit MainWindow( QWidget *parent = 0);
    ~MainWindow() override;
    //enum terminator {none_term=0, standard_CR_LF =1,  standard_CR =2, standard_LF = 3,  custom_1 =4, custom_2 =5  };
    //enum parity {none_par =0, odd =1, even =2};
    //enum flowControl {none_flow=0, hardware_DTR_SR = 1, hardware_RTS_CTS=2,  software =3 };
    int dataSize, term, par, flow;
private slots:
    void on_Next_clicked();

private:
    Ui::MainWindow *ui;

};

#endif // MAINWINDOW_H
