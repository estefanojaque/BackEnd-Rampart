using catch_up_platform.UserProfile;
using catch_up_platform.Dishes;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace catch_up_platform.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
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
        builder.Entity<ProfileData>().ToTable("user_profiles"); // Especifica el nombre de la tabla
        builder.Entity<ProfileData>().HasKey(up => up.Id);
        builder.Entity<ProfileData>().Property(up => up.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ProfileData>().Property(up => up.Photo).IsRequired().HasColumnName("photo");
        builder.Entity<ProfileData>().Property(up => up.Name).IsRequired().HasColumnName("name");
        builder.Entity<ProfileData>().Property(up => up.Email).IsRequired().HasColumnName("email");
        builder.Entity<ProfileData>().Property(up => up.BirthDate).HasColumnName("birth_date").IsRequired();
        builder.Entity<ProfileData>().Property(up => up.Address).IsRequired().HasColumnName("address");
        builder.Entity<ProfileData>().Property(up => up.PaymentMethod).IsRequired().HasColumnName("paymentmethod");
        builder.Entity<ProfileData>().Property(up => up.CardNumber).HasColumnName("cardnumber").IsRequired();
        builder.Entity<ProfileData>().Property(up => up.YapeNumber).HasColumnName("yapenumber").IsRequired();
        builder.Entity<ProfileData>().Property(up => up.CashPayment).IsRequired().HasColumnName("cashpayment");
        
        // Configuración para PreferencesJson
        // Ignorar la propiedad Preferences
        builder.Entity<ProfileData>().Ignore(up => up.Preferences);

        // Configuración para PreferencesJson
        builder.Entity<ProfileData>()
            .Property(up => up.PreferencesJson)
            .HasColumnName("preferencesJson") // Asegúrate de que coincida con el nombre de la columna
            .HasColumnType("TEXT") // Tipo para almacenar JSON
            .IsRequired(false); // Puede ser opcional
        
        // Configuración para DishData
        builder.Entity<DishData>(entity =>
        {
            entity.HasKey(d => d.Id);
            entity.Property(d => d.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            entity.Property(d => d.ChefName)
                .HasColumnName("chef_name")
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(d => d.NameOfDish)
                .HasColumnName("name_of_dish")
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(d => d.IngredientsJson)
                .HasColumnName("ingredients_json")
                .HasColumnType("TEXT")
                .IsRequired();

            entity.Property(d => d.PreparationStepsJson)
                .HasColumnName("preparation_steps_json")
                .HasColumnType("TEXT")
                .IsRequired();

            entity.Property(d => d.Favorite)
                .HasColumnName("favorite")
                .IsRequired();
        });
    }
    
    // Agregar DbSet para las entidades
    public DbSet<ProfileData> UserProfiles { get; set; }
    public DbSet<DishData> Dishes { get; set; } // Agrega el DbSet para DishData
}