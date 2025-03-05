using InMindLab5.Application.Mappers;
using InMindLab5.Application.ViewModels;
using InMindLab5.Domain.Entities;
using InMindLab5.Persistence.Data.Repositories;
using MediatR;

namespace InMindLab5.Application.Queries;


public class RetrieveStudentHandler : IRequestHandler<RetrieveStudentQuery, IEnumerable<StudentDto>>
{
    private readonly IRepository<Student> _courseRepository;

    public RetrieveStudentHandler(IRepository<Student> courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<IEnumerable<StudentDto>> Handle(RetrieveStudentQuery request, CancellationToken cancellationToken)
    {
        List<Student> courses = await _courseRepository.GetAllAsync();
        List<StudentDto> coursesDto = courses.ToDtoList();
        return coursesDto.AsQueryable();
    }
}