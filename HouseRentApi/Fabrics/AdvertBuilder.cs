using HouseRentApi.Models.Adverts;
using HouseRentApi.Models.DTO;

namespace HouseRentApi.Fabrics;

public abstract class AbstractAdvertBuilder
{
    private IAdvert _advert;
    private IAdvertRequestDTO _advertRequestDto;

    public AbstractAdvertBuilder(IAdvertRequestDTO advertRequestDto)
    {
        _advertRequestDto = advertRequestDto;
        this.Reset(_advertRequestDto.OrderType);
    }
    
    private void CreateRealEstate(string estateType)
    {
        _advert.RealEstate = new RealEstateFactory(estateType).Create();
    }
    
    /// <summary>
    /// Создает объявление 
    /// </summary>
    /// <returns>Возвращяет созданное объявление</returns>
    public IAdvert GetAdvert()
    {
        this.Build();
        IAdvert advert = _advert;
        return advert;
    }

    protected virtual void FillAllProperties()
    {
        
    }

    public void Reset(string orderType)
    {
        _advert = new AdvertFactory(orderType).Create();
    }
    
    private void Build()
    {
        this.Reset(_advertRequestDto.OrderType);
        this.CreateRealEstate(_advertRequestDto.EstateType);
        this.FillAllProperties();
    }
}