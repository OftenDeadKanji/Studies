/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ProjektyGminne.Servlety.HTML_Template;

import java.io.PrintWriter;

/**
 *
 * @author Frogi
 */
public class HTML_Template {

    public void startHTML(PrintWriter out) {
        out.println("<!DOCTYPE html>");
        out.println("<html>");
        out.println("<head>");
        out.println("<meta charset=\"UTF-8\">");
        out.println("<title>Projekty gminne</title>");
        out.println("<meta name=\"author\" content=\"IIIIOOOOIIIIOOOOIIIIOOOO\">");
        out.println("<link rel=\"stylesheet\" type=\"text/css\" href=\"styles.css\">");
        out.println("</head>");
        out.println("<body>");
        out.println("<header id=\"NAGLOWEK\">");
        out.println("<h1>Projekty gminne</h1>");
        out.println("<nav id=\"MENU\">");
        out.println("<ul>");
        out.println("<li><a href=\"Lista_projektow\">Projekty</a></li>");
        out.println("<li><a href=\"Archiwum\">Wyniki</a></li>");
        out.println("<li><a href=\"Panel_uzytkownika\">Panel użytkownika</a></li>");
        out.println("</ul>");
        out.println("</nav>");
        out.println("</header>");
        out.println("<section id=\"ZAWARTOSC\">");
        out.println("<article id=\"TRESC\">");
    }

    public void endHTML(PrintWriter out) {
        out.println("</article>");
        out.println("</section>");
        out.println("<footer id=\"STOPKA\">");
        out.println("Projekty gminne<br>");
        out.println("Autorzy: grupa 3-4 sekcja 3");
        out.println("</footer>");
        out.println("</body>");
        out.println("</html>");
    }
}
