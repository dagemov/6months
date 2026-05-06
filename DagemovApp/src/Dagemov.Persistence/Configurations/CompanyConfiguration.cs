using Dagemov.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dagemov.Persistence.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.Property(name => name.Name).IsUnicode().HasMaxLength(150);
        builder.Property(legalName => legalName).IsUnicode().HasMaxLength(150);
        builder.Property(description => description).IsRequired(false).HasMaxLength(200);

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.UpdatedDate)
            .IsRequired();

        builder.Property(x => x.ModifiedByUser)
            .IsRequired(false)
            .HasMaxLength(150);
    }
}
