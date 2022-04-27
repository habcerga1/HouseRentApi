using System.Threading;
using System.Threading.Tasks;
using HouseRentApi.DbContext;
using HouseRentApi.Models.Adverts;
using HouseRentApi.Models.DTO;
using HouseRentApi.Fabrics;
using HouseRentApi.Models.DTO.Request;
using HouseRentApi.Models.DTO.Response;
using HouseRentApi.Models.RealEstate;
using HouseRentApi.Models.RealEstate.Utilits;
using HouseRentApi.Sevices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdvertController : ControllerBase
{
    public AdvertController(AppDbContext dbContext)
    {
        
    }
    
    /// <summary>
    /// Creates a new Rent Advert.
    /// </summary>
    /// <param name="requestAdvert">RentAdvertRequestDTO model</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    /// <remarks>
    ///  POST /RentAdvertRequestDTO
    ///   
    /// </remarks>
    [Authorize(Roles = CustomRoles.AutorizedUsers)]
    [HttpPost("Rent")]
    public async Task<IActionResult> Post(RentAdvertRequestDTO rentAdvertRequestDto,CancellationToken cancellationToken)
    {
        AbstractAdvertBuilder factory = new AdvertBuilderFactory(rentAdvertRequestDto).Create();
        RentAdvert advert = (RentAdvert)factory.GetAdvert();
        return Ok();
    }
    
    
    /// <summary>
    /// Creates a new Sell Advert.
    /// </summary>
    /// <param name="requestAdvert">SellAdvertRequestDTO model</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    /// <remarks>
    ///  POST /SellAdvertRequestDTO
    ///   
    /// </remarks>
    [Authorize(Roles = CustomRoles.AutorizedUsers)]
    [HttpPost("Sell")]
    public async Task<IActionResult> Post(SellAdvertRequestDto sellAdvertRequestDto,CancellationToken cancellationToken)
    {
        AbstractAdvertBuilder factory = new AdvertBuilderFactory(sellAdvertRequestDto).Create();
        var asdas = factory.GetAdvert();
        SellAdvert advert = (SellAdvert)factory.GetAdvert();
        return Ok();
    }
    
    
}