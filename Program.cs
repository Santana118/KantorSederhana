using KantorSederhana.Model;
using System;
using System.Data.SqlClient;
namespace KantorSederhana
{
    class Program
    {
        SqlConnection conn;
        public string connectionString =
            "Data Source=WINDOWS-PC;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;" +
            "Encrypt=False;" +
            "TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;" +
            "MultiSubnetFailover=False;" +
            "Initial Catalog=KantorSederhana;" +
            "User ID=WINDOWS-PC\\Santana;" +
            "Password=mateyize49;";
        static void Main(string[] args)
        {
            Program program = new Program();
            while (true)
            {
                Console.WriteLine("APLIKASI KANTOR SEDERHANA v.0.0.1-aplha build");
                Console.Write("username : ");
                string username = Console.ReadLine();
                Console.Write("password : ");
                string password = Console.ReadLine();
                int accessLevel = program.TestLogin(username, password);
                string[] data = new string[5];
                if (accessLevel != -1)
                {
                    switch (accessLevel)
                    {
                        case 1:
                            data = program.GetUserData(username);
                            Employee employee = new Employee()
                            {
                                Id = data[0],
                                Name = data[1],
                                DepartementId = data[2],
                                DivisionId = data[3],
                                PrivilegeLevel = data[4],
                            };
                            Console.Clear();
                            Console.WriteLine($"Selamat Datang {employee.Name}");
                            employee.Homepage();
                            break;
                        case 2:
                            data = program.GetUserData(username);
                            Manager manager = new Manager()
                            {
                                Id = data[0],
                                Name = data[1],
                                DepartementId = data[2],
                                DivisionId = data[3],
                                PrivilegeLevel = data[4],
                            };
                            Console.Clear();
                            Console.WriteLine($"Selamat Datang Manager {manager.Name}");
                            manager.Homepage();
                            break;
                        case 3:
                            data = program.GetUserData(username);
                            Admin admin = new Admin()
                            {
                                Id = data[0],
                                Name = data[1],
                                DepartementId = data[2],
                                DivisionId = data[3],
                                PrivilegeLevel = data[4],
                            };
                            Console.Clear();
                            Console.WriteLine($"Selamat Datang Admin {admin.Name}");
                            admin.Homepage();
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Wrong password or username !!");
                }
            }

        }

        int TestLogin(string username, string passwd)
        {
            string query = $"SELECT privilegeLevel FROM Employee WHERE username='{username}' AND passwd='{passwd}';";
            conn = new SqlConnection(connectionString);
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
                            //Console.WriteLine(sqlDataReader[0]);
                            return (int)sqlDataReader[0];
                        }
                    }
                    else
                    {
                        //Console.WriteLine("Wrong password or username !!");
                    }
                    sqlDataReader.Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return -1;

        }

        string[] GetUserData(string username)
        {
            string query = $"SELECT TOP 1 id, name, departementId, divisionId, privilegeLevel FROM Employee WHERE username='{username}';";
            conn = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        string[] data = new string[5];
                        int i = 0;
                        while (sqlDataReader.Read())
                        {
                            data[0] = sqlDataReader[0].ToString();
                            data[1] = sqlDataReader[1].ToString();
                            data[2] = sqlDataReader[2].ToString();
                            data[3] = sqlDataReader[3].ToString();
                            data[4] = sqlDataReader[4].ToString();

                        }
                        return data;
                    }
                    sqlDataReader.Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return new string[0];
        }
        
    }
}
