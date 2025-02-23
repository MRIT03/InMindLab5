namespace InMindLab5.Domain.Entities;

public class Enroll
{
    public required int EnrollId { get; set; }
    public required int StudentId { get; set; }
    public required int CourseId { get; set; }
    
    private DateTime _enrollDate;
    public required DateTime Date {
        get => _enrollDate;
        set => _enrollDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    
    public virtual Student Student { get; set; }
    public virtual Course Course { get; set; }
    
    
}