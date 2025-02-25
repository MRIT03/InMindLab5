using InMindLab5.Application.ViewModels;
using MediatR;
using InMindLab5.Common;

namespace InMindLab5.Application.Commands;

public class StudentEnrollClassCommand : IRequest<Result<EnrollDto>>
{
    public int EnrollId { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime EnrollDate { get; set; }
    
}