/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.view;

import javax.swing.JButton;
import pl.polsl.lab.Buttons;

/**
 * A class that represents a button in GUI. It uses a JButton class.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class Button extends JButton {

    /**
     * Variables which informs about button's left upper corner position.
     */
    private int x, y;
    /**
     * An enum that informs about button's function.
     */
    private final Buttons type;

    /**
     * A class constructor.
     *
     * @param text text to be shown on the button
     * @param x x coordinate of button's left upper corner
     * @param y y coordinate of button's left upper corner
     * @param w button's width
     * @param h button's height
     */
    Button(String text, int x, int y, int w, int h) {
        super(text);
        this.x = x;
        this.y = y;
        setLocation(x, y);
        setSize(w, h);
        this.type = Buttons.NONE;
    }

    /**
     *
     * @param text text to be shown on the button
     * @param type a type, function of button
     * @param x x coordinate of button's left upper corner
     * @param y y coordinate of button's left upper corner
     * @param w button's width
     * @param h button's height
     */
    Button(String text, Buttons type, int x, int y, int w, int h) {
        super(text);
        this.type = type;
        setLocation(x, y);
        setSize(w, h);
    }

    /**
     * A getter that gives access to a private field - buttonType.
     *
     * @return an enum that indicated button type.
     */
    public Buttons getType() {
        return type;
    }
}
