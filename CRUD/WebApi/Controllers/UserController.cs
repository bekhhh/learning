using BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers;

[ApiController]
[Route("User")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(string name, string email)
    {
        await userService.CreateAsync(name, email);
        return NoContent();
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserAsync([FromRoute]int id)
    {
        var result = await userService.GetByIdAsync(id);
        return Ok(result);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateUserAsync([FromRoute]int id, string newName, string email)
    {
        await userService.UpdateAsync(id, newName, email);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> UpdateUserAsync([FromRoute]int id)
    {
        await userService.DeleteAsync(id);
        return NoContent();
    }
}