using PesquisaEleitoral_v2.Controllers;
using PesquisaEleitoral_v2.DTOs.IntencoesDeVoto;
using PesquisaEleitoral_v2.DTOs.Mapping;
using PesquisaEleitoral_v2.Repositories.Interfaces;

namespace PesquisaEleitoral_v2.Services
{
    public class IntencaoDeVotoService
    {
        private readonly IUnitOfWork _uow;
        public IntencaoDeVotoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IntencaoDeVotoResponseDTO> GetByIdAsync(int id, int pesquisaId)
        {
            var intencaoDeVoto = await _uow.IntencaoDeVotoRepository.GetByIdAsync(id, pesquisaId)
                ?? throw new KeyNotFoundException("Intenção de voto não encontrada.");

            var intencoesDeVotoDto = intencaoDeVoto.ToIntencaoDeVotoResponseDTO();
            return intencoesDeVotoDto;
        }
        public async Task<IntencaoDeVotoResponseDTO> CreateAsync(IntencaoDeVotoDTO votoDto)
        {
            var verifyEleitor = await _uow.EleitorRepository
                .VerifyAsync(e => e.EleitorId == votoDto.EleitorId);

            if (!verifyEleitor)
                throw new KeyNotFoundException("Eleitor não existe.");

            var verifyPesquisa = await _uow.PesquisaRepository.GetByIdAsync(votoDto.PesquisaId);
            if (verifyPesquisa is null)
                throw new KeyNotFoundException("Pesquisa não existe.");

            var verifyCandidato = verifyPesquisa.Candidatos.FirstOrDefault(c => c.CandidatoId == votoDto.CandidatoId);

            if (verifyCandidato is null)
                throw new KeyNotFoundException("Candidato não existe.");

            var verifyVotoEleitor = await _uow.IntencaoDeVotoRepository
                .JaVotouAsync(votoDto.EleitorId);

            if (verifyVotoEleitor)
                throw new InvalidOperationException("Eleitor já votou .");

            var intencao = votoDto.ToIntencaoDeVoto();
            intencao = _uow.IntencaoDeVotoRepository.Create(intencao);
            await _uow.CommitAsync();

            intencao = await _uow.IntencaoDeVotoRepository
                .GetByIdAsync(intencao.IntencaoDeVotoId);

            if (intencao is null) throw new KeyNotFoundException("Erro ao recuperar a intenção de voto");

            var intencaoResponseDto = intencao.ToIntencaoDeVotoResponseDTO();

            return intencaoResponseDto;
        }

    }
}
