#include "transmition.h"
#include "ui_transmition.h"
#include <QTimer>

Transmition::Transmition( QWidget *parent, RS232 * rs) :
        QMainWindow(parent),
        ui(new Ui::Transmition)
{
    ui->setupUi(this);
    this->rs = rs;
    QTimer::singleShot(200, this, SLOT(read()));

}

Transmition::~Transmition()
{
    delete ui;
}

void Transmition::on_send_clicked(){
    std::string temp = ui->message->toPlainText().toStdString();
    if(temp.find("/ping")!= std::string::npos)
        begin = std::chrono::steady_clock::now();
    rs->send(ui->message->toPlainText().toStdString());

    conversation += ">> " + ui->message->toPlainText() +'\n';
    ui->conversation->setText(conversation);
    ui->message->clear();
}

void Transmition::read() {
    auto temp = rs->read();
    if(temp.find("/ping") != std::string::npos)
        rs->send("/pong");
    else if(temp.find("/pong") !=  std::string::npos) {
        end = std::chrono::steady_clock::now();
        auto t = std::chrono::duration_cast<std::chrono::milliseconds>(end - begin).count();
        conversation +=  QString::fromStdString(std::to_string(t)) + "ms\n";
        ui->conversation->setText(conversation);
    }
    else if(!temp.empty()) {
        conversation += "<< " + QString::fromStdString(temp);
        //conversation += QString::fromStdString("123\n");
        ui->conversation->setText(conversation);
    }
    QTimer::singleShot(200,this, SLOT(read()));

}
