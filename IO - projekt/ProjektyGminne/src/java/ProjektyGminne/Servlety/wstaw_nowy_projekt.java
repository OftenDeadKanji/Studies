/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ProjektyGminne.Servlety;

import ProjektyGminne.Encje.Operacje;
import ProjektyGminne.Encje.Projekty;
import ProjektyGminne.Encje.Urzędnicy;
import ProjektyGminne.Encje.Załączniki;
import ProjektyGminne.Servlety.HTML_Template.HTML_Template;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.annotation.Resource;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

/**
 *
 * @author Kanjiklub
 */
public class wstaw_nowy_projekt extends HttpServlet {
    
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
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
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

            //pobranie parametrów
            String tytul = request.getParameter("tytul_projektu");
            String opis = request.getParameter("opis_projektu");
            String dzielnica = request.getParameter("dzielnica");
            String kosztS = request.getParameter("koszt");
            Integer koszt = 0;
            String czas = request.getParameter("czas_trwania");
            String nazwa_zalacznika = request.getParameter("nazwa_zalacznika");
            String link = request.getParameter("link_zalacznika");
            
            if (tytul == null || tytul.isEmpty()
                    || opis == null || opis.isEmpty()
                    || dzielnica == null || dzielnica.isEmpty()
                    || kosztS == null || kosztS.isEmpty()
                    || czas == null || czas.isEmpty()) {
                out.println("<h2 style=\"color: #BB1245;\">");
                out.println("Błędne dane wejściowe!");
                out.println("</h2>");
                out.println("<form method=POST action=dodaj_projekt>");
                out.println("<input type=submit value=\"Powrót\">");
                out.println("</form>");
            } else {
                try {
                    koszt = Integer.parseInt(kosztS);
                    if (koszt < 0) {
                        throw new Exception();
                    }
                    Projekty nowyProjekt = new Projekty();
                    nowyProjekt.setProjekt(tytul, opis, dzielnica, koszt, czas, "2020", Boolean.FALSE, Boolean.FALSE);
                    persist(nowyProjekt);
                    
                    Operacje nowaOperacja = new Operacje();
                    Urzędnicy urzednik = (Urzędnicy) em.createNamedQuery("Urzędnicy.findByIdU").setParameter("idU", ID).getSingleResult();
                    nowaOperacja.setOperacja(1, nowyProjekt, urzednik);
                    
                    if (!(nazwa_zalacznika == null || nazwa_zalacznika.isEmpty() || link == null || link.isEmpty())) {
                        Załączniki nowyZalacznik = new Załączniki();
                        nowyZalacznik.setZałącznik(nazwa_zalacznika, link, nowyProjekt);
                        persist(nowyZalacznik);
                    }
                    
                    out.println("<h2 style=\"color: #12BB45;\">");
                    out.println("Dodano nowy projekt!");
                    out.println("</h2>");
                    out.println("<form method=POST action=Lista_projektow>");
                    out.println("<input type=submit value=\"Powrót\">");
                    out.println("</form>");
                } catch (Exception e) {
                    out.println("<h2 style=\"color: #BB1245;\">");
                    out.println("Błędne dane wejściowe!");
                    out.println("</h2>");
                    out.println("<form method=POST action=dodaj_projekt>");
                    out.println("<input type=submit value=\"Powrót\">");
                    out.println("</form>");
                }
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
