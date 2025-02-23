using InMindLab5.Common;
using MediatR;

namespace InMindLab5.Application.Commands;

public class StudentUploadPictureCommand : IRequest<Result<string>>
{
    public int StudentID { get; set; }
    public string PictureName { get; set; }
}