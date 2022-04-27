using HouseRentApi.Models.DTO;

namespace HouseRentApi.Fabrics;

/// <summary>
/// Фабрика билдеров для модели объявлений DTO.
/// </summary>
public class AdvertBuilderFactory : AbstractAdvertBuilderFactory
{
    /// <summary>
    ///  
    /// </summary>
    /// <param name="advertRequest">Интерфейс описывает модель объявления приходящее с front-end'a</param>
    public AdvertBuilderFactory(IAdvertRequestDTO advertRequest) : base(advertRequest)
    {
    }
}