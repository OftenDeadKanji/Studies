/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.controller;

import pl.polsl.lab.Commands;
import pl.polsl.lab.model.MenuModel;
import pl.polsl.lab.model.Model;
import pl.polsl.lab.view.MenuView;
import pl.polsl.lab.view.View;

/**
 * A Controller derived class which represents controller in program's menu.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class MenuController extends Controller {

    /**
     * A class constructor.
     */
    public MenuController() {
        this.model = new MenuModel();
        this.view = new MenuView();

        this.runProgram = true;
        this.command = Commands.COMMAND_CONTINUE;
    }

    /**
     * A controller's method where user's input is interpreted.
     */
    @Override
    protected void processInput() {
        switch (pressedButton) {
            case BUTTON_BUBBLE:
                command = Commands.COMMAND_START_BUBBLE;
                view.delete();
                break;
            case BUTTON_BOGO:
                command = Commands.COMMAND_START_BOGO;
                view.delete();
                break;
            case BUTTON_INSERTION:
                command = Commands.COMMAND_START_INSERTION;
                view.delete();
                break;
            case BUTTON_EXIT:
                runProgram = false;
                view.delete();
                break;
            case NONE:
                command = Commands.COMMAND_CONTINUE;
                break;
            default:
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
    }
}
