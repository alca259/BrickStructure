using BrickStructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrickStructure.Data.Repositories.Mappings
{
    internal class WeatherMapping : IEntityTypeConfiguration<WeatherEntity>
    {
        public void Configure(EntityTypeBuilder<WeatherEntity> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.ToTable("Weather", "System");

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.StationCode).HasColumnName("Station_Code").IsRequired().HasMaxLength(50);
            builder.Property(p => p.Location).HasColumnName("Location").IsRequired().HasMaxLength(100);
            builder.Property(p => p.Longitude).HasColumnName("Longitude").IsRequired();
            builder.Property(p => p.Latitude).HasColumnName("Latitude").IsRequired();
            builder.Property(p => p.Altitude).HasColumnName("Altitude").IsRequired();
            builder.Property(p => p.RegisteredDate).HasColumnName("Registered_Date").IsRequired();
            builder.Property(p => p.Precipitation).HasColumnName("Precipitation").IsRequired();
            builder.Property(p => p.WindSpeed).HasColumnName("Wind_Speed").IsRequired();
            builder.Property(p => p.WindDirection).HasColumnName("Wind_Direction").IsRequired();
            builder.Property(p => p.WindCardinality).HasColumnName("Wind_Cardinality").IsRequired().HasMaxLength(50);
            builder.Property(p => p.Pressure).HasColumnName("Pressure").IsRequired();
            builder.Property(p => p.Humidity).HasColumnName("Humidity").IsRequired();
            builder.Property(p => p.TemperatureFloor).HasColumnName("Temperature_Floor").IsRequired();
            builder.Property(p => p.TemperatureAir).HasColumnName("Temperature_Air").IsRequired();
            builder.Property(p => p.SkyStatus).HasColumnName("Sky_Status").IsRequired();
        }
    }
}
