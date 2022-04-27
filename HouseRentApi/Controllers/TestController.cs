using System.Threading.Tasks;
using HouseRentApi.DbContext;
using HouseRentApi.Models.Adverts;
using HouseRentApi.Fabrics;
using HouseRentApi.Models.DTO;
using HouseRentApi.Models.RealEstate;
using HouseRentApi.Models.Repository;
using HouseRentApi.Models.Users;
using HouseRentApi.Sevices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseRentApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly AppDbContext _db;

    public TestController(AppDbContext dbContext, UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
    {
        _userRepository = new UserRepository(dbContext, userManager, roleManager);
        _db = dbContext;
    }
    
    
    [Authorize(Roles = CustomRoles.Admin)]
    [Route("AdminRole")]
    [HttpPost]
    public async Task<IActionResult> AdminRole()
    {
        return Ok("Admin Role Working");
    }
    
    [Authorize(Roles = CustomRoles.User)]
    [Route("UserRole")]
    [HttpPost]
    public async Task<IActionResult> ClientRole()
    {
        return Ok("User Role Working");
    }
    
    [Authorize(Roles = CustomRoles.Owner)]
    [Route("OwnerRole")]
    [HttpPost]
    public async Task<IActionResult> OwnerRole()
    {
        return Ok("User Role Working");
    }
    
    [Authorize(Roles = CustomRoles.Agency)]
    [Route("AgencyRole")]
    [HttpPost]
    public async Task<IActionResult> AgencyRole()
    {
        return Ok("Agency Role Working");
    }
    
    [Route("db")]
    [HttpGet]
    public async Task<IActionResult> DB()
    {
        var response = await _db.Users.Select(a => a).FirstOrDefaultAsync();
        return Ok( $"DB is working and its firs user from DB {response}");
    }
    
    [Route("hosting")]
    [HttpGet]
    public async Task<IActionResult> Hosting()
    {
        return Ok( $"Website is working");
    }

    [Route("NewEstate")]
    [HttpPost]
    public async Task<IActionResult> AddEstate(ApartmentDTO apartment,CancellationToken cancellationToken)
    {
        var _estate = apartment;
        return _estate == null ? BadRequest() : Ok();
    }


}