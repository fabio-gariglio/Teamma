using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IStoryRepository
    {
        Task<Story> GetById(int storyInternalId);
    }
}
