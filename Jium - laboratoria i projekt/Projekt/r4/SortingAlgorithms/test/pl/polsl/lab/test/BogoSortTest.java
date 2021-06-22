/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.test;

import org.junit.*;
import static org.junit.Assert.*;
import pl.polsl.lab.model.sorter.BogoSort;

/**
 * Testing the bogo sort method.
 * 
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class BogoSortTest {

    private BogoSort sorter;

    @Before
    public void setup() {
        sorter = new BogoSort();
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
            sorter.sort(array, 0);
        } catch (NullPointerException exception) {
            fail("Passing array with null elements fails.");
        }

        array = new Integer[]{1, 3, 2, 5, 10, 7, 6, 4, 3, 1};

        //bogo sort should always return -1
        if (sorter.sort(array, 2) != -1) {
            fail("Method does not return -1");
        }
        if (sorter.sort(array, 12) != -1) {
            fail("Method does not return -1");
        }
        if (sorter.sort(array, -5) != -1) {
            fail("Method does not return -1");
        }
    }
}
