using System.Net.Mime;
using BackEnd.UserProfile.Domain.Services;
using BackEnd.UserProfile.Interfaces.REST.Resource;
using BackEnd.UserProfile.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BackEnd.UserProfile.Interfaces.REST;

[ApiController]
[Route("/api/v1/user-profiles")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("User Profiles")]
public class UserProfileController : ControllerBase
{
    private readonly IUserProfileCommandService _userProfileCommandService;
    private readonly IUserProfileQueryService _userProfileQueryService;

    public UserProfileController(
        IUserProfileCommandService userProfileCommandService,
        IUserProfileQueryService userProfileQueryService)
    {
        _userProfileCommandService = userProfileCommandService;
        _userProfileQueryService = userProfileQueryService;
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a user profile",
        Description = "Create a user profile with the provided user information",
        OperationId = "CreateUserProfile")]
    [SwaggerResponse(201, "The user profile was created", typeof(UserProfileResource))]
    [SwaggerResponse(400, "The user profile was not created")]
    public async Task<ActionResult> CreateUserProfile([FromBody] CreateUserProfileResource resource)
    {
        var command = CreateUserProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await _userProfileCommandService.Handle(command);
        if (result is null)
        {
            return BadRequest("User profile could not be created.");
        }
        return CreatedAtAction(nameof(GetUserProfileById), new { id = result.Id },
            UserProfileResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a user profile by ID",
        Description = "Retrieve a user profile using the specified ID",
        OperationId = "GetUserProfileById")]
    [SwaggerResponse(200, "User profile retrieved successfully")]
    [SwaggerResponse(404, "User profile not found")]
    public async Task<ActionResult> GetUserProfileById(int id)
    {
        var getUserProfileById = new GetUserProfileByIdQuery(id);
        var result = await _userProfileQueryService.Handle(getUserProfileById);
    
        if (result is null)
        {
            return NotFound($"User profile with ID {id} not found.");
        }
    
        var resource = UserProfileResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }


    /*
    [HttpGet("by-preference")]
    [SwaggerOperation(
        Summary = "Get user profiles by preferences",
        Description = "Retrieve user profiles that match the specified food preferences",
        OperationId = "GetUserProfilesByPreference")]
    [SwaggerResponse(200, "User profiles retrieved successfully")]
    [SwaggerResponse(404, "No user profiles found matching the given preferences")]
    public async Task<ActionResult> GetUserProfilesByPreference([FromQuery] List<string> preferences)
    {
        var query = new GetUserProfilesByPreferenceQuery(preferences);
        var userProfiles = await _userProfileQueryService.Handle(query);

        if (!userProfiles.Any())
        {
            return NotFound("No user profiles found matching the given preferences.");
        }

        var resources = userProfiles.Select(UserProfileResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    */
    
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update a user profile",
        Description = "Update a user profile with the specified ID",
        OperationId = "UpdateUserProfile")]
    [SwaggerResponse(200, "User profile updated successfully")]
    [SwaggerResponse(404, "User profile not found")]
    public async Task<IActionResult> UpdateUserProfile(int id, [FromBody] UpdateUserProfileCommand command)
    {
        if (command == null)
        {
            return BadRequest("Invalid data.");
        }

        // Utiliza el id de la URL para el perfil a actualizar
        var updatedCommand = command with { UserId = id };

        // Llama al servicio de comando para actualizar el perfil
        var result = await _userProfileCommandService.Handle(updatedCommand);

        if (result == null)
        {
            return NotFound($"User profile with ID {id} not found.");
        }

        // Retorna un mensaje simple indicando que la actualización fue exitosa
        return Ok(new { Message = "User profile updated successfully." });
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a user profile",
        Description = "Delete a user profile with the specified ID",
        OperationId = "DeleteUserProfile")]
    [SwaggerResponse(204, "User profile was successfully deleted")]
    [SwaggerResponse(404, "User profile not found")]
    public async Task<ActionResult> DeleteUserProfile(int id)
    {
        // Llama al servicio de comandos para eliminar el perfil
        var result = await _userProfileCommandService.DeleteUserProfileAsync(id);
    
        if (!result)
        {
            return NotFound($"User profile with ID {id} not found."); // Si no se encontró, retorna 404
        }

        return NoContent(); // Retorna 204 No Content si se elimina correctamente
    }

}
