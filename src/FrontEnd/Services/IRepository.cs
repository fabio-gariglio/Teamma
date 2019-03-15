using System.Threading.Tasks;

namespace FrontEnd.Services
{
    public interface IRepository<TKey, TValue>
    {
        Task Save(TKey key, TValue value);
        Task<TValue> Get(TKey key);
    }
}