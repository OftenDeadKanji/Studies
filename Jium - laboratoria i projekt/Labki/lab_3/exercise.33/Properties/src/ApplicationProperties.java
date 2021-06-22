import java.io.*;
import java.util.*;

/**
 * Application presents how to use application properties.
 *
 * @author Gall Anonim
 * @version 1.0
 */
public class ApplicationProperties {

    /**
     * Main method of the application
     *
     * @param args the command line arguments
     */
    public static void main(String[] args) {

        /* initialization */
        Properties properties = new Properties();
        properties.setProperty("login", "duke");
        properties.setProperty("pass", "java");

        /* writing properties */
        try (FileOutputStream out = new FileOutputStream(".properties")) {
            properties.store(out, "--Konfiguracja--");
        } catch (IOException e) {
            System.err.println(e.getMessage());
        }

        /* writing properties into xml file*/
        try (FileOutputStream out = new FileOutputStream("app.xml")) {
            properties.storeToXML(out, "--Konfiguracja--");
        } catch (IOException e) {
            System.err.println(e.getMessage());
        }

        /* reading properties */
        try (FileInputStream in = new FileInputStream(".properties")) {
            properties.load(in);
            System.out.println("\n.property");
            System.out.println("login=" + properties.getProperty("login"));
            System.out.println("pass=" + properties.getProperty("pass"));
            System.out.println("no property=" + properties.getProperty("no property"));            
            System.out.println("no property=" + properties.getProperty("no property","no value"));            
        } catch (IOException e) {
            System.err.println(e.getMessage());
        }

        /* reading properties from xml file*/
        try (FileInputStream in = new FileInputStream("app.xml")) {
            properties.loadFromXML(in);
            System.out.println("\n.app.xml");
            System.out.println("login=" + properties.getProperty("login"));
            System.out.println("pass=" + properties.getProperty("pass"));
        } catch (IOException e) {
            System.err.println(e.getMessage());
        }

    }
}
