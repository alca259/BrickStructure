using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrickStructure.Client.DataLayer.Mappings
{
    internal class WeatherExtendedMapping : IEntityTypeConfiguration<WeatherExtendedEntity>
    {
        public void Configure(EntityTypeBuilder<WeatherExtendedEntity> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.ToTable("Weather", "System");

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.SkyDescription).HasColumnName("Sky_Description").IsRequired().HasMaxLength(100).IsUnicode(true);
            builder.Property(p => p.IsReal).HasColumnName("Is_Real").IsRequired();

            builder.HasOne(o => o.CoreEntity).WithOne().HasForeignKey<WeatherExtendedEntity>(o => o.Id);
        }
    }
}
