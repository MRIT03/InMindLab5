using InMindLab5.Application.ViewModels;

using MediatR;

namespace InMindLab5.Application.Queries;

public class RetrieveStudentsQuery : IRequest<IQueryable<StudentDto>>
{
    
}