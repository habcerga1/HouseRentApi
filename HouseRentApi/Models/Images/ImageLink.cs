using System;

namespace HouseRentApi.Models.Images;

public class ImageLink : IEntity
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    
    public string Image { get; set; }
    public string Preview { get; set; }
}