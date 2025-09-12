namespace mogaERP.Infrastructure._Data.Configurations;
public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Items", SchemaNames.Inventory);

        builder.Property(i => i.Name)
               .IsRequired()
               .HasMaxLength(200);
    }
}
