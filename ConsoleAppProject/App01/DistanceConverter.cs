using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This application allows the user to convert different distance units.(metres, miles and feet)
    /// </summary>
    /// <author>
    /// Nicoara Danci 07/03/2022
    /// </author>
    public class DistanceConverter
    {

        public const int FEET_IN_MILES = 5280;
        public const double METRES_IN_MILES = 1609.34;
        public const double FEET_IN_METRES = 3.28;


        public DistanceUnits fromUnit { get; set; }

        public DistanceUnits toUnit { get; set; }

        public double toDistance { get; set; }

        public double fromDistance { get; set; }

        /// <summary>
        /// This method will run the program and print a heading
        /// </summary>
        public void Run()
        {
            ConsoleHelper.OutputHeading(" Distance Converter");

            fromUnit = SelectUnit("  Please select the unit you want to convert > ");
            toUnit = SelectUnit("  Please select the unit you want to convert in > ");

            Console.WriteLine($"  You are converting {fromUnit} to {toUnit} \n ");

            fromDistance = ConsoleHelper.InputNumber($"  Please input the distance in {fromUnit} > ");

            ConvertDistance();

            OutputDistance();
        }


        private DistanceUnits SelectUnit(string prompt)
        {
            string[] choices =
                {
                    $"  {DistanceUnits.Miles}",
                    $"  {DistanceUnits.Feet}",
                    $"  {DistanceUnits.Metres}"
                };

            Console.WriteLine(prompt);
            Console.WriteLine();
            int choice = ConsoleHelper.SelectChoice(choices);

            return ExecuteChoice(choice);
        }


        private static DistanceUnits ExecuteChoice(int choice)
        {
            switch (choice)
            {
                case 1: return DistanceUnits.Miles; break;
                case 2: return DistanceUnits.Feet; break;
                case 3: return DistanceUnits.Metres; break;

                default: return DistanceUnits.NoUnit;
            }
        }

        private void OutputDistance()
        {
            Console.WriteLine();
            Console.WriteLine($" {fromDistance} {fromUnit} = {toDistance}  {toUnit}!");
            Console.WriteLine();
        }

        /// <summary>
        /// This method converts the distance chosed by the user 
        /// </summary>
        public void ConvertDistance()
        {
            if (fromUnit == DistanceUnits.Miles &&
                  toUnit == DistanceUnits.Feet)
            {
                toDistance = fromDistance * FEET_IN_MILES;
            }
            else if (fromUnit == DistanceUnits.Feet &&
                       toUnit == DistanceUnits.Miles)
            {
                toDistance = fromDistance / FEET_IN_MILES;
            }
            else if (fromUnit == DistanceUnits.Metres &&
                       toUnit == DistanceUnits.Miles)
            {
                toDistance = fromDistance / METRES_IN_MILES;
            }
            else if (fromUnit == DistanceUnits.Miles &&
                    toUnit == DistanceUnits.Metres)
            {
                toDistance = fromDistance * METRES_IN_MILES;
            }
            else if (fromUnit == DistanceUnits.Metres &&
                    toUnit == DistanceUnits.Feet)
            {
                toDistance = fromDistance * FEET_IN_METRES;
            }
            else if (fromUnit == DistanceUnits.Feet &&
                    toUnit == DistanceUnits.Metres)
            {
                toDistance = fromDistance / FEET_IN_METRES;
            }

        }
        
    }
}
