namespace ECommerce.DataAccessLayer.Configurations;

public class CategoryConfigurations : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
       builder.Property(p=>p.Name).HasMaxLength(255).IsRequired();
        builder.HasIndex(p => p.Name).IsUnique();

        builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);


        //Many-to-Many
        //builder.HasMany(c => c.Products)
        //    .WithMany(p => p.Categories)
        //    .UsingEntity("CategoryProducts",);
    }
}
