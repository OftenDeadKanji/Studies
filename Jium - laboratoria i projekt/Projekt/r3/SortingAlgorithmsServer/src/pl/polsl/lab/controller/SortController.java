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
import pl.polsl.lab.model.SortModel;

/**
 * A Controller derived class that represents controller during array sorting.
 *
 * @author Mateusz Chłopek
 * @version 1.1
 */
public class SortController extends Controller {

    /**
     * A class constructor.
     *
     * @param communicator - An object that represent a communication between
     * server and client.
     * @param command a command that's going to be given to a model
     */
    public SortController(Communicator communicator, Commands command) {
        this.model = new SortModel(command);
        this.communicator = communicator;

        this.runProgram = true;
        this.mode = 2;
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
                case COMMUNICATION_GET_MODEL_INDEX:
                    String outIndex = "";
                    outIndex += model.getIndex();
                    communicator.sendCommunication(outIndex);
                case COMMUNICATION_GET_MODEL:
                    String outArray = "";
                    int[] array = model.getInnerModel();

                    if (array.length > 0) {
                        outArray += array[0];
                    }
                    for (int i = 1; i < array.length; i++) {
                        outArray += "," + array[i];
                    }
                    communicator.sendCommunication(outArray);
                    break;
                case COMMUNICATION_GET_MODE:
                    String out = "";
                    out += mode;
                    communicator.sendCommunication(out);
                    break;
                case COMMUNICATION_SEND_BUTTON:
                    pressedButton = communicator.getSentButton();
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
            case BUTTON_EXIT:
                command = Commands.COMMAND_STOP;
                break;
            case NONE:
                command = Commands.COMMAND_CONTINUE;
                break;
        }
    }
}
