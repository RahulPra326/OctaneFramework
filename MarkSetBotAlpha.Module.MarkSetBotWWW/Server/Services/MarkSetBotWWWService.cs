using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Oqtane.Models;
using Oqtane.Security;
using Oqtane.Shared;
using MarkSetBotAlpha.Module.MarkSetBotWWW.Repository;

namespace MarkSetBotAlpha.Module.MarkSetBotWWW.Services
{
    public class ServerMarkSetBotWWWService : IMarkSetBotWWWService
    {
        private readonly IMarkSetBotWWWRepository _MarkSetBotWWWRepository;
        private readonly IUserPermissions _userPermissions;
        private readonly ILogManager _logger;
        private readonly IHttpContextAccessor _accessor;
        private readonly Alias _alias;

        public ServerMarkSetBotWWWService(IMarkSetBotWWWRepository MarkSetBotWWWRepository, IUserPermissions userPermissions, ITenantManager tenantManager, ILogManager logger, IHttpContextAccessor accessor)
        {
            _MarkSetBotWWWRepository = MarkSetBotWWWRepository;
            _userPermissions = userPermissions;
            _logger = logger;
            _accessor = accessor;
            _alias = tenantManager.GetAlias();
        }

        public Task<List<Models.MarkSetBotWWW>> GetMarkSetBotWWWsAsync(int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.View))
            {
                return Task.FromResult(_MarkSetBotWWWRepository.GetMarkSetBotWWWs(ModuleId).ToList());
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized MarkSetBotWWW Get Attempt {ModuleId}", ModuleId);
                return null;
            }
        }

        public Task<Models.MarkSetBotWWW> GetMarkSetBotWWWAsync(int MarkSetBotWWWId, int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.View))
            {
                return Task.FromResult(_MarkSetBotWWWRepository.GetMarkSetBotWWW(MarkSetBotWWWId));
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized MarkSetBotWWW Get Attempt {MarkSetBotWWWId} {ModuleId}", MarkSetBotWWWId, ModuleId);
                return null;
            }
        }

        public Task<Models.MarkSetBotWWW> AddMarkSetBotWWWAsync(Models.MarkSetBotWWW MarkSetBotWWW)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, MarkSetBotWWW.ModuleId, PermissionNames.Edit))
            {
                MarkSetBotWWW = _MarkSetBotWWWRepository.AddMarkSetBotWWW(MarkSetBotWWW);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "MarkSetBotWWW Added {MarkSetBotWWW}", MarkSetBotWWW);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized MarkSetBotWWW Add Attempt {MarkSetBotWWW}", MarkSetBotWWW);
                MarkSetBotWWW = null;
            }
            return Task.FromResult(MarkSetBotWWW);
        }

        public Task<Models.MarkSetBotWWW> UpdateMarkSetBotWWWAsync(Models.MarkSetBotWWW MarkSetBotWWW)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, MarkSetBotWWW.ModuleId, PermissionNames.Edit))
            {
                MarkSetBotWWW = _MarkSetBotWWWRepository.UpdateMarkSetBotWWW(MarkSetBotWWW);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "MarkSetBotWWW Updated {MarkSetBotWWW}", MarkSetBotWWW);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized MarkSetBotWWW Update Attempt {MarkSetBotWWW}", MarkSetBotWWW);
                MarkSetBotWWW = null;
            }
            return Task.FromResult(MarkSetBotWWW);
        }

        public Task DeleteMarkSetBotWWWAsync(int MarkSetBotWWWId, int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.Edit))
            {
                _MarkSetBotWWWRepository.DeleteMarkSetBotWWW(MarkSetBotWWWId);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "MarkSetBotWWW Deleted {MarkSetBotWWWId}", MarkSetBotWWWId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized MarkSetBotWWW Delete Attempt {MarkSetBotWWWId} {ModuleId}", MarkSetBotWWWId, ModuleId);
            }
            return Task.CompletedTask;
        }
    }
}
