namespace HouseRentApi.Models.RealEstate.Utilits;

public interface IAppliance : IEntity
{
    string Name { get; set; }
}

public class Appliciance : IAppliance
{
    public Appliciance(string name)
    {
        Name = name;
        Guid = Guid.NewGuid();
    }

    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Name { get; set; }
}