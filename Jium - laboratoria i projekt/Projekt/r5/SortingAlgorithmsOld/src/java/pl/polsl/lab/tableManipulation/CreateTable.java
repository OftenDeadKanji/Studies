/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.tableManipulation;

import java.sql.*;

/**
 *
 * @author Kanjiklub
 */
public class CreateTable {
    
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
            //statement.executeUpdate("DROP TABLE SORTING_TABLES");
            statement.executeUpdate("CREATE TABLE SORTING_TABLES "
                    + "(ID INTEGER PRIMARY KEY, "
                    + "SIZE INTEGER, "
                    + "ALGORITHM CHAR(20), "
                    + "IS_SORTED BOOLEAN )");
            System.out.println("Table SORTING_TABLES created.");
            con.close();
        } catch (SQLException sqle) {
            System.err.println(sqle.getMessage());
        }
    }
    
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
            //statement.executeUpdate("DROP TABLE ALGORITHMS");
            statement.executeUpdate("CREATE TABLE ALGORITHMS "
                    + "(ID INTEGER PRIMARY KEY, "
                    + "NAME CHAR(20), "
                    + "TABLE_ID INTEGER REFERENCES SORTING_TABLES ON DELETE CASCADE, "
                    + "STATE INTEGER )");
            System.out.println("Table ALGORITHMS created.");
            con.close();
        } catch (SQLException sqle) {
            System.err.println(sqle.getMessage());
        }
    }
    
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
            //statement.executeUpdate("DROP TABLE NUMBERS");
            statement.executeUpdate("CREATE TABLE NUMBERS "
                    + "(ID INTEGER PRIMARY KEY, "
                    + "VALUE INTEGER, "
                    + "TABLE_ID INTEGER REFERENCES SORTING_TABLES ON DELETE CASCADE, "
                    + "INDEX INTEGER,"
                    + "IS_POINTED_AT BOOLEAN )");
            System.out.println("Table NUMBERS created.");
            con.close();
        } catch (SQLException sqle) {
            System.err.println(sqle.getMessage());
        }
    }
    
    public void createTables(){
        this.createSortingTablesTable();
        this.createAlgorithmsTable();
        this.createNumbersTable();
    }
    
    public static void main(String[] args) {
        CreateTable createTablesApp = new CreateTable();
        createTablesApp.createTables();
    }
    
}
