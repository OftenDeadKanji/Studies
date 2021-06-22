/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.test;

import java.util.ArrayList;
import java.util.List;
import org.junit.*;
import static org.junit.Assert.*;
import pl.polsl.lab.entities.Numbers;
import pl.polsl.lab.entities.SortingTables;
import pl.polsl.lab.model.sorter.InsertionSort;

/**
 * Testing the insertion sort method.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class InsertionSortTest {

    private InsertionSort sorter;
    private SortingTables array;
    private List<Numbers> numbers;

    @Before
    public void setup() {
        sorter = new InsertionSort();

        array = new SortingTables(5, "INSERTION");

        numbers = new ArrayList<>();

        numbers.add(new Numbers(1, array, 0));
        numbers.add(new Numbers(2, array, 1));
        numbers.add(new Numbers(3, array, 2));
        numbers.add(new Numbers(4, array, 3));
        numbers.add(new Numbers(3, array, 4));
        numbers.add(new Numbers(3, array, 5));
    }

    @Test
    public void sortTest() {
        try {
            sorter.sort(null, null);
        } catch (NullPointerException exception) {
            fail("Passing null as parameters in sort fails.");
        }

        Integer[] array = new Integer[10];
        try {
            sorter.sort(array, 11);
        } catch (IndexOutOfBoundsException exception) {
            fail("Passing index greater than array's size fails.");
        }

        try {
            sorter.sort(array, 0);
        } catch (NullPointerException exception) {
            fail("Passing array with null elements fails.");
        }
    }

    @Test
    public void sortNumbersTest() {
        try {
            sorter.sortNumbers(null, null);
        } catch (NullPointerException exception) {
            fail("Passing null as parameters in sort fails.");
        }
        
        List<Numbers> numbersNull = new ArrayList<>();
        try {
            sorter.sortNumbers(numbersNull, 0);
        } catch (NullPointerException exception) {
            fail("Passing array with null elements fails.");
        }
        
        try {
            sorter.sortNumbers(numbers, 11);
        } catch (IndexOutOfBoundsException exception) {
            fail("Passing index greater than array's size fails.");
        }
    }
}
