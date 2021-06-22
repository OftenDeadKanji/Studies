/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab;

import pl.polsl.lab.controller.*;

/**
 * Main program class.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class SortingAlgorithms {

    /**
     * Main program method.
     *
     * @param args the command line arguments - not used in program
     */
    public static void main(String[] args) {
        Controller controller = new MenuController();

        int mode = 1;
        //main program loop
        while (true) {
            controller.run();
            if (!controller.getRun()) {
                break;
            }
            //menu -> sorting
            if (mode == 1) {
                mode = 2;
                controller = new SortController(controller.getCommand());
            } //sorting -> menu
            else {
                mode = 1;
                controller = new MenuController();
            }

        }
    }
}
