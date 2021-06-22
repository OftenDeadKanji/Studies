#ifndef SLAVE_H
#define SLAVE_H

#include <QMainWindow>
#include "ASCIImodbus.h"

namespace Ui {
class Slave;
}

class Slave : public QMainWindow
{
    Q_OBJECT
public slots:
    void read();
public:
    explicit Slave(QWidget *parent = 0);
    ~Slave();

private:
    Ui::Slave *ui;
    ASCIImodbus * modbus;
};

#endif // SLAVE_H
