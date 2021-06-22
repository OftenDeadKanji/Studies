/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.model.sorter;

import static java.util.Objects.isNull;

/**
 * A Sorter derived class that sorts an array using insertion sort algorithm.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class InsertionSort extends Sorter {

    /**
     * A variable that informs if currently an element is being inserted or not.
     */
    private boolean inserting;
    /**
     * a variable that informs of the szie of the already sorted part of the array.
     */
    private int sortedArraySize;

    /**
     * A class constructor.
     */
    public InsertionSort() {
        this.inserting = false;
        this.sortedArraySize = 1;
    }

    /**
     * A method that sorts the array using insertion sort. It inserts an element into alredy sorted array that is a part of the whole array.
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
        //if (index > sortedArraySize)
            //return sortedArraySize;
        
        if (inserting) {
            //finding right place
            if (index > 0 && sortingArray[index] < sortingArray[index - 1]) {
                Integer tmp = sortingArray[index];
                sortingArray[index] = sortingArray[index - 1];
                sortingArray[index - 1] = tmp;
                return --index;
                //place found
            } else {
                inserting = false;
                sortedArraySize++;
                return index;
            }
        } else if (index < sortedArraySize) {
            index = sortedArraySize;
            inserting = true;
            return index;
        }

        return -1;
    }
}
