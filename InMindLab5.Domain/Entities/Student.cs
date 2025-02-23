using System.ComponentModel.DataAnnotations;

namespace InMindLab5.Domain.Entities;

public class Student
{
    public required int StudentId { get; set; }
    public required string Name { get; set; }
    [Range(0.0, 20.0)]
    public float? GradePointAverage { get; set; }
    public bool canApplyToFrance { get; set; }
}