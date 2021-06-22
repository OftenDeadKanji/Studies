/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.model;

import java.util.Arrays;
import java.util.List;
import pl.polsl.lab.model.sorter.*;
import java.util.Random;
import pl.polsl.lab.entities.Numbers;
import pl.polsl.lab.enums.Commands;
import pl.polsl.lab.exception.OutOfSupposedRangeException;

/**
 * A Menu derived class that represents model during array sorting.
 *
 * @author Mateusz Chłopek
 * @version 1.4
 */
public class SortModel extends Model {

    /**
     * An Integer array that is being sorted.
     */
    private Integer[] array;

    /**
     * A list of Numbers that will be sorted.
     */
    private List<Numbers> numbers;
    
    /**
     * Size of a sorting array.s
     */
    private int arraySize;
    
    /**
     * A current index of the array.
     */
    private Integer index;
    
    /**
     * A variable that informs whether array is sorted (true) or not (false).
     */
    private Sorter sorter;

    /**
     * A class constructor.
     *
     * @param command An enum that represents which sorting algorithm has been.
     * chosen.
     * @param size Size of an array.
     */
    public SortModel(Commands command, int size) {
        changeMode = false;
        arraySize = size;
        array = new Integer[size];
        index = 0;

        // creating array with random values in range of 1 - 21
        for (int i = 0; i < arraySize; i++) {
            array[i] = new Random().nextInt(arraySize) + 1;
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
     * A class constructor. Used when list of Numbers will be sorted.
     * @param command A command given to the model.
     * @param numbers A list of Numbers that will be sorted.
     * @param state Current state of a sorting algorithm.
     * @param index A current array index.
     */
    public SortModel(Commands command, List<Numbers> numbers, int state, int index) {
        this.changeMode = false;
        this.arraySize = numbers.size();
        this.array = new Integer[arraySize];
        this.index = index;

        this.numbers = numbers;

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
        this.sorter.setState(state);

        this.command = Commands.COMMAND_CONTINUE;
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
                if (sorter.getState() != 0) {
                    index = sorter.sortNumbers(numbers, index);
                }
                break;
            default:
                throw new OutOfSupposedRangeException("SortModel: command out"
                        + "of range in update methode.");
        }
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

    /**
     * A getter for a current state of a sorter.
     * @return Sorter's current state.
     */
    public int getSorterState() {
        return sorter.getState();
    }

}
