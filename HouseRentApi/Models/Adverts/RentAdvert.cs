using System;
using System.Collections.Generic;
using HouseRentApi.Models.RealEstate;
using HouseRentApi.Models.RealEstate.Utilits;

namespace HouseRentApi.Models.Adverts;


public class RentAdvert : IAdvert
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public OrderType OrderType { get; set; }
    public EstateType EstateType { get; set; }
    public RentType RentType { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public IRealEstate RealEstate { get; set; }
    public IList<IAppliance> Appliances { get; set; }
    public bool IsPetsAllowed { get; set; }
    public bool IsWithPledge { get; set; }

    public RentAdvert()
    {
        OrderType = OrderType.Rent;
        Appliances = new List<IAppliance>();
    }

    public RentAdvert(IRealEstate realEstate,params object[] param){}
}