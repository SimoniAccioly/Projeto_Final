using CarteiraDoInvestidor.Domain.Financeiro.Agreggates;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteiraDoInvestidor.Domain.ValueObject;

namespace CarteiraDoInvestidor.Repository.Mapping.Financeiro
{
    public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {

            builder.ToTable(nameof(Transacao));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.DtTransacao).IsRequired();
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1024);


            builder.OwnsOne<Monetario>(d => d.Valor, c =>
            {
                c.Property(x => x.Valor).HasColumnName("ValorTransacao").IsRequired();
            });

            builder.OwnsOne<Merchant>(d => d.Merchant, c =>
            {
                c.Property(x => x.Nome).HasColumnName("MerchantNome").IsRequired();
            });

        }
    }
}
