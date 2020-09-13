using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Brka.Bank.Contas.Repository.Abstrations
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        protected readonly Context Context;
        protected readonly IMapper Mapper;
        
        public Repository(Context context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public async Task Criar(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Atualizar(T entity)
        {
            Context.Entry(entity).State = EntityState.Detached;
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispose)
        {
            if(dispose)
                Context?.Dispose();
        }
    }
}