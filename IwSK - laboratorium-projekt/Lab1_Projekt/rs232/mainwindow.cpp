#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "RS232.h"

MainWindow::MainWindow( QWidget *parent) :
     QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);

}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_Next_clicked()
{
   rs = new RS232(ui->patch->text().toStdString());

   rs->setSpeed(ui->baud->currentIndex()+5);
   if(ui->dataSize_7->isChecked())
       rs->setCharSize(RS232::S7);
   else
       rs->setCharSize(RS232::S8);

   int stopBit;
   if(ui->stopBit_1->isChecked())
       stopBit =1;
   else
       stopBit =2;
    rs->setStopBits(stopBit);

   if( ui->terminator_none->isChecked())
       rs->setTermNone();
   else if( ui->terminator_ocalenie->isChecked())
      rs->setTerm(ui->term_custom->text().toStdString());
   else
   {
       if(ui->terminatorStandard->currentIndex() == 0)
            rs->setTermCR();
       else if(ui->terminatorStandard->currentIndex() == 1)
            rs->setTermLF();
       else
            rs->setTermCRLF();
   }

   if( ui->parity_n->isChecked())
       rs->setControl(RS232::N);
   else if( ui->parity_o->isChecked())
       rs->setControl(RS232::O);
   else
       rs->setControl(RS232::E);

  rs->setSoftwareFC(!ui->flowControl_none->isChecked());
  rs->applySettings();
  t = new Transmition(this,rs);
  t->show();




}
