using System;
using System.Collections.Generic;
using System.Linq;
using CoreSchool;
using CoreSchool.App;
using CoreSchool.Entities;
using CoreSchool.Util;

namespace CoreSchools
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += EventAction;

            var engine = new SchoolEngine();
            engine.Init();
            Printer.WriteTitle("WELCOME TO SCHOOL");
            Console.WriteLine(engine.School);

            var dictionary = engine.GetObjectDictionary();
            engine.PrintDictionary(dictionary, true);

            var report = new Reporter(engine.GetObjectDictionary());
            var listProm = report.GetPromeStudentsforAsignature();
        }

        private static void EventAction(object sender, EventArgs e)
        {
            Printer.WriteTitle("Exit");
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
