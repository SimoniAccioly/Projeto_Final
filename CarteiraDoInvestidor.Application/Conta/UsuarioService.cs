using AutoMapper;
using CarteiraDoInvestidor.Application.Conta.Dto;
using CarteiraDoInvestidor.CrossCuting.Utils;
using CarteiraDoInvestidor.Domain.Conta.Agreggates;
using CarteiraDoInvestidor.Domain.Financeiro.Agreggates;
using CarteiraDoInvestidor.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Application.Conta
{
    public class UsuarioService
    {
        private IMapper Mapper { get; set; }
        private UsuarioRepository UsuarioRepository { get; set; }
        private PlanoRepository PlanoRepository { get; set; }


        public UsuarioService(IMapper mapper, UsuarioRepository usuarioRepository, PlanoRepository planoRepository)
        {
            Mapper = mapper;
            UsuarioRepository = usuarioRepository;
            PlanoRepository = planoRepository;
        }

        public UsuarioDto Criar(UsuarioDto dto)
        {
            if (this.UsuarioRepository.Exists(x => x.Email == dto.Email))
                throw new Exception("Usuario já existente na base");


            Plano plano = this.PlanoRepository.GetById(dto.PlanoId);

            if (plano == null)
                throw new Exception("Plano não existente ou não encontrado");

            Cartao cartao = this.Mapper.Map<Cartao>(dto.Cartao);

            Usuario usuario = new Usuario();
            usuario.CriarConta(dto.Nome, dto.Email, dto.Senha, dto.CPF, dto.DtNascimento, plano, cartao);

            this.UsuarioRepository.Save(usuario);
            var result = this.Mapper.Map<UsuarioDto>(usuario);

            return result;

        }

        public UsuarioDto Obter(Guid id)
        {
            var usuario = this.UsuarioRepository.GetById(id);
            var result = this.Mapper.Map<UsuarioDto>(usuario);
            return result;
        }

        public UsuarioDto Autenticar(String email, String senha)
        {
            var usuario = this.UsuarioRepository.Find(x => x.Email == email && x.Senha == senha.HashSHA256()).FirstOrDefault();
            var result = this.Mapper.Map<UsuarioDto>(usuario);
            return result;
        }

        public UsuarioDto Atualizar(UsuarioDto dto)
        {
            var usuarioExistente = UsuarioRepository.GetById(dto.Id);
            if (usuarioExistente == null)
                return null;

            Mapper.Map(dto, usuarioExistente);

            UsuarioRepository.Update(usuarioExistente);

            // Mapeia a entidade atualizada de volta para o DTO
            return Mapper.Map<UsuarioDto>(usuarioExistente);
        }

        public void Deletar(Guid id)
        {
            var usuarioExistente = UsuarioRepository.GetById(id);
            if (usuarioExistente == null)
                return; // Ou lançar uma exceção, dependendo do comportamento desejado

            UsuarioRepository.Delete(usuarioExistente);
        }
    }
}
