import java.io.*;

/**
 * The example shows the usage of the File class. The one parameter (file name
 * or directory name) is needed
 *
 * @author Gall Anonim
 * @version 1.2
 */
public class FileDemo {

    /**
     * The main method of the application
     *
     * @param args the name of the file system element (file or directory)
     */
    public static void main(String args[]) {

        if (args.length != 1) {
            System.err.println("Give a file name or directory name!");
            return;
        }
        String name = args[0];
        File file = new File(name);

        if (!file.exists()) {
            System.err.println(name + " does't exist!");
            return;
        }

        if (file.isFile()) {
            if (!file.canRead()) {
                System.err.println(name + " can't be read!");
                return;
            } else {
                try (FileInputStream in = new FileInputStream(name)) {
                    byte buffer[] = new byte[1024];
                    while (true) {
                        int byteCount = in.read(buffer);
                        if (byteCount == -1) 
                            break;
                        System.out.write(buffer, 0, byteCount);
                    }
                } catch (IOException e) {
                    System.err.println(e.getMessage());
                    return;
                }
            }
        } else // directory
        {
            System.out.println(name + " includes: ");
            // List of directory elements    

            for (String element: file.list()) {
                System.out.print(element);
                File dir = new File(name + "\\" + element);
                if (dir.isDirectory()) 
                    System.out.print("\t is a direcory");
                System.out.println();
            }
        }
    }
}
