
namespace mogaERP.Infrastructure._Data.Configurations;
public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Suppliers", schema: SchemaNames.Procurement);

        builder.Property(s => s.AccountCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(s => s.Address)
            .HasMaxLength(300);

        builder.Property(s => s.ResponsibleName1)
            .HasMaxLength(100);

        builder.Property(s => s.ResponsibleName2)
            .HasMaxLength(100);

        builder.Property(s => s.Phone1)
            .HasMaxLength(20);

        builder.Property(s => s.Phone2)
            .HasMaxLength(20);

        builder.Property(s => s.TaxNumber)
            .HasMaxLength(50);

        builder.Property(s => s.Job)
            .HasMaxLength(100);

        builder.Property(s => s.Fax1)
            .HasMaxLength(20);

        builder.Property(s => s.Fax2)
            .HasMaxLength(20);

        builder.Property(s => s.Email)
            .HasMaxLength(100);

        builder.Property(s => s.Website)
            .HasMaxLength(750);

        builder.Property(s => s.Notes)
            .HasMaxLength(1050);
    }
}
