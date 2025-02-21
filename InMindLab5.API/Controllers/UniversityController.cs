using InMindLab5.Application.Commands;
using InMindLab5.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InMindLab5.Application.Controllers;


[ApiController]
[Route("api/[controller]")]
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
            CourseId = teacherCourse.Course.CourseId,
            ClassStart = teacherCourse.ClassStart,
            ClassEnd = teacherCourse.ClassEnd,
        };
        
        var createdClass = await _mediator.Send(command);
        
        return Ok(createdClass);
        
    }
}