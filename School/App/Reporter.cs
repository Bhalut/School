using System;
using System.Linq;
using System.Collections.Generic;
using CoreSchool.Entities;

namespace CoreSchool
{
    public class Reporter
    {
        Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>> _dictionary;
        public Reporter(Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>> dic)
        {
            if (dic != null)
            {
                _dictionary = dic;
            }
            else
            {
                throw new ArgumentNullException(nameof(dic));
            }
        }

        public IEnumerable<Test> GetTestList()
        {
            if (_dictionary.TryGetValue(KeyDictionary.Test, out IEnumerable<BaseSchoolObject> list))
            {
                return list.Cast<Test>();
            }
            else
            {
                return new List<Test>();
            }
        }

        public IEnumerable<String> GetAsignatureList()
        {
            return GetAsignatureList(out var dummy);
        }

        public IEnumerable<String> GetAsignatureList(out IEnumerable<Test> listTest)
        {
            listTest = GetTestList();
            return (from Test test in listTest select test.Asignature.Name).Distinct();
        }

        public Dictionary<string, IEnumerable<Test>> GetTestDictionary()
        {
            var dictionary = new Dictionary<string, IEnumerable<Test>>();
            var listAsig = GetAsignatureList(out var listTest);

            foreach (var asig in listAsig)
            {
                var testAsig = from Test test in listAsig where test.Asignature.Name == asig select test;
                dictionary.Add(asig, testAsig);
            }
            return dictionary;
        }

        public Dictionary<string, IEnumerable<Object>> GetPromeStudentsforAsignature()
        {
            var answer = new Dictionary<string, IEnumerable<Object>>();
            var dicTestforAsig = GetTestDictionary();

            foreach (var asigforTest in dicTestforAsig)
            {
                var promStudient = from Test test in asigforTest.Value
                                   group test by new {test.Studient.UniqueId, test.Studient.Name}
                                   into groupTestforStudient
                                   select new AverageStudient
                                   {
                                       name = groupTestforStudient.Key.Name,
                                       studientID = groupTestforStudient.Key.UniqueId,
                                       average = groupTestforStudient.Average(test => test.Calification)

                                   };
                answer.Add(asigforTest.Key, promStudient);
            }
            return answer;
        }
    }
}