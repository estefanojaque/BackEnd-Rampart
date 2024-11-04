using catch_up_platform_firtness.Shared.Domain.Repositories;
using catch_up_platform_firtness.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace catch_up_platform_firtness.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}