/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ProjektyGminne.Servlety;

import ProjektyGminne.Encje.Projekty;
import ProjektyGminne.Encje.Załączniki;
import ProjektyGminne.Servlety.HTML_Template.HTML_Template;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author Frogi
 */
@WebServlet(name = "Archiwum", urlPatterns = {"/Archiwum"})
public class Archiwum extends HttpServlet {

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
        try (PrintWriter out = response.getWriter()) {
            template.startHTML(out);
            out.println("<h1>Wyniki głosowania</h1>");

            EntityManagerFactory emf = Persistence.createEntityManagerFactory("ProjektyGminnePU");
            EntityManager em = emf.createEntityManager();
            
            // Zapytanie do bd o listę projektów
            List<Projekty> projekty = em.createNamedQuery("Projekty.findAll").getResultList();
            List<Projekty> zakonczone = new ArrayList<>();
            for (int i=0;i<projekty.size();i++) {
                if (projekty.get(i).getCzyZakonczony()) {
                    zakonczone.add(projekty.get(i));
                }
            }

            // w pętli for wypisanie wszystkich, zakończonych projektów
            for (Projekty p : zakonczone) {
                String tytul_projektu = "Projekt " + p.getNazwa();
                String opis_projektu = p.getDzielnica() + " " + p.getCzasTrwania() + " " + p.getKoszt().toString();
                String edycja = p.getDataGłosowania();
                boolean wprowadzony = p.getCzyWprowadzony();

                out.println("<div id=\"PROJEKT\">");
                out.println("<h2>" + tytul_projektu + "</h2>");
                out.println("<p>" + opis_projektu + "<p>");
                out.println("<p>Edycja: " + edycja + "<p>");
                
                if (wprowadzony) {
                    out.println("<p>Wprowadzony</p>");
                } else {
                    out.println("<p>Niewprowadzony</p>");
                }
                out.println("<ul>");
                // w pętli wypisane wszystkie załączniki dla danego projektu
                List<Załączniki> zalaczniki = em.createNamedQuery("Załączniki.findAll").getResultList();
                for (int i =0;i<zalaczniki.size();i++) {
                    if (zalaczniki.get(i).getIdP() == p) {
                        String link = zalaczniki.get(i).getŚcieżkaZasobu();
                        String nazwa_zalacznika = zalaczniki.get(i).getNazwa();
                        out.println("<li><a href=\"" + link + "\">" + nazwa_zalacznika + "</a></li>");
                    }
                }
                out.println("</ul>");
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
