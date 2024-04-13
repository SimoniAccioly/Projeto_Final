using CarteiraDoInvestidor.Domain.Carteira.Agreggates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Repository.Mapping.Conta
{
    public class CarteirasMapping : IEntityTypeConfiguration<Carteiras>
    {
        public void Configure(EntityTypeBuilder<Carteiras> builder)
        {
            builder.ToTable(nameof(Carteiras));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.NomeCarteira).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(150); ;
            builder.Property(x => x.DataCriacao).IsRequired();
            builder.HasMany(x => x.ListaDeAtivos).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.UsuarioId).IsRequired();
            //builder.HasOne(x => x.Usuario);

        }
    }
}
