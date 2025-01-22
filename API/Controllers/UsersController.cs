using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]  //localhost:5001/api/users
public class UsersController(DataContext context) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();

        return users;  // http responses because of ActionResult (Ok, NotFound, BadRequest)
    }

    [HttpGet("{id:int}")] //specify id    e.g. /api/users/3
    public async Task<ActionResult<AppUser>> GetUsers(int id)
    {
        var user = await context.Users.FindAsync(id);

        if(user == null) return NotFound();  // 404 not found if user is null

        return user;  
    }
}
