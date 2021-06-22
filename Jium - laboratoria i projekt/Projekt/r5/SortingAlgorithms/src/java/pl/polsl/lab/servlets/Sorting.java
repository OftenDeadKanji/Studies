/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.servlets;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;
import javax.annotation.Resource;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.NoResultException;
import javax.persistence.PersistenceUnit;
import javax.servlet.ServletException;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.transaction.UserTransaction;
import pl.polsl.lab.entities.Algorithms;
import pl.polsl.lab.entities.Numbers;
import pl.polsl.lab.entities.SortingTables;
import pl.polsl.lab.enums.Commands;
import pl.polsl.lab.model.*;

/**
 * A servlet that shows the process of array sorting. It refreshes itself every
 * seconde.
 *
 * @author Mateusz Chłopek
 * @version 1.1
 */
public class Sorting extends HttpServlet {

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
    /**
     * An object that represent model in project and is responsible for sorting.
     */
    private SortModel model;

    /**
     * A methode to write out styles in html
     *
     * @param out PrintWriter for writing in html
     */
    private void writeStyle(PrintWriter out) {
        out.println("<style>");

        out.println("#div");
        out.println("{");

        out.println("border-radius: 40px;");
        out.println("background-color: #00004d;");
        out.println("margin-left: auto;");
        out.println("margin-right: auto;");
        out.println("padding-top: 2vh;");
        out.println("padding-bottom: 2vh;");
        out.println("text-align: center;");
        out.println("width: 70vw;");
        out.println("color: white;");
        out.println("font-size: 20px;");
        out.println("font-family: Courier New, Courier, Lucida Sans Typewriter, Lucida Typewriter,monospace;");

        out.println("}");

        out.println("#p1");
        out.println("{");

        out.println("border-radius: 1em;");
        out.println("background-color: #000080;");
        out.println("margin-left: auto;");
        out.println("margin-right: auto;");
        out.println("margin-bottom: 2vh;");
        out.println("margin-top: auto;");
        out.println("text-align: center;");
        out.println("width: 14vw;");
        out.println("font-size: 1.2em;");

        out.println("}");

        out.println("#p2");
        out.println("{");

        out.println("border-radius: 1em;");
        out.println("background-color: #000080;");
        out.println("margin-left: auto;");
        out.println("margin-right: auto;");
        out.println("text-align: center;");
        out.println("width: 25vw;");
        out.println("font-size: 1.8em;");

        out.println("}");

        out.println("#exception");
        out.println("{");

        out.println("border-radius: 0.6em;");
        out.println("background-color: #000080;");
        out.println("margin-left: auto;");
        out.println("margin-right: auto;");
        out.println("margin-bottom: 2vh;");
        out.println("margin-top: auto;");
        out.println("text-align: center;");
        out.println("width: 68vw;");
        out.println("font-size: 2em;");

        out.println("}");

        out.println("#array");
        out.println("{");

        out.println("border-radius: 1em;");
        out.println("background-color: #000080;");
        out.println("margin-left: auto;");
        out.println("margin-right: auto;");

        out.println("padding-top: 1vh;");
        out.println("padding-bottom: 1vh;");

        out.println("text-align: center;");
        out.println("width: 60vw;");
        out.println("font-size: 1em;");

        out.println("}");

        out.println("#fields");
        out.println("{");

        out.println("border-radius: 1em;");
        out.println("background-color: #000080;");
        out.println("margin-left: auto;");
        out.println("margin-right: auto;");
        out.println("text-align: center;");
        out.println("width: 15vw;");
        out.println("font-size: 1.0em;");

        out.println("}");

        out.println("#button");
        out.println("{");

        out.println("border-radius: 1em;");
        out.println("background-color: #000080;");
        out.println("margin-left: auto;");
        out.println("margin-right: auto;");
        out.println("text-align: center;");
        out.println("width: auto;");
        out.println("color: white;");
        out.println("font-size: 1em;");
        out.println("font-family: Courier New, Courier, Lucida Sans Typewriter, Lucida Typewriter,monospace;");
        out.println("}");

        out.println("</style>");
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

        response.setContentType("text/html;charset=UTF-8");
        response.setHeader("Refresh", "1");

        String loginCheck = (String) request.getSession().getAttribute("login");
        if (loginCheck == null) {
            response.sendRedirect("Logging");
        }
        Cookie[] cookies = request.getCookies();
        boolean logged = false;
        for (Cookie cookieMonster : cookies) {
            if (cookieMonster.getValue().equals(loginCheck)) {
                logged = true;
                break;
            }
        }
        if (!logged) {
            response.sendRedirect("Logging");
        } else {
            PrintWriter out = response.getWriter();

            out.println("<!DOCTYPE html>");
            out.println("<html>");
            out.println("<head>");
            out.println("<title>Servlet Sorting</title>");
            out.println("</head>");

            writeStyle(out);

            out.println("<body bgcolor=\"black\">");
            out.println("<div id=\"div\">");

            out.println("<p id=\"p1\">");
            out.println("Back to menu:");
            out.println("</p>");

            out.println("<form action=\"Menu\">");
            out.println("<input id=\"button\" type=\"submit\" value=\"Back\">");
            out.println("</form>");

            if (request.getParameter("tableID") == null || request.getParameter("tableID").isEmpty()) {
                return;
            }
            try {
                assert emf != null;  //Make sure injection went through correctly.
                EntityManager em = emf.createEntityManager();

                int tableID = Integer.parseInt(request.getParameter("tableID"));

                //reading from DB
                SortingTables array = (SortingTables) em.createQuery("SELECT tab FROM SortingTables tab WHERE tab.id = :param").setParameter("param", tableID).getSingleResult();
                Algorithms algorithm = (Algorithms) em.createQuery("SELECT alg FROM Algorithms alg WHERE alg.idTable = " + tableID).getSingleResult();
                List<Numbers> numbers = em.createQuery("SELECT numb FROM Numbers numb WHERE numb.tableId = " + tableID).getResultList();

                //preparing obejcts for Model creation
                Commands command;
                switch (algorithm.getName().toUpperCase()) {
                    default:
                        command = Commands.COMMAND_START_BUBBLE;
                        break;
                    case "BOGO":
                        command = Commands.COMMAND_START_BOGO;
                        break;
                    case "INSERTION":
                        command = Commands.COMMAND_START_INSERTION;
                        break;
                }

                int[] sortArray = new int[array.getSize()];
                int currentIndex = 0;

                for (int i = 0; i < sortArray.length; i++) {
                    sortArray[numbers.get(i).getIndex()] = numbers.get(i).getValue();
                    if (numbers.get(i).getIsPointedAt()) {
                        currentIndex = numbers.get(i).getIndex();
                    }
                }

                int state = algorithm.getCurrentState();

                //creating new Model
                model = new SortModel(command, numbers, state, currentIndex);
                out.println("<p id=\"p2\">Table sorting</p>");
                out.println("<p id=\"array\" >");

                //displaying current array
                for (int i = 0; i < numbers.size(); i++) {
                    for (int j = 0; j < numbers.size(); j++) {
                        if (numbers.get(j).getIndex() == i) {
                            if (state != 0 && numbers.get(j).getIndex() == currentIndex) {
                                out.println("<b>" + numbers.get(j).getValue() + " </b>");
                            } else if (state != 0) {
                                out.println(numbers.get(j).getValue() + " ");
                            } else {
                                out.println("<font color=#00e600><b>" + numbers.get(j).getValue() + "</b></font> ");
                            }
                        }
                    }
                }
                out.println("</p>");

                //sorting
                model.receiveCommand(Commands.COMMAND_CONTINUE);
                numbers.forEach((n) -> {
                    //n.setIsPointedAt(n.getIndex() == model.getIndex());
                    if (n.getIndex() == model.getIndex()) {
                        n.setIsPointedAt(true);
                    } else {
                        n.setIsPointedAt(false);
                    }
                });

                //refreshing session
                request.getSession().setAttribute("model", model);

                algorithm.setCurrentState(model.getSorterState());
                array.setIsSorted(model.getSorterState() == 0);

                //saving to DB
                utx.begin();
                em = emf.createEntityManager();
                em.merge(algorithm);
                em.merge(array);
                for (Numbers n : numbers) {
                    em.merge(n);
                }
                utx.commit();

            } catch (NoResultException exception) {
                out.println("<p id=\"exception\"> No table with such ID!</p>");
            } catch (Exception exception) {
                System.err.println(exception.getMessage());
            }

            out.println("</div>");
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
