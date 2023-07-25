namespace ECommerce.DataAccessLayer.Configurations;

public class CategoryConfigurations : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
       builder.Property(p=>p.Name).HasMaxLength(255).IsRequired();
        builder.HasIndex(p => p.Name).IsUnique();
    }
}
