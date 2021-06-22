/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ProjektyGminneAdmin.ZarzadzanieTabelami;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;

/**
 * Klasa usuwa wszystkie tabele z BD (w odpowiedniej kolejności).
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class UsuniecieTabel {

    /**
     * Metoda po wywolaniu usunie wszystkie tabele z BD.
     *
     * @return TRUE, jeśli pomyślnie usunięto wszystkie tabele, FALSE w
     * przeciwnym wpadku
     */
    public Boolean usunTabele() {
        try {
            usunTabeleGlosy();
        } catch (SQLException wyjatek) {
            System.out.println("WYJĄTEK: " + wyjatek.getMessage());
            //    return Boolean.FALSE;
        }
        try {
            usunTabeleWyniki();
        } catch (SQLException wyjatek) {
            System.out.println("WYJĄTEK: " + wyjatek.getMessage());
            //    return Boolean.FALSE;
        }
        try {
            usunTabeleOperacje();
        } catch (SQLException wyjatek) {
            System.out.println("WYJĄTEK: " + wyjatek.getMessage());
            //    return Boolean.FALSE;
        }
        try {
            usunTabeleUrzednicy();
        } catch (SQLException wyjatek) {
            System.out.println("WYJĄTEK: " + wyjatek.getMessage());
            //    return Boolean.FALSE;
        }
        try {
            usunTabeleMieszkancy();
        } catch (SQLException wyjatek) {
            System.out.println("WYJĄTEK: " + wyjatek.getMessage());
            //    return Boolean.FALSE;
        }
        try {
            usunTabeleZalaczniki();
        } catch (SQLException wyjatek) {
            System.out.println("WYJĄTEK: " + wyjatek.getMessage());
            //    return Boolean.FALSE;
        }
        try {
            usunTabeleProjekty();
        } catch (SQLException wyjatek) {
            System.out.println("WYJĄTEK: " + wyjatek.getMessage());
            //    return Boolean.FALSE;
        }
        return Boolean.TRUE;
    }

    private void usunTabeleProjekty() throws SQLException {
        try {
            Class.forName("org.apache.derby.jdbc.ClientDriver");
        } catch (ClassNotFoundException cnfe) {
            System.err.println(cnfe.getMessage());
            return;
        }

        Connection con = DriverManager.getConnection("jdbc:derby://localhost:1527/ProjektyGminne", "IO", "IO");
        Statement statement = con.createStatement();

        statement.executeUpdate("DROP TABLE Projekty");
        System.out.println("Tabela Projekty usunięta.");
        con.close();
    }

    private void usunTabeleMieszkancy() throws SQLException {
        try {
            Class.forName("org.apache.derby.jdbc.ClientDriver");
        } catch (ClassNotFoundException cnfe) {
            System.err.println(cnfe.getMessage());
            return;
        }

        Connection con = DriverManager.getConnection("jdbc:derby://localhost:1527/ProjektyGminne", "IO", "IO");
        Statement statement = con.createStatement();

        statement.executeUpdate("DROP TABLE Mieszkańcy");
        System.out.println("Tabela Mieszkańcy usunięta.");
        con.close();
    }

    private void usunTabeleUrzednicy() throws SQLException {
        try {
            Class.forName("org.apache.derby.jdbc.ClientDriver");
        } catch (ClassNotFoundException cnfe) {
            System.err.println(cnfe.getMessage());
            return;
        }

        Connection con = DriverManager.getConnection("jdbc:derby://localhost:1527/ProjektyGminne", "IO", "IO");
        Statement statement = con.createStatement();

        statement.executeUpdate("DROP TABLE Urzędnicy");
        System.out.println("Tabela Urzędnicy usunięta.");
        con.close();
    }

    private void usunTabeleGlosy() throws SQLException {
        try {
            Class.forName("org.apache.derby.jdbc.ClientDriver");
        } catch (ClassNotFoundException cnfe) {
            System.err.println(cnfe.getMessage());
            return;
        }

        Connection con = DriverManager.getConnection("jdbc:derby://localhost:1527/ProjektyGminne", "IO", "IO");
        Statement statement = con.createStatement();

        statement.executeUpdate("DROP TABLE Głosy");
        System.out.println("Tabela Głosy usunięta.");
        con.close();
    }

    private void usunTabeleOperacje() throws SQLException {
        try {
            Class.forName("org.apache.derby.jdbc.ClientDriver");
        } catch (ClassNotFoundException cnfe) {
            System.err.println(cnfe.getMessage());
            return;
        }

        Connection con = DriverManager.getConnection("jdbc:derby://localhost:1527/ProjektyGminne", "IO", "IO");
        Statement statement = con.createStatement();

        statement.executeUpdate("DROP TABLE Operacje");
        System.out.println("Tabela Operacja usunięta.");
        con.close();
    }

    private void usunTabeleWyniki() throws SQLException {
        try {
            Class.forName("org.apache.derby.jdbc.ClientDriver");
        } catch (ClassNotFoundException cnfe) {
            System.err.println(cnfe.getMessage());
            return;
        }

        Connection con = DriverManager.getConnection("jdbc:derby://localhost:1527/ProjektyGminne", "IO", "IO");
        Statement statement = con.createStatement();

        statement.executeUpdate("DROP TABLE Wyniki");
        System.out.println("Tabela Wyniki usunięta.");
        con.close();
    }

    private void usunTabeleZalaczniki() throws SQLException {
        try {
            Class.forName("org.apache.derby.jdbc.ClientDriver");
        } catch (ClassNotFoundException cnfe) {
            System.err.println(cnfe.getMessage());
            return;
        }

        Connection con = DriverManager.getConnection("jdbc:derby://localhost:1527/ProjektyGminne", "IO", "IO");
        Statement statement = con.createStatement();

        statement.executeUpdate("DROP TABLE Załączniki");
        System.out.println("Tabela Załączniki usunięta.");
        con.close();
    }
}
