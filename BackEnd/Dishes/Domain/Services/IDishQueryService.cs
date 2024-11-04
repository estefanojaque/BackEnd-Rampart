using System.Collections.Generic;
using System.Threading.Tasks;

namespace catch_up_platform.Dishes.Domain.Services
{
    public interface IDishQueryService
    {
        /// <summary>
        /// Retrieves a dish by its ID.
        /// </summary>
        /// <param name="query">GetDishByIdQuery query</param>
        /// <returns>The Dish or null if not found</returns>
        Task<DishData?> Handle(GetDishByIdQuery query);

        /// <summary>
        /// Retrieves all dishes.
        /// </summary>
        /// <returns>A list of Dishes</returns>
        Task<IEnumerable<DishData>> Handle(GetAllDishesQuery query);
    }
}