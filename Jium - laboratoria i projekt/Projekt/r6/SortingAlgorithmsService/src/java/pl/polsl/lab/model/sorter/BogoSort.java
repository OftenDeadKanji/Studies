/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.model.sorter;

import java.util.ArrayList;
import java.util.Arrays;
import static java.util.Collections.shuffle;
import java.util.List;
import pl.polsl.lab.entities.Numbers;
import static java.util.Objects.isNull;

/**
 * A Sorter derived class that sorts an array using bogo sort algorithm.
 *
 * @author Mateusz Chłopek
 * @version 1.2
 */
public class BogoSort extends Sorter {

    /**
     * A method that sorts the array using bogo sort. It creates new (random)
     * order of values in the array.
     *
     * @param sortingArray array to be sorted
     * @param index a starting index (not used in this algorithm)
     * @return -1 - index is not used in this algorithm
     */
    @Override
    public Integer sort(Integer[] sortingArray, Integer index) {

        if (isNull(sortingArray)) {
            return -1;
        }

        List<Integer> sortingList = new ArrayList<>();
        sortingList.addAll(Arrays.asList(sortingArray));
        shuffle(sortingList);

        for (int i = 0; i < sortingArray.length; i++) {
            sortingArray[i] = sortingList.get(i);
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

        List<Integer> indexes = new ArrayList<>();

        for (int i = 0; i < numbers.size(); i++) {
            indexes.add(numbers.get(i).getIndex());
        }
        shuffle(indexes);

        for (int i = 0; i < numbers.size(); i++) {
            numbers.get(i).setIndex(indexes.get(i));
        }

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
