using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WKTechnology.Domain.Entities;

namespace WKTechnology.Infra.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Ativo)
            .IsRequired();

        builder.Property(c => c.DataCadastro)
            .IsRequired()
            .HasColumnType("DATETIME");

        builder.Property(c => c.DataInativacao)
            .HasColumnType("DATETIME");

        builder.HasMany(c => c.Produtos)
            .WithOne(p => p.Categoria)
            .HasForeignKey(p => p.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}