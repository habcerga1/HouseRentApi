using System.Threading;
using System.Threading.Tasks;
using HouseRentApi.Models.DTO;
using HouseRentApi.Models.DTO.Request;
using HouseRentApi.Models.Users;

namespace HouseRentApi.Models.Repository;

public interface IUserRepository: IRepository<User>
{
    Task<User> GetByEmailAndPassAsync(AuthenticationRequestDTO user, CancellationToken cancellationToken);
    Task<bool> AddNewUserAsync(RegistrationRequestDTO newUser,CancellationToken cancellationToken);
    Task<string> AuthenticateAsync(AuthenticationRequestDTO user, CancellationToken cancellationToken);
}