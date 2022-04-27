using System;
using System.Collections.Generic;
using HouseRentApi.Models.Images;
using HouseRentApi.Models.Locations;

namespace HouseRentApi.Models.RealEstate;

public interface IRealEstate : IEntity
{
    public double FloorSpace { get; set; }
    
    public int LocationId { get; set; }
    public ILocation Location { get; set; }
    
    public IList<ImageLink> Images { get; set; }
    
    public DateTime BuildYear { get; set; } 
    
    public string Description { get; set; }
}