/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.view;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import pl.polsl.lab.Buttons;

/**
 * A Panel derived class that may consists of buttons and combo boxes.
 * 
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class ButtonPanel extends Panel implements ActionListener {

    /**
     * An array of buttons that are in the panel.
     */
    private final ArrayList<Button> buttonsArray;
    /**
     * An enum that represents type of pressed button.
     */
    private Buttons pressedButton;
    /**
     * An object that represents combo box.
     */
    private ComboBox comboBox;

    /**
     * A class constructor.
     *
     * @param w panel's width
     * @param h panel's height
     */
    public ButtonPanel(int w, int h) {
        super(w, h);
        buttonsArray = new ArrayList<>();
        pressedButton = Buttons.NONE;
    }

    /**
     * A method that adds button to the panel.
     * 
     * @param text text to be shown on the button
     * @param type a type, function of button
     * @param x x coordinate of button's left upper corner
     * @param y y coordinate of button's left upper corner
     * @param w button's width
     * @param h button's height
     */
    public void addButton(String text, Buttons type, int x, int y, int w, int h) {
        Button button = new Button(text, type, x, y, w, h);
        add(button);
        buttonsArray.add(button);
        button.addActionListener(this);
    }

    /**
     * A method that adds combo box to the panel.
     *
     * @param choices String array that consists of avaible choices
     * @param x x coordinate of the box's left upper corner
     * @param y y coordinate of the box's left upper corner
     */
    public void addComboBox(String[] choices, int x, int y) {
        this.comboBox = new ComboBox(choices, x, y);
        add(comboBox);
        comboBox.addActionListener(this);
    }

    /**
     * A method that finds source object of user's interaction with GUI and sets
     * pressedButton variable.
     *
     * @param event event associated with user's interaction
     */
    @Override
    public void actionPerformed(ActionEvent event) {
        Object source = event.getSource();
        for (int i = 0; i < buttonsArray.size(); i++) {
            if (buttonsArray.get(i) == source) {
                pressedButton = buttonsArray.get(i).getType();
                if (pressedButton == Buttons.BUTTON_SELECT) {
                    pressedButton = Buttons.values()[comboBox.getSelectedIndex() + 2];
                }
            }
        }
    }

    /**
     * A getter that gives access to a private field - pressedButton.
     *
     * @return type of pressed button
     */
    @Override
    public Buttons getPressedButtonType() {
        return pressedButton;
    }
}
