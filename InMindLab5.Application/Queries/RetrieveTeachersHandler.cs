using InMindLab5.Domain.Entities;
using InMindLab5.Persistence.Data.Repositories;
using InMindLab5.Application.Mappers;
using InMindLab5.Application.ViewModels;
using MediatR;

namespace InMindLab5.Application.Queries;

public class RetrieveTeachersHandler : IRequestHandler<RetrieveTeachersQuery, IQueryable<TeacherDto>>
{
    private readonly IRepository<Teacher> _repository;

    public RetrieveTeachersHandler(IRepository<Teacher> repository)
    {
        _repository = repository;
    }
    public async Task<IQueryable<TeacherDto>> Handle(RetrieveTeachersQuery request, CancellationToken cancellationToken)
    {
        List<Teacher> teachers = await _repository.GetAllAsync();
        List<TeacherDto> teacherDto = teachers.ToDtoList();
        return teacherDto.AsQueryable();
    }
}