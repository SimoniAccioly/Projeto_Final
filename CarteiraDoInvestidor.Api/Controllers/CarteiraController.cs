using CarteiraDoInvestidor.Application.Investimentos.Dto;
using CarteiraDoInvestidor.Application.Investimentos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDoInvestidor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarteiraController : ControllerBase
    {
        private readonly CarteiraService _carteiraService;

        public CarteiraController(CarteiraService carteiraService)
        {
            _carteiraService = carteiraService;
        }

       /* [HttpGet]
        public IActionResult GetCarteiras()
        {
            var result = this._carteiraService.ObterCarteiraseAtivos(Guid carteiraId);

            return Ok(result);
        }*/

        // GET: api/Carteira/{carteiraId}
        [HttpGet("{carteiraId}")]
        public ActionResult<CarteirasDto> ObterCarteiraPorId(Guid carteiraId)
        {
            var carteira = _carteiraService.ObterCarteiraPorId(carteiraId);
            if (carteira == null)
            {
                return NotFound();
            }
            return Ok(carteira);
        }

        // POST: api/Carteira
        [HttpPost]
        public ActionResult<CarteirasDto> Criar(CarteirasDto dto)
        {
            var novaCarteira = _carteiraService.Criar(dto);
            return CreatedAtAction(nameof(ObterCarteiraPorId), new { carteiraId = novaCarteira.Id }, novaCarteira);
        }

        /*// PUT: api/Carteira/{carteiraId}
        [HttpPut("{carteiraId}")]
        public IActionResult AtualizarCarteira(Guid carteiraId, CarteirasDto dto)
        {
            if (carteiraId != dto.Id)
            {
                return BadRequest();
            }

            try
            {
                _carteiraService.AtualizarCarteira(dto);
            }
            catch (Exception)
            {
                if (!_carteiraService.CarteiraExiste(carteiraId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // DELETE: api/Carteira/{carteiraId}
        [HttpDelete("{carteiraId}")]
        public IActionResult DeletarCarteira(Guid carteiraId)
        {
            var carteira = _carteiraService.ObterCarteiraPorId(carteiraId);
            if (carteira == null)
            {
                return NotFound();
            }

            _carteiraService.DeletarCarteira(carteiraId);
            return NoContent();
        }
    }
}
    

