
import java.io.*;
import java.net.*;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
/**
 *
 * @author Student
 */
public class TCPClient {

    final private int PORT = 8888;

    private BufferedReader inFromUser;
    private DataOutputStream outToServer;
    private BufferedReader inFromServer;

    /**
     * socket representing connection to the client
     */
    private final Socket clientSocket;
    /**
     * buffered input character stream
     */
    private final BufferedReader input;
    /**
     * Formatted output character stream
     */
    private final PrintWriter output;

    public TCPClient() throws IOException {
        clientSocket = new Socket("localhost", PORT);
        output = new PrintWriter(
                new BufferedWriter(
                        new OutputStreamWriter(
                                clientSocket.getOutputStream())), true);
        input = new BufferedReader(
                new InputStreamReader(
                        clientSocket.getInputStream()));

        inFromUser = new BufferedReader(new InputStreamReader(System.in));
//        outToServer = new DataOutputStream(clientSocket.getOutputStream());
//        inFromServer = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));

        output.println("Connecting.");

        while (true) {
            System.out.println("FROM SERVER: " + input.readLine());

            String sentence = inFromUser.readLine();

            output.println(sentence);
        }

    }

    public static void main(String args[]) throws IOException {
        TCPClient tcpClient = new TCPClient();
    }
}
