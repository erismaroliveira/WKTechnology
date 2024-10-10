using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WKTechnology.Domain.Entities;

namespace WKTechnology.Infra.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Descricao)
            .HasColumnType("TEXT");

        builder.Property(p => p.Preco)
            .IsRequired()
            .HasColumnType("DECIMAL(10, 2)");

        builder.Property(p => p.Ativo)
            .IsRequired();

        builder.Property(p => p.DataCadastro)
            .IsRequired()
            .HasColumnType("DATETIME");

        builder.Property(p => p.DataInativacao)
            .HasColumnType("DATETIME");

        builder.HasOne(p => p.Categoria)
            .WithMany(c => c.Produtos)
            .HasForeignKey(p => p.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}