/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.controller;

import java.io.IOException;
import pl.polsl.lab.Buttons;
import pl.polsl.lab.Commands;
import pl.polsl.lab.communicator.Communicator;
import pl.polsl.lab.exception.OutOfSupposedRangeException;
import pl.polsl.lab.model.Model;

/**
 * An abstract class for controller, which is responsible for interpreting
 * user's input, giving commands to model and communitacing between model and
 * view.
 *
 * @author Mateusz Chłopek
 * @version 1.1
 */
public abstract class Controller {

    /**
     * A variable that informs program when it has to be closed (false).
     */
    protected boolean runProgram;

    /**
     * A current program mode.
     */
    protected int mode;
    /**
     * An object that represents program's model.
     */
    protected Model model;
    /**
     * An object that represent a communication between server and client.
     */
    protected Communicator communicator;
    /**
     * An object of enum class that represents the type of pressed button.
     */
    protected Buttons pressedButton;
    /**
     * An object of enum class that represent the command which value is chosen
     * during user's input interpretation.
     */
    protected Commands command;

    /**
     * A primary controller's method. Required for program to work.
     *
     */
    public void run() {

        while (!model.getChange() && runProgram) {
            try {
                //sending a command to the model
                model.receiveCommand(this);
                if (model.getChange()) {
                    break;
                }
            } catch (OutOfSupposedRangeException exception) {
                communicator.writeErrorLog(exception.getMessage());
                runProgram = false;
                break;
            }

            try { //checking if a client is connected
                if (!communicator.getIsConnected()) {
                    communicator.socketAccept();
                } else { //communicating with a client
                    communicate(communicator);
                }
            } catch (IOException exception) {
                System.err.println(exception.getMessage());
                runProgram = false;
                break;
            }
        }
    }

    /**
     * A method that allows server-client communication.
     * @param communicator An object that represent a communication between 
     * server and client.
     */
    protected abstract void communicate(Communicator communicator);

    /**
     * A controller's method where user's input is interpreted.
     */
    protected abstract void processInput();

    /**
     * A getter that gives access to private field - command - inforamtion about
     * controller's command that model will recive.
     *
     * @return an enum that gives information about controller's command.
     */
    public Commands getCommand() {
        return command;
    }
    /**
     * A getter that gives access to private field - runProgram - main program
     * condition to keep running.
     *
     * @return true when it's required to exit from program, false when it
     * continues it's work.
     */
    public boolean getRun() {
        return runProgram;
    }

    /**
     * A getter for a mode private field.
     * @return A current program mode: 1 - menu; 2 - sorting.
     */
    public int getMode() {
        return mode;
    }
}
