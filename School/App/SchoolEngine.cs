using System;
using System.Collections.Generic;
using System.Linq;
using CoreSchool.Entities;

namespace CoreSchool
{
    public class SchoolEngine
    {
        public School School { get; set; }

        public void Init()
        {
            School = new School("Platzi Academy", 2009, TypesSchool.HighSchool, "Colombia", "Bogota");
            LoadCourse();
            LoadAsignature();
            LoadTest();
        }

        private void LoadTest()
        {
            foreach (var course in School.Courses)
            {
                foreach (var asignature in course.Asignatures)
                {
                    foreach (var studient in course.Studients)
                    {
                        var rmd = new Random(System.Environment.TickCount);
                        for (int i = 0; i < 5; i++)
                        {
                            var test = new Test
                            {
                                Asignature = asignature,
                                Name = $"{asignature.Name}, Test: #{i + 1}",
                                Calification = (float)(5 * rmd.NextDouble()),
                                Studient = studient
                            };
                            studient.Test.Add(test);
                        }
                    }
                }
            }
        }

        private void LoadAsignature()
        {
            foreach (var course in School.Courses)
            {
                var listAsignatures = new List<Asignature>()
                {
                            new Asignature{Name = "Maths"} ,
                            new Asignature{Name = "Sport"},
                            new Asignature{Name = "Lenguages"},
                            new Asignature{Name = "Sciences"}
                };
                course.Asignatures = listAsignatures;
            }
        }

        private List<Studient> GeneratorStudients(int size)
        {
            string[] _name1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] _lastName1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] _name2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listStudients =  from n1 in _name1
                                from n2 in _name2
                                from a1 in _lastName1
                                select new Studient{ Name = $"{n1} {n2} {a1}" };
            
            return listStudients.OrderBy( (studient)=> studient.UniqueId ).Take(size).ToList();
        }

        private void LoadCourse()
        {
            School.Courses = new List<Course>
            {
                new Course{Name = "101", Types = TypesWorkingDay.Morning},
                new Course{Name = "201", Types = TypesWorkingDay.Morning},
                new Course{Name = "301", Types = TypesWorkingDay.Morning},
                new Course{Name = "401", Types = TypesWorkingDay.Late},
                new Course{Name = "501", Types = TypesWorkingDay.Late}
            };

            Random rmd = new Random();
            
            foreach (var course in School.Courses)
            {
                int sizeRandom = rmd.Next(5, 20);
                course.Studients = GeneratorStudients(sizeRandom);
            }
        }
    }
}