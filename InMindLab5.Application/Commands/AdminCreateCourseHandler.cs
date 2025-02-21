using InMindLab5.Application.ViewModels;
using InMindLab5.Domain.Entities;
using InMindLab5.Persistence.Data.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InMindLab5.Application.Commands;

public class AdminCreateCourseHandler : IRequestHandler<AdminCreateCourseCommand, CourseDto>
{
    private readonly IRepository<Course> _courseRepository;
    private readonly IRepository<Admin> _adminRepository; 

    public AdminCreateCourseHandler(IRepository<Course> courseRepository, IRepository<Admin> adminRepository)
    {
        _courseRepository = courseRepository;
        _adminRepository = adminRepository;
    }

    public async Task<CourseDto> Handle(AdminCreateCourseCommand request, CancellationToken cancellationToken)
    {

        
        Course newCourse = new Course
        {
            CourseId = request.CourseToBeCreated.Id,
            Name = request.CourseToBeCreated.Title,
            MaxNb = request.CourseToBeCreated.MaxStudents,
            EnrollStart = DateTime.SpecifyKind( request.CourseToBeCreated.EnrollementStart, DateTimeKind.Utc),
            EnrollEnd =  DateTime.SpecifyKind(request.CourseToBeCreated.EnrollementEnd, DateTimeKind.Utc),
        };

        await _courseRepository.AddAsync(newCourse);

        return request.CourseToBeCreated;
    }
}