/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.view;

import java.awt.*;
import java.awt.geom.Rectangle2D;
import pl.polsl.lab.Buttons;

/**
 * A View derived class that represent view during array soring.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class SortView extends View {

    /**
     * Width of frame.
     */
    private final int wFrame;
    /**
     * Height of frame.
     */
    private final int hFrame;
    /**
     * Width of button panel.
     */
    private final int wButtonPanel;
    /**
     * Height of button panel.
     */
    private final int hButtonPanel;
    /**
     * Width of drawing panel.
     */
    private final int wDrawingPanel;
    /**
     * Height of drawing panel.
     */
    private final int hDrawingPanel;
    /**
     * Sorted array's max value.
     */
    private int maxValue;
    /**
     * Max height of rectangles that are drawn.
     */
    private final int maxHeight;
    /**
     * An object that represents a button panel.
     */
    private final ButtonPanel buttonPanel;
    /**
     * An object that represents a drawing panel.
     */
    private final DrawingPanel drawingPanel;

    /**
     * A class constructor
     * @param array a sorted array
     */
    public SortView(int[] array) {
        //seting up the frame
        this.wFrame = 800;
        this.hFrame = 600;
        this.frame = new Frame("Wizualizacja algorytmów sortowania", wFrame, hFrame);
        this.frame.setLayout(new FlowLayout());
        this.frame.setBackground(Color.DARK_GRAY);

        //setting up the button panel
        this.wButtonPanel = 800;
        this.hButtonPanel = 100;

        this.buttonPanel = new ButtonPanel(wButtonPanel, hButtonPanel);
        this.buttonPanel.setLocation(10, 500);
        this.buttonPanel.setBackground(Color.DARK_GRAY);

        int wButton = 150;
        int hButton = 25;
        buttonPanel.addButton("Wróć do menu", Buttons.BUTTON_EXIT, (int) ((wButtonPanel - wButton) * 0.5), hButton, wButton, hButton);

        //setting up the drawing panel
        this.wDrawingPanel = 800;
        this.hDrawingPanel = 500;
        this.drawingPanel = new DrawingPanel(wDrawingPanel, hDrawingPanel, array.length);
        this.drawingPanel.setLocation(0, 0);
        this.drawingPanel.setBackground(Color.DARK_GRAY);

        frame.addPanel(drawingPanel);
        frame.addPanel(buttonPanel);

        //creating Rectangles
        this.maxValue = 0;
        this.maxHeight = hDrawingPanel;
        for (int i = 0; i < array.length; i++) {
            if (maxValue < array[i]) {
                maxValue = array[i];
            }
        }
    }

    /**
     * A setter that allows to view to display currently sorted array
     *
     * @param array array that is being sorted
     * @param index current array index
     */
    @Override
    public void setDrawable(int[] array, int index) {
        this.drawingPanel.setIndex(index);

        Rectangle2D[] rectArray = new Rectangle2D[array.length];

        for (int i = 0; i < array.length; i++) {
            float rectHeight = (float) array[i] / (float) maxValue * (float) maxHeight;
            float rectY = hDrawingPanel - rectHeight;
            rectArray[i] = new Rectangle2D.Float(i * 40, rectY, 40, rectHeight);
        }

        drawingPanel.setRectangles(rectArray);
    }

    /**
     * A method responsible for updating the frame.
     */
    @Override
    public void draw() {
        frame.validate();
        frame.repaint();
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
