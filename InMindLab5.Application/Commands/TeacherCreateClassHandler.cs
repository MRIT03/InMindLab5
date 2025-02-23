using InMindLab5.Application.Mappers;
using InMindLab5.Application.ViewModels;
using InMindLab5.Domain.Entities;
using InMindLab5.Persistence.Data.Repositories;
using MediatR;

namespace InMindLab5.Application.Commands;

public class TeacherCreateClassHandler : IRequestHandler<TeacherCreateClassCommand, TeacherCourseDto>
{
    private readonly IRepository<TeacherCourse> _TeacherCourseRepository;

    public TeacherCreateClassHandler(IRepository<TeacherCourse> teacherCourseRepository)
    {
        _TeacherCourseRepository = teacherCourseRepository;
    }
    
    public async Task<TeacherCourseDto> Handle(TeacherCreateClassCommand request, CancellationToken cancellationToken)
    {
        TeacherCourse newTeacherCourse = new TeacherCourse
        {
            TeacherCourseId = request.Id,
            TeacherId = request.TeacherId,
            CourseId = request.CourseId,
            ClassStart = request.ClassStart,
            ClassEnd = request.ClassEnd
        };
        
        await _TeacherCourseRepository.AddAsync(newTeacherCourse);

        return newTeacherCourse.ToDto();
    }
}