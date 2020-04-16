using BrickStructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrickStructure.Data.Repositories.Mappings
{
    internal class WeatherForecastMapping : IEntityTypeConfiguration<WeatherForecastEntity>
    {
        public void Configure(EntityTypeBuilder<WeatherForecastEntity> builder)
        {
            builder.ToTable("Weather_Forecast", "System").HasKey(pk => pk.Id);

            builder.Property(p => p.Id);
        }
    }
}
