using catch_up_platform_firtness.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using BackEnd.Posts;
using BackEnd.Posts.Domain.Model.Aggregates;

namespace BackEnd.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext (DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.UseSnakeCaseNamingConvention();
        
        builder.Entity<Post>().ToTable("post");
        builder.Entity<Post>().HasKey(up => up.id);
        builder.Entity<Post>().Property(up => up.dishId).IsRequired().HasColumnName("dishId");
        builder.Entity<Post>().Property(up => up.publishDate).IsRequired().HasColumnName("publishDate");
        builder.Entity<Post>().Property(up => up.stock).IsRequired().HasColumnName("stock");
    }
    
    public DbSet<Post> Posts { get; set; }
}