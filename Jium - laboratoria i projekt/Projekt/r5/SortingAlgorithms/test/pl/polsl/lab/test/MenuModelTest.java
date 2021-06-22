/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.test;

import org.junit.*;
import static org.junit.Assert.*;
import pl.polsl.lab.exception.OutOfSupposedRangeException;
import pl.polsl.lab.model.MenuModel;

/**
 * Testing the model class method.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class MenuModelTest {

    MenuModel model;

    @Before
    public void setup() {
        model = new MenuModel();
    }

    @Test
    public void receiveCommandTest() {
        
        try {
            model.receiveCommand(null);
        } catch (NullPointerException exception) {
            fail("Passing null Controller fails.");
        } catch(OutOfSupposedRangeException exception){}
        
    }
}
