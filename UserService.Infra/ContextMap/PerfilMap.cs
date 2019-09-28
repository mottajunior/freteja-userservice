using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Infra.ContextMap
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("perfil");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Tipo).IsRequired().HasColumnName("tipo").HasColumnType("varchar(30)");
        }
    }
}
