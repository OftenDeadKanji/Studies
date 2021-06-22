/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.view;

import java.awt.Dimension;
import javax.swing.JPanel;
import pl.polsl.lab.Buttons;
/**
 * A class that represent a panel. It uses a JPanel class and implements ac ActionLister interface.
 * 
 * @author Mateusz Chłopek
 * @version 1.0
 */
public abstract class Panel extends JPanel {
    
    /**
     * A class constructor.
     * @param w panel's width
     * @param h panel's height
     */
    Panel(int w, int h){
        setLayout(null);
        setPreferredSize(new Dimension(w, h));
    }
    /**
     * A getter that gives access to a private field - pressedButton.
     *
     * @return type of pressed button
     */
    public abstract Buttons getPressedButtonType();
}
