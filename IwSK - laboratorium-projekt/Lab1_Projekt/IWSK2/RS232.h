//
// Created by debian on 6/25/20.
//

#ifndef RS232_RS232_H
#define RS232_RS232_H


#include <string>
#include <termios.h>
#include <unistd.h>

class RS232 {
    int retransmision = 0;
public:
    void setRetransmision(int retransmision);

private:
    int fd;
    struct termios options;
    std::string term = "\n";
public:
    enum charSize {
        S7,
        S8
    };
    enum control {
        E,
        O,
        N
    };

    RS232();
    void open(const std::string& port);
    explicit RS232(const std::string& port);
    void send(const std::string& text);
    std::string read(int bufSize = 256);
    void setTerm(const std::string& text);
    bool setSpeed(unsigned int speed);
    void setTermLF();
    void setTermNone();
    void setTermCR();
    void setTermCRLF();
    RS232 &setCharSize(RS232::charSize size);
    RS232 &setControl(RS232::control con);
    RS232 &setStopBits(unsigned int sb);
    RS232 &setSoftwareFC(bool enabled);
    RS232 &setTime(int time);
    int applySettings();
    RS232 &setTimeout(int timeout);
    virtual ~RS232();
};





#endif //RS232_RS232_H
