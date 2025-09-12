
namespace mogaERP.Infrastructure._Data.Configurations;
public class ItemGroupConfiguration : IEntityTypeConfiguration<ItemGroup>
{
    public void Configure(EntityTypeBuilder<ItemGroup> builder)
    {
        builder.ToTable("ItemGroups", SchemaNames.Inventory);

        builder.Property(ig => ig.Name)
               .IsRequired()
               .HasMaxLength(200);
    }
}
