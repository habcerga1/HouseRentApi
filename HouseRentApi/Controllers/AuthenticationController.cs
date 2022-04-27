using System.Threading;
using System.Threading.Tasks;
using HouseRentApi.DbContext;
using HouseRentApi.Models.DTO;
using HouseRentApi.Models.DTO.Request;
using HouseRentApi.Models.Repository;
using HouseRentApi.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public AuthenticationController(AppDbContext dbContext,UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
    {
        _userRepository = new UserRepository(dbContext,userManager,roleManager);
    }
    
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Post(AuthenticationRequestDTO user,CancellationToken cancellationToken)
    {
        var response = await _userRepository.AuthenticateAsync(user,cancellationToken);
        return response != "Bad user or password" ? Ok(response) : BadRequest(response);
    }
    
}