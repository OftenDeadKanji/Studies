/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.test;

import org.junit.*;
import static org.junit.Assert.*;
import pl.polsl.lab.Commands;
import pl.polsl.lab.exception.OutOfSupposedRangeException;
import pl.polsl.lab.model.SortModel;

/**
 * Testing the model class method.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class SortModelTest {

    private SortModel modelBubble;
    private SortModel modelBogo;
    private SortModel modelInsertion;

    @Before
    public void setup() {
        modelBubble = new SortModel(Commands.COMMAND_START_BUBBLE);
        modelBogo = new SortModel(Commands.COMMAND_START_BOGO);
        modelInsertion = new SortModel(Commands.COMMAND_START_INSERTION);
    }
    
    @Test
    public void receiveCommandTest() {
        
        try {
            modelBubble.receiveCommand(null);
        } catch (NullPointerException exception) {
            fail("Passing null Controller fails.");
        } catch(OutOfSupposedRangeException exception){
            fail("Enum out of supposed range.");
        }
        
        try {
            modelBogo.receiveCommand(null);
        } catch (NullPointerException exception) {
            fail("Passing null Controller fails.");
        } catch(OutOfSupposedRangeException exception){
            fail("Enum out of supposed range.");
        }
        
        try {
            modelInsertion.receiveCommand(null);
        } catch (NullPointerException exception) {
            fail("Passing null Controller fails.");
        } catch(OutOfSupposedRangeException exception){
            fail("Enum out of supposed range.");
        }
        
    }
}

