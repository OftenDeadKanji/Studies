import java.util.*;
import java.util.stream.Stream;

/**
 * Streams
 *
 * @author Gall Anonim
 * @version 1.0
 */
public class Streams {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Stream<Integer> stream;

        //Using Stream.of(val1, val2, val3….)
        stream = Stream.of(1, 2, 3, 4, 5, 6, 7, 8, 9);
        stream.forEach(p -> System.out.print(p + ","));
        System.out.println();
        //stream.forEach(System.out::print);

        // Using Stream.of(arrayOfElements)
        stream = Stream.of(new Integer[]{1, 2, 3, 4, 5, 6, 7, 8, 9});
        stream.forEach(p -> System.out.print(p + ","));
        System.out.println();

        // Using someList.stream()
        List<Integer> list = new ArrayList<Integer>();
        for (int i = 1; i < 10; i++) {
            list.add(i);
        }
        stream = list.stream();
        stream.forEach(p -> System.out.print(p + ","));
        System.out.println();

     }

}
