/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.servlets;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import javax.annotation.Resource;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.PersistenceUnit;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.transaction.UserTransaction;
import pl.polsl.lab.entities.Algorithms;
import pl.polsl.lab.entities.Numbers;
import pl.polsl.lab.entities.SortingTables;

/**
 * A servlet class that checks the sorting table parameters and if they are
 * correct, creates it, algorithm and number. Then it inserts them into the DB.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class SortingTableAddCheck extends HttpServlet {

    /**
     * An entity manager factory that is used to get rows from DB.
     */
    @PersistenceUnit
    private EntityManagerFactory emf;

    /**
     * An object to handle DB transactions
     */
    @Resource
    private UserTransaction utx;

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
        response.setContentType("text/html;charset=UTF-8");
        try (PrintWriter out = response.getWriter()) {
            out.println("<!DOCTYPE html>");
            out.println("<html>");
            out.println("<head>");
            out.println("<title>Servlet SortingTableAddCheck</title>");
            out.println("</head>");
            out.println("<body>");

            assert emf != null;
            EntityManager em = null;
            try {
                String sizeInStr = request.getParameter("size");
                if (sizeInStr == null || sizeInStr.isEmpty()) {
                    request.setAttribute("exceptionMessage", "Wrong parameters!");
                } else {
                    try {
                        int sizeIn = Integer.parseInt(sizeInStr);
                        String algorithmIn = (String) request.getParameter("algorithm");

                        SortingTables table = new SortingTables(sizeIn, algorithmIn);
                        Algorithms algorithm = new Algorithms(algorithmIn, table);
                        List<Numbers> numbers = new ArrayList<>();

                        for (int i = 0; i < sizeIn; i++) {
                            numbers.add(new Numbers(new Random().nextInt(sizeIn) + 1, table, i));
                        }

                        table.setAlgorithmFK(algorithm);
                        table.setContent(numbers);

                        utx.begin();
                        em = emf.createEntityManager();

                        em.persist(table);
                        em.persist(algorithm);
                        for (int i = 0; i < numbers.size(); i++) {
                            em.persist(numbers.get(i));
                        }

                        utx.commit();
                    } catch (NumberFormatException exception) {
                        request.setAttribute("exceptionMessage", "Wrong parameters!");
                    }
                }

                request.getRequestDispatcher("AddSortingTable").forward(request, response);
            } catch (Exception ex) {
                System.err.println(ex.getMessage());
            } finally {
                if (em != null) {
                    em.close();
                }
            }

            out.println("</body>");
            out.println("</html>");
        }
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
        doGet(request, response);
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
