using BackEnd.Dishes.Interfaces.REST.Resource;

namespace BackEnd.Dishes.Interfaces.REST.Transform
{
    public static class DishResourceFromEntityAssembler
    {
        /// <summary>
        /// Converts a DishData entity to a DishResource.
        /// </summary>
        /// <param name="entity">The DishData entity to convert.</param>
        /// <returns>A DishResource representing the entity.</returns>
        public static DishResource ToResourceFromEntity(DishData entity)
        {
            return new DishResource(
                entity.ChefName,               // Nombre del chef
                entity.NameOfDish,             // Nombre del platillo
                entity.Ingredients,            // Lista de ingredientes
                entity.PreparationSteps,       // Pasos de preparación
                entity.Favorite                // Indica si es un platillo favorito
            );
        }
    }
}