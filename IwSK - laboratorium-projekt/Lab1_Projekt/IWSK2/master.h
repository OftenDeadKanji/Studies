#ifndef MASTER_H
#define MASTER_H

#include <QMainWindow>
#include "ASCIImodbus.h"
#include <chrono>

namespace Ui {
class Master;
}

class Master : public QMainWindow
{
    Q_OBJECT

public:
    explicit Master(QWidget *parent = 0);
    ~Master();

private slots:
    void on_isBroatcast_clicked(bool checked);
    void on_ok_clicked();
    void read();

private:
    Ui::Master *ui;
    ASCIImodbus* modbus;
    int m_lastAddress = 0;
    int m_retransmition = 0;
    int m_timeout = 0;

    std::chrono::time_point<std::chrono::steady_clock> m_beginTimeout;
};

#endif // MASTER_H
