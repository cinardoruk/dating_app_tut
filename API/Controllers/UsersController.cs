using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entitities;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // /api/users would route to this vv
public class UsersController(DataContext context) : ControllerBase //inherit from ControllerBase
{
	[HttpGet]

	public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
	{
		var users = await context.Users.ToListAsync();

		return users;
	}

	[HttpGet("{id:int}")] // api/users/{id_number}

	public async Task<ActionResult<AppUser>> GetUser(int id)
	{
		var user = await context.Users.FindAsync(id);

		if (user == null) return NotFound();

		return user;
	}
}
