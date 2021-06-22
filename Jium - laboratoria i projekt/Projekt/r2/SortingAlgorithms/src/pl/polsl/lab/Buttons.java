/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab;

/**
 * Enum class describing buttons type and user's interaction with GUI.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public enum Buttons {
    /**
     * No user interaction.
     */
    NONE,
    /**
     * A select button (e.g. used with combo box).
     */
    BUTTON_SELECT,
    /**
     * Selection of bubble sorting algorithm.
     */
    BUTTON_BUBBLE,
    /**
     * Selection of bogo sorting algorithm.
     */
    BUTTON_BOGO,
    /**
     * Selection of insertion sorting algorithm.
     */
    BUTTON_INSERTION,
    /**
     * An exit button.
     */
    BUTTON_EXIT;
};
