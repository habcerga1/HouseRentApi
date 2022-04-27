using System.Net;
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

[Route("api/[controller]")]
[ApiController]
public class RegistrationController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public RegistrationController(AppDbContext dbContext,UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
    {
       _userRepository = new UserRepository(dbContext,userManager,roleManager);
    }

    
    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="user">User model RegistrationDTO, Role types is Admin,Client,Agence,Owner</param>
    /// <returns>A newly created new User</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Registration
    ///     {
    ///        "FirstName" : "Ivan",
    ///        "LastName" : "Ivanow",
    ///        "Email" : "client1@mail.com",
    ///        "PhoneNumber" : "89138473891",
    ///        "Password" : "5uckYou!",
    ///        "Role" : "Client"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created user</response>
    /// <response code="400">If the user is null</response>
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Post(RegistrationRequestDTO user,CancellationToken cancellationToken)
    {
        return await _userRepository.AddNewUserAsync(user,cancellationToken) == true ?  Ok() : BadRequest();
    }
}