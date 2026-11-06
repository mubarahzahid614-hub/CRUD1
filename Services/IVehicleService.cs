using CRUD1.Models;

namespace CRUD1.Services;

public interface IVehicleService
{
    Task<List<Vehicle>> GetAllAsync(string? search = null);
    Task<Vehicle?> GetByIdAsync(int id);
    Task CreateAsync(Vehicle vehicle);
    Task UpdateAsync(Vehicle vehicle);
    Task DeleteAsync(int id);
}