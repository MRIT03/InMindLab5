namespace InMindLab5.Application.Mappers;
using InMindLab5.Application.ViewModels;
using InMindLab5.Domain.Entities;


public static class StudentMapper
{
    public static StudentDto ToDto(this Student student)
    {
        return new StudentDto
        {
            Id = student.StudentId,
            Name = student.Name,
        };

    }

    public static List<StudentDto> ToDtoList(this List<Student> students)
    {
        return students.Select( s => s.ToDto()).ToList();
    }
}