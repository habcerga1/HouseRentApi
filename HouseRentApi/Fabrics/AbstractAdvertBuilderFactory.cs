using HouseRentApi.Models.Adverts;
using HouseRentApi.Models.DTO;
using HouseRentApi.Models.DTO.Request;

namespace HouseRentApi.Fabrics;

public abstract class AbstractAdvertBuilderFactory
{
    private readonly OrderType _orderType;
    private readonly IAdvertRequestDTO _advertRequest;
   
    public AbstractAdvertBuilderFactory(IAdvertRequestDTO advertRequest)
    {
        _advertRequest = advertRequest;
        Enum.TryParse(advertRequest.OrderType, true, out _orderType);
    }
    
    /// <summary>
    /// Создает билдер для аренды либо продажи, на основе свойства OrderType в типе переданном в конструктор
    /// </summary>
    /// <returns>Возвращает билдер</returns>
    public virtual AbstractAdvertBuilder Create()
    {
        switch (_orderType)
        {
            case OrderType.Rent : return new RentAdvertBuilder(_advertRequest);
            case OrderType.Sell : return new SellAdvertBuilder(_advertRequest);
        }
        return null;
    }
}