import java.util.*;
import java.util.stream.Stream;

/**
 * Streams
 *
 * @author Gall Anonim
 * @version 1.0
 */
public class Operations {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {

        Stream.of(new Integer[]{1, 2, 3, 4, 5, 6, 7, 8, 9})
                .findFirst()
                .ifPresent(p -> System.out.println("1st = " + p));

        Arrays.stream(new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9})
                .average()
                .ifPresent(p -> System.out.println("avg = " + p));

        Arrays.stream(new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9})
                .max()
                .ifPresent(p -> System.out.println("max = " + p));

        Arrays.stream(new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9})
                .map(n -> 2 * n)
                .forEach(p -> System.out.print(p + ","));
        System.out.println();

        System.out.println("sum = " + Arrays.stream(new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9})
                .sum());

        
    }

}
