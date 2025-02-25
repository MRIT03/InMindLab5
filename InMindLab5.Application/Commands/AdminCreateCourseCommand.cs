using InMindLab5.Application.ViewModels;
using MediatR;

namespace InMindLab5.Application.Commands;

public class AdminCreateCourseCommand : IRequest<CourseDto>
{
    public int AdminId { get; set; }
    public CourseDto CourseToBeCreated { get; set; }

}