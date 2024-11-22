using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Services;
using Oqtane.Shared;

namespace MarkSetBotAlpha.Module.MarkSetBotWWW.Services
{
    public class MarkSetBotWWWService : ServiceBase, IMarkSetBotWWWService
    {
        public MarkSetBotWWWService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("MarkSetBotWWW");

        public async Task<List<Models.MarkSetBotWWW>> GetMarkSetBotWWWsAsync(int ModuleId)
        {
            List<Models.MarkSetBotWWW> MarkSetBotWWWs = await GetJsonAsync<List<Models.MarkSetBotWWW>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId), Enumerable.Empty<Models.MarkSetBotWWW>().ToList());
            return MarkSetBotWWWs.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.MarkSetBotWWW> GetMarkSetBotWWWAsync(int MarkSetBotWWWId, int ModuleId)
        {
            return await GetJsonAsync<Models.MarkSetBotWWW>(CreateAuthorizationPolicyUrl($"{Apiurl}/{MarkSetBotWWWId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.MarkSetBotWWW> AddMarkSetBotWWWAsync(Models.MarkSetBotWWW MarkSetBotWWW)
        {
            return await PostJsonAsync<Models.MarkSetBotWWW>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, MarkSetBotWWW.ModuleId), MarkSetBotWWW);
        }

        public async Task<Models.MarkSetBotWWW> UpdateMarkSetBotWWWAsync(Models.MarkSetBotWWW MarkSetBotWWW)
        {
            return await PutJsonAsync<Models.MarkSetBotWWW>(CreateAuthorizationPolicyUrl($"{Apiurl}/{MarkSetBotWWW.MarkSetBotWWWId}", EntityNames.Module, MarkSetBotWWW.ModuleId), MarkSetBotWWW);
        }

        public async Task DeleteMarkSetBotWWWAsync(int MarkSetBotWWWId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{MarkSetBotWWWId}", EntityNames.Module, ModuleId));
        }
    }
}
