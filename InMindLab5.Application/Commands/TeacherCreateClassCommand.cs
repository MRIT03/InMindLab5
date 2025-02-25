using InMindLab5.Application.ViewModels;
using MediatR;

namespace InMindLab5.Application.Commands;

public class TeacherCreateClassCommand : IRequest<TeacherCourseDto>
{
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public int CourseId { get; set; }
    public TimeOnly ClassStart { get; set; }
    public TimeOnly ClassEnd { get; set; }
}