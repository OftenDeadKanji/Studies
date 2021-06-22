/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.model.sorter;

import java.util.List;
import static java.util.Objects.isNull;
import pl.polsl.lab.entities.Numbers;

/**
 * A Sorter derived class that sorts an array using bubble sort algorithm.
 *
 * @author Mateusz Chłopek
 * @version 1.1
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

        for (Numbers sortingArr : numbers) {
            if (isNull(sortingArr)) {
                return -1;
            }
        }

        //end of array
        if (index == numbers.size() - 1) {
            index = 0;
            return index;
        } else {
            //comparing
            Integer value1 = 0;
            Integer index1 = 0;
            Integer value2 = 0;
            Integer index2 = 0;
            for (int i = 0; i < numbers.size(); i++) {
                if (numbers.get(i).getIndex().equals(index)) {
                    value1 = numbers.get(i).getValue();
                    index1 = i;
                }
                if (numbers.get(i).getIndex().equals(index + 1)) {
                    value2 = numbers.get(i).getValue();
                    index2 = i;
                }
            }
            if (value1 > value2) {
                int tmp = numbers.get(index2).getIndex();
                numbers.get(index2).setIndex(numbers.get(index1).getIndex());
                numbers.get(index1).setIndex(tmp);

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

            }
            return index + 1;
        }
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
