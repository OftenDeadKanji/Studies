/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.exception;

/**
 * Exception class responsible for handling situations when some variables
 * (enum) have values out of supposed range.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class OutOfSupposedRangeException extends Exception {

    /**
     * A class constructor.
     *
     * @param message message to be written in a file
     */
    public OutOfSupposedRangeException(String message) {
        super(message);
    }
}
