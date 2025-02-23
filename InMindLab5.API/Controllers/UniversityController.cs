using Asp.Versioning;
using InMindLab5.Application.Commands;
using InMindLab5.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace InMindLab5.API.Controllers;

[ApiVersion( 1.0 )]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class UniversityController : ControllerBase
{
    private readonly IMediator _mediator;

    public UniversityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("[action]/{adminId:int}")]
    public async Task<IActionResult> CreateCourse([FromRoute]int adminId, [FromBody]  CourseDto course)
    {
        AdminCreateCourseCommand command = new AdminCreateCourseCommand
        {
            AdminId = adminId,
            CourseToBeCreated = course
        };
        var createdCourse = await _mediator.Send(command);
        
        return Ok(createdCourse);
        
    }

    [HttpPost("[action]/{teacherId:int}")]
    public async Task<IActionResult> CreateClass([FromRoute] int teacherId, [FromBody] TeacherCourseDto teacherCourse)
    {

        TeacherCreateClassCommand command = new TeacherCreateClassCommand
        {
            TeacherId = teacherId,
            CourseId = teacherCourse.CourseId,
            ClassStart = teacherCourse.ClassStart,
            ClassEnd = teacherCourse.ClassEnd,
        };
        
        var createdClass = await _mediator.Send(command);
        
        return Ok(createdClass);
        
    }

    [HttpPost("[action]/{studentId:int}")]
    public async Task<IActionResult> Enroll([FromRoute] int studentId, [FromBody] EnrollDto enroll)
    {
        StudentEnrollClassCommand command = new StudentEnrollClassCommand
        {
            EnrollId = enroll.Id,
            StudentId = studentId,
            CourseId = enroll.CourseId,
            EnrollDate = enroll.EnrollementDate
        };
        var enrolledCourseResult = await _mediator.Send(command);
        if (enrolledCourseResult.IsSuccess)
        {
            return Ok(enrolledCourseResult.Value);
        }
        return BadRequest(enrolledCourseResult.Error);
        
        
        
    }
}