using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace KantorSederhana.Model
{
    public class Manager : Employee
    {
        public override void Homepage()
        {
            while (true)
            {
                //Console.WriteLine($"Selamat Datang {Name}");
                Console.WriteLine($"---------------------------");
                Console.WriteLine($"Pilih Opsi :");
                Console.WriteLine($"1. Board Annoucement ");
                Console.WriteLine($"2. Timesheet ");
                Console.WriteLine($"3. Create Timesheet ");
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
                    case "3":
                        Console.Clear();
                        CreateTimesheet();
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
        void CreateTimesheet()
        {
            string[] sendData = new string[7];
            DisplayQuery("SELECT * FROM Project");
            Console.Write("Masukkan id project : ");
            sendData[0] = Console.ReadLine();
            Console.Write("Deskripsi pekerjaan : ");
            sendData[1] = Console.ReadLine();
            DisplayQuery("SELECT * FROM Departement");
            Console.Write("Masukkan id departemen : ");
            sendData[2] = Console.ReadLine();
            DisplayQuery("SELECT * FROM Division");
            Console.Write("Masukkan id divisi : ");
            sendData[3] = Console.ReadLine();
            Console.Write("Tanggal Mulai (YYYY-MM-DD) : ");
            sendData[4] = Console.ReadLine();
            Console.Write("Tanggal Berakhir (YYY-MM-DD) : ");
            sendData[5] = Console.ReadLine();
            Console.Write("Status (COMPLETED/ONGOING/ONCOMING) : ");
            sendData[6] = Console.ReadLine();

            Program program = new Program();
            using (SqlConnection conn = new SqlConnection(program.connectionString))
            {
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();

                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@idProject";
                sqlParameter.Value = sendData[0];
                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@task";
                sqlParameter1.Value = sendData[1];
                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@idDepartement";
                sqlParameter2.Value = sendData[2];
                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@idDIvision";
                sqlParameter3.Value = sendData[3];
                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@startDate";
                sqlParameter4.Value = sendData[4];
                SqlParameter sqlParameter5 = new SqlParameter();
                sqlParameter5.ParameterName = "@endDate";
                sqlParameter5.Value = sendData[5];
                SqlParameter sqlParameter6 = new SqlParameter();
                sqlParameter6.ParameterName = "@status";
                sqlParameter6.Value = sendData[6];

                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);
                sqlCommand.Parameters.Add(sqlParameter5);
                sqlCommand.Parameters.Add(sqlParameter6);

                try
                {
                    sqlCommand.CommandText = "INSERT INTO Timesheet " +
                        "VALUES (@idProject, @idDepartement, @idDivision, @task, @startDate, @endDate, @status)";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine("Success Adding new timesheet !!!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
