package pl.polsl.lab.servlets;

import javax.servlet.*;
import javax.servlet.http.*;
import java.io.*;

/**
 * Main class of the servlet generating the answer in form of a image in GIF
 * standard
 * 
 * @author Gall Anonim
 * @version 1.0
 */
public class GIFServlet extends HttpServlet {

    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param req servlet request
     * @param resp servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    public void doGet(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException {
        try {
            String GIFfile = getServletContext().getRealPath("/WEB-INF/images/duke_swinging.gif");
            resp.setContentType("image/gif");
            FileInputStream in = new FileInputStream(GIFfile);
            ServletOutputStream out = resp.getOutputStream();
            byte buffer[] = new byte[512];
            int length;
            while ((length = in.read(buffer)) != -1) {
                out.write(buffer, 0, length);
            }
        } catch (IOException e) {
            resp.setContentType("text/plain; charset=ISO-8859-2");
            PrintWriter out = resp.getWriter();
            out.write("Read error!!!");
        }
    }
}
