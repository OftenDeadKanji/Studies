using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class Database
{
    static string dbFile = "URI=file:Users.db";

    public static void CreateDB()
    {
        using (var con = new SqliteConnection(dbFile))
        {
            con.Open();

            using (var command = con.CreateCommand())
            {
                CreateTableUsers(command);
                CreateTableUsersGames(command);
            }

            con.Close();
        }
    }
    
    public static bool TryToAddUser(string name, string password)
    {
        using (var con = new SqliteConnection(dbFile))
        {
            con.Open();

            try
            {
                using (var command = con.CreateCommand())
                {
                    string sqlCommand = @"
                    INSERT INTO [Users] 
                    ([Login], [Password]) 
                    VALUES 
                    ('{0}', '{1}')
                ";

                    sqlCommand = string.Format(sqlCommand, name, password);

                    command.CommandText = sqlCommand;
                    command.ExecuteNonQuery();
                }
            }
            catch(SqliteException ex)
            {
                Debug.Log(ex.Message);

                return false;
            }
            con.Close();
        }

        return true;
    }

    public static void AddVictory(string userName)
    {
        using (var con = new SqliteConnection(dbFile))
        {
            con.Open();

            try
            {
                using (var command = con.CreateCommand())
                {
                    string sqlCommand = @"
                        SELECT [id]
                        FROM [Users]
                        WHERE [Login] = '{0}';
                    ";
                    sqlCommand = string.Format(sqlCommand, userName);
                    command.CommandText = sqlCommand;
                   
                    long userID = -1;
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userID = (long)reader["id"];
                        }
                    }

                    try
                    {
                        string sqlCommandWithoutUser = @"
                                    INSERT INTO [UsersGames]
                                    ([UserId])
                                    VALUES
                                    ({0})
                                ;";
                        sqlCommandWithoutUser = string.Format(sqlCommandWithoutUser, userID);

                        command.CommandText = sqlCommandWithoutUser;
                        command.ExecuteNonQuery();
                    }
                    catch (SqliteException ex)
                    {
                    }

                    string sqlCommandWithUser = @"
                                    UPDATE [UsersGames]
                                    SET [Victories] = [Victories] + 1
                                    WHERE [UserId] = {0}
                                ;";
                    sqlCommandWithUser = string.Format(sqlCommandWithUser, userID);

                    command.CommandText = sqlCommandWithUser;
                    command.ExecuteNonQuery();
                }
            }
            catch (SqliteException ex)
            {
                return;
            }

            con.Close();
        }
    }

    public static void AddDefeat(string userName)
    {
        using (var con = new SqliteConnection(dbFile))
        {
            con.Open();

            try
            {
                using (var command = con.CreateCommand())
                {
                    string sqlCommand = @"
                        SELECT [id]
                        FROM [Users]
                        WHERE [Login] = '{0}';
                    ";
                    sqlCommand = string.Format(sqlCommand, userName);
                    command.CommandText = sqlCommand;

                    long userID = -1;
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userID = (long)reader["id"];
                        }
                    }

                    try
                    {
                        string sqlCommandWithoutUser = @"
                                    INSERT INTO [UsersGames]
                                    ([UserId])
                                    VALUES
                                    ({0})
                                ;";
                        sqlCommandWithoutUser = string.Format(sqlCommandWithoutUser, userID);

                        command.CommandText = sqlCommandWithoutUser;
                        command.ExecuteNonQuery();
                    }
                    catch (SqliteException ex)
                    {
                    }

                    string sqlCommandWithUser = @"
                                    UPDATE [UsersGames]
                                    SET [Defeats] = [Defeats] + 1
                                    WHERE [UserId] = {0}
                                ;";
                    sqlCommandWithUser = string.Format(sqlCommandWithUser, userID);

                    command.CommandText = sqlCommandWithUser;
                    command.ExecuteNonQuery();
                }
            }
            catch (SqliteException ex)
            {
                return;
            }

            con.Close();
        }
    }

    public static string[] GetUser(string name)
    {
        string[] user = new string[2];

        using (var con = new SqliteConnection(dbFile))
        {
            con.Open();

            try
            {
                using (var command = con.CreateCommand())
                {
                    string sqlCommand = @"
                        SELECT [Login], [Password]
                        FROM [Users]
                        WHERE [Login] = '{0}';
                    ";
                    sqlCommand = string.Format (sqlCommand, name);

                    command.CommandText = sqlCommand;
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user[0] = (string)reader["Login"];
                            user[1] = (string)reader["Password"];
                        }
                    }
                }
            }
            catch (SqliteException ex)
            {
                Debug.LogException(ex);

                return null;
            }
            con.Close();
        }

        return user;
    }

    public static int GetUsersVictoriesCount(string userName)
    {
        using (var con = new SqliteConnection(dbFile))
        {
            con.Open();

            try
            {
                using (var command = con.CreateCommand())
                {
                    string sqlCommand = @"
                        SELECT [id]
                        FROM [Users]
                        WHERE [Login] = '{0}';
                    ";
                    sqlCommand = string.Format(sqlCommand, userName);
                    command.CommandText = sqlCommand;

                    long userID = -1;
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userID = (long)reader["id"];
                        }
                    }

                    try
                    {
                        string sqlSelectCommand = @"
                                    SELECT [Victories]
                                    FROM [UsersGames]
                                    WHERE [UserId] = {0}
                                ;";
                        sqlSelectCommand = string.Format(sqlSelectCommand, userID);

                        command.CommandText = sqlSelectCommand;
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return (int)(long)reader["Victories"];
                            }
                        }
                    }
                    catch (SqliteException ex)
                    {
                        Debug.Log(ex.Message);
                        return -1;
                    }
                }
            }
            catch (SqliteException ex)
            {
                Debug.Log(ex.Message);
                return -1;
            }

            con.Close();
        }

        return -1;
    }

    public static int GetUsersDefeatsCount(string userName)
    {
        using (var con = new SqliteConnection(dbFile))
        {
            con.Open();

            try
            {
                using (var command = con.CreateCommand())
                {
                    string sqlCommand = @"
                        SELECT [id]
                        FROM [Users]
                        WHERE [Login] = '{0}';
                    ";
                    sqlCommand = string.Format(sqlCommand, userName);
                    command.CommandText = sqlCommand;

                    long userID = -1;
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userID = (long)reader["id"];
                        }
                    }

                    try
                    {
                        string sqlSelectCommand = @"
                                    SELECT [Defeats]
                                    FROM [UsersGames]
                                    WHERE [UserId] = {0}
                                ;";
                        sqlSelectCommand = string.Format(sqlSelectCommand, userID);

                        command.CommandText = sqlSelectCommand;
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return (int)(long)reader["Defeats"];
                            }
                        }
                    }
                    catch (SqliteException ex)
                    {
                        Debug.Log(ex.Message);
                        return -1;
                    }
                }
            }
            catch (SqliteException ex)
            {
                Debug.Log(ex.Message);
                return -1;
            }

            con.Close();
        }

        return -1;
    }

    static void CreateTableUsers(SqliteCommand command)
    {
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS [Users] ( 
            [id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
            [Login] TEXT UNIQUE NOT NULL,
            [Password] TEXT NOT NULL
            ); 
        ";
        command.ExecuteNonQuery();
    }

    static void CreateTableUsersGames(SqliteCommand command)
    {
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS [UsersGames] ( 
            [UserId] INTEGER NOT NULL PRIMARY KEY,
            [Victories] INTEGER DEFAULT '0' NOT NULL,
            [Defeats] INTEGER DEFAULT '0' NOT NULL,
            FOREIGN KEY([UserId]) REFERENCES [Users]([id])
            ); 
        ";
        command.ExecuteNonQuery();
    }
}
