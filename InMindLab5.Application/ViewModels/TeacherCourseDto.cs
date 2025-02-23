using InMindLab5.Domain.Entities;

namespace InMindLab5.Application.ViewModels;

public class TeacherCourseDto
{
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public int CourseId { get; set; }
    public TimeOnly ClassStart { get; set; }
    public TimeOnly ClassEnd { get; set; }
}