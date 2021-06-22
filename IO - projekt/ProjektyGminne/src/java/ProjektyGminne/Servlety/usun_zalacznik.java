/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ProjektyGminne.Servlety;

import ProjektyGminne.Encje.Załączniki;
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
@WebServlet(name = "usun_zalacznik", urlPatterns = {"/usun_zalacznik"})
public class usun_zalacznik extends HttpServlet {

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
                String IDZ_string = request.getParameter("IDZ");
                long IDP = -1;
                long IDZ = -1;

                try {
                    IDP = Long.parseLong(IDP_string);
                    IDZ = Long.parseLong(IDZ_string);
                } catch (NumberFormatException e) {
                    out.println("<h2 style=\"color: #BB1245;\">");
                    out.println("Błąd przetwarzania danych");
                    out.println("</h2>");
                    out.println("<form method=POST action=Lista_projektow>"); // tutaj wracamy do listy projektów, bo jest problem z ID konkretnego projektu :/
                    out.println("<input type=submit value=\"Powrót\">");
                    out.println("</form>");
                }

                // usunięcie załącznika o id IDZ z projektu o id IDP
                EntityManagerFactory emf = Persistence.createEntityManagerFactory("ProjektyGminnePU");
                EntityManager em = emf.createEntityManager();
                
                Załączniki zalacznik = (Załączniki) em.createNamedQuery("Załączniki.findByIdZ").setParameter("idZ", IDZ).getSingleResult();
                
                em.getTransaction().begin();
                em.remove(zalacznik);
                em.getTransaction().commit();

                out.println("<h2 style=\"color: #12BB45;\">");
                out.println("Załącznik usunięty!");
                out.println("</h2>");
                out.println("<form method=POST action=Edycja_projektu>"); // Tutaj wracamy do edycji projektu o id IDP
                out.println("<input name=\"IDP\" value=" + IDP + " style=\"display: none;\"/>"); // to już jest znane
                out.println("<input type=submit value=\"Powrót\">");
                out.println("</form>");
                template.endHTML(out);
            }
        } else {
            response.sendRedirect("Lista_projektow"); // tutaj wracamy do listy projektów, bo nie jesteśmy urzędnikiem :/
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
