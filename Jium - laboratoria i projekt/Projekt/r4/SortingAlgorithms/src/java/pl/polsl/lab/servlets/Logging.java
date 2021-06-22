/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.servlets;

import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 * A servlet for logging in. User gives a login and a password.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class Logging extends HttpServlet {

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        try (PrintWriter out = response.getWriter()) {
            /* TODO output your page here. You may use following sample code. */

            out.println("<!DOCTYPE html>");
            out.println("<html>");
            out.println("<head>");
            out.println("<title>Servlet Logging</title>");
            out.println("</head>");

            out.println("<style>");

            out.println("#div");
            out.println("{");

            out.println("border-radius: 40px;");
            out.println("background-color: #00004d;");
            out.println("margin-left: auto;");
            out.println("margin-right: auto;");
            out.println("padding-top: 2vh;");
            out.println("padding-bottom: 2vh;");
            out.println("text-align: center;");
            out.println("width: 70vw;");
            out.println("color: white;");
            out.println("font-size: 20px;");
            out.println("font-family: Courier New, Courier, Lucida Sans Typewriter, Lucida Typewriter,monospace;");

            out.println("}");

            out.println("#p1");
            out.println("{");

            out.println("border-radius: 1em;");
            out.println("background-color: #000080;");
            out.println("margin-left: auto;");
            out.println("margin-right: auto;");
            out.println("margin-bottom: 2vh;");
            out.println("margin-top: auto;");
            out.println("text-align: center;");
            out.println("width: 60vw;");
            out.println("font-size: 2.5em;");

            out.println("}");
            
            out.println("#p2");
            out.println("{");

            out.println("border-radius: 1em;");
            out.println("background-color: #000080;");
            out.println("margin-left: auto;");
            out.println("margin-right: auto;");
            out.println("text-align: center;");
            out.println("width: 25vw;");
            out.println("font-size: 1.3em;");

            out.println("}");
            
            out.println("#fields");
            out.println("{");

            out.println("border-radius: 1em;");
            out.println("background-color: #000080;");
            out.println("margin-left: auto;");
            out.println("margin-right: auto;");
            out.println("text-align: center;");
            out.println("width: 15vw;");
            out.println("font-size: 1.0em;");

            out.println("}");

            out.println("#button");
            out.println("{");

            out.println("border-radius: 1em;");
            out.println("background-color: #000080;");
            out.println("margin-left: auto;");
            out.println("margin-right: auto;");
            out.println("text-align: center;");
            out.println("width: auto;");
            out.println("color: white;");
            out.println("font-size: 1em;");
            out.println("font-family: Courier New, Courier, Lucida Sans Typewriter, Lucida Typewriter,monospace;");
            out.println("}");

            out.println("</style>");

            out.println("<body bgcolor=\"black\">");
            out.println("<div id=\"div\">");

            out.println("<p id=\"p1\">");
            out.println("Proszę się zalogować.");
            out.println("</p>");
            out.println("<p id = \"p2\">");
            out.println("(konto testowe: admin admin)");
            out.println("</p>");

            out.println("<form action=\"LoggingCheck\">");
            out.println("<p id=\"fields\">Login: <input type=text name=login></p>");
            out.println("<p id=\"fields\">Hasło: <input type=password name=password></p>");
            out.println("<input id=\"button\" type=submit value=\"Zaloguj\">");
            out.println("</form>");

            out.println("</div>");
            out.println("</body>");
            out.println("</html>");
        }
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        doGet(request, response);
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
