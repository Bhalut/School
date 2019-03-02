using System;

namespace CoreSchool.Entities
{
    public abstract class BaseSchoolObject
    {
        public string UniqueId { get; private set; }
        public string Name { get; set; }

        public BaseSchoolObject() => UniqueId = Guid.NewGuid().ToString();

        public override string ToString() => $"{Name}, {UniqueId}";
    }
}