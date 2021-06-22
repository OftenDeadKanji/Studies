/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.view;

import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import pl.polsl.lab.Buttons;

/**
 * A View derived class that represent view in menu.
 *
 * @author Mateusz Chłopek
 * @version 1.1
 */
public class MenuView extends View {

    /**
     * A class constructor.
     */
    public MenuView() {
        frame = new Frame("Wizualizacja algorytmów sortowania", 300, 200);

        frame.addWindowListener(new WindowAdapter() {
            @Override
            public void windowClosing(WindowEvent we) {
                frame.setIsClosed(true);
            }
        });

        int wPanel = 300, hPanel = 200;
        ButtonPanel panel = new ButtonPanel(wPanel, hPanel);

        int wButton = 100, hButton = 25;

        panel.addButton("Sortuj", Buttons.BUTTON_SELECT, (int) ((wPanel - wButton) * 0.5), 3 * hButton, wButton, hButton);

        panel.addButton("Wyjdź", Buttons.BUTTON_EXIT, (int) ((wPanel - 100) * 0.5), hPanel - 3 * hButton, 100, hButton);

        String[] choices = {"Sortowanie bąbelkowe", "Sortowanie bogo", "Sortowanie przez wstawianie"};
        panel.addComboBox(choices, (int) ((wPanel - 200) * 0.5), 1 * hButton);

        frame.addPanel(panel);
        frame.validate();
    }

    /**
     * A setter that allows to view to display currently sorted array
     *
     * @param array array that is being sorted
     * @param index current array index
     */
    @Override
    public void setDrawable(int[] array, int index) {
    }

    /**
     * A method responsible for updating the frame.
     */
    @Override
    public void draw() {
    }

    /**
     * A getter that gives access to a private field - pressedButton
     *
     * @return a type of pressed button
     */
    @Override
    public Buttons getPressedButtonType() {
        return frame.getPressedButtonType();
    }
}
