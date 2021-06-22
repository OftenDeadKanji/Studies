package apps;

import java.sql.*;

public class CreateTablesApp {

    public void createTables() {

        try {
            // loading the JDBC driver
            Class.forName("org.apache.derby.jdbc.ClientDriver");
        } catch (ClassNotFoundException cnfe) {
            System.err.println(cnfe.getMessage());
            return;
        }

        // make a connection to DB
        try (Connection con = DriverManager.getConnection("jdbc:derby://localhost:1527/lab", "lab", "lab")) {
            Statement statement = con.createStatement();
            statement.executeUpdate("CREATE TABLE Dane "
                    + "(id INTEGER, nazwisko VARCHAR(50), "
                    + "imie VARCHAR(50), ocena FLOAT )");
            System.out.println("Table created");
        } catch (SQLException sqle) {
            System.err.println(sqle.getMessage());
        }
    }

    public static void main(String[] args) {
        CreateTablesApp createTablesApp = new CreateTablesApp();
        createTablesApp.createTables();
    }
}
