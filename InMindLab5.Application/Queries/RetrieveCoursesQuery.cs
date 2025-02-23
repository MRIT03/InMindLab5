using InMindLab5.Application.ViewModels;

using MediatR;

namespace InMindLab5.Application.Queries;

public class RetrieveCoursesQuery : IRequest<IQueryable<CourseDto>>
{
    
}