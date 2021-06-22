/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.servlets;

import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import pl.polsl.lab.enums.Commands;
import pl.polsl.lab.exception.OutOfSupposedRangeException;
import pl.polsl.lab.model.*;

/**
 * A servlet that shows the process of array sorting. It refreshes itself every
 * seconde.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class Sorting extends HttpServlet {

    /**
     * An object that represent model in project and is responsible for sorting.
     */
    private Model model;
    /**
     * A current index of sorting array.
     */
    private int index = 0;

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
        response.setHeader("Refresh", "0.7");

        String loginCheck = (String) request.getSession().getAttribute("login");
        if (loginCheck == null) {
            response.sendRedirect("Logging");
        }
        Cookie[] cookies = request.getCookies();
        boolean logged = false;
        for (Cookie cookieMonster : cookies) {
            if (cookieMonster.getValue().equals(loginCheck)) {
                logged = true;
                break;
            }
        }
        if (!logged) {
            response.sendRedirect("Logging");
        } else {

            PrintWriter out = response.getWriter();
            
            out.println("<!DOCTYPE html>");
            out.println("<html>");
            out.println("<head>");
            out.println("<title>Servlet Sorting</title>");
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
            out.println("width: 14vw;");
            out.println("font-size: 1.2em;");

            out.println("}");

            out.println("#p2");
            out.println("{");

            out.println("border-radius: 1em;");
            out.println("background-color: #000080;");
            out.println("margin-left: auto;");
            out.println("margin-right: auto;");
            out.println("text-align: center;");
            out.println("width: 25vw;");
            out.println("font-size: 1.8em;");

            out.println("}");
            
            out.println("#exception");
            out.println("{");

            out.println("border-radius: 0.6em;");
            out.println("background-color: #000080;");
            out.println("margin-left: auto;");
            out.println("margin-right: auto;");
            out.println("margin-bottom: 2vh;");
            out.println("margin-top: auto;");
            out.println("text-align: center;");
            out.println("width: 68vw;");
            out.println("font-size: 2em;");

            out.println("}");
            
            out.println("#array");
            out.println("{");

            out.println("border-radius: 1em;");
            out.println("background-color: #000080;");
            out.println("margin-left: auto;");
            out.println("margin-right: auto;");
            
            out.println("padding-top: 1vh;");
            out.println("padding-bottom: 1vh;");
            
            out.println("text-align: center;");
            out.println("width: 60vw;");
            out.println("font-size: 1em;");

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
            out.println("Powrót do menu:");
            out.println("</p>");

            out.println("<form action=\"Menu\">");
            out.println("<input id=\"button\" type=\"submit\" value=\"Wróć\">");
            out.println("</form>");

            out.println("<p id=\"p2\" >Sortowanie tablicy</p>");
            out.println("<p id=\"array\" >");

            model = (SortModel) request.getSession().getAttribute("model");
            if (model == null) {
                model = new SortModel(Commands.COMMAND_START_BUBBLE, 20);
                request.getSession().setAttribute("model", model);
                request.getSession().setAttribute("size", "20");
                request.getSession().setAttribute("algorithm", "Bąbelkowe");
            }

            try {
                model.receiveCommand(Commands.COMMAND_CONTINUE);
            } catch (OutOfSupposedRangeException exception) {
                out.println("<p id=\"exception\">WYJATEK!<br>" + exception.getMessage() + "</p>");
            }

            int[] array = model.getInnerModel();
            index = model.getIndex();

            for (int i = 0; i < array.length; i++) {
                if (i == index) {
                    out.println("<b>" + array[i] + " </b>");
                } else {
                    out.println(array[i] + " ");
                }
            }
            request.getSession().setAttribute("model", model);

            out.println("</p>");

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
