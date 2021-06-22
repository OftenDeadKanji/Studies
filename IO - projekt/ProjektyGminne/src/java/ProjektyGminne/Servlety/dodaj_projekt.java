/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ProjektyGminne.Servlety;

import ProjektyGminne.Servlety.HTML_Template.HTML_Template;
import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

/**
 *
 * @author Kanjiklub
 */
public class dodaj_projekt extends HttpServlet {

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
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
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
        if (zalogowany == 'u') {
            try (PrintWriter out = response.getWriter()) {
                template.startHTML(out);
                
                out.println("<div id=\"PROJEKT\">");

                out.println("<form method=POST action=wstaw_nowy_projekt>");
                
                out.println("Tytuł projektu:<br><input name=\"tytul_projektu\" type=text value=\"tytuł_projektu\"/><br>");
                out.println("Opis projektu:<br><textarea name=\"opis_projektu\" rows=\"5\" cols=\"50\">opis_projektu</textarea><br>");
                out.println("Dzielnica miasta:<br><input name=\"dzielnica\" type=text value=\"dzielnica_projektu\"/><br>");
                out.println("Koszt projektu:<br><input name=\"koszt\" type=number value=\"koszt\"/><br>");
                out.println("Przybliżony czas trwania wprowadzania projektu:<br><input name=\"czas_trwania\" type=text value=\"czas_trwania\"/><br>");
                //out.println("<input name=\"data_glosowania\" type=text value=\"data_glosowania\"/><br>");
                out.println("Nazwa pliku i link do załącznika:<br><input name=\"nazwa_zalacznika\" type=text placeholder=\"Nazwa załącznika\"/>");
                out.println("<input name=\"link_zalacznika\" type=text placeholder=\"Link\"/><br>");
                
                out.println("<input type=submit value=\"Dodaj nowy projekt\"/><br>");
                out.println("</form><br>");
                
                out.println("<form method=POST action=Lista_projektow>");
                out.println("<input type=submit value=\"Powrót\">");
                out.println("</form>");
                out.println("</div>");
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
