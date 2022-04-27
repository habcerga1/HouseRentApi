using HouseRentApi.DbContext;
using HouseRentApi.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HouseRentApi.Models.Repository;

/*
public class RealRealEstateRepository : BaseRepository<Property.RealEstate>,IRealEstateRepository
{
    public RealRealEstateRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<IRealEstate>> GetRangeByCityAsync(string city, CancellationToken cancellationToken)
    {
        var result = await base.Entities.Where(c => c.Location.City == city).ToListAsync();
        return result;
    }

    public IEnumerable<IRealEstate> GetRangeByCity(string city, CancellationToken cancellationToken)
    {
        var result = base.Entities.Where(c => c.Location.City == city).ToList();
        return result;
    }
}
*/