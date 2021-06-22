/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.model;

import pl.polsl.lab.enums.Commands;
import pl.polsl.lab.exception.OutOfSupposedRangeException;

/**
 *
 * @author Mateusz Chłopek
 * @version 1.2
 */
public abstract class Model {

    /**
     * An enum that represents command given to model.
     */
    protected Commands command;
    /**
     * A variable that informs program when current mode has to be changed
     * (true).
     */
    protected boolean changeMode;

    /**
     * A method for receiving command from controller by model.
     *
     * @param command - a command given to the model
     * @throws OutOfSupposedRangeException exception describing a variable's
     * value that is out of supposed range.
     */
    public void receiveCommand(Commands command) throws OutOfSupposedRangeException {
        if (command == null) {
            command = Commands.COMMAND_CONTINUE;
        }
        this.command = command;
        update();

    }

    /**
     * A primary method where model changes the program's inner structure.
     *
     * @throws OutOfSupposedRangeException exception describing a variable's
     *
     */
    protected abstract void update() throws OutOfSupposedRangeException;

    /**
     * A getter that gives access to private field - runMode.
     *
     * @return true when it's required to change program's mode - from menu to
     * sorting or the opposite.
     */
    public boolean getChange() {
        return changeMode;
    }

    /**
     * A getter that gives access to the sorted array.
     *
     * @return an integers array that is being sorted.
     */
    public abstract int[] getInnerModel();

    /**
     * A getter that gives access to a current index.
     *
     * @return -2 when array has been sorted, -1 when currently there's no
     * selected element, any other - current array index
     */
    public abstract int getIndex();
}
