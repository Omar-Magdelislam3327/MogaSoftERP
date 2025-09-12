
namespace mogaERP.Infrastructure._Data.Configurations;
public class ItemUnitConfiguration : IEntityTypeConfiguration<ItemUnit>
{
    public void Configure(EntityTypeBuilder<ItemUnit> builder)
    {
        builder.ToTable("ItemUnits", SchemaNames.Inventory);
        builder.Property(iu => iu.Name)
               .IsRequired()
               .HasMaxLength(100);
    }
}
