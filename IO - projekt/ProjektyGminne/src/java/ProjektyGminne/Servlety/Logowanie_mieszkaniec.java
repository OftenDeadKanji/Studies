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
@WebServlet(name = "Logowanie_mieszkaniec", urlPatterns = {"/Logowanie_mieszkaniec"})
public class Logowanie_mieszkaniec extends HttpServlet {

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

        try (PrintWriter out = response.getWriter()) {
            template.startHTML(out);

            try {
                String login = request.getParameter("login");
                String haslo = request.getParameter("haslo");

                if (login.length() == 0 || haslo.length() == 0) {
                    out.println("<h2 style=\"color: #BB1245;\">");
                    out.println("Nie można zostawić pustego pola!");
                    out.println("</h2>");
                    out.println("<form method=POST action=logowanie_mieszkaniec.html>");
                    out.println("<input type=submit value=\"Powrót\">");
                    out.println("</form>");
                }

                //sprawdzenie czy istnieje w bd konto o takim loginie i haśle
                EntityManagerFactory emf = Persistence.createEntityManagerFactory("ProjektyGminnePU");
                EntityManager em = emf.createEntityManager();

                try {
                    //pobranie mieszkańca o takim loginie
                    Mieszkańcy mieszkaniec = (Mieszkańcy) em.createNamedQuery("Mieszkańcy.findByLogin").setParameter("login", login).getSingleResult();
                    //sprawdzenie hasła
                    if (!haslo.equals(mieszkaniec.getHasło())) {
                        //błędne hasło
                        out.println("<h2 style=\"color: #BB1245;\">");
                        out.println("Błędne hasło!");
                        out.println("</h2>");
                        out.println("<form method=POST action=logowanie_mieszkaniec.html>");
                        out.println("<input type=submit value=\"Powrót\">");
                        out.println("</form>");
                    } else {
                        //poprawne hasło
                        sesja.setAttribute("zalogowany", 'm');
                        sesja.setAttribute("ID", (long) mieszkaniec.getIdM()); // tutaj IDM z tabeli mieszkańcy
                        response.sendRedirect("index.html");
                    }
                } catch (NoResultException e) {
                    //brak mieszkańca o takim loginie
                    out.println("<h2 style=\"color: #BB1245;\">");
                    out.println("Niepoprawny login!");
                    out.println("</h2>");
                    out.println("<form method=POST action=logowanie_mieszkaniec.html>");
                    out.println("<input type=submit value=\"Powrót\">");
                    out.println("</form>");
                }
            } catch (IOException ex) {
                out.println(ex.getMessage());
            }
            out.println();
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
