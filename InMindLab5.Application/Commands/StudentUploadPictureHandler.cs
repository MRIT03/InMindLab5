using InMindLab5.Common;
using InMindLab5.Domain.Entities;
using InMindLab5.Persistence.Data.Repositories;
using MediatR;

namespace InMindLab5.Application.Commands;

public class StudentUploadPictureHandler : IRequestHandler<StudentUploadPictureCommand, Result<string>>
{
    private readonly IRepository<Student> _repository;

    public StudentUploadPictureHandler(IRepository<Student> repository)
    {
        _repository = repository;
    }


    public async Task<Result<string>> Handle(StudentUploadPictureCommand request, CancellationToken cancellationToken)
    {
        var students = await _repository.GetAllAsync();
        Student student = students.FirstOrDefault(s => s.StudentId == request.StudentID);
        if (student == null)
        {
            return Result<string>.Failure("Student not found");
        }
        student.ProfilePictureUrl = request.PictureName;
        return Result<string>.Success("Upload Picture successfully!");
    }
}