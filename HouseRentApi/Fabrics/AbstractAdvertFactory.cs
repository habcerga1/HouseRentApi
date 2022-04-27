using HouseRentApi.Models.Adverts;

namespace HouseRentApi.Fabrics;

public abstract class AbstractAdvertFactory
{
    private readonly OrderType _orderType;
    public AbstractAdvertFactory(string orderType)
    {
        Enum.TryParse(orderType, true, out _orderType);
    }
    public virtual IAdvert Create()
    {
        switch (_orderType)
        {
            case OrderType.Rent : return new RentAdvert();
            case OrderType.Sell : return new SellAdvert();
        }
        return null;
    }
}