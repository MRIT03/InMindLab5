using InMindLab5.Application.Mappers;
using InMindLab5.Application.ViewModels;
using InMindLab5.Domain.Entities;
using InMindLab5.Persistence.Data.Repositories;
using MediatR;

namespace InMindLab5.Application.Queries;

public class RetrieveStudentsHandler : IRequestHandler<RetrieveStudentsQuery, IQueryable<StudentDto>>
{
    private readonly IRepository<Student> _StudentRepository;

    public RetrieveStudentsHandler(IRepository<Student> StudentRepository)
    {
        _StudentRepository = StudentRepository;
    }
    
    public async Task<IQueryable<StudentDto>> Handle(RetrieveStudentsQuery request, CancellationToken cancellationToken)
    {
        List<Student> students = await _StudentRepository.GetAllAsync();
        List<StudentDto> studentDtos = students.ToDtoList();
        return studentDtos.AsQueryable();
    }
}