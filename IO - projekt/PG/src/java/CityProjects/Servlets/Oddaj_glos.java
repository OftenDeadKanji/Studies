/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package CityProjects.Servlets;

import CityProjects.Servlets.HTML_Template.HTML_Template;
import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

/**
 *
 * @author Frogi
 */
@WebServlet(name = "Oddaj_glos", urlPatterns = {"/Oddaj_glos"})
public class Oddaj_glos extends HttpServlet {

    HTML_Template template = new HTML_Template();

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");

        HttpSession sesja = request.getSession();
        char zalogowany = '0';
        long ID = -1;
        try {
            zalogowany = (char) sesja.getAttribute("zalogowany");
            ID = (long) sesja.getAttribute("ID");
        } catch (NullPointerException e) {
            response.sendRedirect("logowanie_mieszkaniec.html");
        }
        if (zalogowany == 'm') {

            try (PrintWriter out = response.getWriter()) {
                template.startHTML(out);

                String IDP_string = request.getParameter("IDP");
                long IDP = -1;
                try {
                    IDP = Long.parseLong(IDP_string);
                } catch (NumberFormatException e) {
                    out.println("<h2 style=\"color: #BB1245;\">");
                    out.println("B????d przetwarzania danych");
                    out.println("</h2>");
                    out.println("<form method=POST action=Lista_projektow>");
                    out.println("<input type=submit value=\"Powr??t\">");
                    out.println("</form>");
                }

                // operacja dodanie g??osu przez mieszka??ca o id ID
                // na projekt o id IDP
                // oraz zmiana flagi mieszka??ca, ??eby nie m??g?? wi??cej g??osowa??
                
                out.println("<h2 style=\"color: #12BB45;\">");
                out.println("Oddano g??os!");
                out.println("</h2>");
                out.println("<form method=POST action=Lista_projektow>");
                out.println("<input type=submit value=\"Powr??t\">");
                out.println("</form>");
                template.endHTML(out);
            }
        }
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
        processRequest(request, response);
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
        processRequest(request, response);
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
