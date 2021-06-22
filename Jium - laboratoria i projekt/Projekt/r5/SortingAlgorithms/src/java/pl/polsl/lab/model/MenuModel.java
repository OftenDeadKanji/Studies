/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.model;

import pl.polsl.lab.enums.Commands;
import pl.polsl.lab.exception.OutOfSupposedRangeException;

/**
 * A Menu derived class that represents model in menu.
 *
 * @author Mateusz Chłopek
 * @version 1.1
 */
public class MenuModel extends Model {

    /**
     * A class constructor.
     */
    public MenuModel() {
        this.changeMode = false;
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
            case COMMAND_START_BUBBLE:
            case COMMAND_START_BOGO:
            case COMMAND_START_INSERTION:
                changeMode = true;
                break;
            case COMMAND_CONTINUE:
                break;
            default:
                throw new OutOfSupposedRangeException("Model: command out of"
                        + "range in update method.");
        }
    }

    /**
     * A getter that gives access to the sorted array.
     *
     * @return null - in menu there's no array to be sorted.
     */
    @Override
    public int[] getInnerModel() {
        return null;
    }

    /**
     * A getter that gives access to a current index.
     *
     * @return -1 - in menu there's no array to be sorted so there's no index as
     * well.
     */
    @Override
    public int getIndex() {
        return -1;
    }
}
