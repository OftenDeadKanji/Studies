
import java.net.*;
import java.io.*;

/**
 * The main class of the server
 *
 * @author Gall Anonim
 * @version 1.2
 */
public class TCPServer implements Closeable {

    /**
     * port number
     */
    final private int PORT = 8888;

    /**
     * field represents the socket waiting for client connections
     */
    private final ServerSocket serverSocket;

    /**
     * Creates the server socket
     *
     * @throws IOException when prot is already bind
     */
    TCPServer() throws IOException {
        serverSocket = new ServerSocket(PORT);
    }

    /**
     * The main application method
     *
     * @param args
     * @params args all parametres are ignored
     */
    public static void main(String args[]) {

        try (TCPServer tcpServer = new TCPServer()) {
            System.out.println("Server started");
            while (true) {
                Socket socket = tcpServer.serverSocket.accept();
                new Thread(
                new Runnable() {
                    @Override
                    public void run() {
                        try {
                            SingleService singleService = new SingleService(socket);
                            singleService.realize();
                        } catch (IOException e) {
                            System.err.println(e.getMessage());
                        }
                    }
                }).start();

            }
        } catch (IOException e) {
            System.err.println(e.getMessage());
        }
    }

    @Override
    public void close() throws IOException {
        if (serverSocket != null) {
            serverSocket.close();
        }
    }
}

/**
 * The server class servicing a single connection
 */
class SingleService {// implements Closeable {

    /**
     * socket representing connection to the client
     */
    private final Socket socket;
    /**
     * buffered input character stream
     */
    private final BufferedReader input;
    /**
     * Formatted output character stream
     */
    private final PrintWriter output;

    /**
     * The constructor of instance of the SingleService class. Use the socket as
     * a parameter.
     *
     * @param socket socket representing connection to the client
     */
    public SingleService(Socket socket) throws IOException {
        this.socket = socket;
        output = new PrintWriter(
                new BufferedWriter(
                        new OutputStreamWriter(
                                socket.getOutputStream())), true);
        input = new BufferedReader(
                new InputStreamReader(
                        socket.getInputStream()));
    }

    /**
     * Realizes the service
     */
    public void realize() {
        try {
            output.println("Welcome to Java Server");

            while (true) {
                String str = input.readLine();
                output.println("Server answers: " + str);
                if (str.toUpperCase().equals("QUIT")) {
                    break;
                }
                System.out.println("Client sent: " + str);
            }
            System.out.println("closing...");
        } catch (IOException e) {
            System.err.println(e.getMessage());
        } finally {
            try {
                socket.close();
            } catch (IOException e) {
                System.err.println(e.getMessage());
            }
        }
    }

//    @Override
//    public void close() throws IOException {
//        if (socket != null) {
//            socket.close();
//        }
//    }
}
