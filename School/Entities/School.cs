using System;
using System.Collections.Generic;
using CoreSchool.Util;

namespace CoreSchool.Entities
{
    public class School : BaseSchoolObject, IPlace
    {
        public int CreationYear { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Direction { get; set; }
        public TypesSchool Types { get; set; }
        public List<Course> Courses { get; set; }

        public School(string name, int year) => (Name, CreationYear) = (name, year);
        public School(string name, int year, TypesSchool types, string country = "", string city = "")
        {
            (Name, CreationYear, Types, Country, City) = (name, year, types, country, city);
        }

        public override string ToString() => $"Name: \"{Name}\", Type: {Types} \nCountry: {Country}, City: {City}";

        public void ClearPlace()
        {
            Printer.DrawLine();
            Console.WriteLine("Cleaning School...");
            foreach (var course in Courses)
            {
                course.ClearPlace();
            }
            Console.WriteLine($"School: {Name} Clean...");
        }
    }
}