#ifndef TRANSMITION_H
#define TRANSMITION_H

#include <QMainWindow>
#include "RS232.h"
#include <iostream>
#include <chrono>
namespace Ui {
class Transmition;
}

class Transmition : public QMainWindow
{
    Q_OBJECT
public:
    QString conversation = " ";
    explicit Transmition(QWidget *parent = 0, RS232* rs = new RS232());


    ~Transmition();

private slots:
    void on_send_clicked();
    void read();

private:
    Ui::Transmition *ui;
    RS232* rs;
    QTimer *timer;
    bool isRead;
    std::chrono::time_point<std::chrono::steady_clock> begin;
    std::chrono::time_point<std::chrono::steady_clock> end;

};

#endif // TRANSMITION_H
