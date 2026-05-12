using Microsoft.AspNetCore.Mvc;
using PesquisaEleitoral_v2.DTOs.Mapping;
using PesquisaEleitoral_v2.DTOs.Pesquisas;
using PesquisaEleitoral_v2.Repositories;

namespace PesquisaEleitoral_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisaController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        
        public PesquisaController(IUnitOfWork uow)
        {
            _uow= uow;
        }

        [HttpGet("{id}", Name = "GetPesquisaById")]
        public async Task<ActionResult> GetById(int id) 
        {
            var pesquisa = await _uow.PesquisaRepository.GetByIdAsync(id);
            
            if (pesquisa is null) return NotFound($"Pesquisa de id {id}não encontrada.");

            var response = pesquisa.ToPesquisaResponseDTO();

            return Ok(response);
        }

        [HttpPost()]
        public async Task<ActionResult> Post(PesquisaDTO pesquisaDto)
        {
            var pesquisa = pesquisaDto.ToPesquisa();
            _uow.PesquisaRepository.Create(pesquisa);
            await _uow.CommitAsync();

            var response = pesquisa.ToPesquisaResponseDTO();

            return CreatedAtRoute("GetPesquisaById", new {id = response.PesquisaId}, response);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var pesquisa = await _uow.PesquisaRepository.GetByIdAsync(id);
            if (pesquisa is null) return NotFound($"Pesquisa de id {id} não encontrada.");
            _uow.PesquisaRepository.Delete(pesquisa);
            await _uow.CommitAsync();
            return NoContent();
        }
    }
}
