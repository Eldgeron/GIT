global using NUnit.Framework;
using LINQHomework.Models;
using System.Net.WebSockets;

var students = new Student[]
        {
            new Student { Id = 1, Name = "Alice", Age = 20, Grade = 85, Subjects = new List<string> { "Math", "Science" }},
            new Student { Id = 2, Name = "Bob", Age = 22, Grade = 90, Subjects = new List<string> { "Math", "History" }},
            new Student { Id = 3, Name = "Charlie", Age = 23, Grade = 80, Subjects = new List<string> { "English", "Science" }},
            new Student { Id = 4, Name = "David", Age = 21, Grade = 88, Subjects = new List<string> { "Math", "Science" }},
            new Student { Id = 5, Name = "Eve", Age = 22, Grade = 92, Subjects = new List<string> { "History", "Science" }}
        };

// Query
var newSortedArray = students
.Where(s => s.Subjects.Contains("Math"))
.OrderByDescending(s => s.Grade)
.Select(s => s.Name)
.ToArray();


// Assert your query
Assert.Multiple(() =>
{
    Assert.That(newSortedArray, Has.Length.EqualTo(3));
    Assert.That(newSortedArray[0].Name, Is.EqualTo("Bob"));
    Assert.That(newSortedArray[1].Name, Is.EqualTo("David"));
    Assert.That(newSortedArray[2].Name, Is.EqualTo("Alice"));
});