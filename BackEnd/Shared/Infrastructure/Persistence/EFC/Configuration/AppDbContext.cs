using BackEnd.Orders.Domain.Model.Aggregates;
using catch_up_platform_firtness.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

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
        
        // Configuración para UserProfile
        builder.Entity<Order>().ToTable("order"); // Especifica el nombre de la tabla
        builder.Entity<Order>().HasKey(up => up.Id);
        builder.Entity<Order>().Property(up => up.customerId).IsRequired().HasColumnName("customerId");
        builder.Entity<Order>().Property(up => up.orderDate).IsRequired().HasColumnName("orderDate");
        builder.Entity<Order>().Property(up => up.deliveryDate).IsRequired().HasColumnName("deliveryDate");
        builder.Entity<Order>().Property(up => up.paymentMethod).IsRequired().HasColumnName("paymentMethod");
        builder.Entity<Order>().Property(up => up.totalAmount).IsRequired().HasColumnName("totalAmount");
        builder.Entity<Order>().Property(up => up.status).IsRequired().HasColumnName("status");
        //builder.Entity<Order>().Property(up => up.dishes).IsRequired().HasColumnName("dishes");
        builder.Entity<Order>().Property(up => up.detailsShown).IsRequired().HasColumnName("detailsShown");
        
        
        // Configuración para PreferencesJson
        // Ignorar la propiedad Preferences
        builder.Entity<Order>().Ignore(up => up.dishes);

        // Configuración para PreferencesJson
        builder.Entity<Order>()
            .Property(up => up.PreferencesJson)
            .HasColumnName("preferencesJson") // Asegúrate de que coincida con el nombre de la columna
            .HasColumnType("TEXT") // Tipo para almacenar JSON
            .IsRequired(false); // Puede ser opcional
    }
    // Agregar DbSet para las entidades
    
    public DbSet<Order> Orders { get; set; }
}