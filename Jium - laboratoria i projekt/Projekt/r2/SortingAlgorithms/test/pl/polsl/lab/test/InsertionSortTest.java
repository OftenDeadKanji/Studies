/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.test;

import org.junit.*;
import static org.junit.Assert.*;
import pl.polsl.lab.model.sorter.InsertionSort;

/**
 * Testing the insertion sort method.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class InsertionSortTest {

    private InsertionSort sorter;

    @Before
    public void setup() {
        sorter = new InsertionSort();
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

        array = new Integer[]{10, 9, 8, 7, 6, 7, 8, 9, 10, 0};

        if (sorter.sort(array, 0) != 1) {
            fail("Sorting begining fails.");
        }

        if (sorter.sort(array, 1) != 0 || sorter.sort(array, 0) != 0 || sorter.sort(array, 0) != 2) {
            fail("Sorting while inserting fails.");
        }
    }
}
