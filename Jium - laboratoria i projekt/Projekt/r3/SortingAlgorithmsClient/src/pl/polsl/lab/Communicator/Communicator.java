/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.Communicator;

import java.io.*;
import java.net.*;
import pl.polsl.lab.Buttons;

/**
 * A class that is responsible for communicating with the server.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class Communicator {

    /**
     * A sorting array that can be received from server.
     */
    private final int[] receivedArray;

    /**
     * A current index of sorting arrat that can be received from server.
     */
    private int receivedIndex;

    /**
     * A variable that consists of a help message that is received from server
     * if there was a command line argument -h.
     */
    private String helpMessage;

    /**
     * A socket that is creating from a client class socket.
     */
    private final Socket socket;

    /**
     * Buffered input character stream.
     */
    private final BufferedReader input;

    /**
     * Formatted output character stream
     */
    private final PrintWriter output;
    
    /**
     * A variable that consists of an error message received from server.
     */
    private String errorMessage;
    
    /**
     * A variable that informs if an error message has been received.
     */
    private boolean gotErrorMessage;

    /**
     * A class constructor that creates socket, input and output streams.
     *
     * @param clientSocket - a socket required for communication.
     * @throws IOException - can be thrown during streams creation.
     */
    public Communicator(Socket clientSocket) throws IOException {
        this.socket = clientSocket;

        output = new PrintWriter(
                new BufferedWriter(
                        new OutputStreamWriter(
                                socket.getOutputStream())), true);
        input = new BufferedReader(
                new InputStreamReader(
                        socket.getInputStream()));

        receivedIndex = -1;
        receivedArray = new int[20];
        helpMessage = "";
        errorMessage = "";
        gotErrorMessage = false;
    }

    /**
     * A method that check the current server mode (menu or sorting).
     *
     * @return 1 - menu; 2 - sorting
     * @throws IOException - can be thrown when reading from input
     */
    public int checkMode() throws IOException {
        if (!socket.isConnected()) {
            return 0;
        }

        //a correct protocole for getting current mode
        output.println("STARTM");
        output.println("GET");
        output.println("MODE");
        output.println("ENDM");

        //confirmation
        String inOk = input.readLine();
        if(inOk.contains("ERROR")){
            gotErrorMessage = true;
            errorMessage = inOk;
        }
        while (!inOk.equalsIgnoreCase("1 OK")) {
            if(inOk.contains("ERROR")){
            gotErrorMessage = true;
            errorMessage = inOk;
        }
            inOk = input.readLine();
        }

        String inCorrect = input.readLine();
        while (!inCorrect.equalsIgnoreCase("FROM SERVER: correct protocol received, processing...")) {
            inCorrect = input.readLine();
        }

        //current mode
        String inMode = input.readLine();
        while (inMode.equalsIgnoreCase(inCorrect)) {
            inMode = input.readLine();
        }

        return Integer.parseInt(inMode);
    }

    /**
     * A methode invoked when there was a command line argument -h - request for
     * help.
     *
     * @throws IOException - can be thrown when reading from input.
     */
    public void sendArgumentHelp() throws IOException {
        output.println("STARTM");
        output.println("SEND");
        output.println("HELP");
        output.println("ENDM");

        //confirmation
        String inOk = input.readLine();
        if(inOk.contains("ERROR")){
            gotErrorMessage = true;
            errorMessage = inOk;
        }
        while (!inOk.equalsIgnoreCase("1 OK")) {
            if(inOk.contains("ERROR")){
            gotErrorMessage = true;
            errorMessage = inOk;
        }
            inOk = input.readLine();
        }

        String inCorrect = input.readLine();
        while (!inCorrect.equalsIgnoreCase("FROM SERVER: correct protocol received, processing...")) {
            inCorrect = input.readLine();
        }

        helpMessage = input.readLine();
        while (helpMessage.equalsIgnoreCase(inCorrect)) {
            helpMessage = input.readLine();
        }

    }

    /**
     * A getter for help message received from server.
     *
     * @return A variable that consists of help message.
     */
    public String getHelpMessage() {
        return helpMessage;
    }

    /**
     * A getter for sorting array received from server.
     *
     * @return A sorting array.
     */
    public int[] getArray() {
        return receivedArray;
    }

    /**
     * A getter for a current index of sorting array received from server.
     *
     * @return A current index.
     */
    public int getIndex() {

        return receivedIndex;
    }
    
    /**
     * A methode that informs if server sent an error message.
     * @return true if there is a error message; false otherwise
     */
    public boolean getIfError(){
        return gotErrorMessage;
    }
    
    public String getErrorMessage(){
        return errorMessage;
    }

    /**
     * A methode that asks server for an inner model - array and index.
     *
     * @throws IOException - can be thrown when reading from input.
     */
    public void askServerForModel() throws IOException {
        if (!socket.isConnected()) {
            return;
        }

        output.println("STARTM");
        output.println("GET");
        output.println("MODEL_AND_INDEX");
        output.println("ENDM");

        //confirmation
        String inOk = input.readLine();
        if(inOk.contains("ERROR")){
            gotErrorMessage = true;
            errorMessage = inOk;
        }
        while (!inOk.equalsIgnoreCase("1 OK")) {
        if(inOk.contains("ERROR")){
            gotErrorMessage = true;
            errorMessage = inOk;
        }
            inOk = input.readLine();
        }

        String inCorrect = input.readLine();
        while (!inCorrect.equalsIgnoreCase("FROM SERVER: correct protocol received, processing...")) {
            inCorrect = input.readLine();
        }

        //index
        String inIndex = input.readLine();
        while (inIndex.equals(inCorrect)) {
            inIndex = input.readLine();
        }
        receivedIndex = Integer.parseInt(inIndex);

        //array
        String inArray = input.readLine();
        while (inArray.equals(inIndex)) {
            inArray = input.readLine();
        }
        String[] array = inArray.split(",");

        for (int i = 0; i < receivedArray.length; i++) {
            receivedArray[i] = Integer.parseInt(array[i]);
        }

    }

    /**
     * A methode that sends a communication about pressed button.
     *
     * @param pressedButton - a pressed button type.
     * @throws IOException - can be thrown when reading from input.
     */
    public void sendButton(Buttons pressedButton) throws IOException {
        String out = "";
        switch (pressedButton) {
            case NONE:
                out = "PRESSED_BUTTON_NONE";
                break;
            case BUTTON_SELECT:
                out = "PRESSED_BUTTON_SELECT";
                break;
            case BUTTON_BUBBLE:
                out = "PRESSED_BUTTON_BUBBLE";
                break;
            case BUTTON_BOGO:
                out = "PRESSED_BUTTON_BOGO";
                break;
            case BUTTON_INSERTION:
                out = "PRESSED_BUTTON_INSERTION";
                break;
            case BUTTON_EXIT:
                out = "PRESSED_BUTTON_EXIT";
                break;
        }

        output.println("STARTM");
        output.println("SEND");
        output.println(out);
        output.println("ENDM");

        //confirmation
        String inOk = input.readLine();
        if(inOk.contains("ERROR")){
            gotErrorMessage = true;
            errorMessage = inOk;
        }
        while (!inOk.equalsIgnoreCase("1 OK")) {
        if(inOk.contains("ERROR")){
            gotErrorMessage = true;
            errorMessage = inOk;
        }
            inOk = input.readLine();
        }

        String inCorrect = input.readLine();
        while (!inCorrect.equalsIgnoreCase("FROM SERVER: correct protocol received, processing...")) {
            inCorrect = input.readLine();
        }
    }

    /**
     * A methode that send a QUIT command.
     *
     * @throws IOException - can be thrown when reading from input.
     */
    public void sendQuit() throws IOException {
        if (!socket.isConnected()) {
            return;
        }
        output.println("QUIT");

        //confirmation
        String inOk = input.readLine();
        if(inOk.contains("ERROR")){
            gotErrorMessage = true;
            errorMessage = inOk;
        }
        while (!inOk.equalsIgnoreCase("1 OK")) {
        if(inOk.contains("ERROR")){
            gotErrorMessage = true;
            errorMessage = inOk;
        }
            inOk = input.readLine();
        }
    }
}
