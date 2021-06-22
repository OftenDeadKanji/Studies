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
import pl.polsl.lab.model.Model;
import pl.polsl.lab.model.SortModel;

/**
 * A servlet that enables user to set the array size and choose sorting
 * algorithm.
 *
 * @author Mateusz Chłopek
 * @version 1.1
 */
public class SortingSetup extends HttpServlet {

    /**
     * An object that represent model in project and is responsible for sorting.
     */
    private Model model;
    /**
     * A chosen size of an array.
     */
    private int size;
    /**
     * A command given to a model.
     */
    private Commands command;

    /**
     * A methode to write out styles in html
     *
     * @param out PrintWriter for writing in html
     */
    private void writeStyle(PrintWriter out) {
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

        out.println("#p1");
        out.println("{");

        out.println("border-radius: 0.6em;");
        out.println("background-color: #000080;");
        out.println("margin-left: auto;");
        out.println("margin-right: auto;");
        out.println("margin-bottom: 2vh;");
        out.println("margin-top: auto;");
        out.println("padding-left: 2vw;");
        out.println("text-align: left;");
        out.println("width: 42vw;");
        out.println("font-size: 1.5em;");

        out.println("}");

        out.println("#checks");
        out.println("{");

        out.println("border-radius: 0.4em;");
        out.println("background-color: #000080;");
        out.println("margin-left: auto;");
        out.println("margin-right: auto;");
        out.println("text-align: left;");
        out.println("width: 22vw;");
        out.println("font-size: 1.1em;");

        out.println("}");

        out.println("#p2");
        out.println("{");

        out.println("border-radius: 1em;");
        out.println("background-color: #000080;");
        out.println("margin-left: auto;");
        out.println("margin-right: auto;");
        out.println("text-align: center;");
        out.println("width: 15vw;");
        out.println("font-size: 1.3em;");

        out.println("}");

        out.println("#fields");
        out.println("{");

        out.println("border-radius: 0.4em;");
        out.println("background-color: #000080;");
        out.println("margin-left: auto;");
        out.println("margin-right: auto;");
        out.println("text-align: center;");
        out.println("width: 18vw;");
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
    }

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
            response.setContentType("text/html;charset=UTF-8");
            PrintWriter out = response.getWriter();
            out.println("<!DOCTYPE html>");
            out.println("<html>");
            out.println("<head>");
            out.println("<title>Servlet SortingSetup</title>");
            out.println("</head>");

            writeStyle(out);

            out.println("<body bgcolor=\"black\">");
            out.println("<div id=\"div\">");

            String sizeP = request.getParameter("size");
            String commandP = request.getParameter("algorithm");
            try { //checking for sorting parameters
                if (sizeP != null && commandP != null) {
                    if (sizeP.length() == 0 || commandP.length() == 0) //size of array
                    {
                        throw new NumberFormatException();
                    }
                    size = Integer.parseInt(request.getParameter("size"));

                    if (size < 0) {
                        throw new NumberFormatException();
                    }
                    request.getSession().setAttribute("size", size);

                    //sorting algorithm
                    switch (request.getParameter("algorithm")) {
                        default:
                            command = Commands.COMMAND_START_BUBBLE;
                            request.getSession().setAttribute("algorithm", "Bąbelkowe");
                            break;
                        case "bogo":
                            command = Commands.COMMAND_START_BOGO;
                            request.getSession().setAttribute("algorithm", "Bogo");
                            break;
                        case "insertion":
                            command = Commands.COMMAND_START_INSERTION;
                            request.getSession().setAttribute("algorithm", "Przez wstawianie");
                            break;
                    }

                    model = new SortModel(command, size);
                    request.getSession().setAttribute("model", model);
                }
            } catch (NumberFormatException exception) {
                out.println("<p id=\"exception\">WYJĄTEK!<br>Proszę wybrać sposób sortowania oraz wpisać poprawny rozmiar tablicy - liczba całkowita, nieujemna!</p>");
            }

            model = (SortModel) request.getSession().getAttribute("model");
            String sizeS;
            String algorithmS;
            if (model != null) {
                if (request.getSession().getAttribute("size") == null) {
                    sizeS = "20";
                } else {
                    sizeS = request.getSession().getAttribute("size").toString();
                }
                if (request.getSession().getAttribute("algorithm") == null) {
                    algorithmS = "Bąbelkowe";
                } else {
                    algorithmS = request.getSession().getAttribute("algorithm").toString();
                }
            } else {
                sizeS = algorithmS = "";
            }

            out.println("<p id=\"p1\">");
            out.println("Aktualnie wybrany rozmiar tablicy: " + sizeS);
            out.println("<br>");
            out.println("Aktualnie wybrany algorytm: " + algorithmS);
            out.println("</p>");

            out.println("<form action=\"SortingSetup\">");
            out.println("<p id=\"fields\">Rozmiar: <input type=text size=20 name=size></p>");
            out.println("<p id=\"checks\">");
            out.println("<input type=\"radio\" name=\"algorithm\" value=\"bubble\"> Sortowanie bąbelkowe");
            out.println("<br>");
            out.println("<input type=\"radio\" name=\"algorithm\" value=\"bogo\"> Sortowanie Bogo");
            out.println("<br>");
            out.println("<input type=\"radio\" name=\"algorithm\" value=\"insertion\"> Sortowanie przez wstawianie");
            out.println("</p>");
            out.println("<input id=\"button\" type=\"submit\" value=\"Zatwierdź\">");
            out.println("</form>");

            out.println("<p id=\"p2\">");
            out.println("Powrót do menu:");
            out.println("</p>");

            out.println("<form action=\"Menu\">");
            out.println("<input id=\"button\" type=\"submit\" value=\"Wróć\">");
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
