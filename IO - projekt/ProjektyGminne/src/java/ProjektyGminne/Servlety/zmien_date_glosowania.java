/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ProjektyGminne.Servlety;

import ProjektyGminne.Encje.Operacje;
import ProjektyGminne.Encje.Projekty;
import ProjektyGminne.Encje.Urzędnicy;
import ProjektyGminne.Servlety.HTML_Template.HTML_Template;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.annotation.Resource;
import javax.persistence.EntityManager;
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
@WebServlet(name = "zmien_date_glosowania", urlPatterns = {"/zmien_date_glosowania"})
public class zmien_date_glosowania extends HttpServlet {

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
                    out.println("<form method=POST action=Lista_projektow>"); // tutaj wracamy do listy projektów, bo jest problem z ID konkretnego projektu :/
                    out.println("<input type=submit value=\"Powrót\">");
                    out.println("</form>");
                }

                String data_glosowania = request.getParameter("nowa_data_glosowania");

                if (data_glosowania.length() == 0) {
                    out.println("<h2 style=\"color: #BB1245;\">");
                    out.println("Nie można zostawić pustego pola!");
                    out.println("</h2>");
                    out.println("<form method=POST action=Edycja_projektu>"); // Tutaj wracamy do edycji projektu o id IDP
                    out.println("<input name=\"IDP\" value=" + IDP + " style=\"display: none;\"/>"); // to już jest znane
                    out.println("<input type=submit value=\"Powrót\">");
                    out.println("</form>");
                } else {
                    // zmiana daty głosowania projektu o id IDP
                    Projekty projekt = (Projekty) em.createNamedQuery("Projekty.findByIdP").setParameter("idP", IDP).getSingleResult();
                    projekt.setDataGłosowania(data_glosowania);
                    merge(projekt);
                    
                    Operacje nowaOperacja = new Operacje();
                    Urzędnicy urzednik = (Urzędnicy) em.createNamedQuery("Urzędnicy.findByIdU").setParameter("idU", ID).getSingleResult();
                    nowaOperacja.setOperacja(2, projekt, urzednik);
                    persist(nowaOperacja);
                    
                    out.println("<h2 style=\"color: #12BB45;\">");
                    out.println("Data głosowania zmieniona!");
                    out.println("</h2>");
                    out.println("<form method=POST action=Edycja_projektu>"); // Tutaj wracamy do edycji projektu o id IDP
                    out.println("<input name=\"IDP\" value=" + IDP + " style=\"display: none;\"/>"); // to już jest znane
                    out.println("<input type=submit value=\"Powrót\">");
                    out.println("</form>");
                }
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

    public void merge(Object object) {
        try {
            utx.begin();
            em.merge(object);
            utx.commit();
        } catch (Exception e) {
            Logger.getLogger(getClass().getName()).log(Level.SEVERE, "exception caught", e);
            throw new RuntimeException(e);
        }
    }

    public void persist(Object object) {
        try {
            utx.begin();
            em.persist(object);
            utx.commit();
        } catch (Exception e) {
            Logger.getLogger(getClass().getName()).log(Level.SEVERE, "exception caught", e);
            throw new RuntimeException(e);
        }
    }
}
