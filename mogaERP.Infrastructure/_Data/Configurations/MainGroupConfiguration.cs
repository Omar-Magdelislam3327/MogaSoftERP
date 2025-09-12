
namespace mogaERP.Infrastructure._Data.Configurations;
public class MainGroupConfiguration : IEntityTypeConfiguration<MainGroup>
{
    public void Configure(EntityTypeBuilder<MainGroup> builder)
    {
        builder.ToTable("MainGroups", SchemaNames.Inventory);

        builder.Property(mg => mg.Name)
               .IsRequired()
               .HasMaxLength(200);
    }
}
