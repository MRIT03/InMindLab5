using InMindLab5.Domain.Entities;

namespace InMindLab5.Application.ViewModels;

public class EnrollDto
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int StudentId { get; set; }
    public DateTime EnrollementDate { get; set; }
}