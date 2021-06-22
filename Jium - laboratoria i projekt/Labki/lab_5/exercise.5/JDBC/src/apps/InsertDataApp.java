package apps;

import java.sql.*;

public class InsertDataApp {

    public void insertData() {
        
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
            statement.executeUpdate("INSERT INTO Dane VALUES (1, 'Nowak', 'Jan', 5.0)");
            statement.executeUpdate("INSERT INTO Dane VALUES (2, 'Kowalski', 'Wojciech', 3.0)");
            statement.executeUpdate("INSERT INTO Dane VALUES (3, 'Mickiewicz', 'Adam', 4.5)");
            statement.executeUpdate("INSERT INTO Dane VALUES (4, 'Kotek', 'Ludwik', 5.0)");
            System.out.println("Data inserted");
        } catch (SQLException sqle) {
            System.err.println(sqle.getMessage());
        }
    }

    public static void main(String[] args) {
        InsertDataApp insertDataApp = new InsertDataApp();
        insertDataApp.insertData();
    }
}
