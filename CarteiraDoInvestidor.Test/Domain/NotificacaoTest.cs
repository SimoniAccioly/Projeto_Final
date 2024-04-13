using CarteiraDoInvestidor.Domain.Conta.Agreggates;
using CarteiraDoInvestidor.Domain.Financeiro.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Test.Domain
{
    public class NotificacaoTest
    {
        [Fact]
        public void CriarNotificacaoComTituloVazioDeveLancarArgumentNullException()
        {
            // Arrange
            string titulo = "";
            string mensagem = "Mensagem de teste";
            TipoNotificacao tipoNotificacao = TipoNotificacao.Usuario;
            Usuario destino = new Usuario();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => Notificacao.Criar(titulo, mensagem, tipoNotificacao, destino));
        }

        [Fact]
        public void CriarNotificacaoComMensagemVaziaDeveLancarArgumentNullException()
        {
            // Arrange
            string titulo = "Título de teste";
            string mensagem = "";
            TipoNotificacao tipoNotificacao = TipoNotificacao.Usuario;
            Usuario destino = new Usuario();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => Notificacao.Criar(titulo, mensagem, tipoNotificacao, destino));
        }

        [Fact]
        public void CriarNotificacaoTipoUsuarioSemRemetenteDeveLancarArgumentNullException()
        {
            // Arrange
            string titulo = "Título de teste";
            string mensagem = "Mensagem de teste";
            TipoNotificacao tipoNotificacao = TipoNotificacao.Usuario;
            Usuario destino = new Usuario();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => Notificacao.Criar(titulo, mensagem, tipoNotificacao, destino));
        }

        [Fact]
        public void CriarNotificacaoTipoUsuarioComRemetenteDeveCriarNotificacao()
        {
            // Arrange
            string titulo = "Título de teste";
            string mensagem = "Mensagem de teste";
            TipoNotificacao tipoNotificacao = TipoNotificacao.Usuario;
            Usuario destino = new Usuario();
            Usuario remetente = new Usuario();

            // Act
            var notificacao = Notificacao.Criar(titulo, mensagem, tipoNotificacao, destino, remetente);

            // Assert
            Assert.NotNull(notificacao);
            Assert.Equal(titulo, notificacao.Titulo);
            Assert.Equal(mensagem, notificacao.Mensagem);
            Assert.Equal(tipoNotificacao, notificacao.TipoNotificacao);
            Assert.Equal(destino, notificacao.UsuarioDestino);
            Assert.Equal(remetente, notificacao.UsuarioRemetente);
        }

        [Fact]
        public void CriarNotificacaoTipoSistemaDeveCriarNotificacao()
        {
            // Arrange
            string titulo = "Título de teste";
            string mensagem = "Mensagem de teste";
            TipoNotificacao tipoNotificacao = TipoNotificacao.Sistema;
            Usuario destino = new Usuario();

            // Act
            var notificacao = Notificacao.Criar(titulo, mensagem, tipoNotificacao, destino);

            // Assert
            Assert.NotNull(notificacao);
            Assert.Equal(titulo, notificacao.Titulo);
            Assert.Equal(mensagem, notificacao.Mensagem);
            Assert.Equal(tipoNotificacao, notificacao.TipoNotificacao);
            Assert.Equal(destino, notificacao.UsuarioDestino);
            Assert.Null(notificacao.UsuarioRemetente);
        }
    }
}


