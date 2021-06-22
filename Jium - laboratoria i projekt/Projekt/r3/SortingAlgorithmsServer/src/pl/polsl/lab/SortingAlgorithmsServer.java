/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab;

import java.io.*;
import java.net.ServerSocket;
import java.util.Properties;
import pl.polsl.lab.controller.*;
import pl.polsl.lab.communicator.Communicator;

/**
 * A main class that creates server for a Sorting Algorithms project.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class SortingAlgorithmsServer {

    /**
     * A variable representing port that is read from .properties file.
     */
    private final int PORT;

    /**
     * A server socket.
     */
    private final ServerSocket serverSocket;

    /**
     * A class constructor. It reads a PORT from .properties file and creates a
     * server with 500ms connection timeout.
     *
     * @throws IOException - exception that can be thrown by file reading.
     */
    public SortingAlgorithmsServer() throws IOException {

        Properties properties = new Properties();
        properties.setProperty("PORT", "8888");

        FileInputStream in = new FileInputStream(".properties");
        properties.load(in);
        PORT = Integer.parseInt(properties.getProperty("PORT"));

        serverSocket = new ServerSocket(PORT);
        serverSocket.setSoTimeout(500);
    }

    /**
     * A getter to the clientSocket private field.
     *
     * @return a clientSocket variable
     */
    public ServerSocket getSocket() {
        return serverSocket;
    }

    /**
     * A main method. The most important is a server object that is created
     * here.
     *
     * @param args the command line arguments, available: -h to get a short
     * message.
     */
    public static void main(String[] args) {
        if (args.length > 0 && args[0].equalsIgnoreCase("-h")) {
            System.out.println("Welcome to Sorting Algorithms program. All things that you can do is by inteacting with GUI - buttons and combo box. ");
        }
        try {
            //creating a server
            SortingAlgorithmsServer server = new SortingAlgorithmsServer();
            System.out.println("Server started.");

            try (Communicator communicator = new Communicator(server.getSocket())) {
                Controller controller = new MenuController(communicator);
                //main program loop
                while (true) {
                    controller.run();
                    if (!controller.getRun()) {
                        break;
                    }
                    //menu -> sorting
                    if (controller.getMode() == 1) {
                        controller = new SortController(communicator, controller.getCommand());
                    } //sorting -> menu
                    else {
                        controller = new MenuController(communicator);
                    }
                }
            } catch (IOException exception) {
                System.err.println(exception.getMessage());
            }
        } catch (IOException exception) {
            System.err.println(exception.getMessage());
        }
    }
}
