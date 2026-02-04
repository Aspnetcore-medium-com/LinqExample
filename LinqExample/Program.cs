// See https://aka.ms/new-console-template for more information
using LinqExample;
using System.Collections.Immutable;

Console.WriteLine("Hello, World!");

List<Employee> employees = new List<Employee>
{
    new Employee { Id = 1, Name = "Anna", Job = "Designer", City = "New York" },
    new Employee { Id = 2, Name = "Zak", Job = "Analyst", City = "Boston" },
    new Employee { Id = 3, Name = "Clement", Job = "Developer", City = "Newark" },
    new Employee { Id = 4, Name = "Elon", Job = "Manager", City = "Boston" },
    new Employee { Id = 5, Name = "Ellis", Job = "Manager", City = "New York" }
};

// where manager
//var managers = employees.Where(e => e.Job == "Manager");
//foreach (var manager in managers)
//{
//    Console.WriteLine($"{manager.Name} - {manager.Job} - {manager.City}");
//}

IEnumerable<Employee> managers = employees.Where(e => e.Job == "Manager");

IEnumerable<Employee> bostonManagers = employees.Where(e => e.Job == "Manager" && e.City == "Boston");

// order by
IEnumerable<Employee> orderedByName = employees.OrderByDescending(e => e.Job).ThenByDescending(e => e.Name);
foreach (var emp in orderedByName)
{
    Console.WriteLine($"{emp.Name} - {emp.Job} - {emp.City}");
}

//var employee = employees.Last(emp => emp.Id == 3);
//Console.WriteLine($"{employee.Name} - {employee.Job} - {employee.City}");

//var employee = employees.LastOrDefault(emp => emp.Id == 2);
//Console.WriteLine($"{employee.Name} - {employee.Job} - {employee.City}");

var employee = employees.Single(emp => emp.Job == "Manager");



