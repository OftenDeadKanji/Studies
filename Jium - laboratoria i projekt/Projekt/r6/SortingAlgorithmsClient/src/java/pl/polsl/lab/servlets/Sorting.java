/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.servlets;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;
import javax.persistence.NoResultException;
import javax.servlet.ServletException;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.xml.ws.WebServiceRef;
import pl.polsl.lab.services.Algorithms;
import pl.polsl.lab.services.Numbers;
import pl.polsl.lab.services.SortingAlgorithmsService_Service;

/**
 * A servlet that shows the process of array sorting. It refreshes itself every
 * second.
 *
 * @author Mateusz Chłopek
 * @version 1.2
 */
public class Sorting extends HttpServlet {

    @WebServiceRef(wsdlLocation = "WEB-INF/wsdl/localhost_8080/SortingAlgorithmsService/SortingAlgorithmsService.wsdl")
    private SortingAlgorithmsService_Service service;

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

        response.setContentType("text/html;charset=UTF-8");
        response.setHeader("Refresh", "1");

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
            out.println("<title>Sorting algorithms visualisation</title>");
            out.println("</head>");

            writeStyle(out);

            out.println("<body bgcolor=\"black\">");
            out.println("<div id=\"div\">");

            out.println("<p id=\"p1\">");
            out.println("Back to menu:");
            out.println("</p>");

            out.println("<form action=\"Menu\">");
            out.println("<input id=\"button\" type=\"submit\" value=\"Back\">");
            out.println("</form>");

            if (request.getParameter("tableID") == null || request.getParameter("tableID").isEmpty()) {
                return;
            }
            try {
                int tableID = Integer.parseInt(request.getParameter("tableID"));

                List<Numbers> tableContent = getSortingTableContent(tableID);
                Algorithms algorithm = getAlgorithm(tableID);
                
                //displaying current array
                for (int i = 0; i < tableContent.size(); i++) {
                    //right order of numbers to display
                    for (int j = 0; j < tableContent.size(); j++) {
                        if (tableContent.get(j).getIndex() == i) {
                            if (algorithm.getState() != 0 && tableContent.get(j).isIsPointedAt()) {
                                //number that is currently 'pointed at' is in bold
                                out.println("<b>" + tableContent.get(j).getValue() + " </b>");
                            } else if (algorithm.getState() != 0) {
                                //other in normaln way
                                out.println(tableContent.get(j).getValue() + " ");
                            } else {
                                //all in green if table has been sorted
                                out.println("<font color=#00e600><b>" + tableContent.get(j).getValue() + "</b></font> ");
                            }
                        }
                    }
                }

                sort(tableID);

                //refreshing session
                request.getSession();
            } catch (NoResultException exception) {
                out.println("<p id=\"exception\"> No table with such ID!</p>");
            } catch (NumberFormatException exception) {
                System.err.println(exception.getMessage());
            }

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

    private void sort(int tableID) {
        // Note that the injected javax.xml.ws.Service reference as well as port objects are not thread safe.
        // If the calling of port operations may lead to race condition some synchronization is required.
        pl.polsl.lab.services.SortingAlgorithmsService port = service.getSortingAlgorithmsServicePort();
        port.sort(tableID);
    }

    private java.util.List<pl.polsl.lab.services.Numbers> getSortingTableContent(int tableID) {
        // Note that the injected javax.xml.ws.Service reference as well as port objects are not thread safe.
        // If the calling of port operations may lead to race condition some synchronization is required.
        pl.polsl.lab.services.SortingAlgorithmsService port = service.getSortingAlgorithmsServicePort();
        return port.getSortingTableContent(tableID);
    }

    private Algorithms getAlgorithm(int tableID) {
        // Note that the injected javax.xml.ws.Service reference as well as port objects are not thread safe.
        // If the calling of port operations may lead to race condition some synchronization is required.
        pl.polsl.lab.services.SortingAlgorithmsService port = service.getSortingAlgorithmsServicePort();
        return port.getAlgorithm(tableID);
    }

}
