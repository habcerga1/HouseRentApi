using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using HouseRentApi.DbContext;
using HouseRentApi.Models.DTO;
using HouseRentApi.Models.Repository;
using HouseRentApi.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RentRealEstateController : ControllerBase
{
    //private readonly IRealEstateRepository _repository;
    public RentRealEstateController(AppDbContext dbContext)
    {
        //_estateRepository = new UserRepository(dbContext,userManager,roleManager);
        //_repository = new RealRealEstateRepository(dbContext);
    }
    
    [HttpPost]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        return Ok();
    }
    
    [AllowAnonymous]
    [HttpGet("GetRangeByCity")]
    public async Task<IActionResult> GetRangeByCity([FromBody] LocationDTO location,CancellationToken cancellationToken)
    {
        /*var result = await _repository.GetRangeByCityAsync(location.City, cancellationToken);
        return result != null ? Ok(JsonSerializer.Serialize(result)) : BadRequest("Null");*/
        return null;
    }
}
