using InMindLab5.Domain.Entities;

namespace InMindLab5.Application.ViewModels;

public class EnrollDto
{
    public int Id { get; set; }
    public Course Course { get; set; }
    public Student Student { get; set; }
    public DateTime EnrollementDate { get; set; }
}