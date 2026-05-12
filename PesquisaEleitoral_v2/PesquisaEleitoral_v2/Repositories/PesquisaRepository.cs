using PesquisaEleitoral_v2.Data;
using PesquisaEleitoral_v2.Models;

namespace PesquisaEleitoral_v2.Repositories
{
    public class PesquisaRepository : Repository<Pesquisa>, IPesquisaRepository
    {
        public PesquisaRepository(AppDbContext context) : base(context)
        {

        }
    }
}
