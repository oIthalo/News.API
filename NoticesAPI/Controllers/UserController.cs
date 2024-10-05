using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.API.Models;
using News.API.Services;
using NoticesAPI.Data;
using NoticesAPI.Data.DTOs;
using NoticesAPI.Models;
using NoticesAPI.Services;
namespace NoticesAPI.Controllers;

[ApiController]
[Route("v1/users")]
public class UserController : ControllerBase
{
    private AppDbContext _context;
    private IMapper _mapper;

    public UserController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] UserDtoRegister userDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var role = await _context.Roles
            .FirstOrDefaultAsync(x => x.Name == "reader");

        try
        {
            User user = _mapper.Map<User>(userDto);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            var userRead = _mapper.Map<UserDtoRead>(user);

            userRead.Role = role!;
            userRead.Role.Id = role!.Id;

            return Ok(userRead);
        }
        catch (Exception)
        {
            return BadRequest("Não foi possível criar um usuário");
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] UserDtoLogin userDto)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => 
            x.Username.Equals(userDto.Username) &&
            x.Password.Equals(userDto.Password));

        if (user is null) return NotFound("Username ou password inválida");
        var token = TokenService.GenerateToken(user);
        var userRead = _mapper.Map<UserDtoRead>(user);
        return Ok(new
        {
            user = userRead,
            token = token
        });
    }
}