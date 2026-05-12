namespace PesquisaEleitoral_v2.Repositories
{
    public interface IUnitOfWork
    {
        ICandidatoRepository CandidatoRepository { get; }
        IEleitorRepository EleitorRepository { get; }
        IPesquisaRepository PesquisaRepository { get; }
        Task CommitAsync();
    }
}
