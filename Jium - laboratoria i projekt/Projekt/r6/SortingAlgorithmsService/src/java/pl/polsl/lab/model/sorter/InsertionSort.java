/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.model.sorter;

import static java.lang.Math.abs;
import java.util.List;
import java.util.Objects;
import static java.util.Objects.isNull;
import pl.polsl.lab.entities.Numbers;

/**
 * A Sorter derived class that sorts an array using insertion sort algorithm.
 *
 * @author Mateusz Chłopek
 * @version 1.1
 */
public class InsertionSort extends Sorter {

    /**
     * A variable that informs if currently an element is being inserted or not.
     */
    private boolean inserting;
    /**
     * a variable that informs of the szie of the already sorted part of the
     * array.
     */
    private int sortedArraySize;

    /**
     * A class constructor.
     */
    public InsertionSort() {
        //this.inserting = false;
        //this.sortedArraySize = 1;
    }

    /**
     * A method that sorts the array using insertion sort. It inserts an element
     * into alredy sorted array that is a part of the whole array.
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
        inserting = state == 2;

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

    /**
     * A method that sorts the List using bogo sort. It creates new (random)
     * order of values in the List..
     *
     * @param numbers List of Numbers to be sorted
     * @param index a starting index (not used in this algorithm)
     * @return -1 - index is not used in this algorithm
     */
    @Override
    public Integer sortNumbers(List<Numbers> numbers, Integer index) {
        if (isNull(numbers) || isNull(index)) {
            return -1;
        }

        if (index > numbers.size() || index < 0) {
            return 0;
        }

        for (Numbers numb : numbers) {
            if (isNull(numb)) {
                return -1;
            }
        }

        inserting = state < 0;
        sortedArraySize = abs(state);

        int value1 = 0, value2 = 0, index1 = 0, index2 = 0;

        if (inserting) {
            for (int i = 0; i < numbers.size(); i++) {
                if (Objects.equals(numbers.get(i).getIndex(), index)) {
                    index1 = i;
                    value1 = numbers.get(i).getValue();
                }
                if (Objects.equals(numbers.get(i).getIndex(), index - 1)) {
                    index2 = i;
                    value2 = numbers.get(i).getValue();
                }
            }
            //finding right place
            if (index > 0 && value1 < value2) {
                Integer tmp = numbers.get(index1).getIndex();
                numbers.get(index1).setIndex(numbers.get(index2).getIndex());
                numbers.get(index2).setIndex(tmp);

                int[] sortCheckArray = new int[numbers.size()];
                numbers.forEach((numb) -> {
                    sortCheckArray[numb.getIndex()] = numb.getValue();
                });

                int tmpState = 0;
                for (int i = 1; i < sortCheckArray.length; i++) {
                    if (sortCheckArray[i - 1] > sortCheckArray[i]) {
                        tmpState = this.state;
                    }
                }
                this.state = tmpState;

                return --index;
                //place found
            } else {
                state = abs(state) + 1;
                return index;
            }
        } else if (index < sortedArraySize) {
            index = sortedArraySize;
            state = abs(state) * -1;
            return index;
        }

        return -1;
    }

    /**
     * A setter for a state of sorter.
     *
     * @param state A current state.
     */
    @Override
    public void setState(int state) {
        this.state = state;
    }
}
