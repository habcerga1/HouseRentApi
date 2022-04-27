using System;
using System.Collections.Generic;
using HouseRentApi.Models.Images;
using HouseRentApi.Models.Locations;

namespace HouseRentApi.Models.RealEstate;

public class TownHouse : IRealEstate
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public double FloorSpace { get; set; }
    public int LocationId { get; set; }
    public ILocation Location { get; set; }
    public IList<ImageLink> Images { get; set; }
    public DateTime BuildYear { get; set; }
    public string Description { get; set; }
    
    public int FloorsNumber { get; set; }
    public int FloorNumber { get; set; }
    public int NumberOfBalconies { get; set; }
    public int NumberOfBedrooms { get; set; }
    public int NumberOfBathrooms { get; set; }
    public int NumberOfGarages { get; set; }
    public int NumberOfKitchen { get; set; }
    public int RentEstateTypeId { get; set; }
    
    public double BalconiesSpace { get; set; }
    public double GaragesSpace { get; set; }
    public double BedroomsSpace { get; set; }
    public double KitchenSpace { get; set; }

    public TownHouse()
    {
        
    }
    public TownHouse(params object[] param)
    {
        
    }
}