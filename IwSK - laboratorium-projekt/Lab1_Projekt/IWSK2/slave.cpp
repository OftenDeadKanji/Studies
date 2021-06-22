#include "slave.h"
#include "ui_slave.h"
#include "RS232.h"
#include <QTimer>

Slave::Slave(QWidget *parent) :
    QMainWindow(parent), ui(new Ui::Slave)
{
    ui->setupUi(this);
    modbus = new ASCIImodbus("/dev/pts/2");
    QTimer::singleShot(10, this, SLOT(read()));
}

Slave::~Slave()
{
    delete ui;
    delete modbus;
}

void Slave::read() {
    auto[outAddress, outCommand, outData, hexText] = modbus->read();

    if((unsigned char)outAddress != 248) {
        if(outAddress == ui->address->value()) {
            if((unsigned char)outCommand < 128) {
                ui->hex->setText(QString::fromStdString(hexText));
                if(outCommand == 1) {
                    ui->message->setText(QString::fromStdString(outData));
                    modbus->sendAdressed("ok", outAddress, outCommand);
                }
                else if(outCommand == 2) {
                    modbus->sendAdressed(ui->message->toPlainText().toStdString(), ui->address->value(), 2);
                }
            }
        }
        else if (outAddress == 0) {
            ui->hex->setText(QString::fromStdString(hexText));
            if(outCommand == 1){
                ui->message->setText(QString::fromStdString(outData));
            }
        }
    }
    QTimer::singleShot(10, this, SLOT(read()));
}
