using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkSetBotAlpha.Module.MarkSetBotWWW.Repository
{
    public interface IMarkSetBotWWWRepository
    {
        IEnumerable<Models.MarkSetBotWWW> GetMarkSetBotWWWs(int ModuleId);
        Models.MarkSetBotWWW GetMarkSetBotWWW(int MarkSetBotWWWId);
        Models.MarkSetBotWWW GetMarkSetBotWWW(int MarkSetBotWWWId, bool tracking);
        Models.MarkSetBotWWW AddMarkSetBotWWW(Models.MarkSetBotWWW MarkSetBotWWW);
        Models.MarkSetBotWWW UpdateMarkSetBotWWW(Models.MarkSetBotWWW MarkSetBotWWW);
        void DeleteMarkSetBotWWW(int MarkSetBotWWWId);
    }
}
