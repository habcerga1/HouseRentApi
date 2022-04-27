using HouseRentApi.Models.Adverts;
using HouseRentApi.Models.DTO;
using HouseRentApi.Models.DTO.Request;
using HouseRentApi.Models.DTO.Response;

namespace HouseRentApi.Fabrics;

/// <summary>
/// Билдер для объявлений типа RentAdvert.
/// </summary>
class RentAdvertBuilder : AbstractAdvertBuilder
{
    private RentAdvert _rentAdvert;
    private RentAdvertRequestDTO _requestAdvertDto;
    
    public RentAdvertBuilder(IAdvertRequestDTO advertRequestDto) : base(advertRequestDto)
    {
        _requestAdvertDto = (RentAdvertRequestDTO)advertRequestDto;
    }
    
    protected override void FillAllProperties()
    {
        _rentAdvert.Description = _requestAdvertDto.Description;
        _rentAdvert.Price = _requestAdvertDto.Price;
        _rentAdvert.IsPetsAllowed = _requestAdvertDto.IsPetsAllowed;
        _rentAdvert.IsWithPledge = _requestAdvertDto.IsWithPledge;
        _rentAdvert.RentType = _requestAdvertDto.RentType;
    }
}