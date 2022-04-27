using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using HouseRentApi.DbContext;
using Microsoft.EntityFrameworkCore;

namespace HouseRentApi.Models.Repository;

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    public DbSet<TEntity> Entities { get; }
    public virtual IQueryable<TEntity> Table => Entities;
    public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();
    
    protected readonly AppDbContext DbContext;

    public BaseRepository(AppDbContext dbContext)
    {
        DbContext = dbContext;
        Entities = dbContext.Set<TEntity>();
    }

    public void Add(TEntity entity,bool saveNow = true)
    {
        Entities.Add(entity);
        if (saveNow) DbContext.SaveChanges();
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken,bool saveNow = true)
    {
        await Entities.AddAsync(entity, cancellationToken).ConfigureAwait(false);
        if (saveNow) await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public void AddRange(IEnumerable<TEntity> entities,bool saveNow = true)
    {
        Entities.AddRange(entities);
        if (saveNow) DbContext.SaveChanges();
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken,bool saveNow = true)
    {
        await Entities.AddRangeAsync(entities, cancellationToken);
        if (saveNow) DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public void Delete(TEntity entity,bool saveNow = true)
    {
        Entities.Remove(entity);
        if (saveNow) DbContext.SaveChanges();
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken,bool saveNow = true)
    {
        Entities.Remove(entity);
        if (saveNow) DbContext.SaveChangesAsync(cancellationToken);
    }

    public void DeleteRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken,bool saveNow = true)
    {
        Entities.RemoveRange(entities);
        if (saveNow) DbContext.SaveChanges();
    }

    public async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken,bool saveNow = true)
    {
        Entities.RemoveRange(entities);
        if(saveNow) DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public TEntity GetById(params object[] ids)
    {
        throw new NotImplementedException();
    }

    public async Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
    {
        throw new NotImplementedException();
    }

    public TEntity GetById(bool saveNow = true,params object[] keys)
    {
        return Entities.Find(keys);
    }

    public async Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, bool saveNow = true,params object[] keys)
    {
        return await Entities.FindAsync(keys,cancellationToken);
    }

    public IEnumerable<TEntity> GetRange(CancellationToken cancellationToken,bool saveNow = true, params object[] keys)
    {
        Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name} Не реализован");
        return null;
    }

    public async Task<IEnumerable<TEntity>> GetRangeAsync(CancellationToken cancellationToken, bool saveNow = true,params object[] keys)
    {
        Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name} Не реализован");
        return null;
    }

    public void Update(TEntity entity,bool saveNow = true)
    {
        Entities.Update(entity);
        DbContext.SaveChanges();
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken,bool saveNow = true)
    {
        Entities.Update(entity);
        if(saveNow) DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public void UpdateRange(IEnumerable<TEntity> entities,bool saveNow = true)
    {
        Entities.UpdateRange(entities);
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken,bool saveNow = true)
    {
        Entities.UpdateRange(entities);
        if(saveNow) DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }
}