namespace ECommerce.DataAccessLayer.Configurations;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(255).IsRequired();
        builder.HasCheckConstraint<Product>("Count", "Count between 0 and 100");        

    }
}
