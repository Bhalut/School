using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using CoreSchool.Entities;
using CoreSchool.Util;

namespace CoreSchool
{
    public sealed class SchoolEngine
    {
        public School School { get; set; }

        public void Init()
        {
            School = new School("Platzi Academy", 2009, TypesSchool.HighSchool, "Colombia", "Bogota");
            LoadCourse();
            LoadAsignature();
            LoadTest();
        }

        public void PrintDictionary(Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>> dic,
        bool isPrintTest = false)
        {
            foreach (var key in dic)
            {
                Printer.WriteTitle(key.Key.ToString());
                foreach (var val in key.Value)
                {
                    switch (key.Key)
                    {
                        case KeyDictionary.Test:
                            if (isPrintTest)
                            {
                                Console.WriteLine(val);
                            }
                            break;
                        case KeyDictionary.School:
                            Console.WriteLine($"School: {val}");
                            break;

                        case KeyDictionary.Studient:
                            Console.WriteLine($"Studient: {val.Name}");
                            break;
                        case KeyDictionary.Course:
                            var courseTmp = val as Course;
                            if (courseTmp != null)
                            {
                                int count = courseTmp.Studients.Count;
                                Console.WriteLine($"Course: {val.Name}, Number of students: {count}");
                            }
                            break;

                        default:
                            Console.WriteLine(val);
                            break;
                    }
                }
            }
        }

        public Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>> GetObjectDictionary()
        {
            var dictionary = new Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>>();

            dictionary.Add(KeyDictionary.School, new[] { School });
            dictionary.Add(KeyDictionary.Course, School.Courses.Cast<BaseSchoolObject>());

            List<Test> testTmp = new List<Test>();
            List<Studient> studientTmp = new List<Studient>();
            List<Asignature> asignatureTmp = new List<Asignature>();

            foreach (var course in School.Courses)
            {
                studientTmp.AddRange(course.Studients);
                asignatureTmp.AddRange(course.Asignatures);

                foreach (var studient in course.Studients)
                {
                    testTmp.AddRange(studient.Test);
                }
            }
            dictionary.Add(KeyDictionary.Studient, studientTmp.Cast<BaseSchoolObject>());
            dictionary.Add(KeyDictionary.Asignature, asignatureTmp.Cast<BaseSchoolObject>());
            dictionary.Add(KeyDictionary.Test, testTmp.Cast<BaseSchoolObject>());
            return dictionary;
        }

        private List<Studient> GeneratorStudients(int size)
        {
            string[] _name1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] _lastName1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] _name2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listStudients = from n1 in _name1
                                from n2 in _name2
                                from a1 in _lastName1
                                select new Studient { Name = $"{n1} {n2} {a1}" };

            return listStudients.OrderBy((studient) => studient.UniqueId).Take(size).ToList();
        }

        public IReadOnlyList<BaseSchoolObject> GetBaseSchools(
                    bool loadTests = true, bool loadStudients = true, bool loadAsignatures = true, bool loadCourses = true
                ) => GetBaseSchools(out int dummy, out dummy, out dummy, out dummy);

        public IReadOnlyList<BaseSchoolObject> GetBaseSchools(
                    out int countTest, bool loadTests = true, bool loadStudients = true, bool loadAsignatures = true, bool loadCourses = true
                ) => GetBaseSchools(out countTest, out int dummy, out dummy, out dummy);

        public IReadOnlyList<BaseSchoolObject> GetBaseSchools(
                    out int countTest, out int countStudient, bool loadTests = true, bool loadStudients = true, bool loadAsignatures = true, bool loadCourses = true
                ) => GetBaseSchools(out countTest, out countStudient, out int dummy, out dummy);

        public IReadOnlyList<BaseSchoolObject> GetBaseSchools(
                   out int countTest, out int countStudient, out int countAsignature,
                   bool loadTests = true, bool loadStudients = true, bool loadAsignatures = true, bool loadCourses = true
               ) => GetBaseSchools(out countTest, out countStudient, out countAsignature, out int dummy);

        public IReadOnlyList<BaseSchoolObject> GetBaseSchools(
            out int countTest, out int countStudient, out int countAsignature, out int countCourse,
            bool loadTests = true, bool loadStudients = true, bool loadAsignatures = true, bool loadCourses = true
        )
        {
            countAsignature = countStudient = countCourse = countTest = 0;

            var listObject = new List<BaseSchoolObject>();
            listObject.Add(School);
            if (loadCourses)
            {
                listObject.AddRange(School.Courses);
                countCourse += School.Courses.Count;
            }

            foreach (var course in School.Courses)
            {
                if (loadAsignatures)
                {
                    listObject.AddRange(course.Asignatures);
                    countAsignature += course.Asignatures.Count;
                }
                if (loadStudients)
                {
                    listObject.AddRange(course.Studients);
                    countStudient += course.Studients.Count;
                }
                if (loadTests)
                {
                    foreach (var studient in course.Studients)
                    {
                        listObject.AddRange(studient.Test);
                        countTest += studient.Test.Count;
                    }
                }
            }

            return listObject.AsReadOnly();
        }

        #region loading methods
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

        private void LoadTest()
        {
            var rmd = new Random();
            foreach (var course in School.Courses)
            {
                foreach (var asignature in course.Asignatures)
                {
                    foreach (var studient in course.Studients)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            var test = new Test
                            {
                                Asignature = asignature,
                                Name = $"{asignature.Name}, Test: #{i + 1}",
                                Calification = MathF.Round(5 * (float)rmd.NextDouble(), 2),
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
        #endregion
    }
}