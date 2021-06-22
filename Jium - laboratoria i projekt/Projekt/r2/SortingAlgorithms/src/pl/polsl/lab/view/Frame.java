/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.view;

import java.awt.Dimension;
import java.awt.Toolkit;
import javax.swing.JFrame;
import java.util.ArrayList;
import pl.polsl.lab.Buttons;

/**
 * A class that represent a frame. It uses a JFrame class.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class Frame extends JFrame {

    /**
     * An object that informs about user's screen resolution.
     */
    private final Dimension screenResolution;
    /**
     * A list of panels in frame.
     */
    private final ArrayList<Panel> panelsArray;

    /**
     * A class constructor.
     *
     * @param text title of the frame.
     * @param w frame's width
     * @param h frame's height
     */
    Frame(String text, int w, int h) {
        super(text);
        screenResolution = Toolkit.getDefaultToolkit().getScreenSize();
        panelsArray = new ArrayList<>();
        changeSize(w, h);

        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setResizable(false);
        setVisible(true);
    }

    /**
     * A method that sets the frame's position. It should be in the center of
     * user's screen.
     *
     * @param w width of the frame
     * @param h height of the frame
     */
    private void changeSize(int w, int h) {
        setSize(new Dimension(w, h));
        setLocation((int) ((screenResolution.width - w) * 0.5f), (int) ((screenResolution.height - h) * 0.5f));
    }

    /**
     * A method that adds a new panel.
     *
     * @param panel panel to be added to the frame
     */
    public void addPanel(Panel panel) {
        add(panel);
        panelsArray.add(panel);
    }

    /**
     * A method that retrieves type of pressed button.
     *
     * @return an enum that represents button's type
     */
    public Buttons getPressedButtonType() {
        for (int i = 0; i < panelsArray.size(); i++) {
            if (panelsArray.get(i).getPressedButtonType() != Buttons.NONE) {
                return panelsArray.get(i).getPressedButtonType();
            }
        }
        return Buttons.NONE;
    }
}
