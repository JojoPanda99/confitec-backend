using ConfitecAPIBusiness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfitecAPIData.Mapping;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Name).IsRequired().HasMaxLength(255);
        builder.Property(u => u.Surname).IsRequired().HasMaxLength(255);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(255);
        builder.Property(u => u.BirthDate).IsRequired();
        builder.Property(u => u.Education).HasConversion<int>().IsRequired();
    }
}