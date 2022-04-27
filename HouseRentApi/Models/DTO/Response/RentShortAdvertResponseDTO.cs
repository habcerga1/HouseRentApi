using HouseRentApi.Models.Images;
using HouseRentApi.Models.Locations;

namespace HouseRentApi.Models.DTO.Response;

/// <summary>
/// Класс описывающий модель объявления аренды недвижимости уходящщую во front-end для DTO.
/// Пользователь получет ее на стороне front-end'a.
/// </summary>
public class RentShortAdvertResponseDTO
{
    public Guid Guid { get; set; }
    public ILocation Location { get; set; }
    public IList<ImageLink> PreviewImages { get; set; }
    public DateTime BuildYear { get; set; }
    public string Description { get; set; }
    
    public int FloorNumber { get; set; }
    public double Price { get; set; }
}