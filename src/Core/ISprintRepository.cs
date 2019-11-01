using System.Threading.Tasks;

namespace Core
{
    public interface ISprintRepository
    {
        Task<Sprint> GetById(int sprintId);
    }
}
