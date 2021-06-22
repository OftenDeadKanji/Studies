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
 * Klasa dodająca wszystkie potrzebne tabele do BD.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class DodanieTabel {

    /**
     * Metoda doda wszystkie potrzebne tabele do BD.
     *
     * @return TRUE, jeśli wszystkie tabele zostały dodane bez przeszkód, FALSE
     * w przeciwnym wypadku
     */
    public Boolean dodajTabele() {
        try {
            dodajTabeleProjekty();
        } catch (SQLException wyjatek) {
            System.out.println("WYJĄTEK: " + wyjatek.getMessage());
         //   return Boolean.FALSE;
        }
        try {
            dodajTabeleZalaczniki();
        } catch (SQLException wyjatek) {
            System.out.println("WYJĄTEK: " + wyjatek.getMessage());
           // return Boolean.FALSE;
        }
        try {
            dodajTabeleMieszkancy();
        } catch (SQLException wyjatek) {
            System.out.println("WYJĄTEK: " + wyjatek.getMessage());
     //       return Boolean.FALSE;
        }
        try {
            dodajTabeleUrzednicy();
        } catch (SQLException wyjatek) {
            System.out.println("WYJĄTEK: " + wyjatek.getMessage());
       //     return Boolean.FALSE;
        }
        try {
            dodajTabeleOperacje();
        } catch (SQLException wyjatek) {
            System.out.println("WYJĄTEK: " + wyjatek.getMessage());
         //   return Boolean.FALSE;
        }
        try {
            dodajTabeleGlosy();
        } catch (SQLException wyjatek) {
            System.out.println("WYJĄTEK: " + wyjatek.getMessage());
       //     return Boolean.FALSE;
        }
        try {
            dodajTabeleWyniki();
        } catch (SQLException wyjatek) {
            System.out.println("WYJĄTEK: " + wyjatek.getMessage());
     //       return Boolean.FALSE;
        }
        return Boolean.TRUE;
    }

    private void dodajTabeleProjekty() throws SQLException {
        try {
            Class.forName("org.apache.derby.jdbc.ClientDriver");
        } catch (ClassNotFoundException cnfe) {
            System.err.println(cnfe.getMessage());
            return;
        }

        Connection con = DriverManager.getConnection("jdbc:derby://localhost:1527/ProjektyGminne", "IO", "IO");
        Statement statement = con.createStatement();

        statement.executeUpdate("CREATE TABLE Projekty "
                + "(id_P bigint not null primary key "
                + "GENERATED ALWAYS AS IDENTITY "
                + "(START WITH 1, INCREMENT BY 1), "
                + "nazwa varchar(200), "
                + "opis varchar(300),"
                + "dzielnica varchar(50), "
                + "koszt int, "
                + "czas_trwania varchar(50), "
                + "data_głosowania varchar(50),"
                + "czy_zakończony boolean,"
                + "czy_wprowadzony boolean)");
        System.out.println("Tabela Projekty stworzona.");
        con.close();
    }

    private void dodajTabeleMieszkancy() throws SQLException {
        try {
            Class.forName("org.apache.derby.jdbc.ClientDriver");
        } catch (ClassNotFoundException cnfe) {
            System.err.println(cnfe.getMessage());
            return;
        }

        Connection con = DriverManager.getConnection("jdbc:derby://localhost:1527/ProjektyGminne", "IO", "IO");
        Statement statement = con.createStatement();

        statement.executeUpdate("CREATE TABLE Mieszkańcy "
                + "(id_M bigint not null primary key "
                + "GENERATED ALWAYS AS IDENTITY "
                + "(START WITH 1, INCREMENT BY 1), "
                + "login varchar(30), "
                + "hasło varchar(30), "
                + "adres_email varchar(50), "
                + "czy_zagłosował boolean)");
        System.out.println("Tabela Mieszkańcy stworzona.");
        con.close();
    }

    private void dodajTabeleUrzednicy() throws SQLException {
        try {
            Class.forName("org.apache.derby.jdbc.ClientDriver");
        } catch (ClassNotFoundException cnfe) {
            System.err.println(cnfe.getMessage());
            return;
        }

        Connection con = DriverManager.getConnection("jdbc:derby://localhost:1527/ProjektyGminne", "IO", "IO");
        Statement statement = con.createStatement();

        statement.executeUpdate("CREATE TABLE Urzędnicy "
                + "(id_U bigint not null primary key "
                + "GENERATED ALWAYS AS IDENTITY "
                + "(START WITH 1, INCREMENT BY 1), "
                + "imię varchar(30), "
                + "nazwisko varchar(30), "
                + "id_pracownika int,"
                + "hasło varchar(30))");
        System.out.println("Tabela Urzędnicy stworzona.");
        con.close();
    }

    private void dodajTabeleZalaczniki() throws SQLException {
        try {
            Class.forName("org.apache.derby.jdbc.ClientDriver");
        } catch (ClassNotFoundException cnfe) {
            System.err.println(cnfe.getMessage());
            return;
        }

        Connection con = DriverManager.getConnection("jdbc:derby://localhost:1527/ProjektyGminne", "IO", "IO");
        Statement statement = con.createStatement();

        statement.executeUpdate("CREATE TABLE Załączniki "
                + "(id_Z bigint not null primary key "
                + "GENERATED ALWAYS AS IDENTITY "
                + "(START WITH 1, INCREMENT BY 1), "
                + "nazwa varchar(30), "
                + "ścieżka_zasobu varchar(200), "
                + "id_P bigint REFERENCES Projekty(id_P) ON DELETE CASCADE)");
        System.out.println("Tabela Załączniki stworzona.");
        con.close();
    }

    private void dodajTabeleOperacje() throws SQLException {
        try {
            Class.forName("org.apache.derby.jdbc.ClientDriver");
        } catch (ClassNotFoundException cnfe) {
            System.err.println(cnfe.getMessage());
            return;
        }

        Connection con = DriverManager.getConnection("jdbc:derby://localhost:1527/ProjektyGminne", "IO", "IO");
        Statement statement = con.createStatement();

        statement.executeUpdate("CREATE TABLE Operacje "
                + "(id_O bigint not null primary key "
                + "GENERATED ALWAYS AS IDENTITY "
                + "(START WITH 1, INCREMENT BY 1), "
                + "id_U bigint REFERENCES Urzędnicy(id_U) ON DELETE NO ACTION, "
                + "id_P bigint REFERENCES Projekty(id_P) ON DELETE NO ACTION, "
                + "rodzaj int)");
        System.out.println("Tabela Operacje stworzona.");
        con.close();
    }

    private void dodajTabeleGlosy() throws SQLException {
        try {
            Class.forName("org.apache.derby.jdbc.ClientDriver");
        } catch (ClassNotFoundException cnfe) {
            System.err.println(cnfe.getMessage());
            return;
        }

        Connection con = DriverManager.getConnection("jdbc:derby://localhost:1527/ProjektyGminne", "IO", "IO");
        Statement statement = con.createStatement();

        statement.executeUpdate("CREATE TABLE Głosy "
                + "(id_G bigint not null primary key "
                + "GENERATED ALWAYS AS IDENTITY "
                + "(START WITH 1, INCREMENT BY 1), "
                + "id_M bigint REFERENCES Mieszkańcy(id_M) ON DELETE NO ACTION, "
                + "id_P bigint REFERENCES Projekty(id_P) ON DELETE CASCADE, "
                + "data date)");
        System.out.println("Tabela Głosy stworzona.");
        con.close();
    }

    private void dodajTabeleWyniki() throws SQLException {
        try {
            Class.forName("org.apache.derby.jdbc.ClientDriver");
        } catch (ClassNotFoundException cnfe) {
            System.err.println(cnfe.getMessage());
            return;
        }

        Connection con = DriverManager.getConnection("jdbc:derby://localhost:1527/ProjektyGminne", "IO", "IO");
        Statement statement = con.createStatement();

        statement.executeUpdate("CREATE TABLE Wyniki "
                + "(id_W bigint not null primary key "
                + "GENERATED ALWAYS AS IDENTITY "
                + "(START WITH 1, INCREMENT BY 1), "
                + "id_P bigint REFERENCES Projekty(id_P) ON DELETE NO ACTION, "
                + "suma int )");
        System.out.println("Tabela Wyniki stworzona.");
        con.close();
    }
}
