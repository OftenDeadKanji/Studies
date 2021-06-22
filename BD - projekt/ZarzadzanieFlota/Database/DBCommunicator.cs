using System;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Linq;
using Nager.Date;

namespace ZarzadzanieFlota
{
    /// <summary>
    /// Klasa służąca jako komunikator z bazą danych. Umożliwia wykonywanie wszelkich zapytań.
    /// </summary>
    static class DBCommunicator
    {
        static readonly string DBpath = Path.GetFullPath("PublicTransport.mdf");
        static readonly SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + DBpath + "; Integrated Security = True");

        #region metody SELECT

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o przystankach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego ID (lub przekazanego o wartości -1) zwracane są informacje o wszystkich przystankach.
        /// </summary>
        public static List<string[]> SelectFromStopsById(int id = -1)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (id == -1)
            {
                cmd = new SqlCommand("SELECT * FROM Stops", con);
            }
            else if (id < -1)
            {
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Stops WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o przystankach o danej nazwie. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanej nazwy zwracany jest null.
        /// </summary>
        public static List<string[]> SelectFromStopsByName(string name)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (name == null)
            {
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Stops WHERE name like @name", con);
                cmd.Parameters.AddWithValue("@name", name);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o liniach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego ID (lub przekazanego o wartości -1) zwracane są informacje o wszystkich liniach.
        /// </summary>
        public static List<string[]> SelectFromLinesById(int id = -1)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (id == -1)
            {
                cmd = new SqlCommand("SELECT * FROM Lines", con);
            }
            else if (id < -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Lines WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o pracownikach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego ID (lub przekazanego o wartości -1) zwracane są informacje o wszystkich pracownikach.
        /// </summary>
        public static List<string[]> SelectFromEmployeesById(int id = -1)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (id == -1)
            {
                cmd = new SqlCommand("SELECT * FROM Employees", con);
            }
            else if (id < -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Employees WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString(),
                        reader[6].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o pracownikach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego loginu (lub przekazanego o wartości "") zwraca null.
        /// </summary>
        public static List<string[]> SelectFromEmployeesByLogin(string login = "")
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (login == "")
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Employees WHERE login like @login", con);
                //cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = login; 
                cmd.Parameters.AddWithValue("@login", login);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString(),
                        reader[6].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o kursach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego ID (lub przekazanego o wartości -1) zwracane są informacje o wszystkich kursach.
        /// </summary>
        public static List<string[]> SelectFromCoursesById(int id = -1)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (id == -1)
            {
                cmd = new SqlCommand("SELECT * FROM Courses", con);
            }
            else if (id < -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Courses WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o kursach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego ID (lub przekazanego o wartości -1) zwracane są informacje o wszystkich kursach.
        /// </summary>
        public static List<string[]> SelectFromCourseByVehicleId(int id = -1)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (id == -1)
            {
                cmd = new SqlCommand("SELECT * FROM Courses", con);
            }
            else if (id < -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Courses WHERE id_vehicle = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o kursach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// </summary>
        public static List<string[]> SelectFromCourseByVehicleIdAndDate(int id, DateTime date)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (id < 0)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Courses WHERE id_vehicle = @id and date = @date", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@date", date);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }


        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o kursach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// </summary>
        public static List<string[]> SelectFromCoursesByTransitIdDriverIdDate(int transitId, int driverId, string date)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            cmd = new SqlCommand("SELECT * FROM Courses WHERE id_transit = @idTransit AND id_driver = @idDriver AND date = @date", con);
            cmd.Parameters.AddWithValue("@idTransit", transitId);
            cmd.Parameters.AddWithValue("@idDriver", driverId);
            cmd.Parameters.AddWithValue("@date", date);

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o pojazdach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego ID (lub przekazanego o wartości -1) zwracane są informacje o wszystkich pojazdach.
        /// </summary>
        public static List<string[]> SelectFromVehiclesById(int id = -1)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (id == -1)
            {
                cmd = new SqlCommand("SELECT * FROM Vehicles", con);
            }
            else if (id < -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Vehicles WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o pojazdach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego capacity (lub przekazanego o wartości -1) zwracane są informacje o wszystkich pojazdach.
        /// </summary>
        public static List<string[]> SelectFromVehiclesByCapacityAndType(int capacity = -1, int type = -1)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (capacity == -1)
            {
                cmd = new SqlCommand("SELECT * FROM Vehicles", con);
            }
            else if (capacity < -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Vehicles WHERE capacity = @capacity AND type = @type", con);
                cmd.Parameters.AddWithValue("@capacity", capacity);
                cmd.Parameters.AddWithValue("@type", type);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o pojazdach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego capacity (lub przekazanego o wartości -1) zwracane są informacje o wszystkich pojazdach.
        /// </summary>
        public static List<string[]> SelectFromVehiclesByNotCapacityAndType(int capacity = -1, int type = -1)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (capacity == -1)
            {
                cmd = new SqlCommand("SELECT * FROM Vehicles", con);
            }
            else if (capacity < -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Vehicles WHERE NOT capacity = @capacity AND type = @type", con);
                cmd.Parameters.AddWithValue("@capacity", capacity);
                cmd.Parameters.AddWithValue("@type", type);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }


        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o kierowcach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego ID (lub przekazanego o wartości -1) zwracane są informacje o wszystkich kierowcach.
        /// </summary>
        public static List<string[]> SelectFromDriversById(int id = -1)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (id == -1)
            {
                cmd = new SqlCommand("SELECT * FROM Drivers", con);
            }
            else if (id < -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Drivers WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o kierowcach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// </summary>
        public static List<string[]> SelectFromDriversByVehicleAndShift(int vehicleType, int shift)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (vehicleType < 0)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Drivers WHERE avail_vehicle_type = @type AND shift = @shift", con);
                cmd.Parameters.AddWithValue("@type", vehicleType);
                cmd.Parameters.AddWithValue("@shift", shift);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }


        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o przydziałach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego ID (lub przekazanego o wartości -1) zwracane są informacje o wszystkich przydziałach.
        /// </summary>
        public static List<string[]> SelectFromAssignmentsById(int id = -1)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (id == -1)
            {
                cmd = new SqlCommand("SELECT * FROM Assignments", con);
            }
            else if (id < -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Assignments WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString(),
                        reader[6].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o wszystkich przydziałach dla danego kierowcy. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego ID (wartość mniejsza od 1) zwracany jest null.
        /// </summary>
        public static List<string[]> SelectFromAssignmentsByDriverId(int driverId = -1)
        {
            if (driverId < 1)
            {
                return null;
            }
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID kierowcy
            SqlCommand cmd = new SqlCommand("SELECT * FROM Assignments WHERE id_driver = @id", con);
            cmd.Parameters.AddWithValue("@id", driverId);

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString(),
                        reader[6].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o wszystkich przydziałach dla danego kierowcy. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// </summary>
        public static List<string[]> SelectFromAssignmentsByDriverIdAndDate(int driverId, DateTime date)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID kierowcy
            SqlCommand cmd = new SqlCommand("SELECT * FROM Assignments WHERE id_driver = @id and date = @date", con);
            cmd.Parameters.AddWithValue("@id", driverId);
            cmd.Parameters.AddWithValue("@date", date);

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString(),
                        reader[6].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }


        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o spóźnieniach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego ID (lub przekazanego o wartości -1) zwracane są informacje o wszystkich spóźnieniach.
        /// </summary>
        public static List<string[]> SelectFromDelaysByCourseId(int courseId = -1)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (courseId == -1)
            {
                cmd = new SqlCommand("SELECT * FROM Delays", con);
            }
            else if (courseId < -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Delays WHERE id_course = @id", con);
                cmd.Parameters.AddWithValue("@id", courseId);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o spóźnieniach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego ID (lub przekazanego o wartości -1) zwracane są informacje o wszystkich spóźnieniach.
        /// </summary>
        public static List<string[]> SelectFromDelaysByStopOnRouteId(int stopOnRouteId = -1)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (stopOnRouteId == -1)
            {
                cmd = new SqlCommand("SELECT * FROM Delays", con);
            }
            else if (stopOnRouteId < -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Delays WHERE id_stop_on_route = @id", con);
                cmd.Parameters.AddWithValue("@id", stopOnRouteId);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o spóźnieniach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego jednego z ID (lub przekazanego o wartości -1) wywoływana jest metoda z drugim podanym argumentem.
        /// W przypadku, gdy nie podane zostało żadne ID (lub oba mają wartość -1) to zwracane są informacje o wszystkich spóźnieniach.
        /// </summary>
        public static List<string[]> SelectFromDelaysByCourseAndStopOnRouteId(int courseId = -1, int stopOnRouteId = -1)
        {
            if (courseId != -1 && stopOnRouteId == -1)
            {
                return SelectFromDelaysByCourseId(courseId);
            }
            else if (courseId == -1 && stopOnRouteId != -1)
            {
                return SelectFromDelaysByStopOnRouteId(stopOnRouteId);
            }

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (courseId == -1 && stopOnRouteId == -1)
            {
                cmd = new SqlCommand("SELECT * FROM Delays", con);
            }
            else if (courseId == -1 && stopOnRouteId == -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Delays WHERE id_course = @course AND id_stop_on_route = @stop", con);
                cmd.Parameters.AddWithValue("@course", courseId);
                cmd.Parameters.AddWithValue("@stop", stopOnRouteId);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o przystankach_na_trasie. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego ID (lub przekazanego o wartości -1) zwracane są informacje o wszystkich przystankach_na_trasie.
        /// </summary>
        public static List<string[]> SelectFromStopsOnRouteById(int id = -1)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (id == -1)
            {
                cmd = new SqlCommand("SELECT * FROM Stops_on_route", con);
            }
            else if (id < -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Stops_on_route WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        public static List<string[]> SelectPreviousFromStopsOnRouteById(int id = -1)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (id <= -1)
            {
                return null;
            }
            else
            {
                string query = "WITH x AS " +
                    "(SELECT id, id_stop, id_prev, ordinal_no, transit_time " +
                    "FROM Stops_on_route " +
                    "WHERE id = @id " +
                    "UNION ALL " +
                    "SELECT son.id, son.id_stop, son.id_prev, son.ordinal_no, son.transit_time " +
                    "FROM x " +
                    "JOIN Stops_on_route son " +
                    "ON x.id_prev = son.id) " +
                    "SELECT x.id, x.ordinal_no, s.district, s.name, x.transit_time " +
                    "FROM x, Stops s " +
                    "WHERE x.id_stop = s.id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        public static List<string[]> SelectNextFromStopsOnRouteById(int id = -1)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (id <= -1)
            {
                return null;
            }
            else
            {
                string query = "WITH x AS " +
                    "(SELECT id, id_stop, id_next, ordinal_no, transit_time " +
                    "FROM Stops_on_route " +
                    "WHERE id = @id " +
                    "UNION ALL " +
                    "SELECT son.id, son.id_stop, son.id_next, son.ordinal_no, son.transit_time " +
                    "FROM x " +
                    "JOIN Stops_on_route son " +
                    "ON x.id_next = son.id) " +
                    "SELECT x.id, x.ordinal_no, s.district, s.name, x.transit_time " +
                    "FROM x, Stops s " +
                    "WHERE x.id_stop = s.id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o przystankach_na_trasie. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego ID przystanku (lub przekazanego o wartości -1) zwracany jest null.
        /// </summary>
        public static List<string[]> SelectFromStopsOnRouteByStopId(int id = -1)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (id <= -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Stops_on_route WHERE id_stop = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o przejazdach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego ID (lub przekazanego o wartości -1) zwracane są informacje o wszystkich przejazdach.
        /// </summary>
        public static List<string[]> SelectFromTransitsById(int id = -1)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (id == -1)
            {
                cmd = new SqlCommand("SELECT * FROM Transits", con);
            }
            else if (id < -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Transits WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString(),
                        reader[6].ToString(),
                        reader[7].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o przejazdach dla danej linii. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego ID (lub przekazanego o wartości -1) zwracane są informacje o wszystkich przejazdach.
        /// </summary>
        public static List<string[]> SelectFromTransitsByLineId(int lineId = -1)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (lineId == -1)
            {
                cmd = new SqlCommand("SELECT * FROM Transits", con);
            }
            else if (lineId < -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Transits WHERE id_line = @id", con);
                cmd.Parameters.AddWithValue("@id", lineId);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString(),
                        reader[6].ToString(),
                        reader[7].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        public static List<string[]> SelectFromTransitsByRouteAndDateTime(DateTime afterWhen, int firstStopOnRoute, int lastStopOnRoute)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            int weekday = (int)afterWhen.DayOfWeek;
            if (weekday < 1) weekday = 6;
            else weekday -= 1;
            int dayType = 0;
            if (afterWhen.DayOfYear > 181 && afterWhen.DayOfYear < 245) dayType = 1;
            if (DateSystem.IsPublicHoliday(afterWhen, CountryCode.PL)) dayType = 2;

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (firstStopOnRoute <= -1 || lastStopOnRoute <= -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Transits WHERE start_time >= @hour " +
                                     "AND id_first_stop = @firstId " + 
                                     "AND id_last_stop = @lastId " +
                                     "AND weekday = @dayOfWeek " +
                                     "AND day_type = @typeOfDay", con);
                cmd.Parameters.AddWithValue("@hour", afterWhen.TimeOfDay);
                cmd.Parameters.AddWithValue("@firstId", firstStopOnRoute);
                cmd.Parameters.AddWithValue("@lastId", lastStopOnRoute);
                cmd.Parameters.AddWithValue("@dayOfWeek", weekday);
                cmd.Parameters.AddWithValue("@typeOfDay", dayType);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString(),
                        reader[6].ToString(),
                        reader[7].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }
        public static List<string[]> SelectFromTransitsByRoute(int firstStopOnRoute, int lastStopOnRoute)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (firstStopOnRoute <= -1 || lastStopOnRoute <= -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Transits WHERE " +
                                     "id_first_stop = @firstId " +
                                     "AND id_last_stop = @lastId", con);
                cmd.Parameters.AddWithValue("@firstId", firstStopOnRoute);
                cmd.Parameters.AddWithValue("@lastId", lastStopOnRoute);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString(),
                        reader[6].ToString(),
                        reader[7].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o przejazdach dla danych danych. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// </summary>
        public static List<string[]> SelectFromTransitsByLineWeekdayStopsTime(int lineId, int weekday, int idFirstStop, int idLastStop, string time)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            cmd = new SqlCommand("SELECT * FROM Transits WHERE id_line = @id AND id_first_stop = @id_first AND id_last_stop = @id_last AND weekday = @weekday AND start_time = @time", con);
            cmd.Parameters.AddWithValue("@id", lineId);
            cmd.Parameters.AddWithValue("@id_first", idFirstStop);
            cmd.Parameters.AddWithValue("@id_last", idLastStop);
            cmd.Parameters.AddWithValue("@weekday", weekday);
            cmd.Parameters.AddWithValue("@time", time);

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString(),
                        reader[6].ToString(),
                        reader[7].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o trasach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Jeśli chociaż jedno z ID nie zostanie przekazane (lub zostanie przekazane z wartością -1) zwracany jest null.
        /// </summary>
        public static List<string[]> SelectFromRouteByFirstAndLastStopId(int firstId = -1, int lastId = -1)
        {
            if (firstId <= -1 || lastId <= -1)
            {
                return null;
            }
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd = new SqlCommand("SELECT * FROM Route WHERE First_stop_id = @first AND Second_stop_id = @second", con);
            cmd.Parameters.AddWithValue("@first", firstId);
            cmd.Parameters.AddWithValue("@second", lastId);

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o nieobecnościach. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// Bez przekazanego ID (lub przekazanego o wartości -1) zwracane są informacje o wszystkich nieobecnościach.
        /// </summary>
        public static List<string[]> SelectFromAbsencesByDriverId(int driverId = -1)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (driverId == -1)
            {
                cmd = new SqlCommand("SELECT * FROM Absences", con);
            }
            else if (driverId < -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return null;
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Absences WHERE id_driver = @id", con);
                cmd.Parameters.AddWithValue("@id", driverId);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        /// <summary>
        /// Metoda zwraca typ pojazdu wymagany w danym przejeździe.
        /// </summary>
        public static int SelectVehicleTypeByTransitId(int transitId)
        {
            int vehicleType = -1;
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (transitId < 0)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return vehicleType;
            }
            else
            {
                cmd = new SqlCommand("SELECT Lines.vehicle_type FROM Lines, Transits WHERE Transits.id = @id AND Transits.id_line = Lines.id", con);
                cmd.Parameters.AddWithValue("@id", transitId);
            }

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                vehicleType = (int)reader[0];
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return vehicleType;
        }


        /// <summary>
        /// Nie wiem czy działa!!!
        /// Metoda zwraca listę tablic zawierające informacje o pierwszych przystankach_na_trasie tras nienależących 
        /// do jakichkolwiek przejazdów. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// </summary>
        public static List<string[]> SelectAbandonedStopsOnRoute()
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            string query =
                "SELECT * " +
                "FROM Stops_on_route " +
                "WHERE id NOT IN " +
                                "(SELECT id_first_stop " +
                                "FROM Transits) " +
                "AND id_prev IS NULL";

            SqlCommand cmd = new SqlCommand(query, con);

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }


        /// <summary>
        /// Metoda zwraca listę tablic zawierające informacje o przejazdach o podanym dniu tygodnia i typie dnia,
        /// które nie mają kursów dla podanego zakresu dat. Kolejność w tablicach jest taka jak kolejność kolumn w BD.
        /// </summary>
        public static List<string[]> SelectNoCoursesTransitsByWeekdayAndDaytype(int weekday, int daytype, DateTime startDate, DateTime endDate)
        {
            if (weekday < 0 || daytype < 0)
                return null;
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            string query =
                "SELECT * " +
                "FROM Transits t " +
                "WHERE t.weekday = @week AND t.day_type = @type " +
                "AND t.id NOT IN " +
                                "(SELECT c.id_transit " +
                                "FROM Courses c " + 
                                "WHERE c.date >= @startDate " +
                                "AND c.date <= @endDate)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@week", weekday);
            cmd.Parameters.AddWithValue("@type", daytype);
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);

            //zwracane wartości będą przechowywane w liście tablic
            List<string[]> results = new List<string[]>();

            //pobranie wyników zapytania
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(new string[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString(),
                        reader[6].ToString(),
                        reader[7].ToString()
                    });
                }
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return results;
        }

        #endregion

        #region metody INSERT

        /// <summary>
        /// Zwraca id wstawionego rekordu.
        /// </summary>
        public static int InsertIntoLines(int lineNumber, int type, int vehicleType)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Lines(line_no, type, vehicle_type) output INSERTED.ID VALUES (@line, @type, @veh)", con);

            //ustawienie parametrów
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@line", lineNumber);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@veh", vehicleType);

            //pobranie liczby wstawionych rekordów
            int result = (int)cmd.ExecuteScalar();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Zwraca id wstawionego rekordu.
        /// </summary>
        public static int InsertIntoVehicles(string registrationNumber, string sideNumber, int type, int capacity)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Vehicles(reg_no, side_no, type, capacity) output INSERTED.ID VALUES (@reg, @side, @type, @capa)", con);

            //ustawienie parametrów
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@reg", registrationNumber);
            cmd.Parameters.AddWithValue("@side", sideNumber);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@capa", capacity);

            //pobranie liczby wstawionych rekordów
            int result = (int)cmd.ExecuteScalar();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Zwraca id wstawionego rekordu.
        /// </summary>
        public static int InsertIntoAbsences(DateTime date, int driverId)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Absences(day, id_driver) output INSERTED.ID VALUES (@date, @driverId)", con);

            //ustawienie parametrów
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@driverId", driverId);

            //pobranie liczby wstawionych rekordów
            int result = (int)cmd.ExecuteScalar();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        public static int InsertIntoAssignments(int driver, int line, DateTime date, TimeSpan start, TimeSpan end, int firstStop)
        {
            
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Assignments(id_driver, id_line, date, start_time, end_time, id_first_stop) output INSERTED.ID VALUES (@driver, @line, @date, @start, @end, @stop)", con);

            //ustawienie parametrów
            cmd.Parameters.AddWithValue("@driver", driver);
            cmd.Parameters.AddWithValue("@line", line);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);
            cmd.Parameters.AddWithValue("@stop", firstStop);

            //pobranie liczby wstawionych rekordów
            int result = (int)cmd.ExecuteScalar();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Zwraca id wstawionego rekordu.
        /// </summary>
        public static int InsertIntoStops(string name, string district, int standCount)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Stops(name, district, stand_no) output INSERTED.ID VALUES (@name, @dist, @stand)", con);

            //ustawienie parametrów
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@dist", district);
            cmd.Parameters.AddWithValue("@stand", standCount);

            //pobranie liczby wstawionych rekordów
            int result = (int)cmd.ExecuteScalar();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Zwraca id wstawionego rekordu.
        /// </summary>
        public static int InsertIntoEmployees(string name, string surname, long phoneNumber, string email, string login, string password)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Employees(name, surname, phone_no, email, login, password) output INSERTED.ID VALUES (@name, @sur, @phone, @email, @log, @pass)", con);

            //ustawienie parametrów
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@sur", surname);
            cmd.Parameters.AddWithValue("@phone", phoneNumber);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@log", login);
            cmd.Parameters.AddWithValue("@pass", password);

            //pobranie liczby wstawionych rekordów
            int result = (int)cmd.ExecuteScalar();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Zwraca id wstawionego rekordu.
        /// </summary>
        public static int InsertIntoCourses(int idDriver, int idVehicle, int idTransit, DateTime date)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand();
            if (idDriver > 0 && idVehicle > 0)
            {
                cmd = new SqlCommand("INSERT INTO Courses(id_driver, id_vehicle, id_transit, date) output INSERTED.ID VALUES (@driver, @vehicle, @transit, @date)", con);
                cmd.Parameters.AddWithValue("@driver", idDriver);
                cmd.Parameters.AddWithValue("@vehicle", idVehicle);
            }
            else if (idDriver <= 0 && idVehicle > 0)
            {
                cmd = new SqlCommand("INSERT INTO Courses(id_vehicle, id_transit, date) output INSERTED.ID VALUES (@vehicle, @transit, @date)", con);
                cmd.Parameters.AddWithValue("@vehicle", idVehicle);
            }
            else if (idDriver >= 0 && idVehicle <= 0)
            {
                cmd = new SqlCommand("INSERT INTO Courses(id_driver, id_transit, date) output INSERTED.ID VALUES (@driver, @transit, @date)", con);
                cmd.Parameters.AddWithValue("@driver", idDriver);
            }
            else
            {
                cmd = new SqlCommand("INSERT INTO Courses(id_transit, date) output INSERTED.ID VALUES (@transit, @date)", con);
            }

            //ustawienie parametrów
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@transit", idTransit);
            cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            //pobranie liczby wstawionych rekordów
            int result = (int)cmd.ExecuteScalar();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Zwraca id wstawionego rekordu.
        /// </summary>
        public static int InsertIntoDrivers(int id, int vehicleType, int shiftType)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Drivers(id, avail_vehicle_type, shift) output INSERTED.ID VALUES (@id, @vehicle, @shift)", con);

            //ustawienie parametrów
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@vehicle", vehicleType);
            cmd.Parameters.AddWithValue("@shift", shiftType);

            //pobranie liczby wstawionych rekordów
            int result = (int)cmd.ExecuteScalar();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Zwraca id wstawionego rekordu.
        /// </summary>
        public static int InsertIntoTransits(int idLine, int idFirstStop, int idLastStop, int weekday, int dayType, DateTime startTime, int preferableCapacity)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Transits(id_line, id_first_stop, id_last_stop, weekday, day_type, start_time, pref_vehicle_cap) output INSERTED.ID VALUES (@line, @first, @last, @week, @type, @time, @cap)", con);

            //ustawienie parametrów
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@line", idLine);
            cmd.Parameters.AddWithValue("@first", idFirstStop);
            cmd.Parameters.AddWithValue("@last", idLastStop);
            cmd.Parameters.AddWithValue("@week", weekday);
            cmd.Parameters.AddWithValue("@type", dayType);
            cmd.Parameters.AddWithValue("@time", startTime.ToString("HH:mm"));
            cmd.Parameters.AddWithValue("@cap", preferableCapacity);

            //pobranie liczby wstawionych rekordów
            int result = (int)cmd.ExecuteScalar();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Zwraca id wstawionego rekordu.
        /// </summary>
        public static int InsertIntoStopsOnRoute(int idStop, int idNext, int idPrev, int ordinalNumber, int transitTime)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand();
            if (idNext < 0 && idPrev < 0)
            {
                //brak natępcy i poprzednika
                cmd = new SqlCommand("INSERT INTO Stops_on_route(id_stop, ordinal_no, transit_time) output INSERTED.ID VALUES (@stop, @ord, @time)", con);
            }
            else if (idNext >= 0 && idPrev < 0)
            {
                //brak poprzednika
                cmd = new SqlCommand("INSERT INTO Stops_on_route(id_stop, id_next, ordinal_no, transit_time) output INSERTED.ID VALUES (@stop, @next, @ord, @time)", con);
                cmd.Parameters.AddWithValue("@next", idNext);
            }
            else if (idNext < 0 && idPrev >= 0)
            {
                //brak następcy
                cmd = new SqlCommand("INSERT INTO Stops_on_route(id_stop, id_prev, ordinal_no, transit_time) output INSERTED.ID VALUES (@stop, @prev, @ord, @time)", con);
                cmd.Parameters.AddWithValue("@prev", idPrev);
            }
            else
            {
                cmd = new SqlCommand("INSERT INTO Stops_on_route(id_stop, id_next, id_prev, ordinal_no, transit_time) output INSERTED.ID VALUES (@stop, @next, @prev, @ord, @time)", con);
                cmd.Parameters.AddWithValue("@next", idNext);
                cmd.Parameters.AddWithValue("@prev", idPrev);
            }

            //ustawienie reszty parametrów
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@stop", idStop);
            cmd.Parameters.AddWithValue("@ord", ordinalNumber);
            cmd.Parameters.AddWithValue("@time", transitTime);

            //pobranie liczby wstawionych rekordów
            int result = (int)cmd.ExecuteScalar();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        #endregion

        #region metody DELETE

        /// <summary>
        /// Usuwa linię o podanym ID. Zwraca liczbę usuniętych rekordów.
        /// </summary>
        public static int DeleteFromAssignmentsByDriverIdDateStartTime(int driverId, DateTime date, TimeSpan start)
        {
            if (driverId < 0)
                return 0;

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Assignments WHERE id_driver = @id AND date = @date AND start_time = @start", con);

            //ustawienie ID
            cmd.Parameters.AddWithValue("@id", driverId);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@start", start);

            //pobranie liczby usuniętych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }


        /// <summary>
        /// Usuwa linię o podanym ID. Zwraca liczbę usuniętych rekordów.
        /// </summary>
        public static int DeleteFromLinesById(int id)
        {
            if (id < 0)
                return 0;

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Lines WHERE id = @id", con);

            //ustawienie ID
            cmd.Parameters.AddWithValue("@id", id);

            //pobranie liczby usuniętych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Usuwa pojazd o podanym ID. Zwraca liczbę usuniętych rekordów.
        /// </summary>
        public static int DeleteFromVehiclesById(int id)
        {
            if (id < 0)
                return 0;

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Vehicles WHERE id = @id", con);

            //ustawienie ID
            cmd.Parameters.AddWithValue("@id", id);

            //pobranie liczby usuniętych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Usuwa nieobecność o podanym ID. Zwraca liczbę usuniętych rekordów.
        /// </summary>
        public static int DeleteFromAbsencesById(int id)
        {
            if (id < 0)
                return 0;

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Absences WHERE id = @id", con);

            //ustawienie ID
            cmd.Parameters.AddWithValue("@id", id);

            //pobranie liczby usuniętych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Usuwa nieobecność o podanym ID kierowcy. Zwraca liczbę usuniętych rekordów.
        /// </summary>
        public static int DeleteFromAbsencesByDriverId(int driverId)
        {
            if (driverId < 0)
                return 0;

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Absences WHERE id_driver = @id", con);

            //ustawienie ID
            cmd.Parameters.AddWithValue("@id", driverId);

            //pobranie liczby usuniętych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Usuwa przystanek o podanym ID. Zwraca liczbę usuniętych rekordów.
        /// </summary>
        public static int DeleteFromStopsById(int id)
        {
            if (id < 0)
                return 0;

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Stops WHERE id = @id", con);

            //ustawienie ID
            cmd.Parameters.AddWithValue("@id", id);

            //pobranie liczby usuniętych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Usuwa przystanek na trasie o podanym ID. Zwraca liczbę usuniętych rekordów.
        /// </summary>
        public static int DeleteFromStopsOnRouteById(int id)
        {
            if (id < 0)
                return 0;

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Stops_on_route WHERE id = @id", con);

            //ustawienie ID
            cmd.Parameters.AddWithValue("@id", id);

            //pobranie liczby usuniętych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Usuwa pracownika o podanym ID. Zwraca liczbę usuniętych rekordów.
        /// </summary>
        public static int DeleteFromEmployeesById(int id)
        {
            if (id < 0)
                return 0;

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE id = @id", con);

            //ustawienie ID
            cmd.Parameters.AddWithValue("@id", id);

            //pobranie liczby usuniętych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Usuwa kurs o podanym ID. Zwraca liczbę usuniętych rekordów.
        /// </summary>
        public static int DeleteFromCoursesById(int id)
        {
            if (id < 0)
                return 0;

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Courses WHERE id = @id", con);

            //ustawienie ID
            cmd.Parameters.AddWithValue("@id", id);

            //pobranie liczby usuniętych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Usuwa kursy w podanym przedziale czasowym. Zwraca liczbę usuniętych rekordów.
        /// </summary>
        public static int DeleteFromCoursesByDates(DateTime startDate, DateTime endDate)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Courses WHERE date >= @start AND date <= @end", con);

            //ustawienie ID
            cmd.Parameters.AddWithValue("@start", startDate);
            cmd.Parameters.AddWithValue("@end", endDate);

            //pobranie liczby usuniętych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Usuwa kursy w podanym przedziale czasowym. Zwraca liczbę usuniętych rekordów.
        /// </summary>
        public static int DeleteFromAssignmentsByDates(DateTime startDate, DateTime endDate)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Assignments WHERE date >= @start AND date <= @end", con);

            //ustawienie ID
            cmd.Parameters.AddWithValue("@start", startDate);
            cmd.Parameters.AddWithValue("@end", endDate);

            //pobranie liczby usuniętych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Usuwa kierowcę o podanym ID. Zwraca liczbę usuniętych rekordów.
        /// </summary>
        public static int DeleteFromDriversById(int id)
        {
            if (id < 0)
                return 0;

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Drivers WHERE id = @id", con);

            //ustawienie ID
            cmd.Parameters.AddWithValue("@id", id);

            //pobranie liczby usuniętych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Usuwa przejazdy o podanym ID. Zwraca liczbę usuniętych rekordów.
        /// </summary>
        public static int DeleteFromTransitsById(int id)
        {
            if (id < 0)
                return 0;

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Transits WHERE id = @id", con);

            //ustawienie ID
            cmd.Parameters.AddWithValue("@id", id);

            //pobranie liczby usuniętych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Usuwa przejazdy dla linii o podanym ID. Zwraca liczbę usuniętych rekordów.
        /// </summary>
        public static int DeleteFromTransitsByLineId(int lineId)
        {
            if (lineId < 0)
                return 0;

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Transits WHERE id_line = @id", con);

            //ustawienie ID
            cmd.Parameters.AddWithValue("@id", lineId);

            //pobranie liczby usuniętych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        #endregion

        #region metody UPDATE

        /// <summary>
        /// Zwraca liczbę zmodyfikowanych rekordów.
        /// </summary>
        public static int UpdateLines(int id, int lineNumber, int type, int vehicleType)
        {
            if (id < 0)
                return 0;

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Lines SET line_no = @line, type = @type WHERE id = @id, vehicle_type = @veh", con);

            //ustawienie parametrów
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@line", lineNumber);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@veh", vehicleType);
            cmd.Parameters.AddWithValue("@id", id);

            //pobranie liczby zmodyfikowanych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Zwraca liczbę zmodyfikowanych rekordów.
        /// </summary>
        public static int UpdateVehicles(int id, string registrationNumber, string sideNumber, int type, int capacity)
        {
            if (id < 0)
                return 0;

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Vehicles SET reg_no = @reg, side_no = @side, type = @type, capacity = @cap WHERE id = @id", con);

            //ustawienie parametrów
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@reg", registrationNumber);
            cmd.Parameters.AddWithValue("@side", sideNumber);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@cap", capacity);
            cmd.Parameters.AddWithValue("@id", id);

            //pobranie liczby zmodyfikowanych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Zwraca liczbę zmodyfikowanych rekordów.
        /// </summary>
        public static int UpdateAbsences(int id, DateTime date, int driverId)
        {
            if (id < 0)
                return 0;

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Absences SET day = @date, id_driver = @driverId WHERE id = @id", con);

            //ustawienie parametrów
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@driverId", driverId);

            //pobranie liczby zmodyfikowanych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Zwraca liczbę zmodyfikowanych rekordów.
        /// </summary>
        public static int UpdateStops(int id, string name, string district, int standCount)
        {
            if (id < 0)
                return 0;

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Stops SET name = @name, district = @dist, stand_no = @stand WHERE id = @id", con);

            //ustawienie parametrów
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@dist", district);
            cmd.Parameters.AddWithValue("@stand", standCount);
            cmd.Parameters.AddWithValue("@id", id);

            //pobranie liczby zmodyfikowanych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Zwraca liczbę zmodyfikowanych rekordów.
        /// </summary>
        public static int UpdateStopsOnRoute(int id, int idStop, int idNext, int idPrev, int ordinalNumber, int transitTime)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand();
            if (idNext < 0 && idPrev < 0)
            {
                //brak natępcy i poprzednika
                cmd = new SqlCommand("UPDATE Stops_on_route SET id_stop = @stop, id_next = NULL, id_prev = NULL, ordinal_no = @ord, transit_time = @time WHERE id = @id", con);
            }
            else if (idNext >= 0 && idPrev < 0)
            {
                //brak poprzednika
                cmd = new SqlCommand("UPDATE Stops_on_route SET id_stop = @stop, id_next = @next, id_prev = NULL, ordinal_no = @ord, transit_time = @time WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@next", idNext);
            }
            else if (idNext < 0 && idPrev >= 0)
            {
                //brak następcy
                cmd = new SqlCommand("UPDATE Stops_on_route SET id_stop = @stop, id_next = NULL, id_prev = @prev, ordinal_no = @ord, transit_time = @time WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@prev", idPrev);
            }
            else
            {
                cmd = new SqlCommand("UPDATE Stops_on_route SET id_stop = @stop, id_next = @next, id_prev = @prev, ordinal_no = @ord, transit_time = @time WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@next", idNext);
                cmd.Parameters.AddWithValue("@prev", idPrev);
            }

            //ustawienie reszty parametrów
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@stop", idStop);
            cmd.Parameters.AddWithValue("@ord", ordinalNumber);
            cmd.Parameters.AddWithValue("@time", transitTime);

            //pobranie liczby wstawionych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Zwraca liczbę zmodyfikowanych rekordów.
        /// </summary>
        public static int UpdateEmployees(int id, string name, string surname, long phoneNumber, string email, string login, string password)
        {
            if (id < 0)
                return 0;

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Employees SET name = @name, surname = @sur, phone_no = @phone, email = @email, login = @log, password = @pass WHERE id = @id", con);

            //ustawienie parametrów
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@sur", surname);
            cmd.Parameters.AddWithValue("@phone", phoneNumber);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@log", login);
            cmd.Parameters.AddWithValue("@pass", password);
            cmd.Parameters.AddWithValue("@id", id);

            //pobranie liczby zmodyfikowanych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Zwraca liczbę zmodyfikowanych rekordów.
        /// </summary>
        public static int UpdateCourses(int id, int idDriver, int idVehicle, int idTransit, DateTime date)
        {
            if (id < 0)
                return 0;

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Courses SET id_driver = @driver, id_vehicle = @vehicle, id_transit = @transit, date = @date WHERE id = @id", con);

            //ustawienie parametrów
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@driver", idDriver);
            cmd.Parameters.AddWithValue("@vehicle", idVehicle);
            cmd.Parameters.AddWithValue("@transit", idTransit);
            cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            cmd.Parameters.AddWithValue("@id", id);

            //pobranie liczby zmodyfikowanych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Zwraca liczbę zmodyfikowanych rekordów.
        /// </summary>
        public static int UpdateCourses_DeleteDriverOnDate(int idDriver, DateTime date)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Courses SET id_driver = NULL WHERE date = @date", con);

            //ustawienie parametrów
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@date", date);

            //pobranie liczby zmodyfikowanych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Zwraca liczbę zmodyfikowanych rekordów.
        /// </summary>
        public static int UpdateDrivers(int id, int vehicleType, int shiftType)
        {
            if (id < 0)
                return 0;

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Drivers SET avail_vehicle_type = @vehicle, shift = @shift WHERE id = @id", con);

            //ustawienie parametrów
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@vehicle", vehicleType);
            cmd.Parameters.AddWithValue("@shift", shiftType);
            cmd.Parameters.AddWithValue("@id", id);

            //pobranie liczby zmodyfikowanych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Zwraca liczbę zmodyfikowanych rekordów.
        /// </summary>
        public static int UpdateTransits(int id, int idLine, int idFirstStop, int idLastStop, int weekday, int dayType, DateTime startTime, int preferableCapacity)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Transits " +
                "SET id_line = @line, " +
                "id_first_stop = @first, " +
                "id_last_stop = @last, " +
                "weekday = @week, " +
                "day_type = @type, " +
                "start_time = @time, " +
                "pref_vehicle_cap = @cap " +
                "WHERE id = @id", con);

            //ustawienie parametrów
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@line", idLine);
            cmd.Parameters.AddWithValue("@first", idFirstStop);
            cmd.Parameters.AddWithValue("@last", idLastStop);
            cmd.Parameters.AddWithValue("@week", weekday);
            cmd.Parameters.AddWithValue("@type", dayType);
            cmd.Parameters.AddWithValue("@time", startTime.ToString("HH:mm"));
            cmd.Parameters.AddWithValue("@cap", preferableCapacity);
            cmd.Parameters.AddWithValue("@id", id);

            //pobranie liczby wstawionych rekordów
            int result = cmd.ExecuteNonQuery();

            //zamknięcie połączenia
            if (con.State == ConnectionState.Open) con.Close();

            return result;
        }

        /// <summary>
        /// Zwraca liczbę zmodyfikowanych rekordów.
        /// </summary>
        public static int UpdateStopOnRouteTransitTime(int id, int transitTime)
        {
            if (id < 1 || transitTime < 0)
            {
                return -1;
            }
            else
            {
                //nawiązanie połączenia
                if (con.State != ConnectionState.Open) con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE Stops_on_route SET transit_time = @time WHERE id = @id", con);

                //ustawienie reszty parametrów
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@time", transitTime);

                //pobranie liczby wstawionych rekordów
                int result = cmd.ExecuteNonQuery();

                //zamknięcie połączenia
                if (con.State == ConnectionState.Open) con.Close();

                return result;
            }
        }

        #endregion

        #region DataTables - to wypełniania "własnych" gridów

        public static DataTable GetLinesByStopId(int stopId)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            if (stopId < 0)
                return null;
            
            //Sprawdzanei czy przystanek jest w jakiejś trasie.
            List<string[]> stopsOnRoute = SelectFromStopsOnRouteByStopId(stopId);
            if (stopsOnRoute.Count == 0)
                return null;

            List<int> lineIds = new List<int>();
            List<string> types = new List<string>();
            List<string> times = new List<string>();
            DataTable results = new DataTable();
            results.Columns.Add("Linia", typeof(string));
            results.Columns.Add("Typ", typeof(string));
            results.Columns.Add("Odjazdy", typeof(string));

            foreach(string[] stop in stopsOnRoute)
            {
                int id = int.Parse(stop[0]);
                int firstStopId = int.Parse(SelectPreviousFromStopsOnRouteById(id).Last()[0]);
                int lastStopId = int.Parse(SelectNextFromStopsOnRouteById(id).Last()[0]);
                List<string[]> transits = SelectFromTransitsByRoute(firstStopId, lastStopId);
                string timeString = "";
                foreach (string[] transit in transits)
                {
                    if (!lineIds.Contains(int.Parse(transit[1])))
                    {
                        lineIds.Add(int.Parse(transit[1]));
                        string type;
                        switch (int.Parse(SelectFromLinesById(int.Parse(transit[1]))[0][2]))
                        {
                            case 0:
                                type = "Zwykla";
                                break;
                            case 1:
                                type = "Nocna";
                                break;
                            default:
                                type = "BLAD";
                                break;
                        }
                        string vehicle_type;
                        switch (int.Parse(SelectFromLinesById(int.Parse(transit[1]))[0][3]))
                        {
                            case 0:
                                vehicle_type = "Autobusowa";
                                break;
                            case 1:
                                vehicle_type = "Tramwajowa";
                                break;
                            case 2:
                                vehicle_type = "Trolejbusowa";
                                break;
                            default:
                                vehicle_type = "BLAD";
                                break;
                        }
                        types.Add(vehicle_type + " " + type);
                    }
                    int iteratorId = firstStopId;
                    DateTime time = DateTime.Parse(transit[6]);
                    while(int.Parse(SelectFromStopsOnRouteById(iteratorId)[0][0]) != id)
                    {
                        time.AddMinutes(int.Parse(SelectFromStopsOnRouteById(iteratorId)[0][5]));
                        iteratorId = int.Parse(SelectFromStopsOnRouteById(iteratorId)[0][2]);
                    }
                    timeString += time.ToShortTimeString() + " ";
                }
                times.Add(timeString);
            }

            for(int i = 0; i < lineIds.Count; i++)
            {
                results.Rows.Add(SelectFromLinesById(lineIds[i])[0][1], types[i], times[i]);
            }
            Console.WriteLine(results.Rows[0].Field<string>(0));
            return results;
        }

        public static DataTable GetRouteByFirstStopId(int firstId)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (firstId < 0)
            {
                return null;
            }
            else
            {
                string query = "WITH x AS " +
                    "(SELECT id, id_stop, id_next, ordinal_no, transit_time " +
                    "FROM Stops_on_route " +
                    "WHERE id = @id " +
                    "UNION ALL " +
                    "SELECT son.id, son.id_stop, son.id_next, son.ordinal_no, son.transit_time " +
                    "FROM x " +
                    "JOIN Stops_on_route son " +
                    "ON x.id_next = son.id) " +
                    "SELECT x.id, x.ordinal_no, s.district, s.name, x.transit_time " +
                    "FROM x, Stops s " +
                    "WHERE x.id_stop = s.id";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", firstId);
            }

            //pobranie wyników zapytania
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return dt;
        }

        public static DataTable GetRoutesAsFirstAndLastStops()
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;

            string query =
                "SELECT son1.id, CONCAT(s1.district, ' ', s1.name), son2.id, CONCAT(s2.district, ' ', s2.name) " +
                "FROM Transits t, Stops_on_route son1, Stops_on_route son2, Stops s1, Stops s2 " +
                "WHERE t.id_first_stop = son1.id " +
                "AND t.id_last_stop = son2.id " +
                "AND son1.id_stop = s1.id " +
                "AND son2.id_stop = s2.id";

            cmd = new SqlCommand(query, con);

            //pobranie wyników zapytania
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return dt;
        }

        public static DataTable GetTransits(int lineId, int weekDay, int dayType)
        {
            if (lineId < 1 || weekDay < 0 || dayType < 0)
            {
                return null;
            }

            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            string query = "SELECT t.id, CONCAT(s1.district, ' ', s1.name), CONCAT(s2.district, ' ', s2.name), t.start_time, t.pref_vehicle_cap " +
                "FROM Transits t, Stops_on_route son1, Stops_on_route son2, Stops s1, Stops s2 " +
                "WHERE t.id_line = @lineId " +
                "AND t.weekday = @week " +
                "AND t.day_type = @type " +
                "AND t.id_first_stop = son1.id " +
                "AND son1.id_stop = s1.id " +
                "AND t.id_last_stop = son2.id " +
                "AND son2.id_stop = s2.id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@lineId", lineId);
            cmd.Parameters.AddWithValue("@week", weekDay);
            cmd.Parameters.AddWithValue("@type", dayType);

            //pobranie wyników zapytania
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return dt;
        }

        public static DataTable GetCourses()
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            string query =
                "SELECT " +
                    "c.id, " +
                    "(SELECT CONCAT(e.name, ' ', e.surname) FROM Employees e WHERE c.id_driver = e.id) AS driver, " +
                    "(SELECT CONCAT(v.reg_no, ' ', v.side_no) FROM Vehicles v WHERE c.id_vehicle = v.id) AS vehicle, " +
                    "CONCAT(l.line_no, ' ', s1.district, ' ', s1.name, ' - ', s2.district, ' ', s2.name), " +
                    "c.date " +
                "FROM " +
                    "Courses c, Transits t, Stops_on_route son1, Stops_on_route son2, Stops s1, Stops s2, Lines l " +
                "WHERE " +
                    "c.id_transit = t.id " +
                    "AND t.id_line = l.id " +
                    "AND t.id_first_stop = son1.id " +
                    "AND son1.id_stop = s1.id " +
                    "AND t.id_last_stop = son2.id " +
                    "AND son2.id_stop = s2.id";

            SqlCommand cmd = new SqlCommand(query, con);

            //pobranie wyników zapytania
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return dt;
        }
        #endregion

        #region  metody SECURITY CHECK

        /// <summary>
        /// Metoda stwierdzająca bezpieczeństwo danego parametru dla zapytania lub filtru. Zwraca true dla bezpiecznego
        /// i false dla nie bezpiecznego parametru tekstowego.
        /// </summary>
        public static bool IsQuerySecure(string queryParameter)
        {
            Regex forbiddenPattern = new Regex(@"(;|((\s|\n|\r)select(\s|\n|\r))|((\s|\n|\r)delete(\s|\n|\r))|((\s|\n|\r)insert(\s|\n|\r))|((\s|\n|\r)update(\s|\n|\r)))", RegexOptions.IgnoreCase);
            MatchCollection matches = forbiddenPattern.Matches(queryParameter);
            return matches.Count <= 0;
        }

        #endregion

        /// <summary>
        /// Metoda zwraca true, jeśli kierowca o danym id ma wpisane wolne na dany dzień
        /// </summary>
        public static bool DoDriverHaveAbsenceOnDate(int driverId, DateTime date)
        {
            //nawiązanie połączenia
            if (con.State != ConnectionState.Open) con.Open();

            //zapytanie i uzupełnienie o ID
            SqlCommand cmd;
            if (driverId < -1)
            {
                if (con.State == ConnectionState.Open) con.Close();
                return false;
            }

            cmd = new SqlCommand("SELECT * FROM Absences WHERE id_driver = @id AND day = @date", con);
            cmd.Parameters.AddWithValue("@id", driverId);
            cmd.Parameters.AddWithValue("@date", date);

            if(cmd.ExecuteScalar() != null)
            {
                return true;
            }

            //zamknięcie połącznia
            if (con.State == ConnectionState.Open) con.Close();

            return false;
        }

    }
}