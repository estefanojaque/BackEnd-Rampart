using System.Net.Mime;
using catch_up_platform.Dishes.Domain.Services;
using catch_up_platform.Dishes.Interfaces.REST.Resource;
using catch_up_platform.Dishes.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace catch_up_platform.Dishes.Interfaces.REST
{
    [ApiController]
    [Route("/api/v1/dishes")]
    [Produces(MediaTypeNames.Application.Json)]
    [Tags("Dishes")]
    public class DishController : ControllerBase
    {
        private readonly IDishCommandService _dishCommandService;
        private readonly IDishQueryService _dishQueryService;

        public DishController(
            IDishCommandService dishCommandService,
            IDishQueryService dishQueryService)
        {
            _dishCommandService = dishCommandService;
            _dishQueryService = dishQueryService;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a dish",
            Description = "Create a dish with the provided information",
            OperationId = "CreateDish")]
        [SwaggerResponse(201, "The dish was created", typeof(DishResource))]
        [SwaggerResponse(400, "The dish was not created")]
        public async Task<ActionResult> CreateDish([FromBody] CreateDishResource resource)
        {
            var command = CreateDishCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await _dishCommandService.Handle(command);
            if (result is null)
            {
                return BadRequest("Dish could not be created.");
            }
            return CreatedAtAction(nameof(GetDishById), new { id = result.Id },
                DishResourceFromEntityAssembler.ToResourceFromEntity(result));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a dish by ID",
            Description = "Retrieve a dish using the specified ID",
            OperationId = "GetDishById")]
        [SwaggerResponse(200, "Dish retrieved successfully")]
        [SwaggerResponse(404, "Dish not found")]
        public async Task<ActionResult> GetDishById(int id)
        {
            var query = new GetDishByIdQuery(id);
            var result = await _dishQueryService.Handle(query);

            if (result is null)
            {
                return NotFound($"Dish with ID {id} not found.");
            }

            var resource = DishResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update a dish",
            Description = "Update a dish with the specified ID",
            OperationId = "UpdateDish")]
        [SwaggerResponse(200, "Dish updated successfully")]
        [SwaggerResponse(404, "Dish not found")]
        public async Task<IActionResult> UpdateDish(int id, [FromBody] UpdateDishCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            var updatedCommand = command with { DishId = id };

            var result = await _dishCommandService.Handle(updatedCommand);

            if (result == null)
            {
                // Indica que no hubo cambios realizados
                return Ok(new { Message = "No changes made to the dish." });
            }

            return Ok(new { Message = "Dish updated successfully.", Dish = result });
        }


        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete a dish",
            Description = "Delete a dish with the specified ID",
            OperationId = "DeleteDish")]
        [SwaggerResponse(204, "Dish was successfully deleted")]
        [SwaggerResponse(404, "Dish not found")]
        public async Task<ActionResult> DeleteDish(int id)
        {
            // Llama al servicio de comandos para eliminar el platillo
            var result = await _dishCommandService.DeleteDishAsync(id);

            if (!result)
            {
                return NotFound($"Dish with ID {id} not found."); // Si no se encontró, retorna 404
            }

            return NoContent(); // Retorna 204 No Content si se elimina correctamente
        }
    }
}
