
import java.util.Enumeration;

/**
 * Application presents values of the system properties.
 *
 * @author Gall Anonim
 * @version 1.0
 */
public class SystemProperties {

    /**
     * Main method of the application
     *
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        java.util.Properties systemProperties = System.getProperties();
        Enumeration propertiesNames = systemProperties.propertyNames();
        while (propertiesNames.hasMoreElements()) {
            String propertyName = (String) propertiesNames.nextElement();
            String propertyValue = (String) systemProperties.getProperty(propertyName);
            System.out.println(propertyName + " = " + propertyValue);
        }
    }
}
