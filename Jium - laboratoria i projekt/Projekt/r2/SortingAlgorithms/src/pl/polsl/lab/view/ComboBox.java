/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.view;

import javax.swing.JComboBox;

/**
 * A class that represents a combo box. It uses a JComboBox class.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class ComboBox extends JComboBox {

    /**
     * Variables which informs about button's left upper corner position.
     */
    private final int x, y;
    /**
     * A String array that consists of texts to be shown as options.
     */
    String[] choices;

    /**
     * A class constructor
     *
     * @param choices String array of avaiable choices
     * @param x x coordinate of box's left upper corner
     * @param y y coordinate of box's left upper corner
     */
    public ComboBox(String[] choices, int x, int y) {
        super(choices);
        this.x = x;
        this.y = y;
        this.choices = choices;

        setLocation(x, y);
        setBounds(this.x, this.y, 200, 25);
        setSelectedIndex(0);
    }
}
