using System;
using System.Collections.Generic;
using HouseRentApi.Models.Images;
using HouseRentApi.Models.Locations;

namespace HouseRentApi.Models.RealEstate;

public class CommercialPremises : IRealEstate
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public double FloorSpace { get; set; }
    public int LocationId { get; set; }
    public ILocation Location { get; set; }
    public IList<ImageLink> Images { get; set; }
    public DateTime BuildYear { get; set; }
    public string Description { get; set; }

    public CommercialPremises()
    {
        
    }
    public CommercialPremises(params object[] param)
    {
        
    }
}