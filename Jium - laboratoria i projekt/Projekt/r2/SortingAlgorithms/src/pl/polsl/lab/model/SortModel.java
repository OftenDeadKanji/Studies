/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.model;

import java.util.Arrays;
import pl.polsl.lab.model.sorter.*;
import java.util.Random;
import pl.polsl.lab.Commands;
import pl.polsl.lab.exception.OutOfSupposedRangeException;

/**
 * A Menu derived class that represents model during array sorting.
 * 
 * @author Mateusz Chłopek
 * @version 1.1
 */
public class SortModel extends Model {

    /**
     * An Integer array that is being sorted.
     */
    private Integer[] array;
    /**
     * A current index of the array.
     */
    private Integer index;
    /**
     * A variable that informs whether array is sorted (true) or not (false).
     */
    private boolean isSorted;
    /**
     * Currently chosen sorting algorithm.
     */
    private Sorter sorter;
    /**
     * A variable that determines an interval between each model's update.
     */
    private final int interval;

    /**
     * A class constructor.
     *
     * @param command An enum that represents which sorting algorithm has been
     * chosen.
     */
    public SortModel(Commands command) {
        changeMode = false;
        array = new Integer[20];
        index = 0;
        isSorted = false;
        interval = 200;

        // creating array with random values in range of 1 - 21
        for (int i = 0; i < array.length; i++) {
            array[i] = new Random().nextInt(array.length) + 1;
        }

        // creating an object that refers to chosen sorting algorithm
        switch (command) {
            case COMMAND_START_BUBBLE:
                sorter = new BubbleSort();
                break;
            case COMMAND_START_BOGO:
                sorter = new BogoSort();
                break;
            case COMMAND_START_INSERTION:
                sorter = new InsertionSort();
                break;
        }
    }

    /**
     * A primary method where model changes the program's inner structure.
     * 
     * @throws OutOfSupposedRangeException exception describing a variable's 
     * value that is out of supposed range.
     */
    @Override
    protected void update() throws OutOfSupposedRangeException {
        switch (command) {
            case COMMAND_STOP:
                changeMode = true;
                break;
            case COMMAND_CONTINUE:
                if (!isSorted) {
                    index = sorter.sort(array, index);
                    isSorted = isFinished();
                    if (isSorted) {
                        index = -2;
                    }
                }
                try {
                    Thread.sleep(interval);
                } catch (InterruptedException e) {}
                break;
            default:
                throw new OutOfSupposedRangeException("SortModel: command out"
                        + "of range in update methode.");
        }
    }

    /**
     * A method that checks if array has been sorted.
     *
     * @return true when is sorted, false otherwise.
     */
    private boolean isFinished() {
        for (int i = 0; i < array.length - 1; i++) {
            if (array[i] > array[i + 1]) {
                return false;
            }
        }
        return true;
    }

    /**
     * A getter that gives access to the sorted array.
     *
     * @return an integers array that is being sorted.
     */
    @Override
    public int[] getInnerModel() {
        return Arrays.stream(array).mapToInt(Integer::intValue).toArray();
    }

    /**
     * A getter that gives access to a current index.
     *
     * @return -2 when array has been sorted, -1 when currently there's no
     * selected element, any other - current array index
     */
    @Override
    public int getIndex() {
        return index;
    }
}
