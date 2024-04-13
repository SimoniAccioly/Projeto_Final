using CarteiraDoInvestidor.Application.Investimentos.Dto;
using CarteiraDoInvestidor.Application.Investimentos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarteiraDoInvestidor.Application.Conta;

namespace CarteiraDoInvestidor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarteiraController : ControllerBase
    {
        private readonly CarteiraService _carteiraService;
        private readonly UsuarioService _usuarioService;

        public CarteiraController(CarteiraService carteiraService)
        {
            _carteiraService = carteiraService;
        }

        [HttpPost]
        public IActionResult CriarCarteira([FromBody] CarteirasDto carteiraDto)
        {
            var novaCarteira = _carteiraService.Criar(carteiraDto);
            return Ok(novaCarteira);
        }

        [HttpGet("{carteiraId}")]
        public IActionResult ObterCarteira(Guid carteiraId)
        {
            var carteira = _carteiraService.ObterCarteiraPorId(carteiraId);
            if (carteira == null)
            {
                return NotFound();
            }
            return Ok(carteira);
        }

        [HttpPut("{carteiraId}")]
        public IActionResult AtualizarCarteira(Guid carteiraId, [FromBody] CarteirasDto carteiraDto)
        {
            if (carteiraId != carteiraDto.Id)
            {
                return BadRequest("O Id da carteira na URL não corresponde ao Id na requisição.");
            }

            _carteiraService.AtualizarCarteira(carteiraDto);
            return NoContent();
        }

        [HttpDelete("{carteiraId}")]
        public IActionResult DeletarCarteira(Guid carteiraId)
        {
            _carteiraService.DeletarCarteira(carteiraId);
            return NoContent();
        }

        [HttpPost("{carteiraId}/ativos")]
        public IActionResult AdicionarAtivo(Guid carteiraId, [FromBody] AtivosDto novoAtivoDto)
        {
            _carteiraService.CriarAtivoAssociadoACarteira(carteiraId, novoAtivoDto);
            return NoContent();
        }

        [HttpPut("{ativoId}/ativos")]
        public IActionResult AtualizarAtivos(Guid ativoId, [FromBody] List<AtivosDto> novosAtivos)
        {
            _carteiraService.AtualizarAtivos(ativoId, novosAtivos);
            return NoContent();
        }

        [HttpDelete("{carteiraId}/ativos")]
        public IActionResult DeletarTodosAtivos(Guid carteiraId)
        {
            _carteiraService.DeletarTodosAtivos(carteiraId);
            return NoContent();
        }
    }
}

       /* [HttpPost]
        public IActionResult Criar([FromBody] CarteirasDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._carteiraService.Criar(dto);

            return Created($"/carteira/{result.Id}", result);
        }*/
    

