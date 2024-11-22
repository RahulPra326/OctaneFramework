using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace MarkSetBotAlpha.Module.MarkSetBotWWW.Repository
{
    public class MarkSetBotWWWContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.MarkSetBotWWW> MarkSetBotWWW { get; set; }

        public MarkSetBotWWWContext(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Models.MarkSetBotWWW>().ToTable(ActiveDatabase.RewriteName("MarkSetBotAlphaMarkSetBotWWW"));
        }
    }
}
