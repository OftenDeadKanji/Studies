//
// Created by debian on 9/12/20.
//

#ifndef IWSK2_ASCIIMODBUS_H
#define IWSK2_ASCIIMODBUS_H
#include "RS232.h"

class ASCIImodbus {

    RS232* rs;
    int timelimit = 0;
public:
    ASCIImodbus(const std::string& path);
    virtual ~ASCIImodbus();

    std::string sendAdressed(const std::string &data, char address, char command);
    std::string sendBroadcast(const std::string& data, char command);
    std::tuple<char, char,std::string, std::string> read();

    void setTimeLimit(int t);

    RS232 * getRS();
    char getLRC(std::string data);

    static std::string convertDataToHexText(const std::string& data);
    static std::string convertCharToHexText(char toConvert);
    static char convertHexTextToChar(const std::string &toConvert);
};


#endif //IWSK2_ASCIIMODBUS_H
