using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Infra.ContextMap
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nome).IsRequired().HasColumnName("nome").HasColumnType("varchar(30)");
            builder.Property(u => u.Email).IsRequired().HasColumnName("email").HasColumnType("varchar(120)");
            builder.Property(u => u.Senha).IsRequired().HasColumnName("senha").HasColumnType("varchar(120)");
            builder.Property(u => u.IdProfile).IsRequired().HasColumnName("id_perfil").HasColumnType("INT");
            builder.Property(u => u.Endereco).IsRequired().HasColumnName("endereco").HasColumnType("varchar(150)");
            builder.Property(u => u.Cidade).IsRequired().HasColumnName("cidade").HasColumnType("varchar(50)");
            builder.Property(u => u.Bairro).IsRequired().HasColumnName("bairro").HasColumnType("varchar(50)");
            builder.Property(u => u.NumeroResidencia).IsRequired().HasColumnName("numero_residencia").HasColumnType("varchar(10)");
            builder.Property(u => u.Telefone).IsRequired().HasColumnName("telefone").HasColumnType("varchar(25)");
            builder.Property(u => u.Cep).IsRequired().HasColumnName("cep").HasColumnType("varchar(20)");
            builder.Property(u => u.Cnh).HasColumnType("INT");
            builder.Property(u => u.DeviceToken).HasColumnType("varchar(200)").HasColumnName("device_token");
            builder.HasOne(u => u.Perfil).WithMany(p => p.Usuarios).HasForeignKey(u => u.IdProfile);
        }
    }
}
