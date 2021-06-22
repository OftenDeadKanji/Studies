/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.model.sorter;
import java.util.List;
import pl.polsl.lab.entities.Numbers;
/**
 * An abstract class that responsible for sorting the array.
 * 
 * @author Mateusz Chłopek
 * @version 1.1
 */
public abstract class Sorter {
    
    protected int state;
    
    /**
     * A method that sorts the array. It is responsible for only one algorithm's iteration so it requires an starting index.
     * 
     * @param sortingArray array to be sorted
     * @param index a starting index
     * @return an index at which it ended an a part of algorithm
     */
    public abstract Integer sort(Integer[] sortingArray, Integer index);
    
    /**
     * A method that sorts the List using bogo sort. It creates new (random)
     * order of values in the List..
     *
     * @param numbers List of Numbers to be sorted
     * @param index a starting index (not used in this algorithm)
     * @return -1 - index is not used in this algorithm
     */
    public abstract Integer sortNumbers(List<Numbers> numbers, Integer index);
    
    /**
     * A setter for a state of sorter.
     * @param state A current state.
     */
    public abstract void setState(int state);
    
    /**
     * A getter for a current state.
     * @return Sorter's current state.
     */
    public int getState(){
        return this.state;
    }
}
