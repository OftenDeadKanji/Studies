/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ProjektyGminne.Servlety;

import ProjektyGminne.Encje.Głosy;
import ProjektyGminne.Encje.Mieszkańcy;
import ProjektyGminne.Encje.Projekty;
import ProjektyGminne.Servlety.HTML_Template.HTML_Template;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.annotation.Resource;
import javax.persistence.EntityManager;
import javax.persistence.NoResultException;
import javax.persistence.PersistenceContext;
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

    @PersistenceContext(unitName = "ProjektyGminnePU")
    private EntityManager em;
    @Resource
    private javax.transaction.UserTransaction utx;

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
                
                // operacja dodanie głosu przez mieszkańca o id ID
                // na projekt o id IDP
                // oraz zmiana flagi mieszkańca, żeby nie mógł więcej głosować
                Mieszkańcy mieszkaniec = (Mieszkańcy) em.createNamedQuery("Mieszkańcy.findByIdM").setParameter("idM", ID).getSingleResult();
                Projekty projekt = (Projekty) em.createNamedQuery("Projekty.findByIdP").setParameter("idP", IDP).getSingleResult();
                
                //stworzenie i dodanie głosu
                Głosy nowyGlos = new Głosy();
                nowyGlos.setGłos(new Date(), mieszkaniec, projekt);
                persist(nowyGlos);
                
                //zmiana mieszkańca
                mieszkaniec.setCzyZagłosował(true);
                merge(mieszkaniec);
                
                } catch (NumberFormatException | NoResultException e) {
                    out.println("<h2 style=\"color: #BB1245;\">");
                    out.println("Błąd przetwarzania danych");
                    out.println("</h2>");
                    out.println("<form method=POST action=Lista_projektow>");
                    out.println("<input type=submit value=\"Powrót\">");
                    out.println("</form>");
                }
                
                out.println("<h2 style=\"color: #12BB45;\">");
                out.println("Oddano głos!");
                out.println("</h2>");
                out.println("<form method=POST action=Lista_projektow>");
                out.println("<input type=submit value=\"Powrót\">");
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

    private void persist(Object object) {
        try {
            utx.begin();
            em.persist(object);
            utx.commit();
        } catch (Exception e) {
            Logger.getLogger(getClass().getName()).log(Level.SEVERE, "exception caught", e);
            throw new RuntimeException(e);
        }
    }
    
    private void merge(Object object) {
        try {
            utx.begin();
            em.merge(object);
            utx.commit();
        } catch (Exception e) {
            Logger.getLogger(getClass().getName()).log(Level.SEVERE, "exception caught", e);
            throw new RuntimeException(e);
        }
    }

}
