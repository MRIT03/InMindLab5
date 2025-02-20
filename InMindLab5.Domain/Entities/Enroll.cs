namespace InMindLab5.Domain.Entities;

public class Enroll
{
    public required int EnrollId { get; set; }
    public required int StudentId { get; set; }
    public required int CourseId { get; set; }
    public required DateTime Date { get; set; }
    
    public virtual Student Student { get; set; }
    public virtual Course Course { get; set; }
    
    
}