using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;
using ConsoleAppProject.App04;
using ConsoleAppProject.Helpers;
using System;


namespace ConsoleAppProject
{
    /// <summary>
    /// The main method is called first whe the program starts.
    /// It enables the user to select wich application to use
    /// 
    /// Nicoara Danci
    /// @version 03/04/22
    /// </summary>

    public static class Program
    {
        private static int choice;
        public static void Main(string[] args)
        {
           

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine();
            Console.WriteLine("  =================================================");
            Console.WriteLine();

            Console.WriteLine("     BNU CO453 Applications Programming 2021-2022! ");
            Console.WriteLine("                                ");
            Console.WriteLine("  =================================================");

            Console.WriteLine(" =================================================");
            Console.WriteLine("    BNU CO453 Applications Programming 2021-2022! ");
            Console.WriteLine("        by Nicoara Danci                          ");
            Console.WriteLine(" =================================================");

            Console.WriteLine();

            string[] choices = new string[]
            {
                "Distance Converter",
                "BMI Calculator",
                "Student Grades",
                "Social Network"
                
            };

            ConsoleHelper.OutputTitle("  Please select a application > ");
            choice = ConsoleHelper.SelectChoice(choices);

            if (choice == 1)
            {
                DistanceConverter converter = new DistanceConverter();
                converter.Run();
            }
            else if (choice == 2)
            {
                BMI calculator = new BMI();
                calculator.Run();
            }
            else if (choice == 3)
            {
                StudentGrades studentGrades = new StudentGrades();
                studentGrades.Run();
            }
            else if (choice == 4)
            {
                NetworkApp network = new NetworkApp();
                network.Run();
            }

        }
    }
}