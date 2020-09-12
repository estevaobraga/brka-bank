using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brka.Bank.Contas.Repository.Abstrations
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> ListarTodos();
        Task Criar(T entity);
        Task Atualizar(T entity);
    }
}