using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using MarkSetBotAlpha.Module.MarkSetBotWWW.Repository;
using Oqtane.Controllers;
using System.Net;

namespace MarkSetBotAlpha.Module.MarkSetBotWWW.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class MarkSetBotWWWController : ModuleControllerBase
    {
        private readonly IMarkSetBotWWWRepository _MarkSetBotWWWRepository;

        public MarkSetBotWWWController(IMarkSetBotWWWRepository MarkSetBotWWWRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _MarkSetBotWWWRepository = MarkSetBotWWWRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.MarkSetBotWWW> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                return _MarkSetBotWWWRepository.GetMarkSetBotWWWs(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized MarkSetBotWWW Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.MarkSetBotWWW Get(int id)
        {
            Models.MarkSetBotWWW MarkSetBotWWW = _MarkSetBotWWWRepository.GetMarkSetBotWWW(id);
            if (MarkSetBotWWW != null && IsAuthorizedEntityId(EntityNames.Module, MarkSetBotWWW.ModuleId))
            {
                return MarkSetBotWWW;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized MarkSetBotWWW Get Attempt {MarkSetBotWWWId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.MarkSetBotWWW Post([FromBody] Models.MarkSetBotWWW MarkSetBotWWW)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, MarkSetBotWWW.ModuleId))
            {
                MarkSetBotWWW = _MarkSetBotWWWRepository.AddMarkSetBotWWW(MarkSetBotWWW);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "MarkSetBotWWW Added {MarkSetBotWWW}", MarkSetBotWWW);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized MarkSetBotWWW Post Attempt {MarkSetBotWWW}", MarkSetBotWWW);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                MarkSetBotWWW = null;
            }
            return MarkSetBotWWW;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.MarkSetBotWWW Put(int id, [FromBody] Models.MarkSetBotWWW MarkSetBotWWW)
        {
            if (ModelState.IsValid && MarkSetBotWWW.MarkSetBotWWWId == id && IsAuthorizedEntityId(EntityNames.Module, MarkSetBotWWW.ModuleId) && _MarkSetBotWWWRepository.GetMarkSetBotWWW(MarkSetBotWWW.MarkSetBotWWWId, false) != null)
            {
                MarkSetBotWWW = _MarkSetBotWWWRepository.UpdateMarkSetBotWWW(MarkSetBotWWW);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "MarkSetBotWWW Updated {MarkSetBotWWW}", MarkSetBotWWW);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized MarkSetBotWWW Put Attempt {MarkSetBotWWW}", MarkSetBotWWW);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                MarkSetBotWWW = null;
            }
            return MarkSetBotWWW;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.MarkSetBotWWW MarkSetBotWWW = _MarkSetBotWWWRepository.GetMarkSetBotWWW(id);
            if (MarkSetBotWWW != null && IsAuthorizedEntityId(EntityNames.Module, MarkSetBotWWW.ModuleId))
            {
                _MarkSetBotWWWRepository.DeleteMarkSetBotWWW(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "MarkSetBotWWW Deleted {MarkSetBotWWWId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized MarkSetBotWWW Delete Attempt {MarkSetBotWWWId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
