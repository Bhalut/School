using System.Collections.Generic;
namespace CoreSchool.Entities
{
    public class School
    {
        string name;
        public string Name
        {
            get { return "Copia: " + name; }
            set { name = value.ToUpper(); }
        }
        public int CreationYear { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public TypesSchool Types { get; set; }
        public List<Course> Courses { get; set; }

        public School(string name, int year) => (Name, CreationYear) = (name, year);
        public School(string name, int year, TypesSchool types,
                    string country = "", string city = "")
        {
            (Name, CreationYear, Types, Country, City) = (name, year, types, country, city);
        }
        public override string ToString()
        {
            return $"Name: \"{Name}\", Type: {Types} \nCountry: {Country}, City: {City}";
        }
    }
}