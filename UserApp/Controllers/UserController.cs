using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApp.DTO;
using UserApp.Models;

namespace UserApp.Controllers;

[ApiController]
[Route("/api/users")]
public class UserController : ControllerBase
{
	private readonly ApplicationDbContext _dbContext;

	public UserController(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	[HttpGet]
	public async Task<List<User>> GetAllUsers()
	{
		List<User> users = await _dbContext
			.Users
			.ToListAsync();

		return users;
	}

	[HttpPost]
	public async Task<ActionResult> AddUser([FromBody] CreateUser createUser)
	{
		User user = new User()
		{
			Name = createUser.Name,
			LastName = createUser.LastName
		};

		_dbContext.Users.Add(user);
		await _dbContext.SaveChangesAsync();

		return Ok();
	}
}