using HouseRentApi.Models.Adverts;
using HouseRentApi.Models.RealEstate;
using HouseRentApi.Models.RealEstate.Utilits;
using HouseRentApi.Models.Users;

namespace HouseRentApi.Models.DTO;

/// <summary>
/// Интерфейс описывает модель объявления приходящее с front-end'a
/// </summary>
public interface IAdvertRequestDTO
{
    public string OrderType { get;  set; } // Sell,Rent
    public string EstateType { get; set; } // Apartment,TownHouse,House
    public string Description { get; set; } // Описание
    public double Price { get;  set; } // Цена
    
    public IRealEstate RealEstate { get;  set; } // тут сам дом
    public IList<IAppliance> Appliances { get;  set; } // список всякой хуйни которое в нем есть, медель холодильник
}

