using Microsoft.AspNetCore.Mvc;
using Fluent.Validation.API.Models;

namespace Fluent.Validation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateOrAnotherWriteAction([FromBody] User model)
        => Ok(model);
}
