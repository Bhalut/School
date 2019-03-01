using System;
using System.Collections.Generic;

namespace CoreSchool.Entities
{
    public class Course : BaseSchoolObject
    {
        public TypesWorkingDay Types { get; set; }
        public List<Asignature> Asignatures{ get; set; }
        public List<Studient> Studients{ get; set; }
    }
}