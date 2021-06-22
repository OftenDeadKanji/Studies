/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.test;

import org.junit.*;
import static org.junit.Assert.*;
import pl.polsl.lab.model.sorter.BubbleSort;

/**
 * Testing the bubble sort method.
 * 
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class BubbleSortTest {

    private BubbleSort sorter;

    @Before
    public void setup() {
        sorter = new BubbleSort();
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
            sorter.sort(array, -2);
        } catch (IndexOutOfBoundsException exception) {
            fail("Passing negative index fails.");
        }
        
        try {
            sorter.sort(array, 0);
        } catch (NullPointerException exception) {
            fail("Passing arraty with null elements fails.");
        }

        array = new Integer[]{10, 9, 8, 7, 6, 7, 8, 9, 10, 0};

        if (sorter.sort(array, 0) != 1) {
            fail("Sorting unsorted array fails.");
        }
        if (sorter.sort(array, 9) != 0) {
           fail("Moving from the last element to the first fails.");
        }
        array = new Integer[]{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        if (sorter.sort(array, 0) != 1) {
           fail("Sorting sorted array fails.");
        }

    }
}
