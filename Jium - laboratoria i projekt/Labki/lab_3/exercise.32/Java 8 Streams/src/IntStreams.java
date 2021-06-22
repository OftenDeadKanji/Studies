import java.util.stream.*;

/**
 * IntStreams
 *
 * @author Gall Anonim
 * @version 1.0
 */
public class IntStreams {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {

        // range
        IntStream.range(1, 10)
                .forEach(p -> System.out.print(p + ","));
        System.out.println();

        // string chars
        IntStream intStream = "12345_abcdefg".chars();
        intStream.forEach(p -> System.out.print(p + ","));
        System.out.println();

        // String tokens
        Stream<String> stringStream = Stream.of("1$2$3$4$5$6$7$8$9".split("\\$"));
        stringStream.forEach(p -> System.out.print(p + ","));
        System.out.println();

        // mapping to objects (strings)
        IntStream.range(1, 10)
                .mapToObj(i -> "a" + i + ",")
                .forEach(System.out::print);
        System.out.println();
       
        // double mapping: to int, to objects (strings) 
        Stream.of(1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0)
                .mapToInt(Double::intValue)
                .mapToObj(i -> "a" + i + ",")
                .forEach(System.out::print);
        System.out.println();
    }

}
