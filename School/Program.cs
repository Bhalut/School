using System;
using System.Collections.Generic;
using CoreSchool;
using CoreSchool.Entities;
using CoreSchool.Util;

namespace CoreSchools
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new SchoolEngine();
            engine.Init();
            Printer.WriteTitle("WELCOME TO SCHOOL");
            Console.WriteLine(engine.School);

            PrintCourseSchool(engine.School);
        }

        private static void PrintCourseSchool(School school)
        {
            Printer.WriteTitle("Courses Of School");
            
            if (school?.Courses != null)
            {
                foreach (var course in school.Courses)
                {
                    Console.WriteLine($"Name: {course.Name} , ID: {course.UniqueId}");
                }
            }
            else
            {
                return;
            }
        }
    }
}
