namespace ECommerce.DataAccessLayer.Persistance.Configurations;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(255).IsRequired();
        builder.HasCheckConstraint("Count", "Count between 0 and 100");

        builder.HasMany(p => p.ProductImages)
                .WithOne(pi => pi.Product)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        //builder.HasOne(p => p.Category)
        //        .WithMany(c => c.Products)
        //        .HasForeignKey(p => p.CategoryId);
    }
}
