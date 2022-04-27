using HouseRentApi.Models.Users;

namespace HouseRentApi.Models.DTO.Request;

/// <summary>
/// Класс описывающий модель регистрации пользователя приходящая с front-end'a для DTO
/// </summary>
public class RegistrationRequestDTO : User
{
    public string Role { get; set; }
    public string Password { get; set; }
}