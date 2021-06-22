/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.model.sorter;

import static java.util.Objects.isNull;

/**
 * A Sorter derived class that sorts an array using bubble sort algorithm.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class BubbleSort extends Sorter {

    /**
     * A method that sorts the array using bubble sort. It compares two elements
     * and replaces them if needed.
     *
     * @param sortingArray array to be sorted
     * @param index a starting index
     * @return an index at which it ended an a part of algorithm
     */
    @Override
    public Integer sort(Integer[] sortingArray, Integer index) {
        if (isNull(sortingArray) || isNull(index)) {
            return -1;
        }

        if (index > sortingArray.length || index < 0) {
            return 0;
        }

        for (Integer sortingArr : sortingArray) {
            if (isNull(sortingArr)) {
                return -1;
            }
        }

        //end of array
        if (index == sortingArray.length - 1) {
            index = 0;
            return index;
        } else {
            //comparing
            if (sortingArray[index] > sortingArray[index + 1]) {
                int tmp = sortingArray[index + 1];
                sortingArray[index + 1] = sortingArray[index];
                sortingArray[index] = tmp;
            }
            return index + 1;
        }
    }
}
