using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Domain.Entities;

namespace UserService.Infra.ContextMap
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("veiculo");
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Placa).IsRequired().HasColumnName("placa").HasColumnType("varchar(15)");
            builder.Property(v => v.Modelo).IsRequired().HasColumnName("modelo").HasColumnType("varchar(60)");
            builder.Property(v => v.Cor).IsRequired().HasColumnName("cor").HasColumnType("varchar(15)");
            builder.Property(v => v.Ano).IsRequired().HasColumnName("ano").HasColumnType("INT");
            builder.Property(v => v.Renavan).IsRequired().HasColumnName("renavan").HasColumnType("varchar(20)");
            builder.Property(v => v.IdUsuario).IsRequired().HasColumnName("id_usuario").HasColumnType("INT");
            builder.Property(v => v.CargaMaximaKg).IsRequired().HasColumnName("carga_max_kg").HasColumnType("decimal(7,2)");
            builder.HasOne(v => v.Usuario).WithMany(u => u.Veiculos).HasForeignKey(v => v.IdUsuario);
        }
    }
}