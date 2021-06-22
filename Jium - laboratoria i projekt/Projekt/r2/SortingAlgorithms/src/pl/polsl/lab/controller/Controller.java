/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.controller;

import java.io.FileNotFoundException;
import pl.polsl.lab.Buttons;
import pl.polsl.lab.Commands;
import pl.polsl.lab.exception.OutOfSupposedRangeException;
import pl.polsl.lab.model.Model;
import pl.polsl.lab.view.View;

/**
 * An abstract class for controller, which is responsible for interpreting
 * user's input, giving commands to model and communitacing between model and
 * view.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public abstract class Controller {

    /**
     * A variable that informs program when it has to be closed (false).
     */
    protected boolean runProgram;
    /**
     * An object that represents program's model.
     */
    protected Model model;
    /**
     * An object that represents program's view.
     */
    protected View view;
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
     */
    public void run() {
        
        while (!model.getChange() && runProgram) {
            try {
                model.receiveCommand(this);
                //model.update();
            } catch (OutOfSupposedRangeException exception) {
                try {
                    view.writeErrorLog(exception.getMessage());
                } catch (FileNotFoundException ex) {}
                runProgram = false;
                break;
            }

            communicateMV(model, view);

            view.draw();

            receiveUserInteraction(view);
           // processInput();
        }
    }

    /**
     * A method which is a way of communication between view and controller.
     *
     * @param view object that can give the controller information about user's
     * interaction with GUI (e.g. buttons).
     */
    public void receiveUserInteraction(View view) {
        pressedButton = view.getPressedButtonType();
        processInput();
    }

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
     * A method which is responsible for enabling communication between model
     * and view.
     *
     * @param model an object that represents program's model.
     * @param view an object that represents program's view.
     */
    protected abstract void communicateMV(Model model, View view);

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
}
