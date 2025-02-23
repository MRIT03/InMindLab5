using InMindLab5.Application.Mappers;
using InMindLab5.Application.ViewModels;
using InMindLab5.Domain.Entities;
using InMindLab5.Persistence.Data.Repositories;
using MediatR;

namespace InMindLab5.Application.Queries;

public class RetrieveCoursesHandler : IRequestHandler<RetrieveCoursesQuery, IQueryable<CourseDto>>
{
    private readonly IRepository<Course> _courseRepository;

    public RetrieveCoursesHandler(IRepository<Course> courseRepository)
    {
        _courseRepository = courseRepository;
    }
    
    public async Task<IQueryable<CourseDto>> Handle(RetrieveCoursesQuery request, CancellationToken cancellationToken)
    {
        List<Course> courses = await _courseRepository.GetAllAsync();
        List<CourseDto> coursesDto = courses.ToDtoList();
        return coursesDto.AsQueryable();
    }
}