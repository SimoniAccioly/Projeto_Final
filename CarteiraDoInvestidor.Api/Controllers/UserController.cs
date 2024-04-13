using CarteiraDoInvestidor.Application.Conta;
using CarteiraDoInvestidor.Application.Conta.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDoInvestidor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UserController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Criar(UsuarioDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._usuarioService.Criar(dto);

            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult Obter(Guid id)
        {
            var result = this._usuarioService.Obter(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Requests.LoginRequest login)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            var result = this._usuarioService.Autenticar(login.Email, login.Senha);

            if (result == null)
            {
                return BadRequest(new
                {
                    Error = "email ou senha inválidos"
                });
            }

            return Ok(result);

        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, UsuarioDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var result = this._usuarioService.Atualizar(dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            var usuario = _usuarioService.Obter(id);

            if (usuario == null)
                return NotFound();

            _usuarioService.Deletar(id);

            return NoContent();
        }
    }
}

