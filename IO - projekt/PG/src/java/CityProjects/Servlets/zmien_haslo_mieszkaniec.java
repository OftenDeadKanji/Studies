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
@WebServlet(name = "zmien_haslo_mieszkaniec", urlPatterns = {"/zmien_haslo_mieszkaniec"})
public class zmien_haslo_mieszkaniec extends HttpServlet {

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

                String aktualne_haslo = request.getParameter("aktualne_haslo");
                String nowe_haslo = request.getParameter("nowe_haslo");
                String powtorz_haslo = request.getParameter("powtorz_haslo");

                if (aktualne_haslo.length() == 0 || nowe_haslo.length() == 0) {
                    out.println("<h2 style=\"color: #BB1245;\">");
                    out.println("Nie mo??na zostawi?? pustego pola!");
                    out.println("</h2>");
                    out.println("<form method=POST action=Panel_uzytkownika>");
                    out.println("<input type=submit value=\"Powr??t\">");
                    out.println("</form>");
                } //sprawdzenie poprawnosci has??a mieszka??ca o id ID
                else if (aktualne_haslo.equals("admin")) {
                    if (nowe_haslo.equals(powtorz_haslo)) {
                        // zmiana has??a mieszka??ca o id ID
                        out.println("<h2 style=\"color: #12BB45;\">");
                        out.println("Has??o zmienione!");
                        out.println("</h2>");
                        out.println("<form method=POST action=Panel_uzytkownika>");
                        out.println("<input type=submit value=\"Powr??t\">");
                        out.println("</form>");
                    } else {
                        out.println("<h2 style=\"color: #BB1245;\">");
                        out.println("B????dnie powt??rzone has??o!");
                        out.println("</h2>");
                        out.println("<form method=POST action=Panel_uzytkownika>");
                        out.println("<input type=submit value=\"Powr??t\">");
                        out.println("</form>");
                    }
                } else {
                    out.println("<h2 style=\"color: #BB1245;\">");
                    out.println("B????dne has??o!");
                    out.println("</h2>");
                    out.println("<form method=POST action=Panel_uzytkownika>");
                    out.println("<input type=submit value=\"Powr??t\">");
                    out.println("</form>");
                }
                template.endHTML(out);
            }
        } else {
            response.sendRedirect("Panel_uzytkownika");
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
