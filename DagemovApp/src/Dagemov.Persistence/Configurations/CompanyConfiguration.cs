using Dagemov.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dagemov.Persistence.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.Property(x => x.Name).IsUnicode().HasMaxLength(150);
        builder.Property(x => x.LegalName).IsUnicode().HasMaxLength(150);
        builder.Property(x => x.Description).IsRequired(false).HasMaxLength(200);

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.UpdatedDate)
            .IsRequired();

        builder.Property(x => x.ModifiedByUser)
            .IsRequired(false)
            .HasMaxLength(150);
    }
}
