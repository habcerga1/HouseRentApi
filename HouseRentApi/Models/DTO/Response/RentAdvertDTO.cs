using System;
using System.Collections.Generic;
using HouseRentApi.Models.Adverts;
using HouseRentApi.Models.RealEstate;
using HouseRentApi.Models.RealEstate.Utilits;

namespace HouseRentApi.Models.DTO;

/// <summary>
/// Класс описывающий модель объявления аренды недвижимости для DTO
/// </summary>
public class RentAdvertDTO 
{
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
}