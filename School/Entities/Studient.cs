using System;
using System.Collections.Generic;

namespace CoreSchool.Entities
{
    public class Studient : BaseSchoolObject
    {
        public List<Test> Test{ get; set; } = new List<Test>();
    }
}