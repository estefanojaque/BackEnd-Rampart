using BackEnd.Shared.Infrastructure.Persistence.EFC.Configuration;
using BackEnd.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Dishes.Infrastructure.Repositories
{
    public class DishRepository(AppDbContext context)
        : BaseRepository<DishData>(context), IDishRepository
    {
        public async Task<DishData?> FindByIdAsync(int dishId)
        {
            return await Context.Set<DishData>().FindAsync(dishId);
        }

        public async Task<IEnumerable<DishData>> GetAllAsync()
        {
            return await Context.Set<DishData>().ToListAsync();
        }

        public async Task CreateAsync(DishData dish)
        {
            await Context.Set<DishData>().AddAsync(dish);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DishData dish)
        {
            Context.Set<DishData>().Update(dish);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int dishId)
        {
            var dish = await FindByIdAsync(dishId);
            if (dish != null)
            {
                Context.Set<DishData>().Remove(dish);
                await Context.SaveChangesAsync();
            }
        }
    }
}