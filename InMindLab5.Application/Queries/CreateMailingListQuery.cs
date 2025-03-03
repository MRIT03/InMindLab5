using InMindLab5.Domain.Entities;
using MediatR;

namespace InMindLab5.Application.Queries;

public class CreateMailingListQuery : IRequest<Dictionary<Student, Course>>
{
    
}