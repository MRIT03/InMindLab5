using System.ComponentModel.DataAnnotations;

namespace InMindLab5.Domain.Entities;

public class Course
{
    [Required]
    public int CourseId { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public int MaxNb { get; set; }
    [Required]
    public DateTime EnrollStart { get; set; }
    [Required]
    public DateTime EnrollEnd { get; set; }
    [Required]
    public int AdminId { get; set; } //this represents the foreign key
}