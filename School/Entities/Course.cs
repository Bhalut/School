using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using CoreSchool.Util;

namespace CoreSchool.Entities
{
    public class Course : BaseSchoolObject, IPlace
    {
        public TypesWorkingDay Types { get; set; }
        public List<Asignature> Asignatures { get; set; }
        public List<Studient> Studients { get; set; }
        public string Direction { get; set; }

        public void ClearPlace()
        {
            Printer.DrawLine();
            Console.WriteLine("Cleaning Place...");
            Console.WriteLine($"Curso: {Name} Clean...");
        }
    }
}