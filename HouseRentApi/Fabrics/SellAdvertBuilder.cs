using HouseRentApi.Models.Adverts;
using HouseRentApi.Models.DTO;
using HouseRentApi.Models.DTO.Request;

namespace HouseRentApi.Fabrics;

/// <summary>
/// Билдер для объявлений типа SellAdvert.
/// </summary>
class SellAdvertBuilder : AbstractAdvertBuilder
{
    private SellAdvert _rentAdvert;
    private SellAdvertRequestDto _advertRequestDto;
    
    public SellAdvertBuilder(IAdvertRequestDTO advertRequestDto) : base(advertRequestDto)
    {
        _advertRequestDto = (SellAdvertRequestDto)advertRequestDto;
    }

    protected override void FillAllProperties()
    {
        _rentAdvert.Description = _advertRequestDto.Description;
        _rentAdvert.Price = _advertRequestDto.Price;
    }
}