/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab;

/**
 * Enum class describing commands given to model by controller.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public enum Commands {
    /**
     * A command that tells model to continue its work.
     */
    COMMAND_CONTINUE,
    /**
     * A command that tells model to exit from program or to stop sorting and
     * return to menu.
     */
    COMMAND_STOP,
    /**
     * A command for starting a bubble sorting algorithm.
     */
    COMMAND_START_BUBBLE,
    /**
     * A command for starting a bogo sorting algorithm.
     */
    COMMAND_START_BOGO,
    /**
     * A command for starting a insertion sorting algorithm.
     */
    COMMAND_START_INSERTION;
};
