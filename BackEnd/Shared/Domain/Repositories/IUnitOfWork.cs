﻿namespace catch_up_platform_firtness.Shared.Domain.Repositories;

/// <summary>
/// Unit of work interface
/// </summary>
/// <remarks>
/// This interface is used to define the unit of work pattern for the repositories
/// </remarks>
/// <typeparam name="TEntity"></typeparam>
public interface IUnitOfWork
{
    /// <summary>
    /// Commit changes to the database
    /// </summary>
    /// <returns></returns>
    Task CompleteAsync();
}