using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using MarkSetBotAlpha.Module.MarkSetBotWWW.Migrations.EntityBuilders;
using MarkSetBotAlpha.Module.MarkSetBotWWW.Repository;

namespace MarkSetBotAlpha.Module.MarkSetBotWWW.Migrations
{
    [DbContext(typeof(MarkSetBotWWWContext))]
    [Migration("MarkSetBotAlpha.Module.MarkSetBotWWW.01.00.00.00")]
    public class InitializeModule : MultiDatabaseMigration
    {
        public InitializeModule(IDatabase database) : base(database)
        {
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new MarkSetBotWWWEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Create();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new MarkSetBotWWWEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Drop();
        }
    }
}
