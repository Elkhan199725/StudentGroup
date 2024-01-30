using System.ComponentModel.DataAnnotations;

namespace ConsoleGroupStudent.Core.Entities;

public class Student
{
    public int StudentId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int? Age { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? Created { get; set; }
    public ICollection<StudentGroup> StudentGroups { get; set; } = null!;
}
