using HouseRentApi.Models.Adverts;
using HouseRentApi.Models.RealEstate;

namespace HouseRentApi.Fabrics;

public abstract class AbstractRealEstateFactory
{
    private readonly EstateType _estateType;

    public AbstractRealEstateFactory(string estateType)
    {
        Enum.TryParse(estateType,true,out _estateType);
    }
    
    public virtual IRealEstate Create()
    {
        switch (_estateType)
        {
            case EstateType.Groud : return new Ground();
            case EstateType.Garage : return new Garage();
            case EstateType.Room : return new Room();
            case EstateType.Apartment : return new Apartment();
            case EstateType.TownHouse : return new TownHouse();
            case EstateType.House : return new House();
            case EstateType.CommercialPremises : return new CommercialPremises();
        }
        return null;
    }
}