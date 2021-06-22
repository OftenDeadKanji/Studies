import java.net.*;
import java.io.*;

/** 
 * The main UDP client class 
 * 
 * @author Gall Anonim
 * @version 1.2
 */
public class ChatterClient extends Thread {

    /** communication socket */
    private DatagramSocket datagramSocket;
    /** server port number  */
    static final int PORT = 1711;
    /** server address */
    private InetAddress hostAddress;
    /** buffer for input data */
    private byte[] buf = new byte[1024];
    /** data frame */
    private DatagramPacket dp = new DatagramPacket(buf, buf.length);
    /** a client id */
    private int id;

    /** 
     * The constructor of the UDP client object
     * @param id client identifier
     */
    public ChatterClient(int id) {
        this.id = id;
        try {
            datagramSocket = new DatagramSocket();
            hostAddress = InetAddress.getByName("localhost");
        } catch (UnknownHostException e) {
            System.err.println("Unknown server!");
        } catch (SocketException e) {
            System.err.println("Connection is not available!");
        }
        System.out.println("Client " + id + " started");
    }

    /** 
     * 
     */
    @Override
    public void run() {
        try {
            // 25 data frames are sent to the UDP server
            for (int i = 0; i < 25; i++) {
                String outMessage = "Client #" + id + ", message #" + i;
                buf = outMessage.getBytes();
                datagramSocket.send(new DatagramPacket(buf, buf.length, hostAddress, PORT));
                datagramSocket.receive(dp);

                String rcvd = "Client #" + id + ", rcvd from "
                        + dp.getAddress() + ", "
                        + dp.getPort() + ": "
                        + new String(dp.getData(), 0, dp.getLength());

                System.out.println(rcvd);
            }
        } catch (IOException e) {
            System.err.println("Error during communication!");
        }
    }

    /** 
     * The main application method 
     * @param args
     */
    public static void main(String[] args) {
        // creates 5 clients for a simulation
        for (int i = 0; i < 5; i++) {
            new ChatterClient(i).start();
        }
    }
}
