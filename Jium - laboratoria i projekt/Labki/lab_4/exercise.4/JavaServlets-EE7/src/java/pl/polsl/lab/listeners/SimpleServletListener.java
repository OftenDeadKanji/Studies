package pl.polsl.lab.listeners;

import javax.servlet.*;
import javax.servlet.annotation.WebListener;

/**
 * Web application lifecycle listener.
 */
@WebListener()
public class SimpleServletListener implements ServletRequestAttributeListener {

    @Override
    public void attributeAdded(ServletRequestAttributeEvent attre) {
        System.out.println("Attribute " + attre.getName() + " has been added with value: " + attre.getValue());
    }

    @Override
    public void attributeRemoved(ServletRequestAttributeEvent attre) {
        System.out.println("Attribute " + attre.getName() + " has been romoved");

    }

    @Override
    public void attributeReplaced(ServletRequestAttributeEvent attre) {
        System.out.println("Attribute " + attre.getName() + " has been replaced, with value: " + attre.getValue());
    }
}
