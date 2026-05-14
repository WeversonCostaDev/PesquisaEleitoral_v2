using Microsoft.EntityFrameworkCore;
using PesquisaEleitoral_v2.Data;
using PesquisaEleitoral_v2.Models;
using PesquisaEleitoral_v2.Repositories.Interfaces;

namespace PesquisaEleitoral_v2.Repositories
{
    public class IntencaoDeVotoRepository : IIntencaoDeVotoRepository
    {
        private readonly AppDbContext _context;
        public IntencaoDeVotoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IntencaoDeVoto?> GetByIdAsync(int id, int pesquisaId)
        {
            var intencaoDeVoto = await _context.IntencoesDeVoto
                .Where(iv => iv.PesquisaId == pesquisaId)
                .Include(i => i.Pesquisa)
                .Include(i => i.Eleitor)
                .Include(i => i.Candidato)
                .FirstOrDefaultAsync(i => i.IntencaoDeVotoId == id);
            return intencaoDeVoto;
        }
        public async Task<bool> VerifyAsync(int id)
        {turn _context.IntencoesDeVoto.
        }
        public IntencaoDeVoto Create(IntencaoDeVoto intencao)
        {
            _context.Add(intencao);
            return intencao;
        }
        public void Delete(IntencaoDeVoto voto)
        {
            _context.Remove(voto);
        }
    }
}
