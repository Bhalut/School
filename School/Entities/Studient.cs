using System;
using System.Collections.Generic;

namespace CoreSchool.Entities
{
    public class Studient
    {
        public string UniqueId { get; private set; }
        public string Name { get; set; }
        public List<Test> Test{ get; set; }

        public Studient() => UniqueId = Guid.NewGuid().ToString();
    }
}