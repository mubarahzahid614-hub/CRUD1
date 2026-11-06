using CRUD1.Data;
using CRUD1.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD1.Services;

public class VehicleService : IVehicleService
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public VehicleService(IDbContextFactory<AppDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<Vehicle>> GetAllAsync(string? search = null)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var query = db.Vehicles.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(v => v.Make.Contains(search) || v.Model.Contains(search));
        }

        return await query.OrderByDescending(v => v.CreatedAt).ToListAsync();
    }

    public async Task<Vehicle?> GetByIdAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Vehicles.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task CreateAsync(Vehicle vehicle)
    {
        await using var db = await _factory.CreateDbContextAsync();
        vehicle.CreatedAt = DateTime.Now;
        db.Vehicles.Add(vehicle);
        await db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Vehicle vehicle)
    {
        await using var db = await _factory.CreateDbContextAsync();
        db.Vehicles.Update(vehicle);
        await db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var vehicle = await db.Vehicles.FindAsync(id);
        if (vehicle is not null)
        {
            db.Vehicles.Remove(vehicle);
            await db.SaveChangesAsync();
        }
    }
}