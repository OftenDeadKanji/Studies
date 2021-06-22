/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.servlets;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.xml.ws.WebServiceRef;
import pl.polsl.lab.services.SortingAlgorithmsService_Service;
import pl.polsl.lab.services.SortingTables;

/**
 * A servlet class that shows Sorting Tables in DB to a user.
 *
 * @author Mateusz Chłopek
 * @version 1.1
 */
public class SortingTablesList extends HttpServlet {

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

        out.println("#table");
        out.println("{");

        out.println("background-color: #000080;");
        out.println("margin-left: auto;");
        out.println("margin-right: auto;");
        out.println("margin-bottom: 2vh;");
        out.println("margin-top: auto;");
        out.println("text-align: center;");

        out.println("}");

        out.println("#firstRow");
        out.println("{");

        out.println("background-color: #000080;");
        out.println("margin-left: auto;");
        out.println("margin-right: auto;");
        out.println("text-align: center;");
        out.println("width: 40vw;");
        out.println("font-size: 1.3em;");

        out.println("}");

        out.println("#row");
        out.println("{");

        out.println("background-color: #000099;");
        out.println("margin-left: auto;");
        out.println("margin-right: auto;");
        out.println("text-align: center;");
        out.println("width: 10vw;");
        out.println("font-size: 1.1em;");

        out.println("}");

        out.println("#IDColumn");
        out.println("{");

        out.println("margin-left: auto;");
        out.println("margin-right: auto;");
        out.println("text-align: center;");
        out.println("width: 4vw;");
        out.println("font-size: 1em;");

        out.println("}");

        out.println("#SizeColumn");
        out.println("{");

        out.println("margin-left: auto;");
        out.println("margin-right: auto;");
        out.println("text-align: center;");
        out.println("width: 8vw;");
        out.println("font-size: 1em;");

        out.println("}");

        out.println("#AlgorithmColumn");
        out.println("{");

        out.println("margin-left: auto;");
        out.println("margin-right: auto;");
        out.println("text-align: center;");
        out.println("width: 12vw;");
        out.println("font-size: 1em;");

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
        try (PrintWriter out = response.getWriter()) {
            out.println("<!DOCTYPE html>");
            out.println("<html>");
            out.println("<head>");
            out.println("<title>Sorting algorithms visualisation</title>");
            out.println("</head>");

            writeStyle(out);

            out.println("<body bgcolor=\"black\">");
            out.println("<div id=\"div\">");

            try {

                List<SortingTables> tables = getAllSortingTables();

                request.getSession().setAttribute("sortingTablesList", tables);
                request.setAttribute("sortingTablesList", tables);

                out.println("<table id=\"table\" border=\"3\">\n"
                        + "<tr id=\"firstRow\">\n"
                        + "    <th id=\"IDColumn\">ID</th>\n"
                        + "    <th id=\"SizeColumn\">Size</th>\n"
                        + "    <th id=\"AlgorithmColumn\">Algorithm</th>\n"
                        + "</tr>");

                for (int i = 0; i < tables.size(); i++) {
                    out.println("<tr id=\"row\">");

                    out.println("<td id=\"IDColumn\">");
                    out.println(tables.get(i).getId());
                    out.println("</td>");

                    out.println("<td id=\"SizeColumn\">");
                    out.println(tables.get(i).getSize());
                    out.println("</td>");

                    out.println("<td id=\"AlgorithmColumn\">");
                    out.println(tables.get(i).getAlgorithm());
                    out.println("</td>");

                    out.println("</tr>");
                }

                out.println("</table>");
            } catch (Exception ex) {
                throw new ServletException(ex);
            }

            out.println("<form action=\"Menu\">");
            out.println("<input id=\"button\" type=\"submit\" value=\"Back\">");
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

    private java.util.List<pl.polsl.lab.services.SortingTables> getAllSortingTables() {
        // Note that the injected javax.xml.ws.Service reference as well as port objects are not thread safe.
        // If the calling of port operations may lead to race condition some synchronization is required.
        pl.polsl.lab.services.SortingAlgorithmsService port = service.getSortingAlgorithmsServicePort();
        return port.getAllSortingTables();
    }
}
