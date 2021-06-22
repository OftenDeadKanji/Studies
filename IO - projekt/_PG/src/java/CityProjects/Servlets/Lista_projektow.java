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
@WebServlet(name = "Lista_projektow", urlPatterns = {"/Lista_projektow"})
public class Lista_projektow extends HttpServlet {

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
        // zalogowany = 'm' - mieszkaniec
        // zalogowany = 'u' - urzednik
        try (PrintWriter out = response.getWriter()) {
            template.startHTML(out);
            out.println("<h1>Archiwum projektow</h1>");
            // Zapytanie do bd o listę projektów
            // w pętli for wypisanie wszystkich, zakończonych projektów
            for (int p = 0; p < 3; p++) {
                String tytul_projektu = "Projekt " + p;
                String opis_projektu = "Opis projektu";
                String dzielnica_projektu = "Dzielnica";
                int koszt = 10000;
                String czas_trwania = "150dni";
                String data_glosowania = "26-09-2020";

                out.println("<div id=\"PROJEKT\">");
                out.println("<h2>" + tytul_projektu + "</h2>");
                out.println("<p>" + opis_projektu + "<p>");
                out.println("<p>" + dzielnica_projektu + "<p>");
                out.println("<p>" + koszt + "<p>");
                out.println("<p>" + czas_trwania + "<p>");
                out.println("<p>" + data_glosowania + "<p>");
                out.println("<ul>");
                // w pętli wypisane wszystkie załączniki dla danego projektu
                for (int z = 0; z < 3; z++) {
                    String link = "#";//link do materiałów
                    String nazwa_zalacznika = "Załącznik_" + z;
                    out.println("<li><a href=\"" + link + "\">" + nazwa_zalacznika + "</a></li>");
                }
                out.println("</ul>");
                if (zalogowany == 'u') {
                    out.println("<form method=POST action=Edycja_projektu>");
                    out.println("<input type=submit value=\"Edytuj\">");
                        long IDP = 0; // ID projektu
                        out.println("<input name=IDP value=" + IDP + " style=\"display: none\">");
                    out.println("</form>");
                } else if (zalogowany == 'm') {
                    boolean moze_glosowac = true; // odczyt z bd czy już głosował
                    if (moze_glosowac) {
                        out.println("<form method=POST action=Oddaj_glos>");
                        out.println("<input type=submit value=\"Oddaj głos\">");
                        long IDP = 0; // ID projektu
                        out.println("<input name=IDP value=" + IDP + " style=\"display: none\">");
                        out.println("</form>");
                    }
                }

                out.println("</div>");
            }
            template.endHTML(out);
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
