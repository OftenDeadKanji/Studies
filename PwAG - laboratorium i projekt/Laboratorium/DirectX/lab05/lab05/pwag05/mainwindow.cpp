#include "common.h"
#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{  
    ui->setupUi(this);
    setCentralWidget(ui->splitter);	

    QList<int> sizes;
    sizes << 800 << 200;
    ui->splitter->setSizes(sizes);
	
	connect(ui->renderWidget, SIGNAL(fpsChanged(double)), ui->lcdNumber, SLOT(display(double)));
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_posXSlider_valueChanged(int val)
{
	ui->renderWidget->setObjectPositionX(.25f * (float)val);
}

void MainWindow::on_posYSlider_valueChanged(int val)
{
	ui->renderWidget->setObjectPositionY(.25f * (float)val);
}

void MainWindow::on_posZSlider_valueChanged(int val)
{
	ui->renderWidget->setObjectPositionZ(.25f * (float)val);
}

void MainWindow::on_useGSCheckBox_toggled(bool checked)
{
	ui->renderWidget->setUseGeometryShaderStage(checked);
}