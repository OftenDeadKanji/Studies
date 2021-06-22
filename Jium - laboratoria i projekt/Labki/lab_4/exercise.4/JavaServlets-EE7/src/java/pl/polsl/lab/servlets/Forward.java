package pl.polsl.lab.servlets;

import javax.servlet.*;
import javax.servlet.http.*;
import java.io.*;

/**
 * Main class of the servlet that demonstrates communicaton between servlets and
 * the ways of redirecting the request
 * 
 * @author Gall Anonim
 * @version 1.0
 */
public class Forward extends HttpServlet {

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param req servlet request
     * @param resp servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    public void doPost(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException {
        String action = req.getParameter("data");

        if (action.equals("date")) {
            resp.setContentType("text/plain; charset=ISO-8859-2");
            PrintWriter out = resp.getWriter();

            out.println("Current date:");
            getServletContext().getRequestDispatcher("/UserDate").include(req, resp);
        } else // action == "page"
        {
            String url = req.getParameter("address");

            if ((url.length() == 0) || url.equals("http://")) {
                getServletContext().getRequestDispatcher("/Error").forward(req, resp);
            } else {
                resp.sendRedirect(url);
            }
        }
    }

    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    public void doGet(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException {
        getServletContext().getRequestDispatcher("/Error").forward(req, resp);
    }
}
