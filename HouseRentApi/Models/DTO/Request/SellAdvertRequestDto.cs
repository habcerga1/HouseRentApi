using HouseRentApi.Models.Adverts;
using HouseRentApi.Models.RealEstate;
using HouseRentApi.Models.RealEstate.Utilits;

namespace HouseRentApi.Models.DTO.Request;

/// <summary>
/// Класс описывающий модель объявления продажи недвижимости приходящая с front-end'a для DTO.
/// Пользователь публикует ее с front-end'a.
/// </summary>
public class SellAdvertRequestDto : IAdvertRequestDTO
{
    public string OrderType { get; set; }
    public string EstateType { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public IRealEstate RealEstate { get; set; }
    public IList<IAppliance> Appliances { get; set; }
    public UserDTO User { get; set; }
}