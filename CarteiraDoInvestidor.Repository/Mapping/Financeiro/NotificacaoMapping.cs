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
    public class NotificacaoMapping : IEntityTypeConfiguration<Notificacao>
    {
        public void Configure(EntityTypeBuilder<Notificacao> builder)
        {
            builder.ToTable(nameof(Notificacao));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.DtNotificacao).IsRequired();
            builder.Property(x => x.Mensagem).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(150);
            builder.Property(x => x.TipoNotificacao).IsRequired();

            builder.HasOne(x => x.UsuarioDestino).WithMany(x => x.Notificacoes).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.UsuarioRemetente).WithMany().IsRequired(false);
        }
    }
}
