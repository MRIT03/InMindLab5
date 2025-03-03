using InMindLab5.Application.ViewModels;
using InMindLab5.Domain.Entities;

namespace InMindLab5.Application.Mappers;

public static class CourseMapper
{
    public static CourseDto ToDto(this Course course)
    {
        return new CourseDto
        {
            Id = course.CourseId,
            Title = course.Name,
            EnrollementStart = course.EnrollStart,
            EnrollementEnd = course.EnrollEnd,

        };
    }

    public static List<CourseDto> ToDtoList(this List<Course> courses)
    {
        return courses.Select( c => c.ToDto() ).ToList();
    }
}