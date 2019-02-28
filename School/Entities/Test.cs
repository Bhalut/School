using System;

namespace CoreSchool.Entities
{
    public class Test
    {
        public string UniqueId { get; private set; }
        public string Name { get; set; }

        public Studient Studient { get; set; }
        public Asignature Asignature  { get; set; }

        public float Calification { get; set; }

        public Test() => UniqueId = Guid.NewGuid().ToString();
    }
}