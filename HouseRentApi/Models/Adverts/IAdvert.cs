using System.Collections.Generic;
using HouseRentApi.Fabrics;
using HouseRentApi.Models.DTO;
using HouseRentApi.Models.Images;
using HouseRentApi.Models.RealEstate;
using HouseRentApi.Models.RealEstate.Utilits;
using HouseRentApi.Models.Users;

namespace HouseRentApi.Models.Adverts;

public interface IAdvert : IEntity
{
    Guid Guid { get; set; }
    OrderType OrderType { get; set; }
    EstateType EstateType { get; set; }
    string Description { get; set; }
    double Price { get; set; }
    
    IRealEstate RealEstate { get; set; }
    IList<IAppliance> Appliances { get; set; }
    
}




