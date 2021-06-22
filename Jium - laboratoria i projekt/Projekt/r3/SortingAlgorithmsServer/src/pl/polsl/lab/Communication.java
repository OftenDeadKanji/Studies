/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab;

/**
 * An enum class that represents a sent communication type.
 * @author Mateusz Chłopek
 * @version 1.0
 */
public enum Communication {
    
    /**
     * No communication sent.
     */
    COMMUNICATION_NONE,
    
    /**
     * A communication to end client connection.
     */
    COMMUNICATION_END,
    
    /**
     * A command to get inner model - array.
     */
    COMMUNICATION_GET_MODEL,
    
    /**
     * A command to get inner model - array and index.
     */
    COMMUNICATION_GET_MODEL_INDEX,
    
    /**
     * A command to get current mode.
     */
    COMMUNICATION_GET_MODE,
    
    /**
     * A command to get a help message.
     */
    COMMUNICATION_HELP,
    
    /**
     * An information that a button has been pressed.
     */
    COMMUNICATION_SEND_BUTTON,
    
    /**
     * No button has been pressed.
     */
    NONE,
    /**
     * A select button (e.g. used with combo box) has been pressed.
     */
    BUTTON_SELECT,
    /**
     * Selection of bubble sorting algorithm has been pressed.
     */
    BUTTON_BUBBLE,
    /**
     * Selection of bogo sorting algorithm has been pressed.
     */
    BUTTON_BOGO,
    /**
     * Selection of insertion sorting algorithm has been pressed.
     */
    BUTTON_INSERTION,
    /**
     * An exit button has been pressed.
     */
    BUTTON_EXIT;
};
