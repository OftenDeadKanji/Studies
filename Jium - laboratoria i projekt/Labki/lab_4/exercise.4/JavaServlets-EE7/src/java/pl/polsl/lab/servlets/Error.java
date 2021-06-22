package pl.polsl.lab.servlets;

import javax.servlet.*;
import javax.servlet.http.*;
import java.io.*;

/** 
 * Servlet handling runtime error
 * 
 * @author Gall Anonim
 * @version 1.0
 */
public class Error extends HttpServlet {

    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param req servlet request
     * @param resp servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    public void doGet(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException {
        resp.setContentType("text/plain; charset=ISO-8859-2");
        PrintWriter out = resp.getWriter();

        out.println("Incorrect servlet call!!!");
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
    public void doPost(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException {
        doGet(req, resp);
    }
}
