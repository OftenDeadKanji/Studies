/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.controller;

import pl.polsl.lab.Buttons;
import pl.polsl.lab.Commands;
import pl.polsl.lab.model.Model;
import pl.polsl.lab.model.SortModel;
import pl.polsl.lab.view.SortView;
import pl.polsl.lab.view.View;

/**
 * A Controller derived class that represents controller during array sorting.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class SortController extends Controller {

    /**
     * A class constructor.
     *
     * @param command a command that's going to be given to a model
     */
    public SortController(Commands command) {
        this.model = new SortModel(command);
        int[] originArray = model.getInnerModel();
        this.view = new SortView(originArray);

        this.runProgram = true;
        this.command = Commands.COMMAND_CONTINUE;
        this.pressedButton = Buttons.NONE;
    }

    /**
     * A method which is a way of communication between view and controller.
     *
     * @param view object that can give the controller information about user's
     * interaction with GUI (e.g. buttons).
     */
    //@Override
    //public void receiveUserInteraction(View view) {
    //    pressedButton = view.getPressedButtonType();
    //}

    /**
     * A controller's method where user's input is interpreted.
     */
    @Override
    protected void processInput() {
        switch (pressedButton) {
            case BUTTON_EXIT:
                command = Commands.COMMAND_STOP;
                view.delete();
                break;
            case NONE:
                command = Commands.COMMAND_CONTINUE;
                break;
        }
    }

    /**
     * A method which is responsible for enabling communication between model
     * and view.
     *
     * @param model an object that represents program's model.
     * @param view an object that represents program's view.
     */
    @Override
    protected void communicateMV(Model model, View view) {
        int[] array = model.getInnerModel();
        int index = model.getIndex();

        view.setDrawable(array, index);
    }
}
