using Generics;

var students = new Store<Student>();
students.Add(new Student { Id = 1, Name = "Ahmed" });
students.Add(new Student { Id = 2, Name = "Sara" });
students.Add(new Student { Id = 3, Name = "Omar" });
students.Add(new Student { Id = 4, Name = "Laila" });
students.Add(new Student { Id = 5, Name = "Youssef" });

var courses = new Store<Course>();
courses.Add(new Course { Id = 10, Title = "C# Basics", Price = 100m });
courses.Add(new Course { Id = 20, Title = "OOP", Price = 150m });
courses.Add(new Course { Id = 30, Title = "Generics", Price = 200m });

// Get one of each by id
var student = students.GetById(3);
var course = courses.GetById(20);
Console.WriteLine($"Student 3: {student?.Name}");
Console.WriteLine($"Course 20: {course?.Title}");

// Duplicate id, catch the exception 
try
{
    students.Add(new Student { Id = 3, Name = "Duplicate" });
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

// Page 2 (size 2) of the students
Console.WriteLine("Students, page 2:");
foreach (var s in students.GetAll().Page(2, 2))
    Console.WriteLine($"  {s.Id} - {s.Name}");

// FindById on a plain List<Course>
var courseList = new List<Course>(courses.GetAll());
var found = courseList.FindById(30);
Console.WriteLine($"FindById(30) on List<Course>: {found?.Title}");

// var bad = new Store<string>();   // must NOT compile



