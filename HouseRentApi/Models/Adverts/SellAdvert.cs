using System;
using System.Collections.Generic;
using HouseRentApi.Models.RealEstate;
using HouseRentApi.Models.RealEstate.Utilits;

namespace HouseRentApi.Models.Adverts;

public class SellAdvert : IAdvert
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public OrderType OrderType { get; set; }
    public EstateType EstateType { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public IRealEstate RealEstate { get; set; }
    public IList<IAppliance> Appliances { get; set; }
    
    public SellAdvert(){}
    public SellAdvert(params object[] param){}
}