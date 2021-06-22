import java.util.*;
import java.util.stream.Collectors;

/**
 * Streams
 *
 * @author Gall Anonim
 * @version 1.0
 */
public class AdvancedOperations {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {

        List<Person> persons = Arrays.asList(
                new Person("Max", 18),
                new Person("Peter", 23),
                new Person("Pamela", 23),
                new Person("David", 12));

        // collecting
        List<Person> filtered = persons
                .stream()
                .filter(p -> p.name.startsWith("P"))
                .collect(Collectors.toList());
        System.out.println(filtered);    // [Peter, Pamela]

        // collecting by age
        Map<Integer, List<Person>> personsByAge = persons
                .stream()
                .collect(Collectors.groupingBy(p -> p.age));
        personsByAge
                .forEach((age, p) -> System.out.format("age %s: %s\n", age, p));

        // collecting and averaging by age
        Double averageAge = persons
                .stream()
                .collect(Collectors.averagingInt(p -> p.age));
        System.out.println("average age is " + averageAge);

        // collecting and joining
        String phrase = persons
                .stream()
                .filter(p -> p.age >= 18)
                .map(p -> p.name)
                .collect(Collectors.joining(" and ", "In Germany ", " are of legal age."));
        System.out.println(phrase);

        // statistics
        IntSummaryStatistics ageSummary = persons
                .stream()
                .collect(Collectors.summarizingInt(p -> p.age));
        System.out.println(ageSummary);

        // simple reducing
        persons
                .stream()
                .reduce((p1, p2) -> p1.age > p2.age ? p1 : p2)
                .ifPresent(System.out::println);    // Pamela

        // advanced reducing
        Person result = persons
                .stream()
                .reduce(new Person("", 0), (p1, p2) -> {
                    p1.age += p2.age;
                    p1.name += p2.name;
                    return p1;
                });
        System.out.format("name=%s; age=%s", result.name, result.age);
        // name=MaxPeterPamelaDavid; age=76

    }

}

class Person {

    String name;
    int age;

    Person(String name, int age) {
        this.name = name;
        this.age = age;
    }

    @Override
    public String toString() {
        return name;
    }
}
