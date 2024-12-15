using Core.Models;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace OnlineCoursesWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CoursesController(ICoursesService coursesService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var courses = coursesService.GetAll();
        return Ok(courses); // 200
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        var model = coursesService.GetById(id);
        return Ok(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CourseModelCreate model)
    {
        await coursesService.Create(model);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromForm] CourseModelEdit model)
    {
        await coursesService.Edit(model);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await coursesService.Delete(id);
        return Ok();
    }

    [HttpGet("categories")]
    public IActionResult Categories()
    {
        var categories = coursesService.GetCategories();
        return Ok(categories);
    }

    [HttpGet("levels")]
    public IActionResult Levels()
    {
        var levels = coursesService.GetLevels();
        return Ok(levels);
    }
}
