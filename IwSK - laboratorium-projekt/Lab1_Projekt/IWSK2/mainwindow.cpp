#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent), ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
    delete m;
    delete s;
}

void MainWindow::on_ok_clicked()
{
    if(ui->comboBox->currentIndex() == 0)
    {
        m = new Master();
        m->show();
    }
    else
    {
        s = new Slave();
        s->show();
    }
}
