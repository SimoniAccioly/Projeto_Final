using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Repository.Mapping.Ativos
{
    public class AtivosMapping : IEntityTypeConfiguration<Domain.Carteira.Agreggates.Ativos>
    {
        public void Configure(EntityTypeBuilder<Domain.Carteira.Agreggates.Ativos> builder)
        {
            builder.ToTable(nameof(Ativos));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Papel).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Quantidade).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Corretora).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TaxaDeCorretagem).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DataDaCompra).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LadoDaOperacao).IsRequired().HasMaxLength(50);

        }
    }
}
