using PesquisaEleitoral_v2.Models;

namespace PesquisaEleitoral_v2.Repositories.Interfaces
{
    public interface IIntencaoDeVotoRepository 
    {
        Task<IntencaoDeVoto?> GetByIdAsync(int id, int pesquisaId);
        IntencaoDeVoto Create(IntencaoDeVoto intencao);
        void Delete(IntencaoDeVoto voto);

    }
}
