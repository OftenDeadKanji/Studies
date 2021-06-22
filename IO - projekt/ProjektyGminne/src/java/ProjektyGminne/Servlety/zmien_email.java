/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ProjektyGminne.Servlety;

import ProjektyGminne.Encje.Mieszkańcy;
import ProjektyGminne.Servlety.HTML_Template.HTML_Template;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
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
@WebServlet(name = "zmien_email", urlPatterns = {"/zmien_email"})
public class zmien_email extends HttpServlet {

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

                String nowy_email = request.getParameter("nowy_email");
                String haslo = request.getParameter("haslo");

                if (haslo.length() == 0 || nowy_email.length() == 0) {
                    out.println("<h2 style=\"color: #BB1245;\">");
                    out.println("Nie można zostawić pustego pola!");
                    out.println("</h2>");
                    out.println("<form method=POST action=Panel_uzytkownika>");
                    out.println("<input type=submit value=\"Powrót\">");
                    out.println("</form>");
                }
                //sprawdzenie poprawnosci hasła mieszkańca o id ID
                try {
                    Mieszkańcy mieszkaniec = (Mieszkańcy) em.createNamedQuery("Mieszkańcy.findByIdM").setParameter("idM", ID).getSingleResult();

                    if (!haslo.equals(mieszkaniec.getHasło())) {
                        //niepoprawne hasło
                        out.println("<h2 style=\"color: #BB1245;\">");
                        out.println("Błędne hasło!");
                        out.println("</h2>");
                        out.println("<form method=POST action=Panel_uzytkownika>");
                        out.println("<input type=submit value=\"Powrót\">");
                        out.println("</form>");
                    } else {
                        //poprawne hasło
                        Pattern p = Pattern.compile(".+@.+\\.[a-z]+");
                        Matcher m = p.matcher(nowy_email);
                        boolean poprawny = m.matches();
                        if (poprawny) {
                            // zmiana email mieszkańca o id ID
                            mieszkaniec.setAdresEmail(nowy_email);
                            merge(mieszkaniec);
                            
                            out.println("<h2 style=\"color: #12BB45;\">");
                            out.println("Email zmieniony!");
                            out.println("</h2>");
                            out.println("<form method=POST action=Panel_uzytkownika>");
                            out.println("<input type=submit value=\"Powrót\">");
                            out.println("</form>");
                        } else {
                            out.println("<h2 style=\"color: #BB1245;\">");
                            out.println("Zły format email!");
                            out.println("</h2>");
                            out.println("<form method=POST action=Panel_uzytkownika>");
                            out.println("<input type=submit value=\"Powrót\">");
                            out.println("</form>");
                        }
                    }
                } catch (NoResultException e) {
                    //niepoprawny login
                    out.println("<h2 style=\"color: #BB1245;\">");
                    out.println("Niepoprawny login!");
                    out.println("</h2>");
                    out.println("<form method=POST action=Panel_uzytkownika>");
                    out.println("<input type=submit value=\"Powrót\">");
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

}
