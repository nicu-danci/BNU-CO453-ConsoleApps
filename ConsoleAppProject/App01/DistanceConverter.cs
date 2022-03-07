using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// Derek version 0.1
    /// </author>
    public class DistanceConverter
    {
        private int miles;
        private int feet;
        private string value;

        public void Run()
        {
            Console.WriteLine("Please enter a distance in miles");

            value = Console.ReadLine();
            miles = Convert.ToInt16(value);

            feet = miles * 5028;

            Console.WriteLine("The number of feet = " + feet);

        }
    }
}
