using Dagemov.Domain.Entities;
using Dagemov.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dagemov.Persistence.Configurations;

public class WorkShiftConfiguration : IEntityTypeConfiguration<WorkShift>
{
    public void Configure(EntityTypeBuilder<WorkShift> builder)
    {
        builder.HasKey(id => id.Id);

        builder.Property(description => description.Description)
            .IsRequired(false)
            .HasMaxLength(180);

        builder.Property(breakTime => breakTime.BreakTime).
            IsRequired(true);
    
      
        builder.OwnsOne(x => x.ShiftPeriod, period =>
        {
            period.Property(p => p.Startshift)
                .HasColumnName("StartShift")
                .IsRequired();

            period.Property(p => p.EndShift)
                .HasColumnName("EndShift")
                .IsRequired();
        });


        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.UpdatedDate)
            .IsRequired();

        builder.Property(x => x.ModifiedByUser)
            .IsRequired(false)
            .HasMaxLength(150);

    }
    
}
