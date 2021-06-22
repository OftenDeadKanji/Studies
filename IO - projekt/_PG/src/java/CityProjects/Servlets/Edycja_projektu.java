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
@WebServlet(name = "Edycja_projektu", urlPatterns = {"/Edycja_projektu"})
public class Edycja_projektu extends HttpServlet {

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
        if (zalogowany == 'u') {

            try (PrintWriter out = response.getWriter()) {
                template.startHTML(out);

                String IDP_string = request.getParameter("IDP");
                long IDP = -1;
                try {
                    IDP = Long.parseLong(IDP_string);
                } catch (NumberFormatException e) {
                    out.println("<h2 style=\"color: #BB1245;\">");
                    out.println("Błąd przetwarzania danych");
                    out.println("</h2>");
                    out.println("<form method=POST action=Lista_projektow>");
                    out.println("<input type=submit value=\"Powrót\">");
                    out.println("</form>");
                }

                String tytul_projektu = "Projekt " + IDP;
                String opis_projektu = "Opis projektu";
                String dzielnica_projektu = "Dzielnica";
                int koszt = 10000;
                String czas_trwania = "150dni";
                String data_glosowania = "2020/2021";

                out.println("<div id=\"PROJEKT\">");

                out.println("<form method=POST action=zmien_tytul>");
                out.println("<input name=\"nowy_tytul_projektu\" type=text value=\"" + tytul_projektu + "\"/>");
                out.println("<input name=\"IDP\" value=" + IDP + " style=\"display: none;\"/>"); // to już jest znane
                out.println("<input type=submit value=\"Zmień tytuł\"/><br>");
                out.println("</form><br>");

                out.println("<form method=POST action=zmien_opis>");
                out.println("<textarea name=\"nowy_opis_projektu\" rows=\"5\" cols=\"50\">" + opis_projektu + "</textarea>");
                out.println("<input name=\"IDP\" value=" + IDP + " style=\"display: none;\"/>"); // to już jest znane
                out.println("<input type=submit value=\"Zmień opis\"/><br>");
                out.println("</form><br>");

                out.println("<form method=POST action=zmien_dzielnice>");
                out.println("<input name=\"nowa_dzielnica\" type=text value=\"" + dzielnica_projektu + "\"/>");
                out.println("<input name=\"IDP\" value=" + IDP + " style=\"display: none;\"/>"); // to już jest znane
                out.println("<input type=submit value=\"Zmień dzielnicę\"/><br>");
                out.println("</form><br>");

                out.println("<form method=POST action=zmien_koszt>");
                out.println("<input name=\"nowy_koszt\" type=number value=\"" + koszt + "\"/>");
                out.println("<input name=\"IDP\" value=" + IDP + " style=\"display: none;\"/>"); // to już jest znane
                out.println("<input type=submit value=\"Zmień koszt\"/><br>");
                out.println("</form><br>");

                out.println("<form method=POST action=zmien_czas_trwania>");
                out.println("<input name=\"nowy_czas_trwania\" type=text value=\"" + czas_trwania + "\"/>");
                out.println("<input name=\"IDP\" value=" + IDP + " style=\"display: none;\"/>"); // to już jest znane
                out.println("<input type=submit value=\"Zmień czas trwania\"/><br>");
                out.println("</form><br>");

                out.println("<form method=POST action=zmien_date_glosowania>");
                out.println("<input name=\"nowa_data_glosowania\" type=text value=\"" + data_glosowania + "\"/>");
                out.println("<input name=\"IDP\" value=" + IDP + " style=\"display: none;\"/>"); // to już jest znane
                out.println("<input type=submit value=\"Zmień datę głosowania\"/><br>");
                out.println("</form><br>");

                out.println("<ul>");
                // w pętli wypisane wszystkie załączniki dla danego projektu
                for (int z = 0; z < 3; z++) {
                    String link = "#";//link do materiałów
                    String nazwa_zalacznika = "Załącznik_" + z;
                    out.println("<li><a href=\"" + link + "\">" + nazwa_zalacznika + "</a></li>");
                    out.println("<form method=POST action=usun_zalacznik>");
                    long IDZ = 0; // Id załącznika 
                    out.println("<input name=\"IDZ\" value=" + IDZ + " style=\"display: none;\"/>");
                    out.println("<input name=\"IDP\" value=" + IDP + " style=\"display: none;\"/>"); // to już jest znane
                    out.println("<input type=submit value=\"Usuń załącznik\"/>");
                    out.println("</form><br>");
                }
                out.println("</ul>");

                out.println("<form method=POST action=dodaj_zalacznik>");
                out.println("<input name=\"nazwa_zalacznika\" type=text placeholder=\"Nazwa załącznika\"/>");
                out.println("<input name=\"link_zalacznika\" type=text placeholder=\"Link\"/>");
                out.println("<input name=\"IDP\" value=" + IDP + " style=\"display: none;\"/>"); // to już jest znane
                out.println("<input type=submit value=\"Dodaj załącznik\"/><br>");
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
