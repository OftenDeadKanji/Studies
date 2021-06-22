/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.communicator;

import java.io.*;
import java.net.*;
import pl.polsl.lab.Buttons;
import pl.polsl.lab.Communication;

/**
 * A class that is responsible for communication with the client.
 * 
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class Communicator implements Closeable {

    /**
     * A pressed button type that is received from a client.
     */
    private Buttons pressedButton;
    
    /**
     * A received communication type.
     */
    private Communication communicationSent;

    /**
     * A single input line.
     */
    private String inLine;
    
    /**
     * A variable that informs if there is a client connected to the server.
     */
    private boolean isConnected;

    /**
     * An array that consists of a correct protocole order. 
     */
    private final String[][][] correctOrder;
    
    /**
     * An array that consists of a help message.
     */
    private final String[] help;

    /**
     * A server socket got from a server object.
     */
    private final ServerSocket serverSocket;
    
    /**
     * A socket used for communication.
     */
    private Socket socket;
    
    /**
     * Buffered input character stream.
     */
    private BufferedReader input;
    
    /**
     * Formatted output character stream.
     */
    private PrintWriter output;

    /**
     * A class constructor that determines a correct protocole order and 
     * a content of a help message.
     * @param serverSocket A socket from a server.
     */
    public Communicator(ServerSocket serverSocket) {

        this.serverSocket = serverSocket;

        pressedButton = Buttons.NONE;
        communicationSent = Communication.COMMUNICATION_NONE;
        isConnected = false;

        correctOrder = new String[][][]{
            {
                {"GET"},
                {"MODEL", "COMMUNICATION_GET_MODEL"},
                {"MODEL_AND_INDEX", "COMMUNICATION_GET_MODEL_INDEX"},
                {"MODE", "COMMUNICATION_GET_MODE"}
            },
            {
                {"SEND"},
                {"HELP", "COMMUNICATION_HELP"},
                {"PRESSED_BUTTON_NONE", "NONE"},
                {"PRESSED_BUTTON_SELECT", "BUTTON_SELECT"},
                {"PRESSED_BUTTON_BUBBLE", "BUTTON_BUBBLE"},
                {"PRESSED_BUTTON_BOGO", "BUTTON_BOGO"},
                {"PRESSED_BUTTON_INSERTION", "BUTTON_INSERTION"},
                {"PRESSED_BUTTON_EXIT", "BUTTON_EXIT"}
            }
        };

        help = new String[]{
            "\nCommunication with server requires correct order in communication",
            "protocole consists of ONLY for lines, which are:",
            "STARTM \t\t\t start of protocole",
            "<COMMAND> \t\t GET or SEND",
            "<DESC> \t\t\t description, for: \n\r\t\t\t GET - MODE, MODEL or MODEL_AND_INDEX \n\r\t\t\t SEND - PRESSED_BUTTON_<BUTTON> where BUTTON: NONE, SELECT, BUBBLE, BOGO, INSERTION or EXIT",
            "ENDM \t\t\t end of protocole",
            "\nto end session - QUIT."
        };
    }

    /**
     * A metohde that checks if there's a client connected and if so, it creates
     * input and output streams.
     * @throws IOException - can be thrown during streams creation.
     */
    public void socketAccept() throws IOException {
        try {
            socket = serverSocket.accept();

            output = new PrintWriter(
                    new BufferedWriter(
                            new OutputStreamWriter(
                                    socket.getOutputStream())), true);
            input = new BufferedReader(
                    new InputStreamReader(
                            socket.getInputStream()));
            isConnected = true;
        } catch (SocketTimeoutException exception) {
            //for debugging only
            //System.out.println(exception.getMessage());
        }
    }

    /**
     * A mothode for received communications from a client.
     * @throws IOException - can be thrown when reading from an input.
     */
    public void receive() throws IOException {

        communicationSent = Communication.COMMUNICATION_NONE;
        socket.setSoTimeout(200);
        try {
            //first line of a communication
            inLine = input.readLine();
            socket.setSoTimeout(0);
            if (inLine.equalsIgnoreCase("HELP")) {
                sendCommunication("1 OK");
                sendCommunication("FROM SERVER: help received");
                for (String iter : help) {
                    sendCommunication(iter);
                }
                return;
            } else if (inLine.equalsIgnoreCase("QUIT")) {
                sendCommunication("1 OK");
                sendCommunication("FROM SERVER: quit received; goodbye!");
                communicationSent = Communication.COMMUNICATION_END;
                close();
            } else if (inLine.equalsIgnoreCase("STARTM")) { //condition for the begining of a communication
                inLine = input.readLine();
                if (inLine.equalsIgnoreCase("ENDM")) { //condition for the end of a communication
                    sendCommunication("FROM SERVER: end received");
                    return;
                }
                for (String[][] correctOrderIter : correctOrder) { //checking correct order
                    if (correctOrderIter[0][0].equals(inLine)) {
                        inLine = input.readLine();
                        for (String[] correctOrderSecIter : correctOrderIter) { //checking correct order
                            if (correctOrderSecIter[0].equalsIgnoreCase(inLine)) {
                                if (input.readLine().equalsIgnoreCase("ENDM")) {
                                    sendCommunication("1 OK");
                                    sendCommunication("FROM SERVER: correct protocol received, processing...");
                                    communicationSent = Communication.valueOf(correctOrderSecIter[1].toUpperCase()); //result for a correct protocol order
                                    convertResult();
                                    return;
                                }
                            }
                        } //no matches in correctOrder array -> wrong protocol order
                        sendCommunication("Wrong protocole.");
                        return;
                    }
                } //no matches in correctOrder array -> wrong protocol order
                sendCommunication("Wrong protocole.");
                return;
            }
            sendCommunication("FROM SERVER: line received, but nothing will change (HELP)");
        } catch (SocketTimeoutException exception) {
        } //no communication from client, server will just keep working
    }

    /**
     * A methode that converts a communication type - only when a button has
     * been pressed.
     */
    private void convertResult() {
        switch (communicationSent) {
            case NONE:
            case BUTTON_SELECT:
            case BUTTON_BUBBLE:
            case BUTTON_BOGO:
            case BUTTON_INSERTION:
            case BUTTON_EXIT:
                pressedButton = Buttons.valueOf(communicationSent.toString());
                communicationSent = Communication.COMMUNICATION_SEND_BUTTON;
                break;
        }
    }

    /**
     * A methode that sends a error message to a client.
     * @param message An error message to be sent to a client.
     */
    public void writeErrorLog(String message) {
        output.println("===ERROR===" + '\n' + message);
    }

    /**
     * A methode for sending a communication to a client.
     * @param message A message to be sent to a client.
     */
    public void sendCommunication(String message) {
        output.println(message);
    }

    /**
     * A getter for a communicationSent private field.
     * @return A type of a communication sent by a client.
     */
    public Communication getSentCommunication() {
        return communicationSent;
    }

    /**
     * A getter for a pressedButton private field.
     * @return A type of pressed button sent by a client.
     */
    public Buttons getSentButton() {
        return pressedButton;
    }

    /**
     * A getter for a isConnected private field.
     * @return true if a client is connected to the server; flase otherwise.
     */
    public boolean getIsConnected() {
        return isConnected;
    }

    /**
     * A methode for closeing the connection.
     * @throws IOException - can be thrwoing when closing input or socket.
     */
    @Override
    public void close() throws IOException {
        output.close();
        input.close();
        socket.close();
        isConnected = false;
    }
}
