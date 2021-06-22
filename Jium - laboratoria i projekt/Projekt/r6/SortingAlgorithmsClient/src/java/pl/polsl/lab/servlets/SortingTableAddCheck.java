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
import javax.xml.ws.WebServiceRef;
import pl.polsl.lab.services.SortingAlgorithmsService_Service;

/**
 * A servlet class that checks the sorting table parameters and if they are
 * correct, creates it, algorithm and number. Then it inserts them into the DB.
 *
 * @author Mateusz Chłopek
 * @version 1.1
 */
public class SortingTableAddCheck extends HttpServlet {

    @WebServiceRef(wsdlLocation = "WEB-INF/wsdl/localhost_8080/SortingAlgorithmsService/SortingAlgorithmsService.wsdl")
    private SortingAlgorithmsService_Service service;


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
            out.println("<body>");

            try {
                //checking size - if it exists
                String sizeInStr = request.getParameter("size");
                if (sizeInStr == null || sizeInStr.isEmpty()) {
                    request.setAttribute("exceptionMessage", "Wrong parameters!");
                } else {
                    try {
                        //checking size - if it's int
                        int sizeIn = Integer.parseInt(sizeInStr);

                        //checking algorithm name - if it's correct
                        String algorithmIn = (String) request.getParameter("algorithm");

                        if (!algorithmIn.toUpperCase().equals("BUBBLE") && !algorithmIn.toUpperCase().equals("BOGO") && !algorithmIn.toUpperCase().equals("INSERTION")) {
                            request.setAttribute("exceptionMessage", "Wrong parameters!");
                        } else { //everything is correct -> adding to DB
                            addSortingTable(sizeIn, algorithmIn);
                        }
                    } catch (NumberFormatException exception) {
                        request.setAttribute("exceptionMessage", "Wrong parameters!");
                    }
                }

                request.getRequestDispatcher("AddSortingTable").forward(request, response);
            } catch (IOException | ServletException ex) {
                System.err.println(ex.getMessage());
            }
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

    private Boolean addSortingTable(int size, java.lang.String algorithm) {
        // Note that the injected javax.xml.ws.Service reference as well as port objects are not thread safe.
        // If the calling of port operations may lead to race condition some synchronization is required.
        pl.polsl.lab.services.SortingAlgorithmsService port = service.getSortingAlgorithmsServicePort();
        return port.addSortingTable(size, algorithm);
    }
}
