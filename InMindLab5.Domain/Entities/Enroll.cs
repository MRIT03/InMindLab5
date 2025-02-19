namespace InMindLab5.Domain.Entities;

public class Enroll
{
    public required int EnrollId { get; set; }
    public required int StudentId { get; set; }
    public required int CourseId { get; set; }
}