using System.Text.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Dishes
{
    public class DishData
    {
        public int Id { get; set; }
        public string ChefName { get; set; } = string.Empty;
        public string NameOfDish { get; set; } = string.Empty;
        public bool Favorite { get; set; }
        
        // JSON para almacenar ingredientes
        public string IngredientsJson { get; set; } = string.Empty;

        // JSON para almacenar pasos de preparación
        public string PreparationStepsJson { get; set; } = string.Empty;

        // Propiedad para acceder a ingredientes como lista
        [NotMapped] // Esto es importante
        public List<string> Ingredients 
        { 
            get => string.IsNullOrEmpty(IngredientsJson) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(IngredientsJson) ?? new List<string>();
            set => IngredientsJson = JsonSerializer.Serialize(value);
        }

        // Propiedad para acceder a pasos como lista
        [NotMapped] // Esto es importante
        public List<string> PreparationSteps 
        { 
            get => string.IsNullOrEmpty(PreparationStepsJson) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(PreparationStepsJson) ?? new List<string>();
            set => PreparationStepsJson = JsonSerializer.Serialize(value);
        }

        // Constructor protegido
        protected DishData() { }

        public DishData(CreateDishCommand command)
        {
            ChefName = command.ChefId;
            NameOfDish = command.NameOfDish;
            Ingredients = command.Ingredients;
            PreparationSteps = command.PreparationSteps;
            Favorite = command.Favorite;
        }
    }
}