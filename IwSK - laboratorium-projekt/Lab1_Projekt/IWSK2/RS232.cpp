//
// Created by debian on 6/25/20.
//

#include "RS232.h"
#include <stdio.h>   /* Standard input/output definitions */
#include <string.h>  /* String function definitions */
#include <unistd.h>  /* UNIX standard function definitions */
#include <fcntl.h>   /* File control definitions */
#include <errno.h>   /* Error number definitions */
#include <termios.h> /* POSIX terminal control definitions */
#include <iostream>

RS232::RS232(const std::string& port) {
    open(port);
}

void RS232::send(const std::string &text) {
    std::string temp = text+term;
    write (fd,temp.c_str(), temp.size());
}

RS232::~RS232() {
    close(fd);
}

void RS232::setTerm(const std::string &text) {
    if(text.size()<=2) //??? mamy w ui zapewnione
        term=text;
}

void RS232::setTermLF() {
    term = "\n";
}

void RS232::setTermCR() {
    term = "\r";
}

void RS232::setTermCRLF() {
    term="\r\n";
}

std::string RS232::read(int bufSize) {
    std::string temp = "";
    char buf = 0;
    while((::read(fd, (void *) &buf, 1))==1) {
        temp += buf;
        if(temp.find(term, temp.size()>2 ?temp.size()-2:0)!=-1)
            break;
    }
    return temp;
}

bool RS232::setSpeed(unsigned int speed) {
    if(speed >17)
        return false;
    if(cfsetispeed(&options, speed)==-1)
        return false;
    if(cfsetospeed(&options, speed)==-1)
        return false;
    return true;
}

RS232 &RS232::setCharSize(charSize size) {
    options.c_cflag &= ~CSIZE;
    if(size==S7)
        options.c_cflag |= CS7;
    else if(size==S8)
        options.c_cflag |= CS8;
    return *this;
}

RS232 &RS232::setControl(RS232::control con){
    if (con==N)
        options.c_cflag &= ~PARENB;
    else if(con==E){
        options.c_cflag |= PARENB;
        options.c_cflag &= ~PARODD;
    }
    else if(con==O){
        options.c_cflag |= PARENB;
        options.c_cflag |= PARODD;
    }
    return *this;
}

RS232 &RS232::setStopBits(unsigned int sb) {
    if(sb==1)
        options.c_cflag &= ~CSTOPB;
    else if(sb==2)
        options.c_cflag |= CSTOPB;
    return *this;
}

int RS232::applySettings() {
    return tcsetattr(fd, TCSANOW, &options);
}

RS232 &RS232::setTimeout(int timeout) {
    options.c_cc[VTIME] = timeout;
    return *this;
}

RS232 &RS232::setSoftwareFC(bool enabled) {
    if(enabled)
        options.c_iflag |= (IXON | IXOFF | IXANY);
    else
        options.c_iflag &= ~(IXON | IXOFF | IXANY);
    return *this;
}

RS232 &RS232::setTime(int time)
{
    tcgetattr(fd, &options);

    options.c_cc[VTIME] = time;

    tcsetattr(fd, TCSANOW, &options);
}

RS232::RS232() {}

void RS232::open(const std::string &port) {
    fd = ::open(port.c_str(),  O_RDWR | O_NOCTTY );
    tcgetattr(fd, &options);

    cfsetispeed(&options, B19200);
    cfsetospeed(&options, B19200);
    options.c_cflag |= (CLOCAL | CREAD);
    options.c_cflag &= ~PARENB;
    options.c_cflag &= ~CSTOPB;
    options.c_cflag &= ~CSIZE;
    options.c_cflag |= CS8;
    options.c_lflag &= ~(ICANON | ECHO | ECHOE | ISIG);
    options.c_cc[VTIME] = 1;
    options.c_cc[VMIN] = 0;
    tcsetattr(fd, TCSANOW, &options);
}

void RS232::setTermNone() {
     term = "";
}

void RS232::setRetransmision(int retransmision) {
    RS232::retransmision = retransmision;
}
