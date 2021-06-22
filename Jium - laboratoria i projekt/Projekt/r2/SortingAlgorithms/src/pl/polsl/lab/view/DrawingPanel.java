/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.view;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.geom.Rectangle2D;
import pl.polsl.lab.Buttons;

/**
 * A Panel derived class that represents visual part of frame that is 
 * responsible for drawing rectangles.
 * 
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class DrawingPanel extends Panel{
    /**
     * A array that consists of rectangles to be displayed.
     */
    private final Rectangle2D[] rectangles;
    /**
     * Index of currently pointed array element.
     */
    private int index;
    
    /**
     * A class constructor.
     * @param w panel's width
     * @param h panels' height
     * @param arraySize size of sorted array
     */
    DrawingPanel(int w, int h, int arraySize){
        super(w, h);
        rectangles = new Rectangle2D[arraySize];
        index = -1;
    }
    
    /**
     * A setter that sets the rectangles array.
     * @param rectangles an array of rectangles to be shown
     */
    public void setRectangles(Rectangle2D[] rectangles) {
        System.arraycopy(rectangles, 0, this.rectangles, 0, rectangles.length);
    }
    
    /**
     * A setter that sets current index.
     * @param index current index
     */
    public void setIndex(int index){
        this.index = index;
    }
    
    /**
     * A method that is required to draw elements.
     * @param g a graphic object
     */
    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);
        Graphics2D g2d = (Graphics2D) g;
        for (int i = 0; i < rectangles.length; i++) {
            if (rectangles[i] != null) {
                
                if (index == i) {
                    g2d.setColor(Color.RED);
                } else if (index == -2){
                    g2d.setColor(Color.GREEN);
                }else {
                
                    g2d.setColor(Color.WHITE);
                }
                g2d.fill(rectangles[i]);
                
                g2d.setColor(Color.BLACK);
                g2d.draw(rectangles[i]);
            }
        }
    }
    /**
     * A getter that gives access to a private field - pressedButton.
     *
     * @return type of pressed button
     */
    @Override
    public Buttons getPressedButtonType(){
        return Buttons.NONE;
    }
}
