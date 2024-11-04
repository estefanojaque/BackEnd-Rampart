using BackEnd.Dishes.Domain.Services;

namespace BackEnd.Dishes.Application.Internal.QueryServices
{
    public class DishQueryService : IDishQueryService
    {
        private readonly IDishRepository _dishRepository;

        public DishQueryService(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        // Método para obtener todos los platos
        public async Task<IEnumerable<DishData>> Handle(GetAllDishesQuery query)
        {
            return await _dishRepository.GetAllAsync();
        }

        // Método para obtener un plato por ID
        public async Task<DishData> Handle(GetDishByIdQuery query)
        {
            var dish = await _dishRepository.FindByIdAsync(query.DishId);
            if (dish == null)
                throw new Exception("Dish not found."); // Lanza excepción si no se encuentra el plato

            return dish;
        }
    }
}