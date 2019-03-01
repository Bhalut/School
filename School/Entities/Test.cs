using System;

namespace CoreSchool.Entities
{
    public class Test : BaseSchoolObject
    {
        public Studient Studient { get; set; }
        public Asignature Asignature  { get; set; }
        public float Calification { get; set; }
    }
}