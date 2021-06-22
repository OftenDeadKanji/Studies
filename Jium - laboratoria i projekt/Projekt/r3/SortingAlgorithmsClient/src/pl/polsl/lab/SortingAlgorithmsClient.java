/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab;

import java.io.FileInputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.Properties;
import pl.polsl.lab.Communicator.Communicator;
import pl.polsl.lab.view.*;

/**
 * Main class for client of SortingAlgorithms project.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class SortingAlgorithmsClient {

    /**
     * A variable representing port that is read from .properties file.
     */
    private final int PORT;
    /**
     * A variable representing server addr that is read from .properties file.
     */
    private final String server;

    /**
     * A socket that represents connection to the client.
     */
    private final Socket clientSocket;

    /**
     * A class constructor. It reads PORT number and server addr from a file and
     * connects to the server.
     *
     * @throws IOException - exception that can be thrown by file reading.
     */
    public SortingAlgorithmsClient() throws IOException {
        Properties properties = new Properties();
        FileInputStream in = new FileInputStream(".properties");
        properties.load(in);
        PORT = Integer.parseInt(properties.getProperty("PORT"));
        server = properties.getProperty("server");

        clientSocket = new Socket(server, PORT);
    }

    /**
     * A getter to the clientSocket private field.
     *
     * @return a clientSocket variable
     */
    public Socket getSocket() {
        return clientSocket;
    }

    /**
     * A main mathod. The most important is a client object that is created
     * here.
     *
     * @param args the command line arguments, available: -h to get help
     * messagebox.
     */
    public static void main(String[] args) {
        try {
            //creating a client
            SortingAlgorithmsClient client = new SortingAlgorithmsClient();
            try {
                Communicator communicator = new Communicator(client.getSocket());
                View view;

                //getting a current mode from server
                int mode = communicator.checkMode();

                if (mode == 1) { //menu
                    view = new MenuView();
                } else { //sorting
                    communicator.askServerForModel();
                    view = new SortView(communicator.getArray());
                }

                if (args.length > 0 && args[0].equalsIgnoreCase("-h")) {
                    communicator.sendArgumentHelp();
                    view.showMessageBox(communicator.getHelpMessage());
                }

                while (true) {
                    if (mode == 2) { //setting rectangles is needed only while sorting
                        communicator.askServerForModel();
                        view.setDrawable(communicator.getArray(), communicator.getIndex());
                    }
                    view.draw();
                    if (communicator.getIfError()) {
                        view.showMessageBox(communicator.getErrorMessage());
                    }

                    //checking if a user has closed a program
                    if ((view.getPressedButtonType() == Buttons.BUTTON_EXIT && mode == 1) || view.getIsFrameClosed()) {
                        communicator.sendQuit();
                        if (communicator.getIfError()) {
                            view.showMessageBox(communicator.getErrorMessage());
                        }
                        break;
                    }
                    //sending pressed button type
                    communicator.sendButton(view.getPressedButtonType());
                    if (communicator.getIfError()) {
                        view.showMessageBox(communicator.getErrorMessage());
                    }

                    //checking if mode has changed
                    int newMode = communicator.checkMode();
                    if (newMode == 0) { //closng program
                        view.delete();
                        break;
                    }
                    if (mode != newMode) {
                        view.delete();
                        if (mode == 1) { //menu -> sorting
                            communicator.askServerForModel();
                            view = new SortView(communicator.getArray());
                            mode = 2;
                        } else if (mode == 2) { //sorting -> menu
                            mode = 1;
                            view = new MenuView();
                        }
                    }
                }
                view.delete();
            } catch (IOException exception) {
                System.err.println(exception.getMessage());
            }
        } catch (IOException exception) {
            System.err.println(exception.getMessage());
        }
    }
}
