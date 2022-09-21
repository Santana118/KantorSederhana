using System;
using KantorSederhana;
using System.Data.SqlClient;
namespace KantorSederhana.Model
{

    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DepartementId { get; set; }
        public string DivisionId { get; set; }
        public string PrivilegeLevel { get; set; }
        public SqlConnection conn;
        public virtual void Homepage()
        {
            while (true)
            {
                //Console.WriteLine($"Selamat Datang {Name}");
                Console.WriteLine($"---------------------------");
                Console.WriteLine($"Pilih Opsi :");
                Console.WriteLine($"1. Board Annoucement ");
                Console.WriteLine($"2. Timesheet ");
                Console.WriteLine($"q. Logout ");
                Console.WriteLine($"---------------------------");
                
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        AnnouncementBoard();
                        Console.WriteLine(" ");
                        break;
                    case "2":
                        Console.Clear();
                        TimesheetBoard();
                        Console.WriteLine(" ");
                        break;
                    case "q":
                        Console.WriteLine("Exiting application ....");
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Unrecognized User input");
                        break;
                }
            }

        }
        public void AnnouncementBoard()
        {
            string query = "SELECT * FROM V_AnnouncementBoard;";
            Program program = new Program();
            conn = new SqlConnection(program.connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        Console.WriteLine("ANNOUNCEMENT");
                        Console.WriteLine("{0,-20} {1,10} {2, -30}", "POSTER", "DATE","BODY");
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine("{0,-20} {1,10} {2,40}", sqlDataReader[0], sqlDataReader[1], sqlDataReader[2]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("NO ANNOUNCEMENT");
                    }

                    sqlDataReader.Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void TimesheetBoard()
        {
            string query = "SELECT Timesheet.dateStart, Timesheet.dateEnd, Project.name, Departement.name, Division.name, Timesheet.task, Timesheet.currentStatus " +
                "FROM Timesheet "+
                "JOIN Departement ON(Timesheet.departementId = Departement.id) "+
                "JOIN Division ON(Timesheet.divisionId = Division.id) "+
                "JOIN Project ON(Timesheet.projectId = Project.id) "+
                $"WHERE Departement.id = {this.DepartementId} AND Division.id = {this.DivisionId}";
            Program program = new Program();
            conn = new SqlConnection(program.connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        Console.WriteLine($"TIMESHEET FOR {this.Name}");
                        Console.WriteLine("{0,-18}  {1,-18}  {2, -20}  {3, -10}  {4, -10}  {5, -10}  {6, -10}", "START DATE", "END DATE", "PROJECT", "Departemen", "Division", "TASK", "STATUS");
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}", 
                                sqlDataReader[0], 
                                sqlDataReader[1],
                                sqlDataReader[2],
                                sqlDataReader[3],
                                sqlDataReader[4],
                                sqlDataReader[5],
                                sqlDataReader[6]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("NO SCHEDULE");
                    }

                    sqlDataReader.Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void DisplayQuery(string query)
        {
            Program program = new Program();
            conn = new SqlConnection(program.connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        
                        
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine($"{sqlDataReader[0]} | {sqlDataReader[1]}");
                        }
                    }

                    sqlDataReader.Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
