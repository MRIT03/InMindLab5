using Asp.Versioning;
using InMindLab5.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace InMindLab5.API.Controllers;
[ApiVersion(2.0)]
[ApiController]
[Route ("api/v{version:apiVersion}/odata/")]

public class ODataUniversityController : ODataController
{
    private readonly IMediator _mediator;

    public ODataUniversityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    [EnableQuery]
    public async Task<IActionResult> GetStudents()
    {
        return Ok(await _mediator.Send(new RetrieveStudentsQuery()));
    }
    
    [HttpGet("[action]")]
    [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Filter)]
    public async Task<IActionResult> GetTeachers()
    {
        return Ok(await _mediator.Send(new RetrieveTeachersQuery()));
    }
    
    [HttpGet("[action]")]
    [EnableQuery]
    public async Task<IActionResult> GetCourses()
    {
        return Ok(await _mediator.Send(new RetrieveCoursesQuery()));
    }
}