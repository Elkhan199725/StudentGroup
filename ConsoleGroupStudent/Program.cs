// See https://aka.ms/new-console-template for more information
using ConsoleGroupStudent.ContextDb;
using ConsoleGroupStudent.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

Console.WriteLine("Hello, World!");

AppDbContext context = new AppDbContext();
var newStudent = new Student { Name = "John" };
var group1 = context.Groups.FirstOrDefault(g => g.Name == "Group1");
var group2 = context.Groups.FirstOrDefault(g => g.Name == "Group2");

if (group1 != null && group2 != null)
{
    newStudent.StudentGroups = new List<StudentGroup>
        {
            new StudentGroup { Group = group1 },
            new StudentGroup { Group = group2 }
        };

    context.Students.Add(newStudent);
    context.SaveChanges();
}
