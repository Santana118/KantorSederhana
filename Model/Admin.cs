using System;
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
                Console.WriteLine($"2. Timesheet ");
                Console.WriteLine($"3. Add Employee ");
                Console.WriteLine($"4. Remove Employee ");
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
}
