/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ProjektyGminne.Servlety;

import ProjektyGminne.Encje.Mieszkańcy;
import ProjektyGminne.Encje.Projekty;
import ProjektyGminne.Encje.Załączniki;
import ProjektyGminne.Servlety.HTML_Template.HTML_Template;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.NoResultException;
import javax.persistence.Persistence;
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
            out.println("<h1>Projekty</h1>");
            if (zalogowany == 'u') {
                out.println("<form method=POST action=dodaj_projekt>");
                out.println("<input type=submit value=\"Dodaj nowy projekt\">");
                out.println("</form><br>");
            }
            // Zapytanie do bd o listę projektów
            EntityManagerFactory emf = Persistence.createEntityManagerFactory("ProjektyGminnePU");
            EntityManager em = emf.createEntityManager();

            List<Projekty> projektyWszystkie = em.createNamedQuery("Projekty.findAll").getResultList();
            List<Projekty> projekty = new ArrayList<>();
            for (int i = 0; i < projektyWszystkie.size(); i++) {
                if (!projektyWszystkie.get(i).getCzyZakonczony()) {
                    projekty.add(projektyWszystkie.get(i));
                }
            }

            // w pętli for wypisanie wszystkich projektów
            for (int i = 0; i < projekty.size(); i++) {
                Projekty p = projekty.get(i);

                String tytul_projektu = p.getNazwa();
                //String opis_projektu = p.getOpis();
                String dzielnica_projektu = p.getDzielnica();
                //int koszt = p.getKoszt();
                //String czas_trwania = p.getCzasTrwania();
                //String data_glosowania = p.getDataGłosowania();

                out.println("<div id=\"PROJEKT\">");
                out.println("<h2>" + tytul_projektu + "</h2>");
                //out.println("<p>Opis: " + opis_projektu + "<p>");
                out.println("<p>Dzielnica miasta: " + dzielnica_projektu + "<p>");
                //out.println("<p>Koszt projektu: " + koszt + " PLN<p>");
                //out.println("<p>Przybliżony czas trwania wprowadzania projektu: " + czas_trwania + "<p>");
                //out.println("<p>" + data_glosowania + "<p>");
                //out.println("<ul>");

                // w pętli wypisane wszystkie załączniki dla danego projektu
                //List<Załączniki> zalaczniki = em.createNamedQuery("Załączniki.findAll").getResultList();
                //for (Załączniki z : zalaczniki) {
                //    if (z.getIdP() == p) {
                //        String link = z.getŚcieżkaZasobu();//link do materiałów
                //        String nazwa_zalacznika = z.getNazwa();
                //        out.println("<li><a href=\"" + link + "\">" + nazwa_zalacznika + "</a></li>");
                //    }
                //}
                //out.println("</ul>");
                if (zalogowany == 'u') {
                    out.println("<form method=POST action=Edycja_projektu>");
                    out.println("<input type=submit value=\"Edytuj\">");
                    long IDP = p.getIdP(); // ID projektu
                    out.println("<input name=IDP value=" + IDP + " style=\"display: none\">");
                    out.println("</form>");
                } else if (zalogowany == 'm') {
                    out.println("<form method=POST action=Przegladaj_projekt>");
                    out.println("<input type=submit value=\"Więcej\">");
                    long IDP = p.getIdP(); // ID projektu
                    out.println("<input name=IDP value=" + IDP + " style=\"display: none\">");
                    out.println("</form>");

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
