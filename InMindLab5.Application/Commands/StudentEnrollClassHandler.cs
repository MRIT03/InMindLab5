using InMindLab5.Application.Mappers;
using InMindLab5.Application.ViewModels;
using InMindLab5.Common;
using InMindLab5.Domain.Entities;
using InMindLab5.Persistence.Data.Repositories;
using MediatR;

namespace InMindLab5.Application.Commands;

public class StudentEnrollClassHandler : IRequestHandler<StudentEnrollClassCommand, Result<EnrollDto>>
{
    private readonly IRepository<Enroll> _EnrollRepository;
    private readonly IRepository<Course> _CourseRepository;

    public StudentEnrollClassHandler(IRepository<Enroll> EnrollRepository, IRepository<Course> CourseRepository)
    {
        _EnrollRepository = EnrollRepository;
        _CourseRepository = CourseRepository;
    }
    
    public async Task<Result<EnrollDto>> Handle(StudentEnrollClassCommand request, CancellationToken cancellationToken)
    {
        Course course = _CourseRepository.Query.Single(x => x.CourseId == request.CourseId);
        Console.WriteLine(course.EnrollStart);
        Console.WriteLine(request.EnrollDate);
        Console.WriteLine(course.EnrollEnd);
        Console.WriteLine(request.EnrollDate >= course.EnrollStart &&
                          request.EnrollDate <= course.EnrollEnd);
        if (request.EnrollDate >= course.EnrollStart &&
            request.EnrollDate <= course.EnrollEnd)
        {
            var newEnroll = new Enroll
            {
                EnrollId = request.EnrollId,
                CourseId = request.CourseId,
                StudentId = request.StudentId,
                Date = request.EnrollDate,
            };
            
            await _EnrollRepository.AddAsync(newEnroll);
            return Result<EnrollDto>.Success(newEnroll.ToDto());
        }

        
        return Result<EnrollDto>.Failure("Student is not enrolling in the allowed time");
    }
}