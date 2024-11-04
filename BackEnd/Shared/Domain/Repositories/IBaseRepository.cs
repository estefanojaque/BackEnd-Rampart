namespace catch_up_platform_firtness.Shared.Domain.Repositories;


/// <summary>
/// Base repository interface for all repositories
/// </summary>
/// <remarks>
/// This interface is used to define the basic CRUD operations for all respositories</remarks>
/// <typeparam name="TEntity"></typeparam>
public interface IBaseRepository<TEntity>
{
    /// <summary>
    /// Adds an entity to the repository
    /// </summary>
    /// <param name="entity">Entity object to add</param>
    /// <returns></returns>
    Task AddAsync(TEntity entity);
    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">The entity object to update</param>
    void Update(TEntity entity);
    /// <summary>
    /// Remove entity
    /// </summary>
    /// <param name="entity">The entity to remove</param>
    void Remove(TEntity entity);
    
    /// <summary>
    /// Find entity by id
    /// </summary>
    /// <param name="id">The entity ID to find</param>
    /// <returns>Entity object if it was found</returns>
    Task<TEntity?> FindByIdAsync(int id);
    /// <summary>
    /// Get all entities
    /// </summary>
    /// <returns>An enumerable containing all entity objects</returns>
    Task<IEnumerable<TEntity>> ListAsync();
    
}