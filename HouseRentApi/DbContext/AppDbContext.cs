using HouseRentApi.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace HouseRentApi.DbContext;

public class AppDbContext : IdentityDbContext<User, IdentityRole, string>
{
    //public DbSet<RealEstate> RealEstates { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("workstation id=realestatespain.mssql.somee.com;packet size=4096;user id=habcerga3_SQLLogin_1;pwd=2o1rdonipd;data source=realestatespain.mssql.somee.com;persist security info=False;initial catalog=realestatespain");
    }
}