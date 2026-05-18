using Microsoft.AspNetCore.Mvc;
using PesquisaEleitoral_v2.DTOs.Estatiscas;
using PesquisaEleitoral_v2.DTOs.IntencoesDeVoto;
using PesquisaEleitoral_v2.Enums;
using PesquisaEleitoral_v2.Pagination;
using PesquisaEleitoral_v2.Services;
using System.Text.Json;

namespace PesquisaEleitoral_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntencoesDeVotosController : ControllerBase
    {
        private readonly IIntencaoDeVotoService _intencaoDeVotoService;

        public IntencoesDeVotosController(IIntencaoDeVotoService intencaoDeVotoService)
        {
            _intencaoDeVotoService = intencaoDeVotoService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IntencaoDeVotoResponseDTO>>> GetPagedAsync(
            [FromQuery] IntencaoDeVotoParameters parameters,[FromQuery] int pesquisaId)
        {
            var pagedListDto = await _intencaoDeVotoService.GetPagedAsync(parameters, pesquisaId);
            var metadata = new
            {
                pagedListDto.CurrentPage,
                pagedListDto.TotalPage,
                pagedListDto.HasPrevious,
                pagedListDto.HasNext,
            };
            Response.Headers.Append("Pagination", JsonSerializer.Serialize(metadata));
            return Ok(pagedListDto);
        }

        [HttpGet("estatisticas")]
        public async Task<ActionResult<IEnumerable<EstatisticaVotoResponseDTO>>> GetEstatistica
            (int pesquisaId, Regiao? regiao)
        {
            var listaDeVotosPorCandidato = await _intencaoDeVotoService.EstatisticaPorCandidatoAsync(pesquisaId, regiao);

            return Ok(listaDeVotosPorCandidato);
        }
        [HttpGet("perfil/eleitores")]
        public async Task<ActionResult<PerfilEleitoresDTO>> GetPerfilEleitores(
            int pesquisaId, int candidatoId)
        {
            var perfil = await _intencaoDeVotoService.GetPerfilEleitores(pesquisaId, candidatoId);
            return Ok(perfil);
        }

        [HttpGet("{pesquisaId}/{votoId}", Name ="GetIntencaoDeVotoById")]
        public async Task<ActionResult> GetIntencaoDeVotoById(int pesquisaId, int votoId)
        {
            var response = await _intencaoDeVotoService.GetByIdAsync(pesquisaId, votoId);
            return Ok(response);
        }
        
        [HttpPost]
        public async Task<ActionResult> Post(IntencaoDeVotoDTO votoDto)
        {
            var response = await _intencaoDeVotoService.CreateAsync(votoDto);
            return CreatedAtRoute(
                "GetIntencaoDeVotoById",
                new 
                {
                    pesquisaId = response.Pesquisa.PesquisaId,
                    votoId = response.IntencaoDeVotoId
                }
                , response);
        }

        [HttpPut]
        public async Task<ActionResult> Put(IntencaoDeVotoUpdateDTO votoDto)
        {
            await _intencaoDeVotoService.UpdateAsync(votoDto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int pesquisaId, int votoId)
        {
            await _intencaoDeVotoService.DeleteAsync(pesquisaId, votoId);
            return NoContent();
        }
    }
}
