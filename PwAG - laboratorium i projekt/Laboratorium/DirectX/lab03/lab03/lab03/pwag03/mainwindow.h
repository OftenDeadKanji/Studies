#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include "common.h"
#include <QMainWindow>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT
    
public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();
    
private slots:
	void on_posXSlider_valueChanged(int val);
	void on_posYSlider_valueChanged(int val);
	void on_posZSlider_valueChanged(int val);

private:
    Ui::MainWindow *ui;
};

#endif // MAINWINDOW_H
