using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Interfaces;
using Oqtane.Enums;
using Oqtane.Repository;
using MarkSetBotAlpha.Module.MarkSetBotWWW.Repository;
using System.Threading.Tasks;

namespace MarkSetBotAlpha.Module.MarkSetBotWWW.Manager
{
    public class MarkSetBotWWWManager : MigratableModuleBase, IInstallable, IPortable, ISearchable
    {
        private readonly IMarkSetBotWWWRepository _MarkSetBotWWWRepository;
        private readonly IDBContextDependencies _DBContextDependencies;

        public MarkSetBotWWWManager(IMarkSetBotWWWRepository MarkSetBotWWWRepository, IDBContextDependencies DBContextDependencies)
        {
            _MarkSetBotWWWRepository = MarkSetBotWWWRepository;
            _DBContextDependencies = DBContextDependencies;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new MarkSetBotWWWContext(_DBContextDependencies), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new MarkSetBotWWWContext(_DBContextDependencies), tenant, MigrationType.Down);
        }

        public string ExportModule(Oqtane.Models.Module module)
        {
            string content = "";
            List<Models.MarkSetBotWWW> MarkSetBotWWWs = _MarkSetBotWWWRepository.GetMarkSetBotWWWs(module.ModuleId).ToList();
            if (MarkSetBotWWWs != null)
            {
                content = JsonSerializer.Serialize(MarkSetBotWWWs);
            }
            return content;
        }

        public void ImportModule(Oqtane.Models.Module module, string content, string version)
        {
            List<Models.MarkSetBotWWW> MarkSetBotWWWs = null;
            if (!string.IsNullOrEmpty(content))
            {
                MarkSetBotWWWs = JsonSerializer.Deserialize<List<Models.MarkSetBotWWW>>(content);
            }
            if (MarkSetBotWWWs != null)
            {
                foreach(var MarkSetBotWWW in MarkSetBotWWWs)
                {
                    _MarkSetBotWWWRepository.AddMarkSetBotWWW(new Models.MarkSetBotWWW { ModuleId = module.ModuleId, Name = MarkSetBotWWW.Name });
                }
            }
        }

        public Task<List<SearchContent>> GetSearchContentsAsync(PageModule pageModule, DateTime lastIndexedOn)
        {
           var searchContentList = new List<SearchContent>();

           foreach (var MarkSetBotWWW in _MarkSetBotWWWRepository.GetMarkSetBotWWWs(pageModule.ModuleId))
           {
               if (MarkSetBotWWW.ModifiedOn >= lastIndexedOn)
               {
                   searchContentList.Add(new SearchContent
                   {
                       EntityName = "MarkSetBotAlphaMarkSetBotWWW",
                       EntityId = MarkSetBotWWW.MarkSetBotWWWId.ToString(),
                       Title = MarkSetBotWWW.Name,
                       Body = MarkSetBotWWW.Name,
                       ContentModifiedBy = MarkSetBotWWW.ModifiedBy,
                       ContentModifiedOn = MarkSetBotWWW.ModifiedOn
                   });
               }
           }

           return Task.FromResult(searchContentList);
        }
    }
}
