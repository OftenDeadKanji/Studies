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
import pl.polsl.lab.model.MenuModel;

/**
 * A Controller derived class which represents controller in program's menu.
 *
 * @author Mateusz Chłopek
 * @version 1.1
 */
public class MenuController extends Controller {

    /**
     * A class constructor.
     *
     * @param communicator An object that represent a communication between
     * server and client.
     */
    public MenuController(Communicator communicator) {
        this.model = new MenuModel();
        this.communicator = communicator;

        this.runProgram = true;
        this.mode = 1;
        this.command = Commands.COMMAND_CONTINUE;
        this.pressedButton = Buttons.NONE;
    }

    /**
     * A method that allows server-client communication.
     *
     * @param communicator An object that represent a communication between
     * server and client.
     */
    @Override
    protected void communicate(Communicator communicator) {
        try {
            communicator.receive();
            switch (communicator.getSentCommunication()) {
                case COMMUNICATION_HELP:
                    communicator.sendCommunication("Welcome to Sorting Algorithms program. All things that you can do is by interacting with GUI - buttons and combo box.");
                    break;
                case COMMUNICATION_SEND_BUTTON:
                    pressedButton = communicator.getSentButton();
                    break;
                case COMMUNICATION_GET_MODE:
                    String out = "";
                    out += mode;
                    communicator.sendCommunication(out);
                    break;
                default:
                    break;
            }
            processInput();
        } catch (IOException exception) {
            System.err.println(exception.getMessage());
        }
    }

    /**
     * A controller's method where user's input is interpreted.
     */
    @Override
    protected void processInput() {
        switch (pressedButton) {
            case BUTTON_BUBBLE:
                command = Commands.COMMAND_START_BUBBLE;
                break;
            case BUTTON_BOGO:
                command = Commands.COMMAND_START_BOGO;
                break;
            case BUTTON_INSERTION:
                command = Commands.COMMAND_START_INSERTION;
                break;
            case BUTTON_EXIT:
                try {
                    communicator.close();
                } catch (IOException ex) {
                }
                break;
            case NONE:
                command = Commands.COMMAND_CONTINUE;
                break;
            default:
                break;
        }
    }
}
