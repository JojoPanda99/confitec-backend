using ConfitecAPIBusiness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfitecAPIData.Mapping;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Name).IsRequired().HasColumnType("varchar(255)");
        builder.Property(u => u.Surname).IsRequired().HasColumnType("varchar(255)");
        builder.Property(u => u.Email).IsRequired().HasColumnType("varchar(255)");
        builder.Property(u => u.BirthDate).IsRequired();
        builder.Property(u => u.Education).HasConversion<int>().IsRequired();

        builder.ToTable("Usuarios");
    }
}