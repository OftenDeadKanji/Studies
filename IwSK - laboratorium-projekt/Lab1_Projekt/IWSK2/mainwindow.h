#ifndef MAINWINDOW_H
#define MAINWINDOW_H
#include "master.h"
#include "slave.h"
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
    void on_ok_clicked();

private:
    Ui::MainWindow *ui;
    Master *m = nullptr;
    Slave *s = nullptr;
};

#endif // MAINWINDOW_H
