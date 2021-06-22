import java.net.*;
import java.io.*;

/** 
 * The main class of the UDP server
 * 
 * @author Gall Anonim
 * @version 1.2
 */
public class ChatterServer {

    /** accessing port */
    static final int PORT = 1711;
    /** buffer for input data */
    private byte[] buf = new byte[1024];
    /** data frame */
    private DatagramPacket datagramPacket = new DatagramPacket(buf, buf.length);
    /** communication socket */
    private DatagramSocket socket;

    /** 
     * The UDP server constructor 
     */
    public ChatterServer() {
        try {
            socket = new DatagramSocket(PORT);
            System.out.println("Server started");
            while (true) {
                socket.receive(datagramPacket);
                String rcvd = new String(datagramPacket.getData(), 0, datagramPacket.getLength())
                        + ", from address: " + datagramPacket.getAddress()
                        + ", port: " + datagramPacket.getPort();
                System.out.println(rcvd);

                String echoString = "Echoed: " + rcvd;

                buf = echoString.getBytes();
                DatagramPacket echo = new DatagramPacket(buf, buf.length,
                        datagramPacket.getAddress(), datagramPacket.getPort());
                socket.send(echo);
            }
        } catch (SocketException e) {
            System.err.println("Connection is not available!");
            System.exit(1);
        } catch (IOException e) {
            System.err.println("Error during connection!");
            e.printStackTrace();
        }
    }

    /** 
     * The main application method 
     */
    public static void main(String[] args) {
        new ChatterServer();
    }
}
