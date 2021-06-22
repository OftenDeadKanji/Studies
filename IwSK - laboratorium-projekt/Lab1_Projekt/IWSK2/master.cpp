#include "master.h"
#include "ui_master.h"
#include <string>
#include "ASCIImodbus.h"
#include <QTimer>
#include <iostream>

Master::Master(QWidget *parent)
    : QMainWindow(parent), ui(new Ui::Master) {
    ui->setupUi(this);

    modbus = new ASCIImodbus("/dev/pts/1");
}

Master::~Master() {
    delete modbus;
    delete ui;
}

void Master::on_isBroatcast_clicked(bool checked) {
    ui->address->setEnabled(!checked);
}

void Master::on_ok_clicked() {

    auto tupl = modbus->read();

    while((unsigned char)std::get<0>(tupl) != 248){
        tupl = modbus->read();
    }

    m_timeout = ui->timeout->value();
    m_lastAddress = ui->address->value();
    m_retransmition = ui->spinBox_2->value();

    char command = ui->comboBox->currentIndex() + 1;

    std::string data = ui->message->toPlainText().toStdString();
    std::string frameText;

    if(ui->isBroatcast->isChecked()){
        frameText = modbus->sendBroadcast(data, command);
        ui->hex->setText(QString::fromStdString(frameText));
        ui->receivedMessage->setText(QString(""));
    }
    else {
        frameText = modbus->sendAdressed(data, m_lastAddress, command);
        ui->hex->setText(QString::fromStdString(frameText));
        m_beginTimeout = std::chrono::steady_clock::now();
        read();
    }
}

void Master::read() {
    auto[outAddress, outCommand, outData, _] = modbus->read();

    if((unsigned char)outAddress != 248) {
        if ((unsigned char)outCommand < 128) {
            if(m_lastAddress == outAddress) {
                if (outCommand == 2) {
                    ui->receivedMessage->setText(QString::fromStdString(outData));
                } else if (outCommand == 1) {
                    ui->receivedMessage->setText(QString::fromStdString(outData));
                }
            }
        } else if (m_retransmition-- > 0) {
            modbus->sendAdressed(ui->message->toPlainText().toStdString(), ui->address->value(),
                                 (unsigned char) outCommand - 128);

            QTimer::singleShot(10, this, SLOT(read()));
        }
    }
    else {
        auto end = std::chrono::steady_clock::now();
        auto elapsedTime = std::chrono::duration_cast<std::chrono::milliseconds>(end - m_beginTimeout).count();

        if (elapsedTime < m_timeout) {
            QTimer::singleShot(10, this, SLOT(read()));
        } else {
            ui->message->setText(QString("timeout!"));
        }
    }
}
