//
// Created by debian on 9/12/20.
//
#include "ASCIImodbus.h"
#include <tuple>
#include <string>


ASCIImodbus::ASCIImodbus(const std::string& path) {
    rs = new RS232(path);
    rs->setTermCRLF();
    rs->setTimeout(0).applySettings();

    //ustaw terminator RS-a na CL+CR
}

ASCIImodbus::~ASCIImodbus() {
    delete rs;
}

std::string ASCIImodbus::sendAdressed(const std::string &data, char address, char command) {

    std::string convertedData = convertDataToHexText(data);
    char LRC = this->getLRC(data);
    std::string toSend = ":" + convertCharToHexText(address) + convertCharToHexText(command) + convertedData + convertCharToHexText(LRC);
    rs->send(toSend);
    return toSend + "\r" + "\n";
}

std::string ASCIImodbus::sendBroadcast(const std::string& data, char command) {

    std::string convertedData = convertDataToHexText(data);
    char LRC = this->getLRC(data);
    std::string toSend = std::string(":") + "00" + convertCharToHexText(command) + convertedData + convertCharToHexText(LRC);
    rs->send(toSend);
    return toSend + "\r" + "\n";
}

std::tuple<char, char,std::string, std::string> ASCIImodbus::read() {

    std::string outData;
    std::string readMessage = rs->read();

    if(readMessage.empty())
        return std::make_tuple(248, 0, "", "");

    char outAddress = 0;
    char outCommand = 0;

    std::string convertedLRC(readMessage, readMessage.length() >= 4? readMessage.length() -4:0, readMessage.length() >= 3? readMessage.length() - 3:0);

    for (int i = 5; i < readMessage.length() - 4; i += 2) {
        std::string toConvert(readMessage, i, i + 1);
        outData += convertHexTextToChar(toConvert);
    }

    std::string convertedCommand(readMessage, 3, 4);
    outCommand = convertHexTextToChar(convertedCommand);

    std::string convertedAddress(readMessage, 1, 2);
    outAddress = convertHexTextToChar(convertedAddress);

    if ((readMessage[0] != ':' || getLRC(outData) != convertHexTextToChar(convertedLRC)) && (unsigned char)outCommand < 128) {
        if(outAddress != 0)
            outCommand+=128;
    }

    return std::make_tuple(outAddress, outCommand, outData, readMessage);
}

char ASCIImodbus::getLRC(std::string data) {

    char LRC = 0;
    for (int i = 0; i < data.length(); i++) {
        LRC ^= data[i];
    }
    return LRC;

}

std::string ASCIImodbus::convertDataToHexText(const std::string& data) {

    std::string convertedData;
    for(char i : data){
        convertedData += convertCharToHexText(i);
    }
    return convertedData;
}

std::string ASCIImodbus::convertCharToHexText(char toConvert) {

    char firstChar = toConvert / 16;
    char secondChar = toConvert % 16;

    if(firstChar < 10) {
        firstChar += '0';
    } else if(firstChar >= 10) {
        firstChar += 'A' - 10;
    }

    if(secondChar < 10) {
        secondChar += '0';
    } else if(secondChar >= 10) {
        secondChar += 'A' - 10;
    }

    char ret[3];
    ret[0] = firstChar;
    ret[1] = secondChar;
    ret[2] = 0;

    return std::string(ret);
}

char ASCIImodbus::convertHexTextToChar(const std::string &toConvert) {

    char retChar = 0;

    if(toConvert[0] <= '9' && toConvert[0] >= '0') {
        retChar += (toConvert[0] - '0') * 16;
    } else if(toConvert[0] >= 'A' && toConvert[0] <= 'F') {
        retChar += (toConvert[0] - 'A' + 10) * 16;
    }

    if(toConvert[1] <= '9' && toConvert[1] >= '0') {
        retChar += (toConvert[1] - '0');
    } else if(toConvert[1] >= 'A' && toConvert[1] <= 'F') {
        retChar += (toConvert[1] - 'A' + 10);
    }

    return retChar;
}

RS232 *ASCIImodbus::getRS() {
    return rs;
}

void ASCIImodbus::setTimeLimit(int t) {
    timelimit = t;
}
