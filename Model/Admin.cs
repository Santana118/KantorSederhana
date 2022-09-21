using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace KantorSederhana.Model
{
    public class Admin : Employee
    {
        public override void Homepage()
        {
            while (true)
            {
                //Console.WriteLine($"Selamat Datang {Name}");
                Console.WriteLine($"---------------------------");
                Console.WriteLine($"Pilih Opsi :");
                Console.WriteLine($"1. Board Annoucement ");
                Console.WriteLine($"2. List All Timesheet ");
                Console.WriteLine($"3. Add Employee ");
                Console.WriteLine($"4. Remove Employee ");
                Console.WriteLine($"5. Update Employee ");
                Console.WriteLine($"6. List Employee ");
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
                        ListAllTimesheet();
                        Console.WriteLine(" ");
                        break;
                    case "3":
                        Console.Clear();
                        CreateEmployee();
                        Console.WriteLine(" ");
                        break;
                    case "4":
                        Console.Clear();
                        DeleteEmployee();
                        Console.WriteLine(" ");
                        break;
                    case "5":
                        Console.Clear();
                        UpdateEmployee();
                        Console.WriteLine(" ");
                        break;
                    case "6":
                        Console.Clear();
                        DisplayQuery("SELECT * FROM Employee");
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
        void CreateEmployee()
        {
            string[] sendData = new string[9];
            Console.Write("Masukkan Nama Lengkap : ");
            sendData[0] = Console.ReadLine();
            Console.Write("username : ");
            sendData[1] = Console.ReadLine();
            Console.Write("Password : ");
            sendData[2] = Console.ReadLine();
            Console.Write("Tanggal Diterima (YYYY-MM-DD) : ");
            sendData[3] = Console.ReadLine();
            DisplayQuery("SELECT * FROM Departement");
            Console.Write("Pilih Id Departemen : ");
            sendData[4] = Console.ReadLine();
            DisplayQuery("SELECT * FROM Division");
            Console.Write("Pilih Id Divisi : ");
            sendData[5] = Console.ReadLine();
            DisplayQuery("SELECT id, name FROM Employee WHERE managerId IS NULL");
            Console.Write("Pilih ID Manager : ");
            sendData[6] = Console.ReadLine();
            Console.Write("Gaji ");
            sendData[7] = Console.ReadLine();
            Console.Write("Privilege Level : ");
            sendData[8] = Console.ReadLine();

            Program program = new Program();
            using (SqlConnection conn = new SqlConnection(program.connectionString))
            {
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();

                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@name";
                sqlParameter.Value = sendData[0];
                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@username";
                sqlParameter1.Value = sendData[1];
                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@password";
                sqlParameter2.Value = sendData[2];
                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@hireDate";
                sqlParameter3.Value = sendData[3];
                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@idDepartement";
                sqlParameter4.Value = sendData[4];
                SqlParameter sqlParameter5 = new SqlParameter();
                sqlParameter5.ParameterName = "@idDivision";
                sqlParameter5.Value = sendData[5];
                SqlParameter sqlParameter6 = new SqlParameter();
                sqlParameter6.ParameterName = "@idManager";
                sqlParameter6.Value = sendData[6];
                SqlParameter sqlParameter7 = new SqlParameter();
                sqlParameter7.ParameterName = "@salary";
                sqlParameter7.Value = sendData[7];
                SqlParameter sqlParameter8 = new SqlParameter();
                sqlParameter8.ParameterName = "@privilege";
                sqlParameter8.Value = sendData[8];

                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);
                sqlCommand.Parameters.Add(sqlParameter5);
                sqlCommand.Parameters.Add(sqlParameter6);
                sqlCommand.Parameters.Add(sqlParameter7);
                sqlCommand.Parameters.Add(sqlParameter8);

                try
                {
                    sqlCommand.CommandText = "INSERT INTO Employee " +
                        "VALUES (@name, @username, @password, @hireDate, @idDepartement, @idDivision, @idManager, @salary, @privilege)";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine("Success membuat karyawan abru !!!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Input tidak valid");
                }
            }
        }
        void DeleteEmployee()
        {
            DisplayQuery("SELECT id, name FROM Employee");
            Console.Write("Pilih id karyawan yang akan dihapus : ");
            string input = Console.ReadLine();
            Program program = new Program();
            using (SqlConnection conn = new SqlConnection(program.connectionString))
            {
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();

                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@id";
                sqlParameter.Value = input;

                sqlCommand.Parameters.Add(sqlParameter);


                try
                {
                    sqlCommand.CommandText = "DELETE FROM Employee " +
                        "WHERE id = @id";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine("Success Menghapus karywan !!!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Input tidak valid");
                }
            }
        }
        void UpdateEmployee()
        {
            string[] sendData = new string[9];
            string idEmployee;
            DisplayQuery("SELECT id, name FROM Employee");
            Console.Write("Masukkan ID Karyawan :");
            idEmployee = Console.ReadLine();
            Console.Write("Nama Lengkap : ");
            sendData[0] = Console.ReadLine();
            Console.Write("username : ");
            sendData[1] = Console.ReadLine();
            Console.Write("Password : ");
            sendData[2] = Console.ReadLine();
            Console.Write("Tanggal Diterima (YYYY-MM-DD) : ");
            sendData[3] = Console.ReadLine();
            DisplayQuery("SELECT * FROM Departement");
            Console.Write("Pilih Id Departemen : ");
            sendData[4] = Console.ReadLine();
            DisplayQuery("SELECT * FROM Division");
            Console.Write("Pilih Id Divisi : ");
            sendData[5] = Console.ReadLine();
            DisplayQuery("SELECT id, name FROM Employee WHERE managerId IS NULL");
            Console.Write("Pilih ID Manager : ");
            sendData[6] = Console.ReadLine();
            Console.Write("Gaji ");
            sendData[7] = Console.ReadLine();
            Console.Write("Privilege Level : ");
            sendData[8] = Console.ReadLine();

            Program program = new Program();
            using (SqlConnection conn = new SqlConnection(program.connectionString))
            {
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();

                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@name";
                sqlParameter.Value = sendData[0];
                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@username";
                sqlParameter1.Value = sendData[1];
                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@password";
                sqlParameter2.Value = sendData[2];
                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@hireDate";
                sqlParameter3.Value = sendData[3];
                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@idDepartement";
                sqlParameter4.Value = sendData[4];
                SqlParameter sqlParameter5 = new SqlParameter();
                sqlParameter5.ParameterName = "@idDivision";
                sqlParameter5.Value = sendData[5];
                SqlParameter sqlParameter6 = new SqlParameter();
                sqlParameter6.ParameterName = "@idManager";
                sqlParameter6.Value = sendData[6];
                SqlParameter sqlParameter7 = new SqlParameter();
                sqlParameter7.ParameterName = "@salary";
                sqlParameter7.Value = sendData[7];
                SqlParameter sqlParameter8 = new SqlParameter();
                sqlParameter8.ParameterName = "@privilege";
                sqlParameter8.Value = sendData[8];
                SqlParameter sqlParameter9 = new SqlParameter();
                sqlParameter9.ParameterName = "@id";
                sqlParameter9.Value = idEmployee;

                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);
                sqlCommand.Parameters.Add(sqlParameter5);
                sqlCommand.Parameters.Add(sqlParameter6);
                sqlCommand.Parameters.Add(sqlParameter7);
                sqlCommand.Parameters.Add(sqlParameter8);
                sqlCommand.Parameters.Add(sqlParameter9);

                try
                {
                    sqlCommand.CommandText = "UPDATE Employee " +
                        "SET name = @name, username = @username, passwd = @password, hireDate = @hireDate, departementId = @idDepartement, divisionId = @idDivision, managerId = @idManager, salary = @salary, privilegeLevel = @privilege " +
                        "WHERE id = @id";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine("Success update karyawan baru !!!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

        }
        void ListAllTimesheet()
        {
            string query = "SELECT Timesheet.dateStart, Timesheet.dateEnd, Project.name, Departement.name, Division.name, Timesheet.task, Timesheet.currentStatus " +
                "FROM Timesheet " +
                "JOIN Departement ON(Timesheet.departementId = Departement.id) " +
                "JOIN Division ON(Timesheet.divisionId = Division.id) " +
                "JOIN Project ON(Timesheet.projectId = Project.id) " +
                "ORDER BY Timesheet.dateStart ASC;";
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
    }
}
