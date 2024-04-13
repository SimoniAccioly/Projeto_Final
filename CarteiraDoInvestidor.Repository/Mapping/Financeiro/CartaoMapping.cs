using CarteiraDoInvestidor.Domain.Financeiro.Agreggates;
using CarteiraDoInvestidor.Domain.ValueObject;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Repository.Mapping.Financeiro
{
    public class CartaoMapping : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.ToTable(nameof(Cartao));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Ativo).IsRequired();

            builder.Property(x => x.Numero).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Validade).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CVV).IsRequired().HasMaxLength(50);

            builder.OwnsOne<Monetario>(d => d.Limite, c =>
            {
                c.Property(x => x.Valor).HasColumnName("Limite").IsRequired();
            });

            builder.HasMany<Transacao>(x => x.Transacoes).WithOne();
        }
    }
}
