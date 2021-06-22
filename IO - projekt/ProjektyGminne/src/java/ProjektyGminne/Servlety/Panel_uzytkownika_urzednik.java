/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ProjektyGminne.Servlety;

import ProjektyGminne.Encje.Urzędnicy;
import ProjektyGminne.Servlety.HTML_Template.HTML_Template;
import java.io.IOException;
import java.io.PrintWriter;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
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
@WebServlet(name = "Panel_uzytkownika_urzednik", urlPatterns = {"/Panel_uzytkownika_urzednik"})
public class Panel_uzytkownika_urzednik extends HttpServlet {

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

        try (PrintWriter out = response.getWriter()) {
            template.startHTML(out);

            out.println("<h1>Panel urzędnika</h1>");
            //Odczyt z tabeli urzednicy imienia, nazwiska, id pracownika z wiersza o id ID
            EntityManagerFactory emf = Persistence.createEntityManagerFactory("ProjektyGminnePU");
            EntityManager em = emf.createEntityManager();

            Urzędnicy urzednik = (Urzędnicy) em.createNamedQuery("Urzędnicy.findByIdU").setParameter("idU", ID).getSingleResult();

            out.println("Urzędnik: " + urzednik.getImię() + " " + urzednik.getNazwisko() + "<br>");
            out.println("Pracownik numer: " + urzednik.getIdPracownika().toString() + "<br><br>");

            out.println("<form method=POST action=zmien_haslo_urzednik>");
            out.println("<input name=\"aktualne_haslo\" type=password placeholder=\"Aktualne hasło\"/><br><br>");
            out.println("<input name=\"nowe_haslo\" type=password placeholder=\"Nowe hasło\"/><br>");
            out.println("<input name=\"powtorz_haslo\" type=password placeholder=\"Powtórz hasło\"/><br><br>");
            out.println("<input type=submit value=\"Zmień hasło\"/>");
            out.println("</form><br><br><br><br>");
            out.println("<form method=POST action=wyloguj>");
            out.println("<input type=submit value=\"Wyloguj\"/><br>");
            out.println("</form>");

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
