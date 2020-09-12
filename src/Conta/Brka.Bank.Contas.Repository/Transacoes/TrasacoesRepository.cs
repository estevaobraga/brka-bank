using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Brka.Bank.Contas.Domain;
using Brka.Bank.Contas.Repository.Abstrations;
using Microsoft.EntityFrameworkCore;

namespace Brka.Bank.Contas.Repository.Transacoes
{
    public class TrasacoesRepository : Repository<TransacaoModel>, ITransacoesRepository
    {
        public TrasacoesRepository(Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ICollection<Transacao>> ObtemTransacoesPorId(int idConta, int idUsuario)
        {
            var transacoes = await Context.Set<TransacaoModel>()
                .Where(x => x.IdConta == idConta && x.IdUsuario == idUsuario)
                .OrderByDescending(x => x.DataTrasacao).ToListAsync();
            
            return Mapper.Map<ICollection<Transacao>>(transacoes);
        }

        public async Task CadastraTransacao(Transacao transacao)
        {
            await Criar(Mapper.Map<TransacaoModel>(transacao));
        }
    }
}