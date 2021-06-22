/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.tablesManipulation;

import java.sql.*;

/**
 * A class that creates tables in DB.
 *
 * @author Mateusz Chłopek
 */
public class CreateTable {

    /**
     * A method for creating a SortingTables table
     */
    private void createSortingTablesTable() {

        try {
            // loading the JDBC driver
            Class.forName("org.apache.derby.jdbc.ClientDriver");
        } catch (ClassNotFoundException cnfe) {
            System.err.println(cnfe.getMessage());
            return;
        }

        // make a connection to DB
        try {
            Connection con = DriverManager.getConnection("jdbc:derby://localhost:1527/SortingAlgorithmsDB", "Kenobi", "Yoda");
            Statement statement = con.createStatement();

            /* uncomment to drop a table if it exists
                |
                |
                v
             */
            //statement.executeUpdate("DROP TABLE SORTING_TABLES");
            statement.executeUpdate("CREATE TABLE SORTING_TABLES "
                    + "(ID INT not null primary key "
                    + "GENERATED ALWAYS AS IDENTITY "
                    + "(START WITH 1, INCREMENT BY 1), "
                    + "SIZE INTEGER, "
                    + "ALGORITHM CHAR(20), "
                    + "IS_SORTED BOOLEAN )");
            System.out.println("Table SORTING_TABLES created.");
            con.close();
        } catch (SQLException sqle) {
            System.err.println(sqle.getMessage());
        }
    }

    /**
     * A method for creating a Algorithms table
     */
    private void createAlgorithmsTable() {

        try {
            // loading the JDBC driver
            Class.forName("org.apache.derby.jdbc.ClientDriver");
        } catch (ClassNotFoundException cnfe) {
            System.err.println(cnfe.getMessage());
            return;
        }

        // make a connection to DB
        try {
            Connection con = DriverManager.getConnection("jdbc:derby://localhost:1527/SortingAlgorithmsDB", "Kenobi", "Yoda");
            Statement statement = con.createStatement();

            /* uncomment to drop a table if it exists
                |
                |
                v
             */
            //statement.executeUpdate("DROP TABLE ALGORITHMS");
            statement.executeUpdate("CREATE TABLE ALGORITHMS "
                    + "(ID INT not null primary key "
                    + "GENERATED ALWAYS AS IDENTITY "
                    + "(START WITH 1, INCREMENT BY 1), "
                    + "NAME CHAR(20), "
                    + "TABLE_ID INT REFERENCES SORTING_TABLES(ID) ON DELETE CASCADE, "
                    + "STATE INTEGER )");
            System.out.println("Table ALGORITHMS created.");
            con.close();
        } catch (SQLException sqle) {
            System.err.println(sqle.getMessage());
        }
    }

    /**
     * A method for creating a Numbers table
     */
    private void createNumbersTable() {

        try {
            // loading the JDBC driver
            Class.forName("org.apache.derby.jdbc.ClientDriver");
        } catch (ClassNotFoundException cnfe) {
            System.err.println(cnfe.getMessage());
            return;
        }

        // make a connection to DB
        try {
            Connection con = DriverManager.getConnection("jdbc:derby://localhost:1527/SortingAlgorithmsDB", "Kenobi", "Yoda");
            Statement statement = con.createStatement();

            /* uncomment to drop a table if it exists
                |
                |
                v
             */
            //statement.executeUpdate("DROP TABLE NUMBERS");
            statement.executeUpdate("CREATE TABLE NUMBERS "
                    + "(ID INT not null primary key "
                    + "GENERATED ALWAYS AS IDENTITY "
                    + "(START WITH 1, INCREMENT BY 1), "
                    + "VALUE INTEGER, "
                    + "TABLE_ID INT REFERENCES SORTING_TABLES(ID) ON DELETE CASCADE, "
                    + "INDEX INTEGER,"
                    + "IS_POINTED_AT BOOLEAN )");
            System.out.println("Table NUMBERS created.");
            con.close();
        } catch (SQLException sqle) {
            System.err.println(sqle.getMessage());
        }
    }

    /**
     * Creation of all tables.
     */
    public void createTables() {
        this.createSortingTablesTable();
        this.createAlgorithmsTable();
        this.createNumbersTable();
    }

    
    public static void main(String[] args) {
        CreateTable createTablesApp = new CreateTable();
        createTablesApp.createTables();
    }

}
