using catch_up_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using catch_up_platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace catch_up_platform.Dishes;

public class DishRepository(AppDbContext context) 
    : BaseRepository<DishData>(context), IDishRepository
{
    // Obtener un platillo por ID
    public async Task<DishData?> FindByIdAsync(int dishId) // Cambia el nombre aquí
    {
        return await Context.Set<DishData>().FindAsync(dishId);
    }

    // Obtener todos los platillos
    public async Task<IEnumerable<DishData>> GetAllAsync()
    {
        return await Context.Set<DishData>().ToListAsync();
    }

    // Crear un nuevo platillo
    public async Task CreateAsync(DishData dish) // Asegúrate de que este nombre se use aquí también
    {
        await Context.Set<DishData>().AddAsync(dish);
        await Context.SaveChangesAsync();
    }

    // Actualizar un platillo existente
    public async Task UpdateAsync(DishData dish)
    {
        Context.Set<DishData>().Update(dish);
        await Context.SaveChangesAsync();
    }

    // Eliminar un platillo por ID
    public async Task DeleteAsync(int dishId)
    {
        var dish = await FindByIdAsync(dishId); // Cambia aquí también
        if (dish != null)
        {
            Context.Set<DishData>().Remove(dish);
            await Context.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException("Dish not found"); // O maneja el error de otra manera
        }
    }
}