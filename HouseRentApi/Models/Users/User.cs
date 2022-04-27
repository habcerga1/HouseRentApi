using System;
using Microsoft.AspNetCore.Identity;

namespace HouseRentApi.Models.Users;

public class User : IdentityUser, IEntity
{
    public int Id { get; set;}
    public Guid Guid { get; set;}
    public bool IsPhoneNumberVisible { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte[]? LogoImage { get; set;}
    
}