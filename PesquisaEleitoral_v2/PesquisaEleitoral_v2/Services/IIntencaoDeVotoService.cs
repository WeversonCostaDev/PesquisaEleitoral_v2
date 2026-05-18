using PesquisaEleitoral_v2.DTOs.Estatiscas;
using PesquisaEleitoral_v2.DTOs.IntencoesDeVoto;
using PesquisaEleitoral_v2.Enums;
using PesquisaEleitoral_v2.Pagination;

namespace PesquisaEleitoral_v2.Services
{
    public interface IIntencaoDeVotoService 
    {
        Task<IPagedList<IntencaoDeVotoResponseDTO>> GetPagedAsync(IQueryStringPagination query, int pesquisaId);
        Task<PerfilEleitoresDTO> GetPerfilEleitores(int pesquisaId, int candidatoId);
        Task<IEnumerable<EstatisticaVotoResponseDTO>> EstatisticaPorCandidatoAsync(
            int pesquisaId, Regiao? regiao = null);
        Task<IntencaoDeVotoResponseDTO> GetByIdAsync(int pesquisaId, int votoId);
        Task<IntencaoDeVotoResponseDTO> CreateAsync(IntencaoDeVotoDTO votoDto);
        Task UpdateAsync(IntencaoDeVotoUpdateDTO votoUpdate);
        Task DeleteAsync(int pesquisaId, int votoId);
    }
}
