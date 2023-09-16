using EOS.CNAB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS.CNAB.InfraStructure.Mappings
{
    public class CnaabMap : IEntityTypeConfiguration<Cnab>
    {
        public void Configure(EntityTypeBuilder<Cnab> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            builder.Property(c => c.Value)
                .HasColumnType("decimal(18,2)");
        }
    }
}
