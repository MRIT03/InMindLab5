using InMindLab5.Application.ViewModels;
using InMindLab5.Domain.Entities;
using MediatR;

namespace InMindLab5.Application.Queries;

public class RetrieveTeachersQuery : IRequest<IQueryable<TeacherDto>>
{
    
}