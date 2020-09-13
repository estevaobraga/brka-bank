using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Brka.Bank.Contas.Domain;
using Brka.Bank.Contas.Repository.Abstrations;
using Microsoft.EntityFrameworkCore;

namespace Brka.Bank.Contas.Repository.Contas
{
    public class ContaRepository : Repository<ContaModel>, IContaRepository
    {
        public ContaRepository(Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task AtualizarContaCorrente(ContaCorrente conta)
        {
            await Atualizar(Mapper.Map<ContaModel>(conta));
        }

        public async Task<ContaCorrente> ObtemContaCorrente(Conta conta)
        {
            var contaCorrente = await Context.Set<ContaModel>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.CodigoAgencia == conta.CodigoAgencia &&
                    x.Numero == conta.Numero &&
                    x.Digito == conta.Digito);

            return Mapper.Map<ContaCorrente>(contaCorrente);
        }

        public async Task<ICollection<ContaCorrente>> OntemContas()
        {
            return Mapper.Map<ICollection<ContaCorrente>>(await Context.Set<ContaModel>().AsNoTracking().ToListAsync());
        }
    }
}