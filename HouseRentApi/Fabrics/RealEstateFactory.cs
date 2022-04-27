using HouseRentApi.Models.Adverts;
using HouseRentApi.Models.RealEstate;

namespace HouseRentApi.Fabrics;

public class RealEstateFactory : AbstractRealEstateFactory
{
    public RealEstateFactory(string estateType) : base(estateType)
    {
    }
}