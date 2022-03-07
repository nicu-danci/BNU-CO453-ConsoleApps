using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// The application determines the users BMI and outputing their  
    /// BMI Status and a message explaining to BAME groups their extra risks.
    /// 
    /// </summary>
    /// <author>
    /// Nicoara Danci 07/03/2022.
    /// </author>
    public class BMI
    {
        public const string IMPERIAL = "Imperial";
        public const string METRIC = "Metric";

        public const string FEET = "Feet";
        public const string INCHES = "Inches";

        public const int INCHES_IN_FEET = 12;
        public const int POUNDS_IN_STONE = 14;
        public const int IMPERIAL_FACTOR = 703;

        public double BMI_Index { get; set; }
        public BMI_Status Status { get; set; }

        public double Height { get; set; }
        public double Weight { get; set; }


        private string unitChoice;

        /// <summary>
        /// This method will run the application and prints out a heading
        /// </summary>
        public void Run()
        {
            
                ConsoleHelper.OutputHeading("BMI Calculator");
                ConvertBMI();
              
            
        }

        /// <summary>
        /// This method prompts the user to chose a unit (imperial or metric)
        /// </summary>
        public void ConvertBMI()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  Please select a unit > \n ");

            string[] choices = new string[]
            {
                IMPERIAL, METRIC
            };

 
            int choice = ConsoleHelper.SelectChoice(choices);
            unitChoice = choices[choice - 1];

            Console.WriteLine($"\n You have selected {unitChoice}! ");

            if (unitChoice == IMPERIAL)
            {
                InputImperial();
                CalculateImperial();
            }
            else if (unitChoice == METRIC)
            {
                InputMetric();
                CalculateMetric();
            }

            OutputBMI_Index();
            string input = Console.ReadLine();
        }

        /// <summary>
        /// Prompts user to enter height in feet and inches
        /// and their weight in stones and pounds. Converts
        /// feet to inches and stones to pounds to calculate
        /// single unit results for both height and weight
        /// </summary>
        private void InputImperial()
        {
            Height = ConsoleHelper.InputNumber($"\n Enter your height in feet > ");
            int inches = (int)ConsoleHelper.InputNumber($" Enter your height in inches > ", 0, INCHES_IN_FEET);
            Height = Height * INCHES_IN_FEET + inches;

            Weight = ConsoleHelper.InputNumber($"\n Enter your weight in stone > ");
            int pounds = (int)ConsoleHelper.InputNumber($" Enter your weight in pounds > ", 0, POUNDS_IN_STONE);
            Weight = Weight * POUNDS_IN_STONE + pounds;
        }

        /// <summary>
        /// Prompts the user to enter height and weight
        /// </summary>
        private void InputMetric()
        {
            Height = ConsoleHelper.InputNumber($"\n Enter your height in metres > ");

            Weight = ConsoleHelper.InputNumber($"\n Enter your weight in kilograms > ");
        }

        /// <summary>
        /// Calculates BMI using  the following formula for imperial units
        /// BMI = (weight in pounds) x 703 / (height in inches)2
        /// </summary>
        public void CalculateImperial()
        {
            BMI_Index = (Weight * IMPERIAL_FACTOR) / (Height * Height);
        }

        /// <summary>
        /// Calculates BMI using the following  formula for metric units
        /// BMI = (weight in kg) / (height in metres)2
        /// </summary>
        public void CalculateMetric()
        {
            BMI_Index = Weight / (Height * Height);
        }

        /// <summary>
        /// This method uses more and less thans to classify the BMI
        /// status through the BMI Index and the BMI_Status Enumeration
        /// class
        /// </summary>
        private void OutputBMI_Index()
        {
            if (BMI_Index < 18.50)
            {
                Status = BMI_Status.UnderWeight;
            }
            else if (BMI_Index > 18.5 && BMI_Index < 24.9)
            {
                Status = BMI_Status.NormalWeight;
            }
            else if (BMI_Index > 25.0 && BMI_Index < 29.9)
            {
                Status = BMI_Status.OverWeight;
            }
            else if (BMI_Index > 30.00 && BMI_Index < 34.9)
            {
                Status = BMI_Status.ObeseI;
            }
            else if (BMI_Index > 35.0 && BMI_Index < 39.9)
            {
                Status = BMI_Status.ObeseII;
            }
            else if (BMI_Index >= 40.0)
            {
                Status = BMI_Status.ObeseIII;
            }

            Console.WriteLine($"\n Your BMI index is {BMI_Index: 0.00}");
            Console.WriteLine($"Your BMI status is {Status}");

            Console.WriteLine("\n If you are Black, Asian, or other minority ethnic group " +
                "\n you have a higher risk of developing some long-term conditions, such as type 2 diabetes");

            Console.WriteLine( "\n These adults with a BMI of:");

            Console.WriteLine("\n 23.0 or more are at increased risk " +
                "\n 27.5 or more are at high risk");


        }


    }
}