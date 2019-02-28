using System;
using System.Collections.Generic;

namespace CoreSchool.Entities
{
    public class Course
    {
        public string UniqueId { get; private set; }
        public string Name { get; set; }
        public TypesWorkingDay Types { get; set; }
        public List<Asignature> Asignatures{ get; set; }
        public List<Studient> Studients{ get; set; }
        public Course () => UniqueId = Guid.NewGuid().ToString();
    }
}