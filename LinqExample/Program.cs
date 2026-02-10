// See https://aka.ms/new-console-template for more information
using LinqExample;
using System.Collections.Immutable;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Hello, World!");

var students = new List<Student>
{
    new() { Id = 1, Name = "Asha", Age = 15, Gender = "F", Class = "10A", Marks = 85, IsActive = true },
    new() { Id = 2, Name = "Ravi", Age = 16, Gender = "M", Class = "10A", Marks = 72, IsActive = true },
    new() { Id = 3, Name = "Neha", Age = 15, Gender = "F", Class = "10B", Marks = 90, IsActive = false },
    new() { Id = 4, Name = "Arjun", Age = 17, Gender = "M", Class = "10B", Marks = 60, IsActive = true },
    new() { Id = 5, Name = "Meera", Age = 16, Gender = "F", Class = "10A", Marks = 45, IsActive = true },
    new() { Id = 6, Name = "Kiran", Age = 15, Gender = "M", Class = "10C", Marks = 88, IsActive = true }
};

var enrollments = new List<Enrollment>
{
    new() { StudentId = 1, Subject = "Maths" },
    new() { StudentId = 1, Subject = "Science" },
    new() { StudentId = 2, Subject = "Maths" },
    new() { StudentId = 3, Subject = "English" },
    new() { StudentId = 4, Subject = "Science" },
    new() { StudentId = 6, Subject = "Maths" }
};

//Join students and enrollments to get:
//Student name
//Subject
students.Join(enrollments, (students) => students.Id, (enrollments) => enrollments.StudentId, (students, enrollments) => new { name = students.Name, subject = enrollments.Subject }).ToList().ForEach(x => Console.WriteLine($"name {x.name} subject {x.subject}"));
Console.WriteLine("----");
//Find students who are NOT enrolled in any subject.
students.Where(x => !enrollments.Any(e => e.StudentId == x.Id)).ToList().ForEach(x => Console.WriteLine($"name {x.Name}"));

students.Join(enrollments,(stu) => stu.Id, (enr) => enr.StudentId , (students,enrollments) => new { name = students.Name, marks = students.Marks, subject = enrollments.Subject}).Where(x => x.subject == "Maths").ToList().ForEach(x => Console.WriteLine($"name {x.name} subject {x.subject} mark {x.marks}"));
Console.WriteLine("----");

//distinct classes
Console.WriteLine("distinct");
students.DistinctBy(x => x.Class).ToList().ForEach(x => Console.WriteLine( $"{x.Name} name {x.Class}"));

//active and enrolled in any subjext
Console.WriteLine("active and enrolled");
students.Where(x => x.IsActive && enrollments.Any(e => e.StudentId == x.Id)).ToList().ForEach(x => Console.WriteLine($"{x.Name}"));

// active but not enrolled
Console.WriteLine("active but not enrolled");
students.Where(x => x.IsActive && !enrollments.Any(e => e.StudentId == x.Id)).ToList().ForEach(x => Console.WriteLine($"{x.Name}"));

//each class get top scorer
Console.WriteLine("top scorer");
var maxGrp = students.GroupBy(x => x.Class).Select(g => new { cla = g.Key, max = g.Max(y => y.Marks) });
foreach (var group in maxGrp)
{
    Console.WriteLine($"{group.cla} {group.max}"); 
}

//marks above class average
students.GroupBy(x => x.Class).Select(x => )
//Get names of active students who scored more than 70 marks, ordered by marks descending.
students.Where(s => s.IsActive  && s.Marks > 70).OrderByDescending(p => p.Marks).ToList().ForEach(x => Console.WriteLine($"id: {x.Id} name: {x.Name} marks: {x.Marks} active: {x.IsActive}"));
//Get a list of anonymous objects containing Name and Marks for students in Class 10A.
students.Where(s => s.Class == "10A").Select(x => new { name = x.Name, marks = x.Marks });
//Get the top 3 scorers across all classes.
Console.WriteLine("Get the top 3 scorers across all classes");
students.OrderByDescending(x => x.Marks).Take(3).ToList().ForEach(x => Console.WriteLine($"id: {x.Id} name: {x.Name} marks: {x.Marks} active: {x.IsActive}"));
//Check if any inactive student scored above 80.
Console.WriteLine("Check if any inactive student scored above 80.");
//var res = students.Where(s => !s.IsActive && s.Marks > 80).ToList().Count() > 0 ? "yes" : "no";
var res = students.Any(s => !s.IsActive && s.Marks > 80) ? "yes" : "no";
Console.WriteLine(res);
// Check if all active students scored at least 50.
//var act = students.All(s => s.IsActive && s.Marks >= 50) ? "yes" : "no";
var act = students.Where(x => x.IsActive).All(x => x.Marks >= 50);
Console.WriteLine(act);
// Skip the lowest 2 marks and return the remaining students ordered by marks.
students.OrderByDescending(s => s.Marks).SkipLast(2).ToList().ForEach(x => Console.WriteLine($"id: {x.Id} name: {x.Name} marks: {x.Marks} active: {x.IsActive}"));
// Group students by Class
var result = students.GroupBy(x => x.Class).Select(g => new { className = g.Key, studentCount = g.Count(),average = g.Average(x => x.Marks) });
foreach (var group in result)
{
    Console.WriteLine($"class name {group.className} {group.studentCount} {group.average}" );
}

var gen = students.GroupBy(x => x.Gender).Select(x => new { gender = x.Key, high = x.Max(g => g.Marks) });
foreach (var group in gen)
{
    Console.WriteLine($"gender {group.gender} {group.high} ");
}
var mar = students.Where(x => x.IsActive).Sum(x => x.Marks);
Console.WriteLine(mar);
//var mar = students.GroupBy(x => x.IsActive).Select(x => new { name = x.Key, count = x.Sum(g => g.Marks) }).Where(x => x.name);
//foreach (var group in mar)
//{
//    Console.WriteLine($"active {group.name} {group.count} ");
//}