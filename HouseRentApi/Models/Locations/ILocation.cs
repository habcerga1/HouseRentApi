namespace HouseRentApi.Models.Locations;

public interface ILocation : IEntity
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int ZipCode { get; set; }
    public string Street { get; set; }
    public string BuildingNumber { get; set; }
}