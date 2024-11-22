using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkSetBotAlpha.Module.MarkSetBotWWW.Services
{
    public interface IMarkSetBotWWWService 
    {
        Task<List<Models.MarkSetBotWWW>> GetMarkSetBotWWWsAsync(int ModuleId);

        Task<Models.MarkSetBotWWW> GetMarkSetBotWWWAsync(int MarkSetBotWWWId, int ModuleId);

        Task<Models.MarkSetBotWWW> AddMarkSetBotWWWAsync(Models.MarkSetBotWWW MarkSetBotWWW);

        Task<Models.MarkSetBotWWW> UpdateMarkSetBotWWWAsync(Models.MarkSetBotWWW MarkSetBotWWW);

        Task DeleteMarkSetBotWWWAsync(int MarkSetBotWWWId, int ModuleId);
    }
}
