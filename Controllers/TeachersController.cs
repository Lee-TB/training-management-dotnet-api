using TrainingManagementApi.Models;
using TrainingManagementApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace TrainingManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{
    private readonly TeachersService _teachersService;

    public TeachersController(TeachersService teachersService) =>
        _teachersService = teachersService;

    [HttpGet]
    public async Task<List<Teacher>> Get() =>
        await _teachersService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Teacher>> Get(string id)
    {
        var teacher = await _teachersService.GetAsync(id);

        if (teacher is null)
        {
            return NotFound();
        }

        return teacher;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Teacher newTeacher)
    {
        await _teachersService.CreateAsync(newTeacher);

        return CreatedAtAction(nameof(Get), new { id = newTeacher.Id }, newTeacher);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Teacher updatedTeacher)
    {
        var teacher = await _teachersService.GetAsync(id);

        if (teacher is null)
        {
            return NotFound();
        }

        updatedTeacher.Id = teacher.Id;

        await _teachersService.UpdateAsync(id, updatedTeacher);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var teacher = await _teachersService.GetAsync(id);

        if (teacher is null)
        {
            return NotFound();
        }

        await _teachersService.RemoveAsync(id);

        return NoContent();
    }
}
