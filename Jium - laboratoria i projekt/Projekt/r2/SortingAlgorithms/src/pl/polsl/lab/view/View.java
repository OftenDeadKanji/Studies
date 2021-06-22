/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.view;

import java.io.FileNotFoundException;
import java.io.PrintWriter;
import pl.polsl.lab.Buttons;

/**
 * An abstract class for view that is responsible of GUI and retrieving user's interaction with it.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public abstract class View {
    /**
     * An object that represent frame.
     */
    protected Frame frame;
    /**
     * A setter that allows to view to display currently sorted array
     * @param array array that is being sorted
     * @param index current array index
     */
    public abstract void setDrawable(int[] array, int index);
    /**
     * A method responsible for updating the frame.
     */
    public abstract void draw();
    /**
     * A getter that gives access to a private field - pressedButton
     * @return a type of pressed button
     */
    public abstract Buttons getPressedButtonType();
    /**
     * A method used for closing and deleting frame.
     */
    public void delete(){
        frame.dispose();
    }
    
    
    public void writeErrorLog(String message) throws FileNotFoundException {
        PrintWriter file = new PrintWriter("logs.txt");
        file.println(message);
        file.close();
    }
}
