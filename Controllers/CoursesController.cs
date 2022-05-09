using TrainingManagementApi.Models;
using TrainingManagementApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace TrainingManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly CoursesService _coursesService;

    public CoursesController(CoursesService coursesService) =>
        _coursesService = coursesService;

    [HttpGet]
    public async Task<List<Course>> Get() =>
        await _coursesService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Course>> Get(string id)
    {
        var course = await _coursesService.GetAsync(id);

        if (course is null)
        {
            return NotFound();
        }

        return course;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Course newCourse)
    {
        await _coursesService.CreateAsync(newCourse);

        return CreatedAtAction(nameof(Get), new { id = newCourse.Id }, newCourse);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Course updatedCourse)
    {
        var course = await _coursesService.GetAsync(id);

        if (course is null)
        {
            return NotFound();
        }

        updatedCourse.Id = course.Id;

        await _coursesService.UpdateAsync(id, updatedCourse);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var course = await _coursesService.GetAsync(id);

        if (course is null)
        {
            return NotFound();
        }

        await _coursesService.RemoveAsync(id);

        return NoContent();
    }
}
