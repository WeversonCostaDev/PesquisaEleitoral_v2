using Microsoft.AspNetCore.Mvc;
using PesquisaEleitoral_v2.DTOs.IntencoesDeVoto;
using PesquisaEleitoral_v2.DTOs.Mapping;
using PesquisaEleitoral_v2.Repositories.Interfaces;

namespace PesquisaEleitoral_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntencoesDeVotosController : ControllerBase
    {
        private readonly IIntencaoDeVotoRepository _intencaoDeVotosRepository;
        private readonly IUnitOfWork _uow;

        public IntencoesDeVotosController(IIntencaoDeVotoRepository intencaoDeVotoRepository, IUnitOfWork uow)
        {
            _intencaoDeVotosRepository = intencaoDeVotoRepository;
            _uow = uow;
        }

        [HttpGet("{id}", Name ="GetIntencaoDeVotoById")]
        public async Task<ActionResult> GetIntencaoDeVotoById(int id, [FromQuery] int pesquisaId)
        {
            var response = await _intencaoDeVotosRepository.GetByIdAsync(id, pesquisaId);
            return Ok(response);
        }
        [HttpPost()]
        public async Task<ActionResult> Post(IntencaoDeVotoDTO votoDto)
        {
            var voto = votoDto.ToIntencaoDeVoto();
            voto = _uow.IntencaoDeVotoRepository.Create(voto);
            await _uow.CommitAsync();

            voto = await _uow.IntencaoDeVotoRepository.GetByIdAsync(voto.IntencaoDeVotoId, voto.PesquisaId);
            if (voto is null) return NotFound();
            var response = voto.ToIntencaoDeVotoResponseDTO();

            return CreatedAtRoute("GetIntencaoDeVotoById", new {id = response.IntencaoDeVotoId}, response);
        }
    }
}
