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

var studentToUpdate = context.Students.Include(s => s.StudentGroups)
                                        .FirstOrDefault(s => s.StudentId == studentId);

var group1 = context.Groups.FirstOrDefault(g => g.Name == "Group1");
var group3 = context.Groups.FirstOrDefault(g => g.Name == "Group3");

if (studentToUpdate != null && group1 != null && group3 != null)
{
    // Remove existing associations
    studentToUpdate.StudentGroups.Clear();

    // Add new associations
    studentToUpdate.StudentGroups.Add(new StudentGroup { Group = group1 });
    studentToUpdate.StudentGroups.Add(new StudentGroup { Group = group3 });

    context.SaveChanges();
}
var existingStudent = context.Students.FirstOrDefault(s => s.Name == "John");

if (existingStudent == null)
{
    // Student does not exist, proceed with creation
}
else
{
    // Student already exists, handle accordingly
}

var existingGroup = context.Groups.FirstOrDefault(g => g.Name == "Group1");

if (existingGroup == null)
{
    // Group does not exist, proceed with creation
}
else
{
    // Group already exists, handle accordingly
}

var studentId = 1; // Replace with the actual student ID
var groupId = 1;   // Replace with the actual group ID

var isAlreadyAssociated = context.StudentGroups
    .Any(sg => sg.StudentId == studentId && sg.GroupId == groupId);

if (!isAlreadyAssociated)
{
    // Student is not already associated with the group, proceed with association
}
else
{
    // Student is already associated with the group, handle accordingly
}