using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// This app will allow the user to
    /// enter a  mark for every student from a list
    /// and convert that mark into a grade
    /// It also calculates simple statistic and
    /// displays a student grade profile
    /// </summary>
    /// 
    /// <author>
    /// Nicoara Danci 20/03/2022
    /// </author>
    public class StudentGrades
    {
        // Constants (Grade Margins)

        public const int LowestMark = 0;
        public const int LowestGradeD = 40;
        public const int LowestGradeC = 50;
        public const int LowestGradeB = 60;
        public const int LowestGradeA = 70;
        public const int HighestMark = 100;

        // Properties

        public string[] Students { get; set; }

        public int[] Marks { get; set; }

        public int[] GradeProfile { get; set; }

        public double Mean { get; set; }

        public int Minimum { get; set; }
        public int Maximum { get; set; }

        /// <summary>
        /// This method will run the program and outputs a heading
        /// </summary>
        public void Run()
        {
            bool repeat = true;
            while (repeat)
            {
                ConsoleHelper.OutputHeading("Student Grades");
                //StudentGrades();
                repeat = ConsoleHelper.WantToRepeat();
            }
        }

        /// <summary>
        /// This method holds the names of the students. It
        /// runs the methods to input the marks, output the
        /// marks, calculate the stats, and calculate the
        /// grade profile for  each student
        /// </summary>
        public StudentGrades()
        {
            Students = new string[]
            {
                "Nick", "Sabrina", "Emy", "Oana",
                "Maria", "Anca", "Monica", "Izabella",
                "Ioana", "Patrick"
            };

            GradeProfile = new int[(int)Grades.A + 1];

            Marks = new int[Students.Length];

            InputMarks();
            OutputMarks();
            CalculateStats();
            CalculateGradeProfile();
        }

        /// <summary>
        /// This method allows the user to input a mark
        /// between 0 - 100 for each student 
        /// </summary>
        public void InputMarks()
        {
            ConsoleHelper.OutputTitle(" Entering Student Marks");
            Console.WriteLine(" Please enter a mark for the following students:");

            for (int index = 0; index < Students.Length; index ++)
            {
                Marks[index] = (int)ConsoleHelper.InputNumber($" {Students[index]} > ", 0, 100);
            }
        }

        /// <summary>
        /// This method lists all the students and displays
        /// their name and current mark and grade
        /// </summary>
        public void OutputMarks()
        {
            ConsoleHelper.OutputTitle(" Student Marks:");

            for (int index = 0; index < Students.Length; index++)
            {
                Grades grade = ConvertToGrade(Marks[index]);
                string name = EnumHelper<Grades>.GetName(grade);

                Console.WriteLine($" {Students[index]} {Marks[index]}% - Grade {grade} | {name}");
            }
        }

        /// <summary>
        /// This method converts a student mark to a grade
        /// </summary>
        public Grades ConvertToGrade(int mark)
        {
            if (mark >= LowestMark && mark < LowestGradeD)
            {
                return Grades.F;
            }
            else if (mark >= LowestGradeD && mark < LowestGradeC)
            {
                return Grades.D;
            }
            else if (mark >= LowestGradeC && mark < LowestGradeB)
            {
                return Grades.C;
            }
            else if (mark >= LowestGradeB && mark < LowestGradeA)
            {
                return Grades.B;
            }
            else if (mark >= LowestGradeA && mark <= HighestMark)
            {
                return Grades.A;
            }
            else
            {
                return Grades.None;
            }
        }

        /// <summary>
        /// This method calculates and outputs the minimum,
        /// maximum and mean mark for the students
        /// </summary>
        public void CalculateStats()
        {
            double total = 0;

            Minimum = HighestMark;
            Maximum = 0;

            foreach (int mark in Marks)
            {
                total = total + mark;
                if (mark > Maximum) Maximum = mark;
                if (mark < Minimum) Minimum = mark;
            }
            Mean = total / Marks.Length;
            OutputStats();
        }

        /// <summary>
        /// This method outputs the statistics of the
        /// students (the minimum, mean
        /// and maximum)
        /// </summary>
        private void OutputStats()
        {
            ConsoleHelper.OutputTitle(" Student Marks Statistics: ");
            Console.WriteLine($" Number of students marked = {Marks.Length}");
            Console.WriteLine($" Minimum mark = {Minimum}");
            Console.WriteLine($" Mean mark = {Mean}");
            Console.WriteLine($" Maximum mark = {Maximum}");
        }

        /// <summary>
        /// This method calculates a grade profile
        /// </summary>
        public void CalculateGradeProfile()
        {
            for(int i = 0; i < GradeProfile.Length; i++)
            {
                GradeProfile[i] = 0;
            }

            foreach(int mark in Marks)
            {
                Grades grade = ConvertToGrade(mark);
                GradeProfile[(int)grade]++;
            }

            OutputGradeProfile();
        }

        /// <summary>
        /// This method outputs the Grade Profile
        /// </summary>
        private void OutputGradeProfile()
        {
            Grades grade = Grades.None;
            ConsoleHelper.OutputTitle("\n Number of students and percentage that " +
                             " achieved the following grades:"); 

            foreach (int count in GradeProfile)
            {
                int percentage = count * 100 / Marks.Length;
                Console.WriteLine($" \n Grade {grade} - {percentage}% | Count {count}");
                grade++;
            }

            Console.WriteLine();
        }
    }
}
