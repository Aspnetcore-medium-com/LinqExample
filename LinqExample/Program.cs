// See https://aka.ms/new-console-template for more information
using LinqExample;

Console.WriteLine("Hello, World!");

List<Employee> employees = new List<Employee>
{
    new Employee { Id = 1, Name = "A", Job = "Designer", City = "New York" },
    new Employee { Id = 2, Name = "B", Job = "Analyst", City = "Boston" },
    new Employee { Id = 3, Name = "C", Job = "Developer", City = "Newark" },
    new Employee { Id = 4, Name = "D", Job = "Manager", City = "Boston" },
    new Employee { Id = 5, Name = "E", Job = "Manager", City = "New York" }
};