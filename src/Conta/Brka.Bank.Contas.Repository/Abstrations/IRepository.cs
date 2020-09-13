using System.Threading.Tasks;

namespace Brka.Bank.Contas.Repository.Abstrations
{
    public interface IRepository<T> where T : class
    {
        Task Criar(T entity);
        Task Atualizar(T entity);
    }
}