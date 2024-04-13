using CarteiraDoInvestidor.Domain.Financeiro.Agreggates;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Repository.Mapping.Financeiro
{
    public class AssinaturaMapping : IEntityTypeConfiguration<Assinatura>
    {
        public void Configure(EntityTypeBuilder<Assinatura> builder)
        {
            builder.ToTable(nameof(Assinatura));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Ativo).IsRequired();
            builder.Property(x => x.DtAtivacao).IsRequired();

            builder.HasOne(x => x.Plano).WithMany();
        }
    }
}
