using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;

namespace MarkSetBotAlpha.Module.MarkSetBotWWW.Repository
{
    public class MarkSetBotWWWRepository : IMarkSetBotWWWRepository, ITransientService
    {
        private readonly IDbContextFactory<MarkSetBotWWWContext> _factory;

        public MarkSetBotWWWRepository(IDbContextFactory<MarkSetBotWWWContext> factory)
        {
            _factory = factory;
        }

        public IEnumerable<Models.MarkSetBotWWW> GetMarkSetBotWWWs(int ModuleId)
        {
            using var db = _factory.CreateDbContext();
            return db.MarkSetBotWWW.Where(item => item.ModuleId == ModuleId).ToList();
        }

        public Models.MarkSetBotWWW GetMarkSetBotWWW(int MarkSetBotWWWId)
        {
            return GetMarkSetBotWWW(MarkSetBotWWWId, true);
        }

        public Models.MarkSetBotWWW GetMarkSetBotWWW(int MarkSetBotWWWId, bool tracking)
        {
            using var db = _factory.CreateDbContext();
            if (tracking)
            {
                return db.MarkSetBotWWW.Find(MarkSetBotWWWId);
            }
            else
            {
                return db.MarkSetBotWWW.AsNoTracking().FirstOrDefault(item => item.MarkSetBotWWWId == MarkSetBotWWWId);
            }
        }

        public Models.MarkSetBotWWW AddMarkSetBotWWW(Models.MarkSetBotWWW MarkSetBotWWW)
        {
            using var db = _factory.CreateDbContext();
            db.MarkSetBotWWW.Add(MarkSetBotWWW);
            db.SaveChanges();
            return MarkSetBotWWW;
        }

        public Models.MarkSetBotWWW UpdateMarkSetBotWWW(Models.MarkSetBotWWW MarkSetBotWWW)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(MarkSetBotWWW).State = EntityState.Modified;
            db.SaveChanges();
            return MarkSetBotWWW;
        }

        public void DeleteMarkSetBotWWW(int MarkSetBotWWWId)
        {
            using var db = _factory.CreateDbContext();
            Models.MarkSetBotWWW MarkSetBotWWW = db.MarkSetBotWWW.Find(MarkSetBotWWWId);
            db.MarkSetBotWWW.Remove(MarkSetBotWWW);
            db.SaveChanges();
        }
    }
}
