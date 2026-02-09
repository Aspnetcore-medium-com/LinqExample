using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Gender { get; set; } = "";
        public string Class { get; set; } = "";
        public int Marks { get; set; }
        public bool IsActive { get; set; }
    }

    public class Enrollment
    {
        public int StudentId { get; set; }
        public string Subject { get; set; } = "";
    }
}
