/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.model.sorter;

/**
 * An abstract class that responsible for sorting the array.
 * 
 * @author Mateusz Chłopek
 * @version 1.0
 */
public abstract class Sorter {
    /**
     * A method that sorts the array. It is responsible for only one algorithm's iteration so it requires an starting index.
     * 
     * @param sortingArray array to be sorted
     * @param index a starting index
     * @return an index at which it ended an a part of algorithm
     */
    public abstract Integer sort(Integer[] sortingArray, Integer index);
}
