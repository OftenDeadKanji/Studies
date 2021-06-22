package pl.polsl.lab.servlets;

import javax.servlet.*;
import javax.servlet.http.*;
import java.io.*;
import java.util.*;

/**
 * Main class of the servlet that demonstrates parameter download given during
 * servlet initialization
 *
 * @author Gall Anonim
 * @version 1.0
 */
public class Form extends HttpServlet {

    /**
     * Collection of statistics
     */
    private final Hashtable<String, String> stats;

    /**
     * Constructor initiating statistics collection
     */
    public Form() {
        this.stats = new Hashtable<>();
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param req servlet request
     * @param resp servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    public void doGet(HttpServletRequest req, HttpServletResponse resp)
            throws IOException, ServletException {
        resp.setContentType("text/html; charset=ISO-8859-2");
        PrintWriter out = resp.getWriter();

        // Get parameter values - firstName i lastName
        String firstName = req.getParameter("firstname");
        String lastName = req.getParameter("lastname");

        // FirstName or lastName was not given - send error message
        if (firstName.length() == 0 || lastName.length() == 0) {
            resp.sendError(HttpServletResponse.SC_BAD_REQUEST, "You should give two parameters!");
        } else {
            out.println("<html>\n<body>\n<h1>Hello " + firstName + " "
                    + lastName + "!!!</h1>\n");

            // How many times the person with given lastName visited the site
            String counter = stats.get(firstName + lastName);

            int value = 1;

            // First visit
            if (counter == null) {
                out.println("You are the first person with name " + firstName + " " + lastName
                        + " who visited this site!!!\n");
            } else {
                value += Integer.parseInt(counter);
                out.println("There are already " + value + " people with the last name " + lastName
                        + " who visited this site!!!\n");
            }
            out.println("</body>\n</html>");

            // Save current visit count
            stats.put(firstName + lastName, "" + value);
        }
    }

    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param req servlet request
     * @param resp servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    public void doPost(HttpServletRequest req, HttpServletResponse resp)
            throws IOException, ServletException {
        resp.setContentType("text/plain; charset=ISO-8859-2");
        PrintWriter out = resp.getWriter();

        out.println("Passed parameters:");

        Enumeration enumeration = req.getParameterNames();
        while (enumeration.hasMoreElements()) {
            String name = (String) enumeration.nextElement();
            out.println(name + " = " + req.getParameter(name));
        }
    }
}
