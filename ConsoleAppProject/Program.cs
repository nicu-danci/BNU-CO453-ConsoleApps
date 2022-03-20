using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.Helpers;
using System;


namespace ConsoleAppProject
{
    /// <summary>
    /// The main method is called first whe the program starts.
    /// It enables the user to select wich application to use
    /// 
    /// This Project has been modified by:
    /// Nicoara Danci 07/03/2022
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
<<<<<<< HEAD
            Console.WriteLine("     BNU CO453 Applications Programming 2021-2022! ");
            Console.WriteLine("                                ");
            Console.WriteLine("  =================================================");
=======
            Console.WriteLine(" =================================================");
            Console.WriteLine("    BNU CO453 Applications Programming 2021-2022! ");
            Console.WriteLine("        by Nicoara Danci                          ");
            Console.WriteLine(" =================================================");
>>>>>>> 2d1e4bc64c05c955731fc35cc7e0296e51d014c5
            Console.WriteLine();

            string[] choices = new string[]
            {
                "Distance Converter",
                "BMI Calculator",
                
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

        }
    }
}