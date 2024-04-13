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
    public class PlanoMapping : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder.ToTable(nameof(Plano));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1024);

            builder.OwnsOne<Monetario>(d => d.Valor, c =>
            {
                c.Property(x => x.Valor).IsRequired();
            });
        }
    }
}
