using Microsoft.AspNetCore.Mvc;
using PesquisaEleitoral_v2.DTOs.Mapping;
using PesquisaEleitoral_v2.DTOs.Pesquisas;
using PesquisaEleitoral_v2.Repositories.Interfaces;

namespace PesquisaEleitoral_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisasController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        
        public PesquisasController(IUnitOfWork uow)
        {
            _uow= uow;
        }

        [HttpGet("{pesquisaId}", Name = "GetPesquisaById")]
        public async Task<ActionResult> GetById(int pesquisaId) 
        {
            var pesquisa = await _uow.PesquisaRepository.GetByIdAsync(pesquisaId);
            
            if (pesquisa is null) return NotFound($"Pesquisa de id {pesquisaId} não encontrada.");

            var response = pesquisa.ToPesquisaResponseDTO();

            return Ok(response);
        }

        //Cria uma pesquisa
        [HttpPost]
        public async Task<ActionResult> Post(PesquisaDTO pesquisaDto)
        {
            var pesquisa = pesquisaDto.ToPesquisa();
            _uow.PesquisaRepository.Create(pesquisa);
            await _uow.CommitAsync();

            var response = pesquisa.ToPesquisaResponseDTO();

            return CreatedAtRoute("GetPesquisaById", new {pesquisaId = response.PesquisaId}, response);
        }
        [HttpPost("candidatos")]
        public async Task<ActionResult> Post(PesquisaCandidatoDTO pc)
        {
            var pesquisa = await _uow.PesquisaRepository.GetByIdAsync(pc.PesquisaId);
            if (pesquisa is null)
                throw new InvalidOperationException($"Pesquisa de Id {pc.PesquisaId} não encontrada.");
            var candidato = await _uow.CandidatoRepository.GetByIdAsync(pc.CandidatoId);
            if (candidato is null)
                throw new InvalidOperationException($"Candidato de Id {pc.CandidatoId} não encontrada.");
            pesquisa.Candidatos.Add(candidato);
            await _uow.CommitAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int pesquisaId)
        {
            var pesquisa = await _uow.PesquisaRepository.GetByIdAsync(pesquisaId);
            if (pesquisa is null) 
                throw new InvalidOperationException($"Pesquisa de id {pesquisaId} não existe.");
            _uow.PesquisaRepository.Delete(pesquisa);
            await _uow.CommitAsync();
            return NoContent();
        }
    }
}
