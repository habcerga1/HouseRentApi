using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HouseRentApi.DbContext;
using HouseRentApi.Models.DTO;
using HouseRentApi.Models.DTO.Request;
using HouseRentApi.Models.Users;
using HouseRentApi.Sevices;
using Microsoft.AspNetCore.Identity;

namespace HouseRentApi.Models.Repository;

public class UserRepository : BaseRepository<User>,IUserRepository
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserRepository(AppDbContext dbContext,UserManager<User> userManager,RoleManager<IdentityRole> roleManager) : base(dbContext)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async Task<User> GetByEmailAndPassAsync(AuthenticationRequestDTO user, CancellationToken cancellationToken)
    {
        var userFromDB = await _userManager.FindByEmailAsync(user.Email).ConfigureAwait(false);
        if (userFromDB != null)
        {
            var isUserExist = await _userManager.CheckPasswordAsync(userFromDB, user.Password).ConfigureAwait(false);
            if (isUserExist != false)
            {
                return userFromDB;
            }
        }
        return null;
    }

    

    public async Task<bool> AddNewUserAsync(RegistrationRequestDTO user, CancellationToken cancellationToken)
    {
        if (new UserRoleContainer(user.Role.ToString()).CheckRole())
        {
            var userExist = await _userManager.FindByEmailAsync(user.Email);
            if (userExist == null)
            {
                var newUser = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    UserName = user.Email,
                    Guid = Guid.NewGuid()
                };
            
                var roleExist = await _roleManager.FindByNameAsync(user.Role);
                if (roleExist == null)
                {
                    IdentityRole role = new IdentityRole(user.Role);
                    await _roleManager.CreateAsync(role);
                }
                
                var userCreated = await _userManager.CreateAsync(newUser, user.Password);
                var userFromDb = await _userManager.FindByEmailAsync(user.Email);
                await _userManager.AddToRoleAsync(userFromDb,user.Role);
            
                return true;

            }
            else
            {
                return false;
            } 
        }
        else
        {
            return false;
        }
        
    }

    public async Task<string> AuthenticateAsync(AuthenticationRequestDTO user,CancellationToken cancellationToken)
    {
        TODO: // fix getting role and record to Token (role)
        var userFromDB = await this.GetByEmailAndPassAsync(user,cancellationToken).ConfigureAwait(false);
        if (userFromDB != null)
        {
            var userRole = await _userManager.GetRolesAsync(userFromDB).ConfigureAwait(false);
            TokenGenerator tokenGenerator = new TokenGenerator(userFromDB, userRole.FirstOrDefault());
            return tokenGenerator.Generate().Result;
        }
        else return "Bad user or password";
    }

    
}